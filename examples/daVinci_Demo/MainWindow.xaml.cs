﻿namespace daVinci_Demo
{
    #region Usings
    using daVinci.ConfigData;
    using daVinci.ConfigData.Bookmark;
    using daVinci.ConfigData.Hub;
    using leonardo.Controls;
    using leonardo.Resources;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Windows;
    using System.Windows.Input;
    using WPFLocalizeExtension.Engine;
    #endregion

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            LocalizeDictionary.Instance.Culture = Thread.CurrentThread.CurrentCulture;

            Table = new TableConfiguration();
            Table.TableName = "The Table";

            var dimension1 = new DimensionColumnData()
            {
                DimensionMeasure = new DimensionMeasure() { LibID = "DimensionLibId1", Text = "DimensionLibId1", Dimension = true },
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
                DimensionMeasure = new DimensionMeasure() { LibID = "", Text = "", Dimension = true },
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
                DimensionMeasure = new DimensionMeasure() { LibID = "MeasureLibId1", Text = "MeasureLibId1", Dimension = false },
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
                DimensionMeasure = new DimensionMeasure() { LibID = "", Text = "", Dimension = true },
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
            Table.DimensionMeasures = new ObservableCollection<DimensionMeasure>()
            {
                new DimensionMeasure(){ Dimension=true, LibID="dim lib1", Text="DimensionLib1" },
                new DimensionMeasure(){ Dimension=true, LibID="dim lib2", Text="DimensionLib2" },
                new DimensionMeasure(){ Dimension=false, LibID="mea lib1", Text="MeasureLib1" },
                new DimensionMeasure(){ Dimension=false, LibID="mea lib2", Text="MeasureLib2" }
            };

            for (int i = 0; i < 200; i++)
            {
                Table.DimensionMeasures.Add(new DimensionMeasure() { Dimension = true, LibID = "dim lib1", Text = "DimensionLib1" });
            }
            string apptext = "Lorem ipsum dolor sit amet, consectetur adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            Hub = new HubData() { UserName = "Mr. User" };
            Hub.Streams = new ObservableCollection<object>()
            {
                new StreamData()
        {
            StreamName = "Everyone",
                    Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream,
                    Apps = new ObservableCollection<AppData>()
                    {
                        new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true}
                    }
                },
                new StreamData()
        {
            StreamName = "Manufacturing",
                    Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream,
                     Apps = new ObservableCollection<AppData>()
                    {
                        new AppData(){ AppName="Very very Long App",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true}
                    }
                },
                new StreamData() { StreamName = "Marketing", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Operations", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                 new StreamData() { StreamName = "Marketing", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Operations", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                 new StreamData() { StreamName = "Marketing", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Operations", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                 new StreamData() { StreamName = "Marketing", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Operations", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Marketing", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Operations", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                 new StreamData() { StreamName = "Marketing", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Operations", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                 new StreamData() { StreamName = "Marketing", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Operations", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                 new StreamData() { StreamName = "Marketing", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Operations", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream},
                new StreamData() { StreamName = "Sales", Icon = leonardo.Resources.LuiIconsEnum.lui_icon_stream}
    };

            Hub.PersonalStreams = new ObservableCollection<object>()
            {
                new StreamData()
    {
        StreamName = "Work",

                    Icon = leonardo.Resources.LuiIconsEnum.lui_icon_sheet,
                    Apps = new ObservableCollection<AppData>()
                    {
                        new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription="short Text", Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                        new AppData(){ AppName="App3",Created=new DateTime(2018,01,01),DataLastLoaded=new DateTime(2018,01,01), Published=new DateTime(2018,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                     new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                        new AppData(){ AppName="App3",Created=new DateTime(2018,01,01),DataLastLoaded=new DateTime(2018,01,01), Published=new DateTime(2018,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                     new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                        new AppData(){ AppName="App3",Created=new DateTime(2018,01,01),DataLastLoaded=new DateTime(2018,01,01), Published=new DateTime(2018,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                     new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                        new AppData(){ AppName="App3",Created=new DateTime(2018,01,01),DataLastLoaded=new DateTime(2018,01,01), Published=new DateTime(2018,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                     new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                        new AppData(){ AppName="App3",Created=new DateTime(2018,01,01),DataLastLoaded=new DateTime(2018,01,01), Published=new DateTime(2018,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                     new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                        new AppData(){ AppName="App3",Created=new DateTime(2018,01,01),DataLastLoaded=new DateTime(2018,01,01), Published=new DateTime(2018,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                     new AppData(){ AppName="App1",Created=new DateTime(2012,07,12),DataLastLoaded=new DateTime(2012,07,12), Published=new DateTime(2012,07,12), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf"},
                        new AppData(){ AppName="App2",Created=new DateTime(2010,01,01),DataLastLoaded=new DateTime(2010,01,01), Published=new DateTime(2010,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true},
                        new AppData(){ AppID="THE_ID", AppName="App21",Created=new DateTime(2018,01,01),DataLastLoaded=new DateTime(2018,01,01), Published=new DateTime(2018,01,01), AppImage="pack://application:,,,/daVinci-wpf;component/Images/QlikApp.png",AppDescription=apptext, Filename=@"c:\Folder\File.qvf", IsPublished=true}
                    }
                }
            };

            Bookmarks = new ObservableCollection<BookmarkData>()
            {
                new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }, new BookmarkData()
{
    BookmarkName = "Bookmark1",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                },
                new BookmarkData()
{
    BookmarkName = "Bookmark2",
                    BookmarkCreated = DateTime.Now,
                    BookmarkDescription = apptext,
                    BookmarkSelection = "The other Selection",
                    BookmarkBelongsTo = "Belongs to Sheet"
                }
            };

            InitializeComponent();

            //settingsDlg.Settings.Add(new daVinci.ConfigData.Settings.SettingsItem()
            //{
            //    Name = "Refresh Selections while selectiontool is open",
            //    Description = "While the selectiontool is open not every Table/SenseEV has to be refreshed after changeing a selection.\nSo the selectiontoll is faster.\nAfter the selectiontool is closed, all data will be refreshed.",
            //    ID = "refreshOnSelect",
            //    SettingsValue = new daVinci.ConfigData.Settings.SettingsValue()
            //    {
            //        ID = "refreshOnSelect",
            //        Type = "bool",
            //        ItemBoolValue = true
            //    },
            //});
            //settingsDlg.Settings.Add(new daVinci.ConfigData.Settings.SettingsItem()
            //{
            //    Name = "Refresh Selections while selectiontool is open",
            //    Description = "While the selectiontool is open not every Table/SenseEV has to be refreshed after changeing a selection.\nSo the selectiontoll is faster.\nAfter the selectiontool is closed, all data will be refreshed.",
            //    ID = "refreshOnSelect",
            //    SettingsValue = new daVinci.ConfigData.Settings.SettingsValue()
            //    {
            //        ID = "refreshOnSelect",
            //        Type = "bool",
            //        ItemBoolValue = true
            //    },
            //});
            //settingsDlg.Settings.Add(new daVinci.ConfigData.Settings.SettingsItem()
            //{
            //    Name = "Refresh Selections while selectiontool is open",
            //    Description = "While the selectiontool is open not every Table/SenseEV has to be refreshed after changeing a selection.\nSo the selectiontoll is faster.\nAfter the selectiontool is closed, all data will be refreshed.",
            //    ID = "refreshOnSelect",
            //    SettingsValue = new daVinci.ConfigData.Settings.SettingsValue()
            //    {
            //        ID = "refreshOnSelect",
            //        Type = "bool",
            //        ItemBoolValue = true
            //    },
            //});
            //settingsDlg.Settings.Add(new daVinci.ConfigData.Settings.SettingsItem()
            //{
            //    Name = "Refresh Selections while selectiontool is open",
            //    Description = "While the selectiontool is open not every Table/SenseEV has to be refreshed after changeing a selection.\nSo the selectiontoll is faster.\nAfter the selectiontool is closed, all data will be refreshed.",
            //    ID = "refreshOnSelect",
            //    SettingsValue = new daVinci.ConfigData.Settings.SettingsValue()
            //    {
            //        ID = "refreshOnSelect",
            //        Type = "string",
            //        ItemValue = "test1"
            //    },
            //});
            //settingsDlg.Settings.Add(new daVinci.ConfigData.Settings.SettingsItem()
            //{
            //    Name = "Refresh Selections while selectiontool is open",
            //    Description = "While the selectiontool is open not every Table/SenseEV has to be refreshed after changeing a selection.\nSo the selectiontoll is faster.\nAfter the selectiontool is closed, all data will be refreshed.",
            //    ID = "refreshOnSelect",
            //    SettingsValue = new daVinci.ConfigData.Settings.SettingsValue()
            //    {
            //        ID = "refreshOnSelect",
            //        Type = "string",
            //        ItemValue = "test"
            //    },
            //});

            AppSelectedCommand = new RelayCommand((o) =>
                            {
                                if (o is AppData appdata)
                                {
                                    LuiMessageBox.ShowDialog($"App '{appdata.AppName}' selektiert");
                                }
                            }, (o) => true);

            DataContext = this;
            //Logger logger = LogManager.GetCurrentClassLogger();
            //logger.Error("Hallo Log!");
        }
        public TableConfiguration Table { get; set; }
        public HubData Hub { get; set; }
        public ObservableCollection<BookmarkData> Bookmarks { get; set; }
        public ICommand AppSelectedCommand { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var json = Table.SaveToJSON();

            var nm = (LocalizeDictionary.Instance.GetLocalizedObject("qlik-resources:Translate_common:Common_Appearance", null, LocalizeDictionary.Instance.Culture));

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
