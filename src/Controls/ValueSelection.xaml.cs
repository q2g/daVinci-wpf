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
                }
            }
        }
        public ValueSelection()
        {
            AllValueItems = new List<ValueItem>();
            SetLabels();
            ItemFilter = new ValueItemFilter();
            FieldItemFilter = new ValueItemFilter() { OnlyFields = true };
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

        #endregion
    }

    public class ValueItem
    {
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
