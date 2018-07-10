namespace daVinci.Controls
{
    #region Usings
    using leonardo.Resources;
    using NLog;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaktionslogik für PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : UserControl, INotifyPropertyChanged
    {
        #region LoggerInit
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
        public PropertyPanel()
        {
            InitializeComponent();
        }

        #region OwnerHwndHwnd DP
        public int OwnerHwnd
        {
            get { return (int)this.GetValue(OwnerHwndProperty); }
            set { this.SetValue(OwnerHwndProperty, value); }
        }

        public static readonly DependencyProperty OwnerHwndProperty = DependencyProperty.Register(
         "OwnerHwnd", typeof(int), typeof(PropertyPanel), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        private bool showImport = false;
        public bool ShowImport
        {
            get { return showImport; }
            set
            {
                if (showImport != value)
                {
                    showImport = value;
                    RaisePropertyChanged();
                }
            }

        }
    }
}
