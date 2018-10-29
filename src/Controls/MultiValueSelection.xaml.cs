using leonardo.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace daVinci.Controls
{
    /// <summary>
    /// Interaktionslogik für MultiValueSelection.xaml
    /// </summary>
    public partial class MultiValueSelection : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public MultiValueSelection()
        {
            valueItemfilter = new ItemFilter();
            InitializeComponent();
        }

        private List<ValueItem> dimensions = new List<ValueItem>();
        public List<ValueItem> Dimensions
        {
            get { return dimensions; }
            set
            {
                if (dimensions != value)
                {
                    dimensions = value;
                    RaisePropertyChanged();
                }
            }
        }

        private List<ValueItem> measures = new List<ValueItem>();
        public List<ValueItem> Measures
        {
            get { return measures; }
            set
            {
                if (measures != value)
                {
                    measures = value;
                    RaisePropertyChanged();
                }
            }
        }

        private List<ValueItem> fields = new List<ValueItem>();
        public List<ValueItem> Fields
        {
            get { return fields; }
            set
            {
                if (fields != value)
                {
                    fields = value;
                    RaisePropertyChanged();
                }
            }
        }

        private ItemFilter valueItemfilter;
        public ItemFilter Filter
        {
            get { return valueItemfilter; }
            set
            {
                if (valueItemfilter != value)
                {
                    valueItemfilter = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string searchtext;
        public string Searchtext
        {
            get { return searchtext; }
            set
            {
                if (searchtext != value)
                {
                    searchtext = value;
                    RaisePropertyChanged();
                }
            }
        }
    }

    public class ItemFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is ValueItem item)
            {
                return item.DisplayText.ToLower().Contains(searchString?.ToLower() ?? "");
            }
            return false;
        }
    }
}
