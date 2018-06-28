namespace daVinci.Controls
{
    #region Usings
    using NLog;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Runtime.CompilerServices;
    using System.Collections.ObjectModel;
    using daVinci.ConfigData.Connection;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für ConnectionTestContent.xaml
    /// </summary>
    public partial class ConnectionTestContent : UserControl, INotifyPropertyChanged
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

        #region ctor
        public ConnectionTestContent()
        {
            InitializeComponent();
        }
        #endregion

        #region Poperties
        private ObservableCollection<ConnectionTestResult> results;
        public ObservableCollection<ConnectionTestResult> Results
        {
            get { return results; }
            set
            {
                if (results != value)
                {
                    results = value;
                    RaisePropertyChanged();
                }
            }
        }
        private ICommand createSupportEmailCommand;
        public ICommand CreateSupportEmailCommand
        {
            get { return createSupportEmailCommand; }
            set
            {
                if (createSupportEmailCommand != value)
                {
                    createSupportEmailCommand = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion       
    }
}
