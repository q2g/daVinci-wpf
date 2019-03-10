namespace daVinci.ConfigData.TableConfigurations
{
    #region Usings
    using System.Collections;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using leonardo.Resources;
    using NLog;
    #endregion

    public class TableImportData : INotifyPropertyChanged
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

        #region Properties
        private string tableID;
        public string TableID
        {
            get
            {
                return tableID;
            }
            set
            {
                if (tableID != value)
                {
                    tableID = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string tableName;
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                if (tableName != value)
                {
                    tableName = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ColumnChooserMode TableMode { get; set; }
        #endregion
    }

    public class TableTypeFilter : ICollectionViewFilter
    {
        public ColumnChooserMode FilterFor { get; set; }
        public bool Filter(object data, string searchString)
        {
            if (data is TableImportData impdata)
            {
                return impdata.TableMode == FilterFor;
            }
            return false;
        }
    }

    public class TableNameComparer : IComparer
    {
        public string FirstItemID { get; set; }
        public int Compare(object x, object y)
        {
            if (x is TableImportData impdatax)
            {
                if (y is TableImportData impdatay)
                {
                    if (impdatax.TableID == FirstItemID)
                        return -1;

                    if (impdatay.TableID == FirstItemID)
                        return 1;

                    return impdatax.TableName.CompareTo(impdatay.TableName);
                }
            }
            return 0;
        }
    }
}
