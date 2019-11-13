namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData.Connection;
    using daVinci.ConfigData.Settings;
    using daVinci.ConfigData.ThemeConfig;
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
        public SettingsDialog()
        {
            BaseTheme.AvailableThemes.ForEach(ele => AvailableThemes.Add(ele));

            InitializeComponent();

            SelectedTheme = BaseTheme.Instance.CurrentTheme;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & Variables
        public ObservableCollection<BaseTheme> AvailableThemes { get; set; } = new ObservableCollection<BaseTheme>();
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
        private BaseTheme selectedTheme;
        public BaseTheme SelectedTheme
        {
            get
            {
                return selectedTheme;
            }
            set
            {
                if (selectedTheme != value)
                {
                    selectedTheme = value;
                    RaisePropertyChanged();
                    BaseTheme.Instance.CurrentTheme = value;
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
