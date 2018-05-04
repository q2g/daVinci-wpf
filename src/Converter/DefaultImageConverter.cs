namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Windows.Data;
    using System.Globalization;
    using System.Windows.Media.Imaging; 
    #endregion
    public class DefaultImageConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public string DefaultImagePath { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    if (DefaultImagePath is string imagename)
                    {
                        return new BitmapImage(new Uri($"pack://application:,,,/daVinci-wpf;component/{imagename}"));
                    }
                }
                return value;
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
