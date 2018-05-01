using daVinci.ConfigData.TableConfigurations;
using leonardo.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci_wpf.ConfigData.TableConfigurations
{
    public class SortOrderIndexProvider : IIndexProvider
    {
        public int GetIndex(object objectWithIndexProperty)
        {
            if (objectWithIndexProperty is IHasSortCriteria sortcriteria)
            {
                return sortcriteria.SortCriterias.SortOrderIndex;
            }
            return -2;
        }

        public void SetIndex(object objectWithIndexProperty, int indexValue)
        {
            if (objectWithIndexProperty is IHasSortCriteria sortcriteria)
            {
                sortcriteria.SortCriterias.SortOrderIndex = indexValue;
            }
        }
    }
}
