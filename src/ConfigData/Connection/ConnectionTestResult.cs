namespace daVinci.ConfigData.Connection
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using leonardo.Resources;
    using NLog;
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
        #endregion
    }
}
