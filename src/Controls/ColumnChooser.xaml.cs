using daVinci.ConfigData;
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
                SelectedCommand = new RelayCommand((o) => true,
                (parameter) =>
                {
                    dialog.PanelWidth = 300;
                    dialog.PanelHeight = 300;
                    if (parameter is string param)
                    {
                        if (param == "DIM")
                        {
                            valueSelection.ValueType = ValueTypeEnum.Dimension;
                            PopupContent = valueSelection;
                        }
                        if (param == "COEF")
                        {
                            valueSelection.ValueType = ValueTypeEnum.Measure;
                            PopupContent = valueSelection;
                        }
                        if (param == "EQU")
                        {
                            object newone = new ColumnConfiguration() { ColumnData = new MeasureColumnData(), ValueType = ValueTypeEnum.Measure };
                            Columns.Add(newone);
                            togglebutton.IsChecked = false;
                        }

                    }
                }
                )
            };

            ICommand selectedAggregateCommand = new RelayCommand((o) => true,
                (parameter) =>
                {
                    if (parameter is ValueItem item)
                    {
                        var newone = new ColumnConfiguration() { ColumnData = new MeasureColumnData() { FieldDef = item.DisplayText, FieldLabel = item.DisplayText }, ValueType = ValueTypeEnum.Measure };
                        Columns.Add(newone);
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
                        if (item.ValueType == ValueTypeEnum.Measure && item.IsField)
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
                            ColumnConfiguration newone = null;
                            switch (item.ValueType)
                            {
                                case ValueTypeEnum.Dimension:
                                    newone = new ColumnConfiguration() { ColumnData = new DimensionColumnData() { LibraryID = item.DisplayText }, ValueType = ValueTypeEnum.Dimension };
                                    Columns.Add(newone);
                                    break;
                                case ValueTypeEnum.Measure:
                                    newone = new ColumnConfiguration() { ColumnData = new MeasureColumnData() { LibraryID = item.DisplayText }, ValueType = ValueTypeEnum.Measure };
                                    Columns.Add(newone);
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
        //private ObservableCollection<LuiAccordionItem> columns=new ObservableCollection<LuiAccordionItem>();
        //public ObservableCollection<LuiAccordionItem> Columns
        //{
        //    get { return columns; }
        //    set
        //    {
        //        if (columns != value)
        //        {
        //            columns = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Columns)));
        //        }

        //    }
        //}

        #region Columns - DP        
        public ObservableCollection<object> Columns
        {
            get { return (ObservableCollection<object>)this.GetValue(ColumnsProperty); }
            set { this.SetValue(ColumnsProperty, value); }
        }

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
         "Columns", typeof(ObservableCollection<object>), typeof(ColumnChooser), new FrameworkPropertyMetadata(new ObservableCollection<object>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnColumnsChanged)));


        private static void OnColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ColumnChooser obj)
            {
                if (e.NewValue is ObservableCollection<object> newvalue)
                {
                    var s = newvalue;
                }
            }
        }
        #endregion
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
            dialog.PanelHeight = 170;
        }

        private object categorySelection;
        private ValueSelection valueSelection;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void control_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height > (togglebutton.Height + 18))
            {
                scrollviewer.Height = e.NewSize.Height - (togglebutton.Height + 18);
            }
        }
    }
}
