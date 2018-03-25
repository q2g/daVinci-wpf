using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci_wpf.ConfigData
{
    public class TableConfiguration
    {
        public ObservableCollection<ColumnConfiguration> Columns { get; set; } = new ObservableCollection<ColumnConfiguration>();

        public string TableName { get; set; }
    }
}
