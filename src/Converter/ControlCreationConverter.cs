namespace daVinci.Converter
{
    #region Usings
    using daVinci.Controls;
    using NLog;
    using System;
    using System.Globalization;
    using System.Windows.Controls;
    using System.Windows.Data;
    #endregion

    [ValueConversion(typeof(object), typeof(object))]
    public class ControlCreationConverter : IMultiValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object[] values, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (values[0] is object datacontext)
                {
                    if (values[1] is int hwnd)
                    {
                        ControlLoader controlHolder = new ControlLoader() { Content = "Loading..." };
                        if (parameter is Type type)
                        {
                            controlHolder.TypeToCreate = type;
                            controlHolder.DataContext = datacontext;
                            controlHolder.Hwnd = hwnd;
                        }
                        return controlHolder;
                    }
                }
                return null;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return new UserControl();
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
