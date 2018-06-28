namespace daVinci.Converter
{
    #region Usings
    using NLog;
    using System;
    using daVinci.Controls;
    using System.Windows.Data;
    using System.Globalization;
    using System.Windows.Controls;
    #endregion

    [ValueConversion(typeof(object), typeof(object))]
    public class ControlCreationConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                ControlLoader controlHolder = new ControlLoader() { Content = "Laden..." };
                if (parameter is Type type)
                {
                    controlHolder.TypeToCreate = type;
                    controlHolder.DataContext = value;


                }
                return controlHolder;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return new UserControl();
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }


    }
}
