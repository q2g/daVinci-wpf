namespace daVinci.ConfigData
{
    #region Usings
    using System.Collections;
    using daVinci.ConfigData.TableConfigurations; 
    #endregion

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
