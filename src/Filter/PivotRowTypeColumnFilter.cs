namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData;
    using leonardo.Resources;
    #endregion

    public class PivotRowTypeColumnFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is DimensionColumnData dimdata)
            {
                return dimdata.PivotType == PivotType.Row;
            }
            return false;
        }
    }
}
