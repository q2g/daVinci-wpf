namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Globalization;
    using System.Windows.Data;
    #endregion

    public class ColumnNameConverter : IMultiValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values != null && values.Length == 4)
                {
                    if (values[0] != null && values[0] is bool && !((bool)values[0]))
                    {
                        return values[1];
                    }
                    else
                    {
                        string label = values[2] as string;
                        if (!string.IsNullOrEmpty(label))
                        {
                            return values[2];
                        }
                        else
                        {
                            if (values[3] is string def)
                            {
                                if (def.StartsWith("="))
                                    def = def.Substring(1);
                                return def;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[4];
        }
    }
}
