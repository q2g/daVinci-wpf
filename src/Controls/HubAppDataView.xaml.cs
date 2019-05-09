namespace daVinci.Controls
{

    #region Usings
    using daVinci.ConfigData.Extenting;
    using daVinci.ConfigData.Hub;
    using daVinci.IOC;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaction logic for HubAppDataView.xaml
    /// </summary>
    public partial class HubAppDataView : UserControl
    {
        public HubAppDataView()
        {
            IocContainer.Instance.ResolveAll<CommandGUIExtention>().ToList().ForEach(ele => ButtonExtentions.Add(ele));
            InitializeComponent();
        }


        public ObservableCollection<CommandGUIExtention> ButtonExtentions { get; set; } = new ObservableCollection<CommandGUIExtention>();

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
