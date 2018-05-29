namespace daVinci.ConfigData.TableConfigurations
{
    #region Usings
    using NLog;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class TableImportConfiguration : INotifyPropertyChanged
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

        private ObservableCollection<TableImportData> tables = new ObservableCollection<TableImportData>();
        public ObservableCollection<TableImportData> Tables
        {
            get
            {
                return tables;
            }
            set
            {
                tables = value;
                RaisePropertyChanged();
            }
        }

        private TableImportData selectedTable;
        public TableImportData SelectedTable
        {
            get
            {
                return selectedTable;
            }
            set
            {
                selectedTable = value;
                RaisePropertyChanged();
            }
        }
    }
}
