namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData.Connection;
    using leonardo.AttachedProperties;
    using NLog;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
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

        #region CreateSupportEmailCommand DP
        public ICommand CreateSupportEmailCommand
        {
            get { return (ICommand)this.GetValue(CreateSupportEmailCommandProperty); }
            set { this.SetValue(CreateSupportEmailCommandProperty, value); }
        }

        public static readonly DependencyProperty CreateSupportEmailCommandProperty = DependencyProperty.Register(
         "CreateSupportEmailCommand", typeof(ICommand), typeof(ConnectionTestContent), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Results DP
        public ObservableCollection<ConnectionTestResult> Results
        {
            get { return (ObservableCollection<ConnectionTestResult>)this.GetValue(ResultsProperty); }
            set { this.SetValue(ResultsProperty, value); }
        }

        public static readonly DependencyProperty ResultsProperty = DependencyProperty.Register(
         "Results", typeof(ObservableCollection<ConnectionTestResult>), typeof(ConnectionTestContent), new FrameworkPropertyMetadata(new ObservableCollection<ConnectionTestResult>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        private ConnectionTestResultFilter hwndfilter;
        public ConnectionTestResultFilter HwndFilter
        {
            get { return hwndfilter; }
            set
            {
                if (hwndfilter != value)
                {
                    hwndfilter = value;
                    RaisePropertyChanged();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = (int)(this.GetValue(ThemeProperties.HwndProperty));
            HwndFilter = new ConnectionTestResultFilter() { ForHwnd = hwnd };
        }
    }
}
