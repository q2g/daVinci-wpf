namespace daVinci.Controls
{
    #region Usings
    using NLog;
    using System;
    using System.Windows;
    using daVinci.Resources;
    using leonardo.Resources;
    using System.Windows.Input;
    using System.ComponentModel;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using WPFLocalizeExtension.Engine;
    using System.Runtime.CompilerServices;
    using System.Collections.ObjectModel;
    using daVinci.ConfigData;
    #endregion

    /// <summary>
    /// Interaktionslogik für ValueSelection.xaml
    /// </summary>
    public partial class ValueSelection : UserControl, INotifyPropertyChanged
    {
        private List<ValueItem> allValueItems;
        public List<ValueItem> AllValueItems
        {
            get { return allValueItems; }
            set
            {
                if (allValueItems != value)
                {
                    allValueItems = value;
                    SetSelectedCommand();
                    SetValueTypeContextofFields();
                    RaisePropertyChanged();
                    SetPivotType();
                }
            }
        }
        public ValueSelection()
        {
            AllValueItems = new List<ValueItem>();
            SetLabels();
            ItemFilter = new ValueItemFilter();
            FieldItemFilter = new ValueItemFilter() { OnlyFields = true };

            AcceptCommand = new RelayCommand((o) =>
            {
                if (collectionView.ProcessedCollection.Count == 1 && fieldCollectionView.ProcessedCollection.Count == 0)
                {
                    if (selectedItemCommand != null)
                    {
                        selectedItemCommand.Execute(collectionView.ProcessedCollection[0]);
                        SearchText = "";
                        scrollviewer.ScrollToTop();
                    }
                }
                if (collectionView.ProcessedCollection.Count == 0 && fieldCollectionView.ProcessedCollection.Count == 1)
                {
                    if (selectedItemCommand != null)
                    {
                        selectedItemCommand.Execute(fieldCollectionView.ProcessedCollection[0]);
                        SearchText = "";
                        scrollviewer.ScrollToTop();
                    }
                }
                if (collectionView.ProcessedCollection.Count == 1 && fieldCollectionView.ProcessedCollection.Count == 1 && ValueType == ValueTypeEnum.Dimension)
                {
                    if (selectedItemCommand != null)
                    {
                        selectedItemCommand.Execute(collectionView.ProcessedCollection[0]);
                        SearchText = "";
                        scrollviewer.ScrollToTop();
                    }
                }
            });
            InitializeComponent();
            DataContext = this;
        }

        #region Properties      
        public string CategoryDisplayText { get; set; }
        public string FieldDisplayText { get; set; }
        public ValueItemFilter ItemFilter { get; set; }
        public ValueItemFilter FieldItemFilter { get; set; }
        private ValueTypeEnum valueType;
        public ValueTypeEnum ValueType
        {
            get { return valueType; }
            set
            {
                if (valueType != value)
                {
                    valueType = value;
                    SetLabels();
                    ItemFilter.ValType = value;
                    FieldItemFilter.ValType = value;
                    SetValueTypeContextofFields();
                    SearchText = "";
                    scrollviewer.ScrollToTop();
                    RaisePropertyChanged(nameof(AllValueItems));
                    //Force an list-rebuild, which executes the reevaluation of the ItemContainerSelector of valueSelection 
                    SearchText = " ";
                    SearchText = "";
                }
            }
        }

        private PivotType pivotType = PivotType.None;
        public PivotType PivotType
        {
            get { return pivotType; }
            set
            {
                if (pivotType != value)
                {
                    pivotType = value;
                    SetPivotType();
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
                    SetSelectedCommand();
                    RaisePropertyChanged();
                }
            }
        }
        public ICommand AcceptCommand { get; set; }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get { return cancelCommand; }
            set
            {
                if (cancelCommand != value)
                {
                    cancelCommand = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region Search
        private string searchText;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    RaisePropertyChanged();

                }
            }
        }
        #endregion

        #region Functions
        private void SetSelectedCommand()
        {
            if (selectedItemCommand != null && allValueItems != null)
            {
                var newselectedCommand = new RelayCommand((o) =>
                {
                    selectedItemCommand.Execute(o);
                    if (o is ValueItem vitem)
                    {
                        if (!(vitem.IsField && vitem.ItemContext == ValueTypeEnum.Measure) || vitem.IsAggregate)
                        {
                            SearchText = "";
                            scrollviewer.ScrollToTop();
                        }
                    }
                }, (o) => true);
                AllValueItems.ForEach(item => item.ItemSelectedCommand = newselectedCommand);

            }
        }

        /// <summary>
        /// Set ValueTypeContext of Fields, so the Styleselector has access to the ValueTypeContext
        /// </summary>
        private void SetValueTypeContextofFields()
        {
            if (allValueItems != null)
            {
                foreach (var item in allValueItems)
                {
                    if (item.IsField)
                        item.ItemContext = valueType;
                }
            }
        }
        private void SetLabels()
        {
            switch (valueType)
            {
                case ValueTypeEnum.Dimension:
                    CategoryDisplayText = (string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_common:Common_Dimensions", null, LocalizeDictionary.Instance.Culture));
                    FieldDisplayText = (string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_common:Common_Fields", null, LocalizeDictionary.Instance.Culture));
                    break;
                case ValueTypeEnum.Measure:
                    CategoryDisplayText = (string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_common:Common_Measures", null, LocalizeDictionary.Instance.Culture));
                    FieldDisplayText = (string)(LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_client:Visualization_Requirements_FromField", null, LocalizeDictionary.Instance.Culture));
                    break;
                default:
                    break;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoryDisplayText)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FieldDisplayText)));
        }
        private void SetPivotType()
        {
            if (allValueItems != null)
            {
                foreach (var item in allValueItems)
                {
                    item.PivotType = pivotType;
                }
            }
        }
        #endregion
    }

    public class ValueItem : INotifyPropertyChanged
    {
        #region LoggerInit
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
        #region properties
        public string DisplayText { get; set; }
        public LuiIconsEnum Icon { get; set; } = LuiIconsEnum.lui_icon_none;
        public ValueTypeEnum ItemType { get; set; }
        public bool IsAggregate { get; set; }
        public bool IsField { get; set; }
        public ValueItem Parent { get; set; }
        public ICommand ItemSelectedCommand { get; set; }
        public DimensionMeasure DimensionMeasure { get; set; }
        public ValueTypeEnum ItemContext { get; set; }
        public PivotType PivotType { get; set; }
        private bool selected;
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }

    public class ValueItemFilter : ICollectionViewFilter
    {
        public ValueTypeEnum ValType { get; set; }
        public bool OnlyFields { get; set; }
        public bool Filter(object data, string searchString)
        {
            if (data is ValueItem item)
            {
                if (OnlyFields)
                    return item.DisplayText.ToLower().Contains(searchString?.ToLower() ?? "") && item.IsField == true;
                else
                    return item.DisplayText.ToLower().Contains(searchString?.ToLower() ?? "") && item.IsField == false && item.ItemType == ValType;

            }
            return false;
        }
    }

    public class ValueTypeTemplateSelector : DataTemplateSelector
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DataTemplate MeasureTemplate { get; set; }
        public DataTemplate MeasureFieldTemplate { get; set; }
        public DataTemplate DimensionTemplate { get; set; }
        public DataTemplate DimensionFieldTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item,
                   DependencyObject container)
        {
            try
            {
                if (item is ValueItem vitem)
                {
                    if (vitem.IsField)
                    {
                        if (vitem.ItemContext == ValueTypeEnum.Measure)
                        {
                            return MeasureFieldTemplate;
                        }
                        if (vitem.ItemContext == ValueTypeEnum.Dimension)
                        {
                            return DimensionFieldTemplate;
                        }
                    }
                    else
                    {
                        if (vitem.ItemType == ValueTypeEnum.Measure)
                        {
                            return MeasureTemplate;
                        }
                        if (vitem.ItemType == ValueTypeEnum.Dimension)
                        {
                            return DimensionTemplate; ;
                        }
                    }



                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }

            return new DataTemplate();
        }
    }
}
