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
        #endregion
    }
}
