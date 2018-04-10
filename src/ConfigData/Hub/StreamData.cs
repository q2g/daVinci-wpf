using daVinci_wpf.ConfigData.Hub;
using leonardo.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci_wpf.ConfigData
{
    public class StreamData : INotifyPropertyChanged
    {
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

        private LUIiconsEnum icon;
        public LUIiconsEnum Icon
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
