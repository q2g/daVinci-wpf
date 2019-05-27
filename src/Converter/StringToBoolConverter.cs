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

    [ValueConversion(typeof(String), typeof(bool))]
    public class StringToBoolConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public string TrueString { get; set; }
        public string FalseString { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value is string stringvalue && stringvalue == TrueString)
                    return true;
                else
                    return false;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is bool boolvalue && boolvalue)
            {
                return TrueString;
            }
            return FalseString;
        }
    }
}
