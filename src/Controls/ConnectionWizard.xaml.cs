namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData.Connection;
    using daVinci.ConfigData.Wizard;
    using leonardo.Controls;
    using leonardo.Resources;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Net;
    using System.Net.Security;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;
    using WPFLocalizeExtension.Engine;
    #endregion

    /// <summary>
    /// Interaktionslogik für ConnectionEditor.xaml
    /// </summary>
    public partial class ConnectionWizard : UserControl, INotifyPropertyChanged
    {
        Dispatcher currentDispatcher;
        public ConnectionWizard()
        {
            currentDispatcher = this.Dispatcher;
            InitializeComponent();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & Variables

        private ICommand supportEmailCommand;
        public ICommand SupportEmailCommand
        {
            get
            {
                return supportEmailCommand;
            }
            set
            {
                if (supportEmailCommand != value)
                {
                    supportEmailCommand = value;
                    RaisePropertyChanged();
                }
            }
        }
        private WizardItem currentStep;
        public WizardItem CurrentStep
        {
            get
            {
                return currentStep;
            }
            set
            {
                if (currentStep != value)
                {
                    currentStep = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ObservableCollection<ConnectionTestResult> Tests { get; set; } = new ObservableCollection<ConnectionTestResult>();
        #endregion


    }
}
