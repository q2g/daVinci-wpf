﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class CoefficientColumnData : INotifyPropertyChanged
    {
        public string CoefficientName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
