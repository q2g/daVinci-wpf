namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData;
    using leonardo.Resources;
    #endregion

    public class PivotDimensionColumnFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            return data is DimensionColumnData;
        }
    }
}
