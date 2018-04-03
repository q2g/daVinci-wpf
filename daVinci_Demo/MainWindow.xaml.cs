using daVinci.ConfigData;
using daVinci.Controls;
using daVinci.Resources;
using daVinci_wpf.Resources;
using leonardo.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace daVinci_Demo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //ColumnChooser cc = new ColumnChooser();
            ////cc.Height = 300;
            //cc.Columns.Add(new LuiAccordionItem() { Header = "TestDimension", Content = new DimensionColumnDataView() { Text= "TestDimension" } });
            //cc.Columns.Add(new LuiAccordionItem() { Header = "TestKennzahl", Content = new MeasureColumnDataView() { Text = "TestKennzahl" } });
            //ItemList = new ObservableCollection<LuiAccordionItem>()
            //{
            //    new LuiAccordionItem(){Header="Daten", Content=cc},
            //     new LuiAccordionItem(){Header="Darstellung", Content=new PresentationAccordion()}
            //};
            Table = new TableConfiguration();
            Table.TableName = "The Table";

            var dimension1 = new DimensionColumnData()
            {
                LibraryID = "DimensionLibId1",
                FieldDef = "A+2/7",
                FieldLabel = "should not be visible",
                AllignmentIndex = 1,
                AllowNULLValues = true,
                BackgroundColorExpression = "BColorExp",
                FixedColumnCountSize = "11",
                GreatherThanLessThanIndex = 2,
                LimitModeIndex = 2,
                OthersLabel = "Otherlabeltext",
                RepresentationIndex = 1,
                ShowOthers = true,
                TextAllignment = true,
                TextColorExpression = "TColorExp",
                TextValue = "Value",
                TopBottomIndex = 1

            };

            var dimension2 = new DimensionColumnData()
            {
                LibraryID = "",
                FieldDef = "A+2/7",
                FieldLabel = "a Description",
                AllignmentIndex = 1,
                AllowNULLValues = true,
                BackgroundColorExpression = "BColorExp",
                FixedColumnCountSize = "11",
                GreatherThanLessThanIndex = 2,
                LimitModeIndex = 2,
                OthersLabel = "Otherlabeltext",
                RepresentationIndex = 1,
                ShowOthers = true,
                TextAllignment = false,
                TextColorExpression = "TColorExp",
                TextValue = "Value",
                TopBottomIndex = 1

            };

            var measure1 = new MeasureColumnData()
            {
                LibraryID = "MeasureLibId",
                FieldDef = "A+2/7",
                FieldLabel = "should not be visible",
                AllignmentIndex = 1,
                TextColorExpression = "tcolorexp",
                TextAllignment = true,
                BackgroundColorExpression = "bcolorexp",
                CurrencyFormatText = "currencformat",
                CustomNumberFormatText = "customNumberformat",
                DateFormatText = "Dateformat",
                DateStandardFormatIndex = 2,
                Dec_SplitterSign = ".",
                DurationFormatText = "duration",
                IsStandardDateFormat = true,
                IsStandardFormat = true,
                NumberFormatIndex = 1,
                NumberFormatText = "numberformat",
                StandardFormatIndex = 1,
                Thou_SplitterSign = ",",
                TotalValueFunctionIndex = 2
            };

            var measure2 = new MeasureColumnData()
            {
                LibraryID = "",
                FieldDef = "A+2/7",
                FieldLabel = "MeasureDescription",
                AllignmentIndex = 1,
                TextColorExpression = "tcolorexp",
                TextAllignment = false,
                BackgroundColorExpression = "bcolorexp",
                CurrencyFormatText = "currencformat",
                CustomNumberFormatText = "customNumberformat",
                DateFormatText = "Dateformat",
                DateStandardFormatIndex = 2,
                Dec_SplitterSign = ".",
                DurationFormatText = "duration",
                IsStandardDateFormat = true,
                IsStandardFormat = false,
                NumberFormatIndex = 1,
                NumberFormatText = "numberformat",
                StandardFormatIndex = 1,
                Thou_SplitterSign = ",",
                TotalValueFunctionIndex = 2
            };



            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = dimension1, ColumnOrderIndex = 1, SortOrderIndex = 1, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = dimension2, ColumnOrderIndex = 2, SortOrderIndex = 2, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Measure, ColumnData = measure1, ColumnOrderIndex = 3, SortOrderIndex = 3, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Measure, ColumnData = measure2, ColumnOrderIndex = 4, SortOrderIndex = 4, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension1" }, ColumnOrderIndex = 5, SortOrderIndex = 5, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension2" }, ColumnOrderIndex = 6, SortOrderIndex = 6, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Measure, ColumnData = new MeasureColumnData() { LibraryID = "Kennzahl" }, ColumnOrderIndex = 7, SortOrderIndex = 7, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension1" }, ColumnOrderIndex = 8, SortOrderIndex = 8, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension2" }, ColumnOrderIndex = 9, SortOrderIndex = 9, Parent = Table });


            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Measure, ColumnData = new MeasureColumnData() { LibraryID = "Kennzahl" }, ColumnOrderIndex = 10, SortOrderIndex = 10, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension1" }, ColumnOrderIndex = 11, SortOrderIndex = 11, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension2" }, ColumnOrderIndex = 12, SortOrderIndex = 12, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Measure, ColumnData = new MeasureColumnData() { LibraryID = "Kennzahl" }, ColumnOrderIndex = 13, SortOrderIndex = 13, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension1" }, ColumnOrderIndex = 14, SortOrderIndex = 14, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension2" }, ColumnOrderIndex = 15, SortOrderIndex = 15, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Measure, ColumnData = new MeasureColumnData() { LibraryID = "Kennzahl" }, ColumnOrderIndex = 16, SortOrderIndex = 16, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension1" }, ColumnOrderIndex = 17, SortOrderIndex = 17, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData() { LibraryID = "Dimension2" }, ColumnOrderIndex = 18, SortOrderIndex = 18, Parent = Table });


            Table.AddOnData.Add(new AddOnDataProcessingConfiguration()
            {
                AllowNULLValues = true,
                CalcCondition = "CalculationConditions"
            });

            Table.PresentationData = new ObservableCollection<object>();
            Table.PresentationData.Add(new PresentationData()
            {
                TotalMode = false,
                TotalPositionIndex = 1,
                TotalLabel = "GesamtwerteTest"
            });


            InitializeComponent();
            DataContext = this;

        }
        public TableConfiguration Table { get; set; }
        public ObservableCollection<LuiAccordionItem> ItemList { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tt.Opacity = 0.5;
        }
    }
}
