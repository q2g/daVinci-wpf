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
    [ValueConversion(typeof(int), typeof(Visibility))]
    public class IntToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; }
        public Visibility FalseValue { get; set; }


        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value == null || !(value is int))
            {
                return Visibility.Visible;
            }
            string stringparameter = parameter as string;
            if (stringparameter == null)
            {
                return Visibility.Visible;
            }
            if (stringparameter.Contains(","))
            {
                return IsValueInIndexes(stringparameter,(int)value) ? TrueValue : FalseValue;
            }
            else
            {
                if (parameter == null || !Int32.TryParse((string)parameter, out int parametervalue))
                {
                    return Visibility.Visible;
                }
                return (int)value == parametervalue ? TrueValue : FalseValue;
            }

            
        }        

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {          
            return null;
        }

        private bool IsValueInIndexes(string stringparameter, int value)
        {
            return stringparameter.Split(',').Any(ele => Int32.Parse(ele) == value);
        }
    }
}
