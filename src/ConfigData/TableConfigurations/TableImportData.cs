namespace daVinci.ConfigData.TableConfigurations
{
    #region Usings
    using NLog;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
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
        #endregion

    }
}
