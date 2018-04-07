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
    [ValueConversion(typeof(double), typeof(double))]
    public class AddNumberConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (parameter is string stringparameter)
                {
                    if (double.TryParse(stringparameter, out double doubleparameter))
                    {
                        if (value is double doublevalue)
                        {
                            return doublevalue + doubleparameter;
                        }
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
