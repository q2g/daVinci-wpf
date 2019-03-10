namespace daVinci.Converter
{
    #region Usings
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using NLog;
    #endregion

    public class ObjectsEqualsConverter : IMultiValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values != null && values.Length > 1)
                {
                    object compareTo = values[0];
                    foreach (var item in values)
                    {
                        if (!compareTo.Equals(item))
                            return false;
                    }
                    return true;
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[4];
        }
    }
}
