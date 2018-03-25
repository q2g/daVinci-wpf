using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    /// Interaktionslogik für AggregateFuncSelection.xaml
    /// </summary>
    public partial class AggregateFuncSelection : UserControl,INotifyPropertyChanged
    {
        #region Member
        private ObservableCollection<ValueItem> aggregateItems;
        #endregion
        #region ctor
        public AggregateFuncSelection()
        {
            InitializeComponent();
            DataContext = this;
        }
        #endregion
        #region Properties
        public ObservableCollection<ValueItem> AggregateItems
        {
            get { return aggregateItems; }
            set
            {
                aggregateItems = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AggregateItems)));
            }
        }
        private ICommand backCommand;
        public ICommand BackCommand
        {
            get { return backCommand; }
            set
            {
                if(backCommand!=value)
                {
                    backCommand = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackCommand)));
                }
            }
        }
        private ICommand selectedItemCommand;
        public ICommand SelectedItemCommand
        {
            get { return selectedItemCommand; }
            set
            {
                if (selectedItemCommand != value)
                {
                    selectedItemCommand = value;
                    
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItemCommand)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
