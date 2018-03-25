using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class TableConfiguration : INotifyPropertyChanged
    {
        private ObservableCollection<ColumnConfiguration> columns = new ObservableCollection<ColumnConfiguration>();
        public ObservableCollection<ColumnConfiguration> Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Columns)));
            }
        }

        private ObservableCollection<object> presentationData = new ObservableCollection<object>();
        public ObservableCollection<object> PresentationData
        {
            get
            {
                return presentationData;
            }
            set
            {
                presentationData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PresentationData)));
            }
        }

        public string TableName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
