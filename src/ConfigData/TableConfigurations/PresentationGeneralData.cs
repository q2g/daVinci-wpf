using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class PresentationGeneralData : INotifyPropertyChanged
    {
        public PresentationGeneralData()
        {
            if (PropertyChanged != null) {/* Make the Compiler Happy */ }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
