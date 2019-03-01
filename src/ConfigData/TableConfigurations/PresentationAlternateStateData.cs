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

        private ObservableCollection<AlternateStateInfo> states = new ObservableCollection<AlternateStateInfo>();
        public ObservableCollection<AlternateStateInfo> States
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
                selectedstate = jsonConfig?.qHyperCubeDef?.qStateName ?? jsonConfig?.qStateName ?? "";
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
                jsonConfig.qHyperCubeDef.qStateName = selectedstate;
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
