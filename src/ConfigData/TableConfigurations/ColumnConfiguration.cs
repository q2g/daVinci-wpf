using daVinci.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class ColumnConfiguration : INotifyPropertyChanged
    {
        public ValueTypeEnum ValueType { get; set; }
        public int ColumnOrderIndex { get; set; }
        public int SortOrderIndex { get; set; }
        public object ColumnData { get; set; }
        public SortConfiguration SortConfiguration { get; set; }

        public ColumnConfiguration()
        {
            SortConfiguration = new SortConfiguration();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
