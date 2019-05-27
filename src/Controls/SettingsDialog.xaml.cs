namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData.Connection;
    using daVinci.ConfigData.Settings;
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
    /// Interaktionslogik für SettingsDialog.xaml
    /// </summary>
    public partial class SettingsDialog : UserControl, INotifyPropertyChanged
    {
        Dispatcher currentDispatcher;
        public SettingsDialog()
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
        private ObservableCollection<SettingsItem> settings = new ObservableCollection<SettingsItem>();
        public ObservableCollection<SettingsItem> Settings
        {
            get
            {
                return settings;
            }
            set
            {
                if (settings != value)
                {
                    settings = value;
                    RaisePropertyChanged();
                }
            }
        }
        private ICommand okCommand;
        public ICommand OKCommand
        {
            get
            {
                return okCommand;
            }
            set
            {
                if (okCommand != value)
                {
                    okCommand = value;
                    RaisePropertyChanged();
                }
            }
        }
        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand;
            }
            set
            {
                if (cancelCommand != value)
                {
                    cancelCommand = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion


    }
}
