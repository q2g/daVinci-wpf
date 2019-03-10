namespace daVinci.Converter
{
    #region Usings
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using NLog;
    #endregion

    [ValueConversion(typeof(double), typeof(double))]
    public class AddNumberConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (parameter is string stringparameter)
                {
                    if (double.TryParse(stringparameter, out double doubleparameter))
                    {
                        if (value is double doublevalue)
                        {
                            return Math.Max(doublevalue + doubleparameter, 0);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
