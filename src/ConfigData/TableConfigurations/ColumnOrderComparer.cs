namespace daVinci.ConfigData
{
    #region Usings
    using System.Collections;
    using daVinci.ConfigData.TableConfigurations; 
    #endregion

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