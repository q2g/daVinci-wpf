using daVinci.ConfigData;
using daVinci.Controls;
using daVinci.Resources;
using daVinci_wpf.ConfigData;
using daVinci_wpf.ConfigData.Hub;
using leonardo.Controls;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

namespace daVinci_Demo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary> 
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            LocalizeDictionary.Instance.Culture = Thread.CurrentThread.CurrentCulture;


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

            Table.ReadFromJSON(GetEmbeddedResourceFile("daVinci_Demo.Resources.Data_Desc.json"));

            string apptext = "Lorem ipsum dolor sit amet, consectetur adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            Hub = new HubData() { UserName = "Mr. User" };
            Hub.Streams = new ObservableCollection<object>()
            {
                new StreamData()
                {
                    StreamName ="Everyone",
                    Icon = leonardo.Resources.LUIiconsEnum.lui_icon_stream,
                    Apps=new ObservableCollection<AppData>()
                    {
                        new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true}
                    }
                },
                new StreamData()
                {
                    StreamName ="Manufacturing",
                    Icon = leonardo.Resources.LUIiconsEnum.lui_icon_stream,
                     Apps=new ObservableCollection<AppData>()
                    {
                        new AppData(){ AppName="Very very Long App",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true}
                    }
                },
                new StreamData(){ StreamName="Marketing", Icon= leonardo.Resources.LUIiconsEnum.lui_icon_stream},
                new StreamData(){ StreamName="Operations", Icon= leonardo.Resources.LUIiconsEnum.lui_icon_stream},
                new StreamData(){ StreamName="Sales", Icon= leonardo.Resources.LUIiconsEnum.lui_icon_stream}
            };

            Hub.PersonalStreams = new ObservableCollection<object>()
            {
                new StreamData()
                {
                    StreamName ="Work",

                    Icon = leonardo.Resources.LUIiconsEnum.lui_icon_sheet,
                    Apps=new ObservableCollection<AppData>()
                    {
                        new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                        new AppData(){ AppName="App3",Created=new DateTime(2018,01,01),DataLastLoaded=new DateTime(2018,01,01), Published=new DateTime(2018,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true}
                    }
                }
            };


            InitializeComponent();




            DataContext = this;
            //Logger logger = LogManager.GetCurrentClassLogger();
            //logger.Error("Hallo Log!");


        }
        public TableConfiguration Table { get; set; }
        public HubData Hub { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var json = Table.SaveToJSON();

            var nm = (LocalizeDictionary.Instance.GetLocalizedObject("Qlik.Sense.Resources:Translate_common:Common_Appearance", null, LocalizeDictionary.Instance.Culture));

            //Kennzahlformel
        }
        public string GetEmbeddedResourceFile(string filename)
        {
            var a = System.Reflection.Assembly.GetExecutingAssembly();
            using (var s = a.GetManifestResourceStream(filename))
            using (var r = new System.IO.StreamReader(s))
            {
                string result = r.ReadToEnd();
                return result;
            }

        }
    }

}
