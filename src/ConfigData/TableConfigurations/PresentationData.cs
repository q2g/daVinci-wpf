using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class PresentationData : INotifyPropertyChanged
    {
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



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
