using daVinci.ConfigData.Connection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace daVinci.ConfigData.Wizard
{
    public class WizardItem : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & Variables
        private UserControl subControl;
        public UserControl SubControl
        {
            get
            {
                return subControl;
            }
            set
            {
                if (subControl != value)
                {
                    subControl = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ObservableCollection<ConnectionTestResult> Tests { get; set; } = new ObservableCollection<ConnectionTestResult>();
        private ICommand userInputFinishedCommand;
        public ICommand UserInputFinishedCommand
        {
            get
            {
                return userInputFinishedCommand;
            }
            set
            {
                if (userInputFinishedCommand != value)
                {
                    userInputFinishedCommand = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool showTests;
        public bool ShowTests
        {
            get
            {
                return showTests;
            }
            set
            {
                if (showTests != value)
                {
                    showTests = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }
}
