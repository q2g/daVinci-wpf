using daVinci_wpf.Resources;
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

        public TableConfiguration()
        {
            Columns = new ObservableCollection<ColumnConfiguration>();
            Columns.CollectionChanged += Columns_CollectionChanged;
        }

        private void Columns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    if (item is ColumnConfiguration configitem)
                    {
                        SortColumns.Add(configitem);
                    }
                }
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    if (item is ColumnConfiguration configitem)
                    {
                        SortColumns.Remove(configitem);
                    }
                }
            }
        }

        private ObservableCollection<ColumnConfiguration> sortColumns = new ObservableCollection<ColumnConfiguration>();
        public ObservableCollection<ColumnConfiguration> SortColumns
        {
            get
            {
                return sortColumns;
            }
            set
            {
                sortColumns = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SortColumns)));
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

        private ObservableCollection<object> addOnData = new ObservableCollection<object>();
        public ObservableCollection<object> AddOnData
        {
            get
            {
                return addOnData;
            }
            set
            {
                addOnData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AddOnData)));
            }
        }

        public string TableName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
