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
    /// Interaction logic for HubAppArea.xaml
    /// </summary>
    public partial class HubAppArea : UserControl
    {
        public HubAppArea()
        {
            InitializeComponent();

        }

        #region Stream - DP        
        public object Stream
        {
            get { return (object)this.GetValue(StreamProperty); }
            set { this.SetValue(StreamProperty, value); }
        }

        public static readonly DependencyProperty StreamProperty = DependencyProperty.Register(
         "Stream", typeof(object), typeof(HubAppArea), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
