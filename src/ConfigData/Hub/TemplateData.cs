namespace daVinci.ConfigData.Hub
{
    #region Usings
    using leonardo.Resources;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    #endregion

    public class TemplateData : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & Variables
        public ObservableCollection<TemplateItem> Items { get; set; } = new ObservableCollection<TemplateItem>();

        private bool templatesLoaded;
        public bool TemplatesLoaded
        {
            get
            {
                return templatesLoaded;
            }
            set
            {
                templatesLoaded = value;
                RaisePropertyChanged();
            }
        }

        private bool hasTemplates;
        public bool HasTemplates
        {
            get
            {
                return hasTemplates;
            }
            set
            {
                hasTemplates = value;
                RaisePropertyChanged();
            }
        }

        private bool isAppSpecific;
        public bool IsAppSpecific
        {
            get
            {
                return isAppSpecific;
            }
            set
            {
                isAppSpecific = value;
                RaisePropertyChanged();
            }
        }

        private string name;
        public string GroupName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        private string groupid;
        public string GroupID
        {
            get
            {
                return groupid;
            }
            set
            {
                groupid = value;
                RaisePropertyChanged();
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
        private System.Windows.Media.Imaging.BitmapImage templateLogo;
        public System.Windows.Media.Imaging.BitmapImage TemplateLogo
        {
            get => templateLogo;
            set
            {
                if (templateLogo != value)
                {
                    templateLogo = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }
    public class TemplateDataFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            string lowerSearchstring = searchString.ToLower();
            if (data is TemplateData tdata)
            {
                return ((tdata?.GroupName?.ToLower() ?? "").Contains(lowerSearchstring)
                    || tdata.Items.Any(ele => ele.Name.ToLower().Contains(lowerSearchstring)));
            }
            return false;
        }
    }
}
