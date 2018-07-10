namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Windows.Data;
    using System.Globalization;
    using daVinci.ConfigData;
    #endregion

    [ValueConversion(typeof(double), typeof(double))]
    public class BoolToColumnChooserModeConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value is bool boolvalue)
                {
                    return boolvalue ? ColumnChooserMode.Pivot : ColumnChooserMode.Combined;
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
