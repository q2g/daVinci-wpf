namespace daVinci.ConfigData.Hub
{
    using leonardo.Resources;
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    #endregion

    public class TemplateItem : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & Variables
        private string name;
        public string Name
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
        private string fullname;
        public string FullName
        {
            get
            {
                return fullname;
            }
            set
            {
                fullname = value;
                RaisePropertyChanged();
            }
        }
        private string fullNameResolved;
        public string FullNameResolved
        {
            get
            {
                return fullNameResolved;
            }
            set
            {
                fullNameResolved = value;
                RaisePropertyChanged();
            }
        }
        private ICommand openCommand;
        public ICommand OpenCommand
        {
            get
            {
                return openCommand;
            }
            set
            {
                openCommand = value;
                RaisePropertyChanged();
            }
        }
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
            set
            {
                deleteCommand = value;
                RaisePropertyChanged();
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
    public class TemplateItemFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            string lowerSearchstring = searchString.ToLower();
            if (data is TemplateItem tdata)
            {
                return ((tdata?.Name?.ToLower() ?? "").Contains(lowerSearchstring));
            }
            return false;
        }
    }
}
