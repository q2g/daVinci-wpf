using daVinci_wpf.Resources;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{

    public class TableConfiguration : INotifyPropertyChanged
    {
        private ObservableCollection<object> columns = new ObservableCollection<object>();
        public ObservableCollection<object> Columns
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
            Columns = new ObservableCollection<object>();
            Columns.CollectionChanged += Columns_CollectionChanged;
        }

        private void Columns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {

                    SortColumns.Add(item);

                }
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {

                    SortColumns.Remove(item);

                }
            }
        }

        private ObservableCollection<object> sortColumns = new ObservableCollection<object>();
        public ObservableCollection<object> SortColumns
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

        public void ReadFromJSON(string JSONstring)
        {
            dynamic jsonConfig = JObject.Parse(JSONstring);
            foreach (var dimension in jsonConfig.qHyperCubeDef.qDimensions)
            {
                var newone = new DimensionColumnData();
                newone.ReadFromJSON(dimension.ToString());
                Columns.Add(newone);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }


    }
}
