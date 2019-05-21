namespace daVinci.Controls
{
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaktionslogik für ConnectionWizardConnectionName.xaml
    /// </summary>
    public partial class ConnectionWizardConnectionName : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public ConnectionWizardConnectionName()
        {
            InitializeComponent();
        }

        #region Properties & Variables
        private string connName;
        public string ConnectionName
        {
            get
            {
                return connName;
            }
            set
            {
                if (connName != value)
                {
                    connName = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string url;
        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                if (url != value)
                {
                    url = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }
}
