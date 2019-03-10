namespace daVinci.Controls
{
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using leonardo.Resources;
    using NLog;
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

        private bool showImport = false;
        public bool ShowImport
        {
            get
            {
                return showImport;
            }
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
