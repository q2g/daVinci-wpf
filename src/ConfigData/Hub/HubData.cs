namespace daVinci.ConfigData
{
    #region Usings
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices; 
    #endregion

    public class HubData : INotifyPropertyChanged
    {
        private ObservableCollection<object> streams = new ObservableCollection<object>();
        public ObservableCollection<object> Streams
        {
            get
            {
                return streams;
            }
            set
            {
                streams = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<object> personalStreams = new ObservableCollection<object>();
        public ObservableCollection<object> PersonalStreams
        {
            get
            {
                return personalStreams;
            }
            set
            {
                personalStreams = value;
                RaisePropertyChanged();
            }
        }

        private StreamData selectedStream;
        public StreamData SelectedStream
        {
            get
            {
                return selectedStream;
            }
            set
            {
                selectedStream = value;
                RaisePropertyChanged();
            }
        }

        private string username;
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
