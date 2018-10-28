namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData;
    using leonardo.Resources;
    #endregion

    public class PivotMeasureColumnFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            return data is MeasureColumnData;
        }
    }
}
