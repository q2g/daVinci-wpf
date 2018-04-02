using daVinci.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class ColumnConfiguration : INotifyPropertyChanged
    {
        public ValueTypeEnum ValueType { get; set; }
        public TableConfiguration Parent { get; set; }

        private int columnOrderIndex;
        public int ColumnOrderIndex
        {
            get
            {
                return columnOrderIndex;
            }
            set
            {
                columnOrderIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColumnOrderIndex)));
                //Parent?.Columns?.RaiseCollectionChanged();

            }
        }


        private int sortOrderIndex;
        public int SortOrderIndex
        {
            get
            {
                return sortOrderIndex;
            }
            set
            {
                sortOrderIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SortOrderIndex)));
                //Parent?.Columns?.RaiseCollectionChanged();


            }
        }
        public object ColumnData { get; set; }
        public SortConfiguration SortConfiguration { get; set; }

        public ColumnConfiguration()
        {
            SortConfiguration = new SortConfiguration();


        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class ColumnOrderIndexSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            ColumnConfiguration custX = x as ColumnConfiguration;
            ColumnConfiguration custY = y as ColumnConfiguration;
            return custX.ColumnOrderIndex.CompareTo(custY.ColumnOrderIndex);
        }
    }

    public class SortOrderIndexSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            ColumnConfiguration custX = x as ColumnConfiguration;
            ColumnConfiguration custY = y as ColumnConfiguration;
            return custX.SortOrderIndex.CompareTo(custY.SortOrderIndex);
        }
    }


}
