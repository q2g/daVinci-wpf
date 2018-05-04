namespace daVinci.Controls
{
    #region Usings
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Controls; 
    #endregion

    /// <summary>
    /// Interaction logic for HubControl.xaml
    /// </summary>
    public partial class HubControl : UserControl
    {
        public HubControl()
        {
            InitializeComponent();
        }

        #region AppSelectionCommand - DP        
        public ICommand AppSelectionCommand
        {
            get { return (ICommand)this.GetValue(AppSelectionCommandProperty); }
            set { this.SetValue(AppSelectionCommandProperty, value); }
        }

        public static readonly DependencyProperty AppSelectionCommandProperty = DependencyProperty.Register(
         "AppSelectionCommand", typeof(ICommand), typeof(HubControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region LastSelectedAppID DP
        public string LastSelectedAppID
        {
            get { return (string)this.GetValue(LastSelectedAppIDProperty); }
            set { this.SetValue(LastSelectedAppIDProperty, value); }
        }

        public static readonly DependencyProperty LastSelectedAppIDProperty = DependencyProperty.Register(
         "LastSelectedAppID", typeof(string), typeof(HubControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
