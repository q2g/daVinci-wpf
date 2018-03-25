using daVinci.Resources;
using leonardo.Controls;
using leonardo.Resources;
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
    /// Interaktionslogik für ColumnChooser.xaml
    /// </summary>
    public partial class ColumnChooser : UserControl, INotifyPropertyChanged
    {
        public ColumnChooser()
        {
            categorySelection = new CategorySelection()
            {
                SelectedCommand=new RelayCommand((o)=>true,
                (parameter)=>
                {
                    dialog.PanelWidth = 300;
                    dialog.PanelHeight = 300;
                    if (parameter is string param)
                    {
                        if (param == "DIM")
                        {
                            valueSelection.ValueType = ValueTypeEnum.Dimension;                           
                        }
                        if (param == "COEF")
                        {
                            valueSelection.ValueType = ValueTypeEnum.Coefficient;                           
                        }                        
                        PopupContent = valueSelection;
                    }
                }
                )};

            ICommand selectedAggregateCommand = new RelayCommand((o) => true,
                (parameter) =>
                {
                    if (parameter is ValueItem item)
                    {
                        
                    }
                });

            valueSelection = new ValueSelection()
            {
                SelectedItemCommand = new RelayCommand((o) => true,
                (parameter) =>
                {
                    if (parameter is ValueItem item)
                    {
                        if (item.ValueType == ValueTypeEnum.Coefficient && item.IsField)
                        {
                            PopupContent = new AggregateFuncSelection()
                            {
                                BackCommand = new RelayCommand((o) => true, (o) => { PopupContent = valueSelection; }),
                                SelectedItemCommand = selectedAggregateCommand,
                                AggregateItems = new ObservableCollection<ValueItem>
                                {
                                    new ValueItem() { Parent = item, DisplayText = $"SUM([{item.DisplayText}])", IsAggregate = true, ItemSelectedCommand = selectedAggregateCommand },
                                    new ValueItem() { Parent = item, DisplayText = $"Count([{item.DisplayText}])", IsAggregate = true, ItemSelectedCommand = selectedAggregateCommand },
                                    new ValueItem() { Parent = item, DisplayText = $"AVG([{item.DisplayText}])", IsAggregate = true, ItemSelectedCommand = selectedAggregateCommand },
                                    new ValueItem() { Parent = item, DisplayText = $"MIN([{item.DisplayText}])", IsAggregate = true, ItemSelectedCommand = selectedAggregateCommand },
                                    new ValueItem() { Parent = item, DisplayText = $"MAX([{item.DisplayText}])", IsAggregate = true, ItemSelectedCommand = selectedAggregateCommand }
                                }
                            };
                        }
                    }
                })
            };
          

            
            PopupContent = categorySelection;
            InitializeComponent();
            DataContext = this;
        }

        #region Accordion
        public ObservableCollection<LuiAccordionItem> Columns { get; set; } = new ObservableCollection<LuiAccordionItem>();
        #endregion

        #region Popup Content
        private object popupContent;
        public object PopupContent
        {
            get { return popupContent; }
            set
            {
                if (popupContent != value)
                {
                    popupContent = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PopupContent)));
                }
            }
        }

        private void dialog_PopupClosed(object sender, EventArgs e)
        {
            PopupContent = categorySelection;
            dialog.PanelWidth = 120;
            dialog.PanelHeight = 120;
        }

        private object categorySelection;
        private ValueSelection valueSelection;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
