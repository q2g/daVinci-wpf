namespace daVinci.Converter
{
    #region Usings
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using daVinci.ConfigData;
    using NLog;
    #endregion

    public class BoolToColumnChooserModeConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ColumnChooserMode TrueValue { get; set; }
        public ColumnChooserMode ValueWhenFalse { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value is ColumnChooserMode mode)
                {
                    if (mode == TrueValue)
                        return true;
                    return false;
                }
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
            try
            {
                if (value is bool boolvalue)
                {
                    return boolvalue ? TrueValue : ValueWhenFalse;
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return ValueWhenFalse;
        }
    }
}
