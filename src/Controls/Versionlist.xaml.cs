namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData.Connection;
    using daVinci.ConfigData.Version;
    using leonardo.AttachedProperties;
    using leonardo.Resources;
    using NLog;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für Versionlist.xaml
    /// </summary>
    public partial class Versionlist : UserControl, INotifyPropertyChanged
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
        public Versionlist()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties & Variables
        public ObservableCollection<VersionDTO> Versions { get; set; } = new ObservableCollection<VersionDTO>();
        private string room;
        public string Room
        {
            get { return room; }
            set
            {
                if (value != room)
                {
                    room = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string waitingText;
        public string WaitingText
        {
            get { return waitingText; }
            set
            {
                if (value != waitingText)
                {
                    waitingText = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool showVersionlist;
        public bool ShowVersionlist
        {
            get { return showVersionlist; }
            set
            {
                if (value != showVersionlist)
                {
                    showVersionlist = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool showBusyCircle;
        public bool ShowBusyCircle
        {
            get { return showBusyCircle; }
            set
            {
                if (value != showBusyCircle)
                {
                    showBusyCircle = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }

    public class VersionsRoomFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is VersionDTO ver)
                return (ver.Version.Room + "") == (searchString + "");
            return false;
        }
    }
}
