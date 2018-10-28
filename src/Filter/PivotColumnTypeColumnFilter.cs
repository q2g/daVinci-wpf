namespace daVinci.Controls
{
    #region Usins
    using daVinci.ConfigData;
    using leonardo.Resources;
    #endregion

    public class PivotColumnTypeColumnFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is DimensionColumnData dimdata)
            {
                return dimdata.PivotType == PivotType.Column;
            }
            return false;
        }
    }
}
