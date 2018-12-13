namespace daVinci.ConfigData
{
    #region Usings
    using Newtonsoft.Json.Linq;
    using NLog;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class PresentationAlternateStateData : INotifyPropertyChanged
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ObservableCollection<string> states = new ObservableCollection<string>();
        public ObservableCollection<string> States
        {
            get
            {
                return states;
            }
            set
            {
                states = value;
                RaisePropertyChanged();
            }
        }

        private string selectedstate;
        public string SelectedState
        {
            get
            {
                return selectedstate;
            }
            set
            {
                if (selectedstate != value)
                {
                    selectedstate = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void ReadFromJSON(dynamic jsonConfig)
        {
            try
            {
                selectedstate = jsonConfig?.qStateName ?? "";
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
                logger.Trace($"JSON:{jsonConfig?.ToString() ?? ""}");
            }
        }

        public void SaveToJSON(dynamic jsonConfig)
        {
            try
            {
                jsonConfig.qStateName = selectedstate;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
