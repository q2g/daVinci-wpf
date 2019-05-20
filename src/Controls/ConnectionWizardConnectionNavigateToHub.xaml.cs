namespace daVinci.Controls
{
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für ConnectionWizardConnectionName.xaml
    /// </summary>
    public partial class ConnectionWizardConnectionNavigateToHub : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public ConnectionWizardConnectionNavigateToHub()
        {
            InitializeComponent();
        }

        #region Properties & Variables
        private ICommand navigateToHubCommand;
        public ICommand NavigateToHubCommand
        {
            get
            {
                return navigateToHubCommand;
            }
            set
            {
                if (navigateToHubCommand != value)
                {
                    navigateToHubCommand = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }
}
