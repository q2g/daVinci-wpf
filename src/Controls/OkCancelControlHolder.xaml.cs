namespace daVinci.Controls
{
    #region Usings
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaction logic for OkCancelControlHolder.xaml
    /// </summary>
    public partial class OkCancelControlHolder : UserControl
    {
        public OkCancelControlHolder()
        {
            InitializeComponent();
        }

        #region ShowOKCancel - DP        
        public bool ShowOKCancel
        {
            get { return (bool)this.GetValue(ShowOKCancelProperty); }
            set { this.SetValue(ShowOKCancelProperty, value); }
        }

        public static readonly DependencyProperty ShowOKCancelProperty = DependencyProperty.Register(
        "ShowOKCancel", typeof(bool), typeof(OkCancelControlHolder), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ShowImport - DP        
        public bool ShowImport
        {
            get { return (bool)this.GetValue(ShowImportProperty); }
            set { this.SetValue(ShowImportProperty, value); }
        }

        public static readonly DependencyProperty ShowImportProperty = DependencyProperty.Register(
        "ShowImport", typeof(bool), typeof(OkCancelControlHolder), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region OKCommand - DP        
        public ICommand OKCommand
        {
            get { return (ICommand)this.GetValue(OKCommandProperty); }
            set { this.SetValue(OKCommandProperty, value); }
        }

        public static readonly DependencyProperty OKCommandProperty = DependencyProperty.Register(
        "OKCommand", typeof(ICommand), typeof(OkCancelControlHolder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region CancelCommand - DP        
        public ICommand CancelCommand
        {
            get { return (ICommand)this.GetValue(CancelCommandProperty); }
            set { this.SetValue(CancelCommandProperty, value); }
        }

        public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(
         "CancelCommand", typeof(ICommand), typeof(OkCancelControlHolder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        private void LuiAbortButton_Click(object sender, RoutedEventArgs e)
        {
            if (CancelCommand != null)
            {
                CancelCommand.Execute(null);
            }
        }

        private void LuiOKButton_Click(object sender, RoutedEventArgs e)
        {
            if (OKCommand != null)
            {
                OKCommand.Execute(null);
            }
        }
    }
}
