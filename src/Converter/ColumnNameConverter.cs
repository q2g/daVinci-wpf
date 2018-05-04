namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Windows.Data;
    using System.Globalization; 
    #endregion

    public class ColumnNameConverter : IMultiValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values[0] != null && values[0] is bool && !((bool)values[0]))
                {
                    return values[1];
                }
                else
                {
                    return values[2];
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
            return new object[2];
        }
    }
}
