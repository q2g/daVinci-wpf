namespace daVinci.ConfigData.Connection
{
    #region Usings
    using leonardo.Resources;
    using NLog;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Media;
    #endregion

    public class ConnectionTestResult : INotifyPropertyChanged
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

        #region CTOR
        public ConnectionTestResult()
        {
            BackgroundBrush = LuiPalette.Brushes.GRAYSCALE95;
        }
        #endregion

        #region Properties
        private string testName;
        public string TestName
        {
            get { return testName; }
            set
            {
                if (testName != value)
                {
                    testName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string helpMessage;
        public string HelpMessage
        {
            get { return helpMessage; }
            set
            {
                if (helpMessage != value)
                {
                    helpMessage = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool? passed = null;
        public bool? Passed
        {
            get { return passed; }
            set
            {
                if (passed != value)
                {
                    if (value.HasValue && value.Value == false)
                        StartBlinking();
                    passed = value;
                    RaisePropertyChanged();
                }
            }
        }
        private async Task StartBlinking()
        {
            BackgroundBrush = LuiPalette.Brushes.ORANGE;
            await Task.Delay(1000);
            BackgroundBrush = LuiPalette.Brushes.GRAYSCALE95;
            await Task.Delay(1000);
            BackgroundBrush = LuiPalette.Brushes.ORANGE;
            await Task.Delay(1000);
            BackgroundBrush = LuiPalette.Brushes.GRAYSCALE95;
            await Task.Delay(1000);
            BackgroundBrush = LuiPalette.Brushes.ORANGE;
            //await Task.Delay(1000);
            //BackgroundBrush = LuiPalette.Brushes.GRAYSCALE95;
        }
        private ObservableCollection<ConnectionTestResult> subResults;
        public ObservableCollection<ConnectionTestResult> SubResults
        {
            get { return subResults; }
            set
            {
                if (subResults != value)
                {
                    subResults = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int progress;
        public int Progress
        {
            get { return progress; }
            set
            {
                if (progress != value)
                {
                    progress = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool showprogress;
        public bool ShowProgress
        {
            get { return showprogress; }
            set
            {
                if (showprogress != value)
                {
                    showprogress = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int hwnd;
        public int Hwnd
        {
            get { return hwnd; }
            set
            {
                if (hwnd != value)
                {
                    hwnd = value;
                    RaisePropertyChanged();
                }
            }
        }

        private object tag;
        public object Tag
        {
            get { return tag; }
            set
            {
                if (tag != value)
                {
                    tag = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool retryVisible;
        public bool RetryVisible
        {
            get { return retryVisible; }
            set
            {
                if (retryVisible != value)
                {
                    retryVisible = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool cancelVisible;
        public bool CancelVisible
        {
            get { return cancelVisible; }
            set
            {
                if (cancelVisible != value)
                {
                    cancelVisible = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                if (isExpanded != value)
                {
                    isExpanded = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ICommand retryCommand;
        public ICommand RetryCommand
        {
            get { return retryCommand; }
            set
            {
                if (retryCommand != value)
                {
                    retryCommand = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get { return cancelCommand; }
            set
            {
                if (cancelCommand != value)
                {
                    cancelCommand = value;
                    RaisePropertyChanged();
                }
            }
        }

        private Brush backgroundBrush;
        public Brush BackgroundBrush
        {
            get { return backgroundBrush; }
            set
            {
                if (backgroundBrush != value)
                {
                    backgroundBrush = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }

    public class ConnectionTestResultFilter : ICollectionViewFilter
    {
        public int ForHwnd { get; set; } = 0;
        public bool Filter(object data, string searchString)
        {
            if (data is ConnectionTestResult ctdata)
            {
                return ctdata.Hwnd == ForHwnd || ctdata.Hwnd == 0;
            }
            return false;
        }
    }
}
