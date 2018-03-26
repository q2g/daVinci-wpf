using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace daVinci.Converter
{
    [ValueConversion(typeof(object), typeof(object))]
    public class ControlCreationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if(parameter is Type type)
            {
                var control = Activator.CreateInstance(type);
                return control;
            }
            return null;
            
        }        

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {          
            return null;
        }

       
    }
}
