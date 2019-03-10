namespace daVinci.ConfigData.FieldConfigurations
{
    #region Usings
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using leonardo.Resources;
    using NLog;
    #endregion

    public class FieldsConfiguration : INotifyPropertyChanged
    {
        #region LoggerInit
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        private ObservableCollection<DimensionMeasure> dimensionMeasures = new ObservableCollection<DimensionMeasure>();
        public ObservableCollection<DimensionMeasure> DimensionMeasures
        {
            get
            {
                return dimensionMeasures;
            }
            set
            {
                dimensionMeasures = value;
                RaisePropertyChanged();
            }
        }
    }

    public class IsFieldFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is DimensionMeasure dimensionMeasure)
            {
                return string.IsNullOrEmpty(dimensionMeasure.LibID) && dimensionMeasure.Text.ToLower().Contains(searchString.ToLower());
            }
            return false;
        }
    }

    public class FieldComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is DimensionMeasure xfield)
            {
                if (y is DimensionMeasure yfield)
                {
                    return xfield.Text.CompareTo(yfield.Text);
                }
            }
            return 0;
        }
    }
}
