using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace daVinci.Controls
{
    /// <summary>
    /// Interaction logic for ControlLoader.xaml
    /// </summary>
    public partial class ControlLoader : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ControlLoader()
        {
            InitializeComponent();

        }

        public Type TypeToCreate { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TypeToCreate != null)
                {
                    var control = (Control)Activator.CreateInstance(TypeToCreate);
                    control.DataContext = DataContext;
                    Content = control;
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
    }
}
