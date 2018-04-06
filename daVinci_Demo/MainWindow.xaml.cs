using daVinci.ConfigData;
using daVinci.Controls;
using daVinci.Resources;
using daVinci_wpf.Resources;
using leonardo.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            //cc.Columns.Add(new LuiAccordionItem() { Header = "TestDimension", Content = new DimensionColumnDataView() { Text= "TestDimension" } }});
            //cc.Columns.Add(new LuiAccordionItem() { Header = "TestKennzahl", Content = new MeasureColumnDataView() { Text = "TestKennzahl" } }});
            //ItemList = new ObservableCollection<LuiAccordionItem>()
            //{
            //    new LuiAccordionItem(){Header="Daten", Content=cc, SortCriterias=new SortCriteria(){
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
                TopBottomIndex = 1,

                SortCriterias = new SortCriteria()
                {
                    ColumnOrderIndex = 1,
                    SortOrderIndex = 1,
                    AutoSort = true
                }

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
                TopBottomIndex = 1,

                SortCriterias = new SortCriteria()
                {
                    ColumnOrderIndex = 2,
                    SortOrderIndex = 2,
                    AutoSort = false,
                    SortByAscii = true,
                    SortByAsciiDirection = 1,
                    SortByExpression = true,
                    SortByExpressionDirection = 1,
                    SortByExpressionText = "expression",
                    SortByNumeric = true,
                    SortByNumericDirection = 1
                }

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
                TotalValueFunctionIndex = 2,

                SortCriterias = new SortCriteria()
                {
                    ColumnOrderIndex = 3,
                    SortOrderIndex = 3
                }
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
                TotalValueFunctionIndex = 2,

                SortCriterias = new SortCriteria()
                {
                    ColumnOrderIndex = 4,
                    SortOrderIndex = 4
                }
            };



            //Table.Columns.Add(dimension1);
            //Table.Columns.Add(dimension2);
            //Table.Columns.Add(measure1);
            //Table.Columns.Add(measure2);
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension1", SortCriterias = new SortCriteria() { ColumnOrderIndex = 5, SortOrderIndex = 5 } });
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension2", SortCriterias = new SortCriteria() { ColumnOrderIndex = 6, SortOrderIndex = 6 } });
            //Table.Columns.Add(new MeasureColumnData() { LibraryID = "Kennzahl", SortCriterias = new SortCriteria() { ColumnOrderIndex = 7, SortOrderIndex = 7 } });
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension1", SortCriterias = new SortCriteria() { ColumnOrderIndex = 8, SortOrderIndex = 8 } });
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension2", SortCriterias = new SortCriteria() { ColumnOrderIndex = 9, SortOrderIndex = 9 } });


            //Table.Columns.Add(new MeasureColumnData() { LibraryID = "Kennzahl", SortCriterias = new SortCriteria() { ColumnOrderIndex = 10, SortOrderIndex = 10 } });
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension1", SortCriterias = new SortCriteria() { ColumnOrderIndex = 11, SortOrderIndex = 11 } });
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension2", SortCriterias = new SortCriteria() { ColumnOrderIndex = 12, SortOrderIndex = 12 } });
            //Table.Columns.Add(new MeasureColumnData() { LibraryID = "Kennzahl", SortCriterias = new SortCriteria() { ColumnOrderIndex = 13, SortOrderIndex = 13 } });
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension1", SortCriterias = new SortCriteria() { ColumnOrderIndex = 14, SortOrderIndex = 14 } });
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension2", SortCriterias = new SortCriteria() { ColumnOrderIndex = 15, SortOrderIndex = 15 } });
            //Table.Columns.Add(new MeasureColumnData() { LibraryID = "Kennzahl", SortCriterias = new SortCriteria() { ColumnOrderIndex = 16, SortOrderIndex = 16 } });
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension1", SortCriterias = new SortCriteria() { ColumnOrderIndex = 17, SortOrderIndex = 17 } });
            //Table.Columns.Add(new DimensionColumnData() { LibraryID = "Dimension2", SortCriterias = new SortCriteria() { ColumnOrderIndex = 18, SortOrderIndex = 18 } });


            //Table.AddOnData.Add(new AddOnDataProcessingConfiguration()
            //{
            //    AllowNULLValues = true,
            //    CalcCondition = "CalculationConditions"
            //});

            //Table.PresentationData = new ObservableCollection<object>();
            //Table.PresentationData.Add(new PresentationData()
            //{
            //    TotalMode = false,
            //    TotalPositionIndex = 1,
            //    TotalLabel = "GesamtwerteTest"
            //});

            Table.ReadFromJSON(File.ReadAllText(@"C:\work\Programming\dotnet\Data_Desc.json"));
            InitializeComponent();
            DataContext = this;

        }
        public TableConfiguration Table { get; set; }
        public ObservableCollection<LuiAccordionItem> ItemList { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var json = Table.SaveToJSON();

            //Kennzahlformel
        }
    }
}
