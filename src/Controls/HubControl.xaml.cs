namespace daVinci.Controls
{
    #region Usings
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
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

        #region Owner DP
        public IntPtr? Owner
        {
            get { return (IntPtr?)this.GetValue(OwnerProperty); }
            set { this.SetValue(OwnerProperty, value); }
        }

        public static readonly DependencyProperty OwnerProperty = DependencyProperty.Register(
         "Owner", typeof(IntPtr?), typeof(HubControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
