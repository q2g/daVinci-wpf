using daVinci.ConfigData;
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
    public class FormatConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public double NumberToFormat { get; set; }


        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                object objectToFormat = null;
                if (parameter is string stringparam)
                {

                    switch (stringparam)
                    {
                        case "d":
                            objectToFormat = NumberToFormat;
                            break;
                        default:
                            break;
                    }
                    if (value is string stringval)
                    {
                        if (objectToFormat != null)
                        {
                            return string.Format("{0:" + stringval + "}", objectToFormat);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return "";


        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }


    }
}
