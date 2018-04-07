using daVinci.Resources;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class AddOnDataProcessingConfiguration : INotifyPropertyChanged
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private bool allowNULLValues;
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
            }
        }

        public void SaveToJSON(dynamic jsonConfig)
        {
            try
            {
                jsonConfig.qSuppressZero = !AllowNULLValues;
                jsonConfig.qCalcCond = new JObject();
                jsonConfig.qCalcCond.qv = CalcCondition;
                jsonConfig.qCalcCondition = new JObject();
                jsonConfig.qCalcCondition.qCond = new JObject();
                jsonConfig.qCalcCondition.qCond.qv = CalcCondition;
                jsonConfig.qCalcCond.qMsg = new JObject();
                jsonConfig.qCalcCond.qMsg.qv = DisplayedMessage;
                jsonConfig.customErrorMessage = new JObject();
                jsonConfig.customErrorMessage.calcCond = DisplayedMessage;
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
