namespace daVinci.ConfigData.Hub
{
    #region Usings
    using leonardo.Resources;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    #endregion

    public class AppData : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public AppData()
        {
        }

        public AppData(AppData other)
        {
            CopyFrom(other);
        }
        public void CopyFrom(AppData other)
        {
            if (other != null)
            {
                AppID = other.AppID;
                AppName = other.AppName;
                AppDescription = other.AppDescription;
                AppImage = other.AppImage;
                DataLastLoaded = other.DataLastLoaded;
                Published = other.Published;
                Created = other.Created;
                filename = other.Filename;
                IsPublished = other.isPublished;
            }
        }

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

        private string appID;
        public string AppID
        {
            get
            {
                return appID;
            }
            set
            {
                if (appID != value)
                {
                    appID = value;
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

        private string filename;
        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                if (filename != value)
                {
                    filename = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool isPublished;
        public bool IsPublished
        {
            get
            {
                return isPublished;
            }
            set
            {
                if (isPublished != value)
                {
                    isPublished = value;
                    RaisePropertyChanged();
                }
            }
        }

        private System.Windows.Media.Imaging.BitmapImage image;
        public System.Windows.Media.Imaging.BitmapImage Image
        {
            get => image;
            set
            {
                if (image != value)
                {
                    image = value;
                    RaisePropertyChanged();
                }
            }
        }

        private TemplateData templatesData = new TemplateData();
        public TemplateData TemplateData
        {
            get
            {
                return templatesData;
            }
            set
            {
                templatesData = value;
                RaisePropertyChanged();
            }
        }
    }

    public class AppDataFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is AppData appdata)
            {
                return ((appdata?.AppDescription?.ToLower() ?? "").Contains(searchString.ToLower())
                    || (appdata?.AppName?.ToLower() ?? "").Contains(searchString.ToLower())
                    || (appdata.Created + "").ToLower().Contains(searchString.ToLower())
                    || (appdata.Published + "").ToLower().Contains(searchString.ToLower())
                    || (appdata.DataLastLoaded + "").ToLower().Contains(searchString.ToLower())
                    || (appdata?.Filename?.ToLower() ?? "").Contains(searchString.ToLower())
                    || (appdata?.AppID?.ToLower() ?? "").Contains(searchString.ToLower()));
            }
            return false;
        }
    }

    public class AppNameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is AppData xappdata)
            {
                if (y is AppData yappdata)
                {
                    return xappdata.AppName.CompareTo(yappdata.AppName);
                }
            }
            return 0;
        }
    }

    public class AppPublishedComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is AppData xappdata)
            {
                if (y is AppData yappdata)
                {
                    return xappdata.Published.CompareTo(yappdata.Published);
                }
            }
            return 0;
        }
    }

    public class AppCreatedComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is AppData xappdata)
            {
                if (y is AppData yappdata)
                {
                    return xappdata.Created.CompareTo(yappdata.Created);
                }
            }
            return 0;
        }
    }
}
