namespace daVinci.Controls
{
    #region Usings
    using NLog;
    using System;
    using System.Linq;
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
    using WPFLocalizeExtension.Engine;

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
                    PanelWidth = 300;
                    PanelHeight = 300;
                    if (parameter is string param)
                    {
                        if (param == "DIM")
                        {
                            valueSelection.ValueType = ValueTypeEnum.Dimension;
                            PopupContent = valueSelection;
                        }
                        if (param == "MEA")
                        {
                            valueSelection.ValueType = ValueTypeEnum.Measure;
                            PopupContent = valueSelection;
                        }
                        if (param == "EQU")
                        {
                            MeasureColumnData newone = new MeasureColumnData() { IsExpression = true };
                            newone.SortCriterias.ColumnOrderIndex = GetMaxColumnsOrder() + 1;
                            newone.SortCriterias.SortOrderIndex = GetMaxSortOrder() + 1;
                            Columns.Add(newone);
                            ShowPopup = false;
                        }

                    }
                }, (o) => true
                ),
                CategoryItems = new List<CategoryItem>()
                {
                    new CategoryItem()
                    {
                        CategoryName =(string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_common:Common_Dimension", null, LocalizeDictionary.Instance.Culture)),
                        CategoryParameter = "DIM"
                    },
                    new CategoryItem()
                    {
                        CategoryName = (string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_common:Common_Measure", null, LocalizeDictionary.Instance.Culture)),
                                    CategoryParameter = "MEA"
                                },
                                new CategoryItem()
                    {
                        CategoryName = "Formula",
                        CategoryParameter = "EQU"
                    }
                }
            };

            pivotCategorySelection = new CategorySelection()
            {
                SelectedCommand = new RelayCommand(
                (parameter) =>
                {
                    PanelWidth = 300;
                    PanelHeight = 300;
                    if (parameter is string param)
                    {
                        if (param == "Row")
                        {
                            valueSelection.ValueType = ValueTypeEnum.Dimension;
                            valueSelection.PivotType = PivotType.Row;
                            PopupContent = valueSelection;
                        }
                        if (param == "Col")
                        {
                            valueSelection.ValueType = ValueTypeEnum.Dimension;
                            valueSelection.PivotType = PivotType.Column;
                            PopupContent = valueSelection;
                        }
                        if (param == "Mea")
                        {
                            valueSelection.ValueType = ValueTypeEnum.Measure;
                            PopupContent = valueSelection;
                        }
                    }
                }, (o) => true
                ),
                CategoryItems = new List<CategoryItem>()
                {
                    new CategoryItem()
                    {
                        CategoryName =(string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_common:Common_Row", null, LocalizeDictionary.Instance.Culture)),
                        CategoryParameter = "Row"
                    },
                    new CategoryItem()
                    {
                        CategoryName = (string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_common:Common_Column", null, LocalizeDictionary.Instance.Culture)),
                        CategoryParameter = "Col"
                    },
                                new CategoryItem()
                    {
                        CategoryName = (string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_common:Common_Measure", null, LocalizeDictionary.Instance.Culture)),
                        CategoryParameter = "Mea"
                    }
                }
            };

            ICommand selectedAggregateCommand = new RelayCommand(
                (parameter) =>
                {
                    if (parameter is ValueItem item)
                    {
                        MeasureColumnData newone = new MeasureColumnData() { FieldDef = item.DisplayText, FieldLabel = item.DisplayText, IsExpression = true };
                        newone.SortCriterias.ColumnOrderIndex = GetMaxColumnsOrder() + 1;
                        newone.SortCriterias.SortOrderIndex = GetMaxSortOrder() + 1;
                        Columns.Add(newone);
                        ShowPopup = false;
                        valueSelection.SearchText = " ";
                        valueSelection.SearchText = "";
                    }
                }, (o) => true);

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
                                                BackCommand = new RelayCommand((o) => { PopupContent = GetCategorySelectionByColumnChooserMode(ColumnChooserMode); }, (o) => true),
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

                                                    DimensionColumnData newdim = new DimensionColumnData() { LibraryID = item.DimensionMeasure.LibID, DimensionMeasure = item.DimensionMeasure, PivotType = item.PivotType };
                                                    if (string.IsNullOrEmpty(item.DimensionMeasure.LibID))
                                                    {
                                                        newdim.IsExpression = true;
                                                        newdim.FieldDef = item.DimensionMeasure.Text;
                                                        newdim.FieldLabel = item.DimensionMeasure.Text;
                                                    }

                                                    switch (ColumnChooserMode)
                                                    {
                                                        case ColumnChooserMode.Combined:
                                                            newdim.SortCriterias.ColumnOrderIndex = GetMaxColumnsOrder() + 1;
                                                            newdim.SortCriterias.SortOrderIndex = GetMaxSortOrder() + 1;
                                                            break;
                                                        case ColumnChooserMode.Pivot:
                                                            switch (newdim.PivotType)
                                                            {
                                                                case PivotType.None:
                                                                    break;
                                                                case PivotType.Row:
                                                                    newdim.SortCriterias.ColumnOrderIndex = PivotGetMaxRowsOrder() + 1;
                                                                    newdim.SortCriterias.SortOrderIndex = PivotGetMaxRowsOrder() + 1;
                                                                    break;
                                                                case PivotType.Column:
                                                                    newdim.SortCriterias.ColumnOrderIndex = PivotGetMaxColumnsOrder() + 1;
                                                                    newdim.SortCriterias.SortOrderIndex = PivotGetMaxColumnsOrder() + 1;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }
                                                            break;
                                                        case ColumnChooserMode.Separeted:
                                                            break;
                                                        default:
                                                            break;
                                                    }


                                                    Columns.Add(newdim);
                                                    break;
                                                case ValueTypeEnum.Measure:
                                                    MeasureColumnData newmea = new MeasureColumnData() { LibraryID = item.DimensionMeasure.LibID, DimensionMeasure = item.DimensionMeasure };

                                                    switch (ColumnChooserMode)
                                                    {
                                                        case ColumnChooserMode.Combined:
                                                            newmea.SortCriterias.ColumnOrderIndex = GetMaxColumnsOrder() + 1;
                                                            newmea.SortCriterias.SortOrderIndex = GetMaxSortOrder() + 1;
                                                            break;
                                                        case ColumnChooserMode.Pivot:
                                                            newmea.SortCriterias.ColumnOrderIndex = PivotGetMaxMeasuresOrder() + 1;
                                                            newmea.SortCriterias.SortOrderIndex = PivotGetMaxMeasuresOrder() + 1;
                                                            break;
                                                        case ColumnChooserMode.Separeted:
                                                            break;
                                                        default:
                                                            break;
                                                    }

                                                    Columns.Add(newmea);
                                                    break;
                                                default:
                                                    break;
                                            }
                                            ShowPopup = false;
                                        }
                                    }
                                }
                                catch (Exception Ex)
                                {
                                    logger.Error(Ex);
                                }
                            }, (o) => true);

            valueSelection = new ValueSelection()
            {
                CancelCommand = new RelayCommand((o) =>
                  {
                      ShowPopup = false;
                  }),
                SelectedItemCommand = SelectedItemCommand

            };

            MultiColumnCommand = new RelayCommand((o) =>
                          {
                              var selectControl = new MultiValueSelection();
                              var selectcommand = new RelayCommand((vitem) =>
                    {
                        if (vitem is ValueItem item)
                        {
                            item.Selected = !item.Selected;
                        }
                    });
                              foreach (var item in dimensionMeasures)
                              {
                                  if (item.LibID == null)
                                  {
                                      selectControl.Fields.Add(new ValueItem()
                                      {
                                          DisplayText = item.Text,
                                          IsAggregate = false,
                                          ItemType = ValueTypeEnum.Dimension,
                                          IsField = item.LibID == null,
                                          ItemSelectedCommand = selectcommand,
                                          DimensionMeasure = item,
                                          Selected = false
                                      });
                                  }
                                  else
                                  {
                                      if ((item.Dimension ?? false))
                                      {
                                          selectControl.Dimensions.Add(new ValueItem()
                                          {
                                              DisplayText = item.Text,
                                              IsAggregate = false,
                                              ItemType = item.Dimension ?? false ? ValueTypeEnum.Dimension : ValueTypeEnum.Measure,
                                              IsField = item.LibID == null,
                                              ItemSelectedCommand = selectcommand,
                                              DimensionMeasure = item,
                                              Selected = false
                                          });
                                      }
                                      if ((item.Dimension ?? false) == false)
                                      {
                                          selectControl.Measures.Add(new ValueItem()
                                          {
                                              DisplayText = item.Text,
                                              IsAggregate = false,
                                              ItemType = item.Dimension ?? false ? ValueTypeEnum.Dimension : ValueTypeEnum.Measure,
                                              IsField = item.LibID == null,
                                              ItemSelectedCommand = selectcommand,
                                              DimensionMeasure = item,
                                              Selected = false

                                          });
                                      }
                                  }
                              }

                              if (LuiDialogWindow.Show("Choose multiple Columns", OwnerHwnd, selectControl, 400, 900, modal: true))
                              {
                                  List<ValueItem> selectedItems = new List<ValueItem>(selectControl.Dimensions);
                                  selectedItems.AddRange(selectControl.Measures);
                                  selectedItems.AddRange(selectControl.Fields);
                                  foreach (var item in selectedItems)
                                  {
                                      if (item.Selected)
                                      {
                                          if (SelectedItemCommand != null)
                                          {
                                              SelectedItemCommand.Execute(item);
                                          }
                                      }
                                  }
                              }
                          });


            PopupContent = GetCategorySelectionByColumnChooserMode(ColumnChooserMode);
            InitializeComponent();
            DataContext = this;
            PanelWidth = 120;
            PanelHeight = 170;
        }

        private int GetMaxSortOrder()
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

        private int GetMaxColumnsOrder()
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

        private int PivotGetMaxRowsOrder()
        {
            int maxindex = 0;
            foreach (var item in Columns)
            {
                if (item is DimensionColumnData dimdata)
                {
                    if (dimdata.PivotType == PivotType.Row)
                    {
                        if (item is IHasSortCriteria criteria)
                        {
                            maxindex = Math.Max(maxindex, criteria.SortCriterias.ColumnOrderIndex);
                        }
                    }
                }
            }
            return maxindex;
        }
        private int PivotGetMaxColumnsOrder()
        {
            int maxindex = 0;
            foreach (var item in Columns)
            {
                if (item is DimensionColumnData dimdata)
                {
                    if (dimdata.PivotType == PivotType.Column)
                    {
                        if (item is IHasSortCriteria criteria)
                        {
                            maxindex = Math.Max(maxindex, criteria.SortCriterias.ColumnOrderIndex);
                        }
                    }
                }
            }
            return maxindex;
        }

        private int PivotGetMaxMeasuresOrder()
        {
            int maxindex = 0;
            foreach (var item in Columns)
            {
                if (item is MeasureColumnData meadata)
                {
                    if (item is IHasSortCriteria criteria)
                    {
                        maxindex = Math.Max(maxindex, criteria.SortCriterias.ColumnOrderIndex);
                    }
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

        #region OwnerHwnd DP
        public int OwnerHwnd
        {
            get { return (int)this.GetValue(OwnerHwndProperty); }
            set { this.SetValue(OwnerHwndProperty, value); }
        }

        public static readonly DependencyProperty OwnerHwndProperty = DependencyProperty.Register(
         "OwnerHwnd", typeof(int), typeof(ColumnChooser), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ColumnChooserMode DP
        private ColumnChooserMode columnChooserMode = ColumnChooserMode.Combined;
        internal ColumnChooserMode ColumnChooserMode_Internal
        {
            get { return columnChooserMode; }
            set
            {
                if (columnChooserMode != value)
                {
                    columnChooserMode = value;
                    PopupContent = GetCategorySelectionByColumnChooserMode(ColumnChooserMode);
                    RaisePropertyChanged();
                }
            }
        }
        public ColumnChooserMode ColumnChooserMode
        {
            get { return (ColumnChooserMode)this.GetValue(ColumnChooserModeProperty); }
            set { this.SetValue(ColumnChooserModeProperty, value); }
        }

        public static readonly DependencyProperty ColumnChooserModeProperty = DependencyProperty.Register(
         "ColumnChooserMode", typeof(ColumnChooserMode), typeof(ColumnChooser), new FrameworkPropertyMetadata(ColumnChooserMode.Combined, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnColumnChooserModeChanged)));
        private static void OnColumnChooserModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is ColumnChooser obj)
                {
                    if (e.NewValue is ColumnChooserMode newvalue)
                    {
                        obj.ColumnChooserMode_Internal = newvalue;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
        #endregion

        #region PopupContent
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

        private bool showPopup;
        public bool ShowPopup
        {
            get { return showPopup; }
            set
            {
                if (showPopup != value)
                {
                    showPopup = value;
                    RaisePropertyChanged();
                    if (value == false)
                    {
                        PopupContent = GetCategorySelectionByColumnChooserMode(ColumnChooserMode);

                        PanelWidth = 120;
                        PanelHeight = 170;
                    }
                }
            }
        }
        private double panelHeight;
        public double PanelHeight
        {
            get { return panelHeight; }
            set
            {
                if (panelHeight != value)
                {
                    panelHeight = value;
                    RaisePropertyChanged();
                }
            }
        }
        private double panelWidth;
        public double PanelWidth
        {
            get { return panelWidth; }
            set
            {
                if (panelWidth != value)
                {
                    panelWidth = value;
                    RaisePropertyChanged();
                }
            }
        }

        private object GetCategorySelectionByColumnChooserMode(ColumnChooserMode mode)
        {
            object retval = null;
            switch (mode)
            {
                case ColumnChooserMode.Combined:
                    retval = categorySelection;
                    break;
                case ColumnChooserMode.Pivot:
                    retval = pivotCategorySelection;
                    break;
                case ColumnChooserMode.Separeted:
                    break;
                default:
                    break;
            }
            return retval;
        }

        private object categorySelection;
        private object pivotCategorySelection;
        private ValueSelection valueSelection;
        #endregion

        private ICommand multiColumnCommand;
        public ICommand MultiColumnCommand
        {
            get { return multiColumnCommand; }
            set
            {
                if (multiColumnCommand != value)
                {
                    multiColumnCommand = value;
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
    }

    public class PivotRowTypeColumnFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is DimensionColumnData dimdata)
            {
                return dimdata.PivotType == PivotType.Row;

            }
            return false;
        }
    }

    public class PivotColumnTypeColumnFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is DimensionColumnData dimdata)
            {
                return dimdata.PivotType == PivotType.Column;

            }
            return false;
        }
    }

    public class PivotMeasureColumnFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            return data is MeasureColumnData;
        }
    }
}
