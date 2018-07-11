namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Windows.Data;
    using System.Globalization;
    using daVinci.ConfigData;
    #endregion

    public class BoolToColumnChooserModeConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value is ColumnChooserMode mode)
                {
                    if (mode == ColumnChooserMode.Pivot)
                        return true;
                    if (mode == ColumnChooserMode.Combined)
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
                    return boolvalue ? ColumnChooserMode.Pivot : ColumnChooserMode.Combined;
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return value;
        }


    }
}
