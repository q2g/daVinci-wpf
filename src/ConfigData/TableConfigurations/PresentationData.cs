namespace daVinci.ConfigData
{
    #region Usings
    using NLog;
    using System;
    using Newtonsoft.Json.Linq;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class PresentationData : INotifyPropertyChanged
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private bool totalMode;
        public bool TotalMode
        {
            get
            {
                return totalMode;
            }
            set
            {
                if (totalMode != value)
                {
                    totalMode = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string totalLabel;
        public string TotalLabel
        {
            get
            {
                return totalLabel;
            }
            set
            {
                if (totalLabel != value)
                {
                    totalLabel = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int totalPositionIndex;
        public int TotalPositionIndex
        {
            get
            {
                return totalPositionIndex;
            }
            set
            {
                if (totalPositionIndex != value)
                {
                    totalPositionIndex = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void ReadFromJSON(dynamic jsonConfig)
        {
            try
            {
                TotalMode = jsonConfig?.show ?? false;
                TotalLabel = jsonConfig?.label ?? "";
                switch (jsonConfig?.position?.ToString() ?? "none")
                {
                    case "none":
                        TotalPositionIndex = 0;
                        break;
                    case "top":
                        TotalPositionIndex = 1;
                        break;
                    case "bottom":
                        TotalPositionIndex = 2;
                        break;
                    default:
                        TotalPositionIndex = 0;
                        break;
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
                logger.Trace($"JSON:{jsonConfig?.ToString() ?? ""}");
            }
        }

        public dynamic SaveToJSON()
        {
            dynamic jsonConfig = new JObject();
            try
            {
                jsonConfig.show = TotalMode;

                switch (TotalPositionIndex)
                {
                    case 0:
                        break;
                    case 1:
                        jsonConfig.position = "top";
                        break;
                    case 2:
                        jsonConfig.position = "bottom";
                        break;
                    default:
                        break;
                }
                jsonConfig.label = TotalLabel;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return jsonConfig;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
