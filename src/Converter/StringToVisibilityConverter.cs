namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    #endregion

    [ValueConversion(typeof(String), typeof(Visibility))]
    public class StringToVisibilityConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public string MatchValue { get; set; }

        public Visibility MatchVisibility { get; set; }
        public Visibility ElseVisibility { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value is string stringvalue && stringvalue == MatchValue)
                {
                    return MatchVisibility;
                }
                else
                    return ElseVisibility;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return ElseVisibility;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
