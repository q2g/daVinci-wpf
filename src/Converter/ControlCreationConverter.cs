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
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            UserControl controlHolder = new UserControl() { Content = "Laden..." };

            if (parameter is Type type)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    //Give UI Time to Breathe
                    Thread.Sleep(1000);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        if (Activator.CreateInstance(type) is Control toCreate)
                        {
                            toCreate.DataContext = value;
                            controlHolder.Content = toCreate;
                        }
                    });

                };
                worker.RunWorkerAsync();

                //controlHolder.Content = Activator.CreateInstance(type);
            }





            return controlHolder;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }


    }
}
