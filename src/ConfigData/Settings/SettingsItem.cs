﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData.Settings
{
    public class SettingsItem : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & variables
        public string ID { get; set; }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (description != value)
                {
                    description = value;
                    RaisePropertyChanged();
                }
            }
        }
        private SettingsValue settingsValue;
        public SettingsValue SettingsValue
        {
            get
            {
                return settingsValue;
            }
            set
            {
                if (settingsValue != value)
                {
                    settingsValue = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (type != value)
                {
                    type = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool restartNeeded;
        public bool RestartNeeded
        {
            get
            {
                return restartNeeded;
            }
            set
            {
                if (restartNeeded != value)
                {
                    restartNeeded = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

    }
}
