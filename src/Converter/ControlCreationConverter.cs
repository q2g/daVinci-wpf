using daVinci.Controls;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace daVinci.Converter
{
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
