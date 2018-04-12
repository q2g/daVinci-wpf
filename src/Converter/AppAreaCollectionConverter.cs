using daVinci.ConfigData;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class AppAreaCollectionConverter : IMultiValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values.Length != 4)
                {
                    return new ObservableCollection<object>();
                }
                if (values[0] != null && values[0] is System.Collections.IEnumerable itemsSource)
                {

                }

                if (values[1] != null && values[1] is int sortByindex)
                {
                    if (values[2] != null && values[2] is bool sortDescending)
                    {

                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return "";

        }



        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[2];
        }
    }
}
