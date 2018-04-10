using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci_wpf.ConfigData.Hub
{
    public class AppData : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        private string appName;
        public string AppName
        {
            get
            {
                return appName;
            }
            set
            {
                if (appName != value)
                {
                    appName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string appDescription;
        public string AppDescription
        {
            get
            {
                return appDescription;
            }
            set
            {
                if (appDescription != value)
                {
                    appDescription = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string appImage;
        public string AppImage
        {
            get
            {
                return appImage;
            }
            set
            {
                if (appImage != value)
                {
                    appImage = value;
                    RaisePropertyChanged();
                }
            }
        }

        private DateTime dataLastLoaded;
        public DateTime DataLastLoaded
        {
            get
            {
                return dataLastLoaded;
            }
            set
            {
                if (dataLastLoaded != value)
                {
                    dataLastLoaded = value;
                    RaisePropertyChanged();
                }
            }
        }

        private DateTime published;
        public DateTime Published
        {
            get
            {
                return published;
            }
            set
            {
                if (published != value)
                {
                    published = value;
                    RaisePropertyChanged();
                }
            }
        }

        private DateTime created;
        public DateTime Created
        {
            get
            {
                return created;
            }
            set
            {
                if (created != value)
                {
                    created = value;
                    RaisePropertyChanged();
                }
            }
        }





    }
}
