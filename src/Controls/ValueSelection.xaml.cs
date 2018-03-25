using daVinci.Resources;
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

            new ValueItem(){ ValueType=ValueTypeEnum.Coefficient, DisplayText="# of Cust AR60+" },
            new ValueItem(){ ValueType=ValueTypeEnum.Coefficient, DisplayText="# of Customers" },
            new ValueItem(){ ValueType=ValueTypeEnum.Coefficient, DisplayText="# of Products" },
            new ValueItem(){ ValueType=ValueTypeEnum.Coefficient, DisplayText="% of Items" },
            new ValueItem(){ ValueType=ValueTypeEnum.Coefficient, DisplayText="Amound Overdue" },
            new ValueItem(){ ValueType=ValueTypeEnum.Coefficient, DisplayText="AR % Overdue" },

            new ValueItem(){  ValueType=ValueTypeEnum.Coefficient, IsField=true, DisplayText="Account" },
            new ValueItem(){  ValueType=ValueTypeEnum.Coefficient, IsField=true, DisplayText="Account Desc" },
            new ValueItem(){  ValueType=ValueTypeEnum.Coefficient, IsField=true, DisplayText="AccountGroup" },
            new ValueItem(){  ValueType=ValueTypeEnum.Coefficient, IsField=true, DisplayText="AccountGroupDesc" },
            new ValueItem(){  ValueType=ValueTypeEnum.Coefficient, IsField=true, DisplayText="Address Number", Icon=LUIiconsEnum.lui_icon_calendar },
            new ValueItem(){  ValueType=ValueTypeEnum.Coefficient, IsField=true, DisplayText="AR1-30" }
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
        private  ValueTypeEnum valueType;
        public ValueTypeEnum ValueType
        {
            get { return valueType; }
            set
            {
                if (valueType!=value)
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItemCommand)));
                }
            }
        }
        #endregion

        #region Search
        private  string searchText;

        public event PropertyChangedEventHandler PropertyChanged;

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
                    CategoryDisplayText = "Dimensionen";
                    FieldDisplayText = "Felder";
                    break;
                case ValueTypeEnum.Coefficient:
                    CategoryDisplayText = "Kennzahlen";
                    FieldDisplayText = "Aus einem Feld";
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
            
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(DisplayedFieldItems)));
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
        public DataTemplate CoefficientTemplate { get; set; }
        public DataTemplate CoefficientFieldTemplate { get; set; }
        public DataTemplate DimensionTemplate { get; set; }
        public DataTemplate DimensionFieldTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item,
                   DependencyObject container)
        {
           if(item is ValueItem vitem)
            {
                if (vitem.ValueType== ValueTypeEnum.Coefficient && vitem.IsField)
                {
                    return CoefficientFieldTemplate;
                }
                if (vitem.ValueType == ValueTypeEnum.Coefficient )
                {
                    return CoefficientTemplate;
                }
                if (vitem.ValueType == ValueTypeEnum.Dimension && vitem.IsField)
                {
                    return DimensionFieldTemplate;
                }
                if (vitem.ValueType == ValueTypeEnum.Dimension )
                {
                    return DimensionTemplate; ;
                }                
            }

            return new DataTemplate();
        }
    }
}
