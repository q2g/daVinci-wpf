using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class DimensionColumnData : INotifyPropertyChanged
    {
        public string DimensionName { get; set; }

        public DimensionColumnData()
        {
            if (PropertyChanged != null) {/* Make the Compiler Happy */ }
        }

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

        private bool beschraenkungIndex;
        public bool BeschraenkungIndex
        {
            get
            {
                return beschraenkungIndex;
            }
            set
            {
                if (beschraenkungIndex != value)
                {
                    beschraenkungIndex = value;
                    RaisePropertyChanged();
                }
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
