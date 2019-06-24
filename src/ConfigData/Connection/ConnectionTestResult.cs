namespace daVinci.ConfigData.Connection
{
    #region Usings
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
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
                    passed = value;
                    RaisePropertyChanged();
                }
            }
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
        #endregion
    }

    public class ConnectionTestResultFilter : ICollectionViewFilter
    {
        public int ForHwnd { get; set; } = 0;
        public bool Filter(object data, string searchString)
        {
            if (data is ConnectionTestResult ctdata)
            {
                return ctdata.Hwnd == ForHwnd;
            }
            return false;
        }
    }
}
