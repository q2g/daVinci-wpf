namespace daVinci.Controls
{
    using daVinci.ConfigData.Connection;
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für ConnectionWizardConnectionFinished.xaml
    /// </summary>
    public partial class ConnectionWizardConnectionFinished : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public ConnectionWizardConnectionFinished()
        {
            InitializeComponent();
        }

        #region Properties & Variables

        #endregion
    }
}
