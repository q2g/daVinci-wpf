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
    [ValueConversion(typeof(string), typeof(Visibility))]
    public class StringLengthToVisibilityConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Visibility LengthGreaterZero_Visbility { get; set; }
        public Visibility LengthZero_Visbility { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return LengthZero_Visbility;
                }
                if (value is string stringvalue)
                {
                    if (stringvalue.Length > 0)
                    {
                        return LengthGreaterZero_Visbility;
                    }
                    else
                    {
                        return LengthZero_Visbility;
                    }
                }

            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return LengthZero_Visbility;

        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }


    }
}
