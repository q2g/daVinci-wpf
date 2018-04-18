using daVinci.ConfigData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData.TableConfigurations
{
    public interface IHasSortCriteria
    {
        SortCriteria SortCriterias { get; set; }
    }
}
