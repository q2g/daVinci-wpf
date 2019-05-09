using leonardo.Controls;
using leonardo.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace daVinci.ConfigData.Extenting
{
    public class CommandGUIExtention : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region properties & vaariables
        private ICommand command;
        public ICommand Command
        {
            get
            {
                return command;
            }
            set
            {
                if (command != value)
                {
                    command = value;
                    RaisePropertyChanged();
                }
            }
        }
        private LuiIconsEnum icon;
        public LuiIconsEnum Icon
        {
            get
            {
                return icon;
            }
            set
            {
                if (icon != value)
                {
                    icon = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (text != value)
                {
                    text = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion
    }
}
