using daVinci.ConfigData.TableConfigurations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    class ColumnOrderComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is IHasSortCriteria xappdata)
            {
                if (y is IHasSortCriteria yappdata)
                {
                    return xappdata.SortCriterias.ColumnOrderIndex.CompareTo(yappdata.SortCriterias.ColumnOrderIndex);
                }
            }
            return 0;
        }
    }

}