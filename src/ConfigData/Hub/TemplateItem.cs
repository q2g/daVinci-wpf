namespace daVinci.ConfigData.Hub
{
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
        }//
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
        }//OpenCommand
        #endregion
    }
}
