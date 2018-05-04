namespace daVinci.Controls
{
    #region Usings
    using System.Windows;
    using daVinci.ConfigData.Hub;
    using System.Windows.Controls; 
    #endregion

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
