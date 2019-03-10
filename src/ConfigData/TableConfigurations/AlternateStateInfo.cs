namespace daVinci.ConfigData
{
    #region Usings
    using System.Collections;
    using leonardo.Resources;
    #endregion

    public class AlternateStateInfo
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        #region ctor
        public AlternateStateInfo()
        { }
        public AlternateStateInfo(AlternateStateInfo other)
        {
            Name = other.Name;
            DisplayName = other.DisplayName;
        }
        #endregion
    }

    public class AlternateStateInfoFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is AlternateStateInfo sadata)
            {
                return (sadata.Name + "").ToLower().Contains(searchString.ToLower())
                    || (sadata.DisplayName + "").ToLower().Contains(searchString.ToLower());
            }
            return false;
        }
    }

    public class AlternateStateInfoNameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is AlternateStateInfo xdata)
            {
                if (y is AlternateStateInfo ydata)
                {
                    return xdata.Name.CompareTo(ydata.Name);
                }
            }
            return 0;
        }
    }
}
