namespace daVinci.ConfigData
{
    #region Usings
    using Newtonsoft.Json.Linq;
    using NLog;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class AddOnDataProcessingConfiguration : INotifyPropertyChanged
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private bool allowNULLValues = true;
        public bool AllowNULLValues
        {
            get
            {
                return allowNULLValues;
            }
            set
            {
                if (allowNULLValues != value)
                {
                    allowNULLValues = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string calcCondition;
        public string CalcCondition
        {
            get
            {
                return calcCondition;
            }
            set
            {
                if (calcCondition != value)
                {
                    calcCondition = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string displayedMessage;
        public string DisplayedMessage
        {
            get
            {
                return displayedMessage;
            }
            set
            {
                if (displayedMessage != value)
                {
                    displayedMessage = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void ReadFromJSON(dynamic jsonConfig)
        {
            try
            {
                AllowNULLValues = (jsonConfig?.qSuppressZero ?? false) == false ? true : false;
                CalcCondition = jsonConfig?.qCalcCond?.qv ?? "";
                if (!string.IsNullOrEmpty(CalcCondition))
                {
                    CalcCondition = jsonConfig?.qCalcCondition?.qCond?.qv ?? "";
                }
                DisplayedMessage = jsonConfig?.qCalcCondition?.qMsg?.qv ?? "";
                if (!string.IsNullOrEmpty(DisplayedMessage))
                {
                    DisplayedMessage = jsonConfig?.customErrorMessage?.calcCond ?? "";
                }
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
                if (!AllowNULLValues)
                    jsonConfig.qSuppressZero = !AllowNULLValues;
                jsonConfig.qCalcCond = new JObject();
                if (!string.IsNullOrEmpty(CalcCondition))
                    jsonConfig.qCalcCond.qv = CalcCondition;
                jsonConfig.qCalcCondition = new JObject();
                jsonConfig.qCalcCondition.qCond = new JObject();
                if (!string.IsNullOrEmpty(CalcCondition))
                    jsonConfig.qCalcCondition.qCond.qv = CalcCondition;
                if (!string.IsNullOrEmpty(DisplayedMessage))
                {
                    jsonConfig.qCalcCond.qMsg = new JObject();
                    jsonConfig.qCalcCond.qMsg.qv = DisplayedMessage;
                }
                if (!string.IsNullOrEmpty(DisplayedMessage))
                {
                    jsonConfig.cusmErrorMessage = new JObject();
                    jsonConfig.customErrorMessage.calcCond = DisplayedMessage;
                }
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
