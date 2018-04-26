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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace daVinci.Converter
{
    public class DefaultImageConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public string DefaultImagePath { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    if (DefaultImagePath is string imagename)
                    {
                        return new BitmapImage(new Uri($"pack://application:,,,/daVinci-wpf;component/{imagename}"));
                    }
                }
                return value;
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
