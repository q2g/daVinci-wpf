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
                        Columns.Add(new LuiAccordionItem() { Header = item.DisplayText, Content = new CoefficientColumnDataView(), IsExpanded = true });
                        togglebutton.IsChecked = false;
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
                        else
                        {
                            switch (item.ValueType)
                            {
                                case ValueTypeEnum.Dimension:
                                    Columns.Add(new LuiAccordionItem() { Header = item.DisplayText, Content = new DimensionColumnDataView(), IsExpanded=true });
                                    break;
                                case ValueTypeEnum.Coefficient:
                                    Columns.Add(new LuiAccordionItem() { Header = item.DisplayText, Content = new CoefficientColumnDataView(), IsExpanded = true });
                                    break;
                                default:
                                    break;
                            }
                            togglebutton.IsChecked = false;
                        }
                    }
                })
            };
          

            
            PopupContent = categorySelection;
            InitializeComponent();
            DataContext = this;
        }

        #region Accordion
        private ObservableCollection<LuiAccordionItem> columns=new ObservableCollection<LuiAccordionItem>();
        public ObservableCollection<LuiAccordionItem> Columns
        {
            get { return columns; }
            set
            {
                if (columns != value)
                {
                    columns = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Columns)));
                }

            }
        }

        //#region Columns - DP        
        //public ObservableCollection<LuiAccordionItem> Columns
        //{
        //    get { return (ObservableCollection<LuiAccordionItem>)this.GetValue(ColumnsProperty); }
        //    set { this.SetValue(ColumnsProperty, value); }
        //}

        //public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
        // "Columns", typeof(ObservableCollection<LuiAccordionItem>), typeof(DimensionColumnDataView), new FrameworkPropertyMetadata(new ObservableCollection<LuiAccordionItem>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        //#endregion
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
