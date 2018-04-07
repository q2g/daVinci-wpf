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
