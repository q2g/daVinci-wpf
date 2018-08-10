namespace daVinci.ConfigData.TableConfigurations
{
    #region Usings
    using leonardo.Resources;
    using daVinci.ConfigData.TableConfigurations; 
    #endregion

    public class ColumnOrderIndexProvider : IIndexProvider
    {
        public int GetIndex(object objectWithIndexProperty)
        {
            if (objectWithIndexProperty is IHasSortCriteria sortcriteria)
            {
                return sortcriteria.SortCriterias.ColumnOrderIndex;
            }
            return -2;
        }

        public void SetIndex(object objectWithIndexProperty, int indexValue)
        {
            if (objectWithIndexProperty is IHasSortCriteria sortcriteria)
            {
                sortcriteria.SortCriterias.ColumnOrderIndex = indexValue;
            }
        }
    }
}
