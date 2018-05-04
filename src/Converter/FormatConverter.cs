namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Windows.Data;
    using System.Globalization; 
    #endregion

    public class FormatConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public double NumberToFormat { get; set; }


        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                object objectToFormat = null;
                if (parameter is string stringparam)
                {

                    switch (stringparam)
                    {
                        case "d":
                            objectToFormat = NumberToFormat;
                            break;
                        default:
                            break;
                    }
                    if (value is string stringval)
                    {
                        if (objectToFormat != null)
                        {
                            return string.Format("{0:" + stringval + "}", objectToFormat);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return "";


        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }


    }
}
