using daVinci_wpf.ConfigData.TableConfigurations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    class SortOrderComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is IHasSortCriteria xappdata)
            {
                if (y is IHasSortCriteria yappdata)
                {
                    return xappdata.SortCriterias.SortOrderIndex.CompareTo(yappdata.SortCriterias.SortOrderIndex);
                }
            }
            return 0;
        }
    }
}
