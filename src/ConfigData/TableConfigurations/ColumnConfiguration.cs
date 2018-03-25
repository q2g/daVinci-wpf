using daVinci.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci_wpf.ConfigData
{
    public class ColumnConfiguration
    {
        public ValueTypeEnum ValueType { get; set; }
        public int ColumnOrderIndex { get; set; }
        public int SortOrderIndex { get; set; }
        public object ColumnData { get; set; }

    }
}
