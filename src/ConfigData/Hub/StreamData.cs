namespace daVinci.ConfigData
{
    #region Usings
    using daVinci.ConfigData.Hub;
    using leonardo.Resources;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class StreamData : INotifyPropertyChanged
    {
        private string streamID;
        public string StreamID
        {
            get
            {
                return streamID;
            }
            set
            {
                if (streamID != value)
                {
                    streamID = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string streamName;
        public string StreamName
        {
            get
            {
                return streamName;
            }
            set
            {
                if (streamName != value)
                {
                    streamName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool isPersonal;
        public bool IsPersonal
        {
            get
            {
                return isPersonal;
            }
            set
            {
                if (isPersonal != value)
                {
                    isPersonal = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<AppData> apps = new ObservableCollection<AppData>();
        public ObservableCollection<AppData> Apps
        {
            get
            {
                return apps;
            }
            set
            {
                apps = value;
                RaisePropertyChanged();
            }
        }

        private LuiIconsEnum icon;
        public LuiIconsEnum Icon
        {
            get
            {
                return icon;
            }
            set
            {
                if (icon != value)
                {
                    icon = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
