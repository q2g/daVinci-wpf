namespace daVinci.ConfigData.Reporting
{
    using leonardo.Resources;
    #region Usings
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class KeyValuePair : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & Variables
        private string key;
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                if (key != value)
                {
                    key = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string valueString;
        public string Value
        {
            get
            {
                return valueString;
            }
            set
            {
                if (valueString != value)
                {
                    valueString = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

    }

    public class KeyValuePairFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is KeyValuePair kvdata)
            {
                return ((kvdata.Key + "").ToLower().Contains(searchString.ToLower())
                    || (kvdata.Value + "").ToLower().Contains(searchString.ToLower()));
            }
            return false;
        }
    }
}
