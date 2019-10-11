namespace daVinci.ConfigData.Hub
{
    using System.Collections.ObjectModel;
    #region Usings
    using System.ComponentModel;
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
}
