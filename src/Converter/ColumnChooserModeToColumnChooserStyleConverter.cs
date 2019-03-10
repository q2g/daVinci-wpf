namespace daVinci.Converter
{
    #region Usings
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using daVinci.ConfigData;
    using NLog;
    #endregion

    public class ColumnChooserModeToColumnChooserStyleConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Style CombinedStyle { get; set; }
        public Style PivotStyle { get; set; }
        public Style SeperateStyle { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value is ColumnChooserMode mode)
                {
                    switch (mode)
                    {
                        case ColumnChooserMode.Combined:
                            return CombinedStyle;
                        case ColumnChooserMode.Pivot:
                            return PivotStyle;
                        case ColumnChooserMode.Separated:
                            return SeperateStyle;
                        default:
                            break;
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
