namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Windows.Data;
    using System.Globalization;
    using System.Windows;
    #endregion

    public class DefaultDataTemplateConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DataTemplate DefaultdataTemplate { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null)
            {
                return DefaultdataTemplate;
            }

            return value;

        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return new object[2];
        }
    }
}
