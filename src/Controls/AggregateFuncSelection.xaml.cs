namespace daVinci.Controls
{
    #region Usings
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für AggregateFuncSelection.xaml
    /// </summary>
    public partial class AggregateFuncSelection : UserControl, INotifyPropertyChanged
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
                RaisePropertyChanged();
            }
        }
        private ICommand backCommand;
        public ICommand BackCommand
        {
            get { return backCommand; }
            set
            {
                if (backCommand != value)
                {
                    backCommand = value;
                    RaisePropertyChanged();
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
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
    }
}
