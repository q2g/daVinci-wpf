using daVinci.ConfigData.Hub;
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
    /// Interaction logic for HubAppDataView.xaml
    /// </summary>
    public partial class HubAppDataView : UserControl
    {
        public HubAppDataView()
        {
            InitializeComponent();
        }

        #region IsEditMode DP
        public bool IsEditMode
        {
            get { return (bool)this.GetValue(IsEditModeProperty); }
            set { this.SetValue(IsEditModeProperty, value); }
        }

        public static readonly DependencyProperty IsEditModeProperty = DependencyProperty.Register(
         "IsEditMode", typeof(bool), typeof(HubAppDataView), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region AppToEdit DP
        public AppData AppToEdit
        {
            get { return (AppData)this.GetValue(AppToEditProperty); }
            set { this.SetValue(AppToEditProperty, value); }
        }

        public static readonly DependencyProperty AppToEditProperty = DependencyProperty.Register(
         "AppToEdit", typeof(AppData), typeof(HubAppDataView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
