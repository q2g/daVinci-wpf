namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Windows.Data;
    using System.Globalization;
    using System.Windows;
    #endregion

    public class HeaderTypeToDataTemplateConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DataTemplate HeaderIsStringTemplate { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value is DataTemplate templ)
                {
                    return templ;
                }
                return HeaderIsStringTemplate;

            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return "";

        }



        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return new object[2];
        }
    }
}
