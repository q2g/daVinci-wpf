namespace daVinci.Controls
{
    #region Usings
    using NLog;
    using System;
    using System.Windows;
    using daVinci.Resources;
    using leonardo.Controls;
    using daVinci.ConfigData;
    using leonardo.Resources;
    using System.Windows.Input;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    #endregion

    using System.Runtime.CompilerServices;
    using daVinci.ConfigData.TableConfigurations;

    /// <summary>
    /// Interaktionslogik für ColumnChooser.xaml
    /// </summary>
    public partial class ColumnChooser : UserControl, INotifyPropertyChanged
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ColumnChooser()
        {
            categorySelection = new CategorySelection()
            {
                SelectedCommand = new RelayCommand(
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
                            MeasureColumnData newone = new MeasureColumnData() { IsExpression = true };
                            newone.SortCriterias.ColumnOrderIndex = getMaxColumnsOrder() + 1;
                            newone.SortCriterias.SortOrderIndex = getMaxSortOrder() + 1;
                            Columns.Add(newone);
                            togglebutton.IsChecked = false;
                        }

                    }
                }, (o) => true
                )
            };

            ICommand selectedAggregateCommand = new RelayCommand(
                (parameter) =>
                {
                    if (parameter is ValueItem item)
                    {
                        MeasureColumnData newone = new MeasureColumnData() { FieldDef = item.DisplayText, FieldLabel = item.DisplayText, IsExpression = true };
                        newone.SortCriterias.ColumnOrderIndex = getMaxColumnsOrder() + 1;
                        newone.SortCriterias.SortOrderIndex = getMaxSortOrder() + 1;
                        Columns.Add(newone);
                        togglebutton.IsChecked = false;
                        valueSelection.SearchText = " ";
                        valueSelection.SearchText = "";
                    }
                }, (o) => true);

            valueSelection = new ValueSelection()
            {
                SelectedItemCommand = new RelayCommand(
                (parameter) =>
                {
                    try
                    {
                        if (parameter is ValueItem item)
                        {
                            if (valueSelection.ValueType == ValueTypeEnum.Measure && item.IsField)
                            {
                                PopupContent = new AggregateFuncSelection()
                                {
                                    BackCommand = new RelayCommand((o) => { PopupContent = valueSelection; }, (o) => true),
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
                                switch (item.ItemType)
                                {
                                    case ValueTypeEnum.Dimension:
                                        DimensionColumnData newdim = new DimensionColumnData() { LibraryID = item.DimensionMeasure.LibID, DimensionMeasure = item.DimensionMeasure };
                                        if (string.IsNullOrEmpty(item.DimensionMeasure.LibID))
                                        {
                                            newdim.IsExpression = true;
                                            newdim.FieldDef = item.DimensionMeasure.Text;
                                            newdim.FieldLabel = item.DimensionMeasure.Text;
                                        }
                                        newdim.SortCriterias.ColumnOrderIndex = getMaxColumnsOrder() + 1;
                                        newdim.SortCriterias.SortOrderIndex = getMaxSortOrder() + 1;
                                        Columns.Add(newdim);
                                        break;
                                    case ValueTypeEnum.Measure:
                                        MeasureColumnData newmea = new MeasureColumnData() { LibraryID = item.DimensionMeasure.LibID, DimensionMeasure = item.DimensionMeasure };
                                        newmea.SortCriterias.ColumnOrderIndex = getMaxColumnsOrder() + 1;
                                        newmea.SortCriterias.SortOrderIndex = getMaxSortOrder() + 1;
                                        Columns.Add(newmea);
                                        break;
                                    default:
                                        break;
                                }
                                togglebutton.IsChecked = false;
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        logger.Error(Ex);
                    }
                }, (o) => true)
            };



            PopupContent = categorySelection;
            InitializeComponent();
            DataContext = this;
        }

        private int getMaxSortOrder()
        {
            int maxindex = 0;
            foreach (var item in Columns)
            {
                if (item is IHasSortCriteria criteria)
                {
                    maxindex = Math.Max(maxindex, criteria.SortCriterias.SortOrderIndex);
                }
            }
            return maxindex;
        }

        private int getMaxColumnsOrder()
        {
            int maxindex = 0;
            foreach (var item in Columns)
            {
                if (item is IHasSortCriteria criteria)
                {
                    maxindex = Math.Max(maxindex, criteria.SortCriterias.ColumnOrderIndex);
                }
            }
            return maxindex;
        }

        #region Columns - DP        
        public ObservableCollection<object> Columns
        {
            get { return (ObservableCollection<object>)this.GetValue(ColumnsProperty); }
            set { this.SetValue(ColumnsProperty, value); }
        }

        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
         "Columns", typeof(ObservableCollection<object>), typeof(ColumnChooser), new FrameworkPropertyMetadata(new ObservableCollection<object>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region DimensionMeasures DP
        public ObservableCollection<DimensionMeasure> dimensionMeasures;
        public ObservableCollection<DimensionMeasure> DimensionMeasures_Internal
        {
            get { return dimensionMeasures; }
            set
            {
                if (dimensionMeasures != value)
                {
                    dimensionMeasures = value;
                    var newlist = new List<ValueItem>();
                    foreach (var item in dimensionMeasures)
                    {
                        newlist.Add(new ValueItem()
                        {
                            DisplayText = item.Text,
                            IsAggregate = false,
                            ItemType = item.Dimension ?? false ? ValueTypeEnum.Dimension : ValueTypeEnum.Measure,
                            IsField = item.LibID == null,
                            DimensionMeasure = item

                        });
                    }
                    valueSelection.AllValueItems = newlist;

                }
            }
        }
        public ObservableCollection<DimensionMeasure> DimensionMeasures
        {
            get { return (ObservableCollection<DimensionMeasure>)this.GetValue(DimensionMeasuresProperty); }
            set { this.SetValue(DimensionMeasuresProperty, value); }
        }

        public static readonly DependencyProperty DimensionMeasuresProperty = DependencyProperty.Register(
         "DimensionMeasures", typeof(ObservableCollection<DimensionMeasure>), typeof(ColumnChooser), new FrameworkPropertyMetadata(new ObservableCollection<DimensionMeasure>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnDimensionMeasuresChanged)));


        private static void OnDimensionMeasuresChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is ColumnChooser obj)
                {
                    if (e.NewValue is ObservableCollection<DimensionMeasure> newvalue)
                    {
                        obj.DimensionMeasures_Internal = newvalue;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
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
                    RaisePropertyChanged();
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
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        private void control_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height > (togglebutton.Height + 18))
            {
                scrollviewer.Height = e.NewSize.Height - (togglebutton.Height + 18);
            }
        }
    }
}
