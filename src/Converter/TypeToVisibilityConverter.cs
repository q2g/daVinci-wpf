namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Globalization; 
    #endregion

    public class TypeToVisibilityConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Visibility MatchValue { get; set; }
        public Visibility DoesNotMatchValue { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return DoesNotMatchValue;
                }

                if (parameter is Type type)
                {
                    if (value.GetType() == type)
                    {
                        return MatchValue;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return DoesNotMatchValue;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }


    }
}
