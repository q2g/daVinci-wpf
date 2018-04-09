using daVinci.Resources;
using leonardo.Resources;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Resources;
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
using WPFLocalizeExtension.Engine;

namespace daVinci.Controls
{
    /// <summary>
    /// Interaktionslogik für ValueSelection.xaml
    /// </summary>
    public partial class ValueSelection : UserControl, INotifyPropertyChanged
    {
        private List<ValueItem> AllValueItems = new List<ValueItem>()
        {
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, DisplayText="Account" },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, DisplayText="Account Drill", Icon=LUIiconsEnum.lui_icon_select_alternative },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, DisplayText="Account Group" },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, DisplayText="ARAge" },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, DisplayText="Customer" },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, DisplayText="Customer Number" },

            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, IsField=true, DisplayText="Account" },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, IsField=true, DisplayText="Account Desc" },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, IsField=true, DisplayText="AccountGroup", Icon=LUIiconsEnum.lui_icon_calendar },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, IsField=true, DisplayText="AccountGroupDesc" },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, IsField=true, DisplayText="Address Number" },
            new ValueItem(){ ValueType=ValueTypeEnum.Dimension, IsField=true, DisplayText="AR1-30" },

            new ValueItem(){ ValueType=ValueTypeEnum.Measure, DisplayText="# of Cust AR60+" },
            new ValueItem(){ ValueType=ValueTypeEnum.Measure, DisplayText="# of Customers" },
            new ValueItem(){ ValueType=ValueTypeEnum.Measure, DisplayText="# of Products" },
            new ValueItem(){ ValueType=ValueTypeEnum.Measure, DisplayText="% of Items" },
            new ValueItem(){ ValueType=ValueTypeEnum.Measure, DisplayText="Amound Overdue" },
            new ValueItem(){ ValueType=ValueTypeEnum.Measure, DisplayText="AR % Overdue" },

            new ValueItem(){  ValueType=ValueTypeEnum.Measure, IsField=true, DisplayText="Account" },
            new ValueItem(){  ValueType=ValueTypeEnum.Measure, IsField=true, DisplayText="Account Desc" },
            new ValueItem(){  ValueType=ValueTypeEnum.Measure, IsField=true, DisplayText="AccountGroup" },
            new ValueItem(){  ValueType=ValueTypeEnum.Measure, IsField=true, DisplayText="AccountGroupDesc" },
            new ValueItem(){  ValueType=ValueTypeEnum.Measure, IsField=true, DisplayText="Address Number", Icon=LUIiconsEnum.lui_icon_calendar },
            new ValueItem(){  ValueType=ValueTypeEnum.Measure, IsField=true, DisplayText="AR1-30" }
        };
        public ValueSelection()
        {
            SetLabels();
            CalculateDisplayedLists();
            InitializeComponent();
            DataContext = this;
        }

        #region Properties      
        public string CategoryDisplayText { get; set; }
        public string FieldDisplayText { get; set; }
        public ObservableCollection<ValueItem> DisplayedFieldItems { get; set; } = new ObservableCollection<ValueItem>();
        public ObservableCollection<ValueItem> DisplayedValueItems { get; set; } = new ObservableCollection<ValueItem>();
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
                    CalculateDisplayedLists();
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
                    AllValueItems.ForEach(item => item.ItemSelectedCommand = value);
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
                    CalculateDisplayedLists();

                }
            }
        }
        #endregion

        #region Functions
        private void SetLabels()
        {
            switch (valueType)
            {
                case ValueTypeEnum.Dimension:
                    CategoryDisplayText = (string)(LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_common:Common_Dimensions", null, LocalizeDictionary.Instance.Culture));
                    FieldDisplayText = (string)(LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_common:Common_Fields", null, LocalizeDictionary.Instance.Culture));
                    break;
                case ValueTypeEnum.Measure:
                    CategoryDisplayText = (string)(LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_common:Common_Measures", null, LocalizeDictionary.Instance.Culture));
                    FieldDisplayText = (string)(LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_client:Visualization_Requirements_FromField", null, LocalizeDictionary.Instance.Culture));
                    break;
                default:
                    break;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoryDisplayText)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FieldDisplayText)));
        }
        private void CalculateDisplayedLists()
        {
            DisplayedFieldItems.Clear();
            DisplayedValueItems.Clear();
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                AllValueItems
                    .Where(item => item.ValueType == ValueType && item.IsField)
                    .ToList()
                    .ForEach(ele => DisplayedFieldItems.Add(ele));
                AllValueItems
                   .Where(item => item.ValueType == ValueType && !item.IsField)
                   .ToList()
                   .ForEach(ele => DisplayedValueItems.Add(ele));
            }
            else
            {
                AllValueItems
                    .Where(item => item.ValueType == ValueType && item.DisplayText.ToLower().Contains(searchText.ToLower()) && item.IsField)
                    .ToList()
                .ForEach(ele => DisplayedFieldItems.Add(ele));

                AllValueItems
                    .Where(item => item.ValueType == ValueType && item.DisplayText.ToLower().Contains(searchText.ToLower()) && !item.IsField)
                    .ToList()
                .ForEach(ele => DisplayedValueItems.Add(ele));
            }
            //Um die Visibility-Bindings zu triggern
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayedFieldItems)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayedValueItems)));
        }
        #endregion
    }

    public class ValueItem
    {
        #region properties
        public string DisplayText { get; set; }
        public LUIiconsEnum Icon { get; set; } = LUIiconsEnum.lui_icon_none;
        public ValueTypeEnum ValueType { get; set; }
        public bool IsAggregate { get; set; }
        public bool IsField { get; set; }
        public ValueItem Parent { get; set; }
        public ICommand ItemSelectedCommand { get; set; }
        #endregion
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
                    if (vitem.ValueType == ValueTypeEnum.Measure && vitem.IsField)
                    {
                        return MeasureFieldTemplate;
                    }
                    if (vitem.ValueType == ValueTypeEnum.Measure)
                    {
                        return MeasureTemplate;
                    }
                    if (vitem.ValueType == ValueTypeEnum.Dimension && vitem.IsField)
                    {
                        return DimensionFieldTemplate;
                    }
                    if (vitem.ValueType == ValueTypeEnum.Dimension)
                    {
                        return DimensionTemplate; ;
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
