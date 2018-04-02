using daVinci.ConfigData;
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
    public class ColumnNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length != 2)
            {
                return "";
            }
            if (values[0] != null && values[0] is string && !string.IsNullOrEmpty((string)values[0]))
            {
                return values[0];
            }
            if (values[1] != null && values[1] is string && !string.IsNullOrEmpty((string)values[1]))
            {
                return values[1];
            }
            return "";

        }



        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[2];
        }
    }
}
