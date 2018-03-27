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
            //cc.Columns.Add(new LuiAccordionItem() { Header = "TestKennzahl", Content = new CoefficientColumnDataView() { Text = "TestKennzahl" } });
            //ItemList = new ObservableCollection<LuiAccordionItem>()
            //{
            //    new LuiAccordionItem(){Header="Daten", Content=cc},
            //     new LuiAccordionItem(){Header="Darstellung", Content=new PresentationAccordion()}
            //};
            Table = new TableConfiguration();
            Table.TableName = "The Table";

            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Coefficient, ColumnData = new CoefficientColumnData(), ColumnName = "Kennzahl", ColumnOrderIndex = 1, SortOrderIndex = 1, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData(), ColumnName = "Dimension1", ColumnOrderIndex = 2, SortOrderIndex = 2, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData(), ColumnName = "Dimension2", ColumnOrderIndex = 3, SortOrderIndex = 3, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Coefficient, ColumnData = new CoefficientColumnData(), ColumnName = "Kennzahl", ColumnOrderIndex = 4, SortOrderIndex = 4, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData(), ColumnName = "Dimension1", ColumnOrderIndex = 5, SortOrderIndex = 5, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData(), ColumnName = "Dimension2", ColumnOrderIndex = 6, SortOrderIndex = 6, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Coefficient, ColumnData = new CoefficientColumnData(), ColumnName = "Kennzahl", ColumnOrderIndex = 7, SortOrderIndex = 7, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData(), ColumnName = "Dimension1", ColumnOrderIndex = 8, SortOrderIndex = 8, Parent = Table });
            Table.Columns.Add(new ColumnConfiguration() { ValueType = ValueTypeEnum.Dimension, ColumnData = new DimensionColumnData(), ColumnName = "Dimension2", ColumnOrderIndex = 9, SortOrderIndex = 9, Parent = Table });





            Table.AddOnData.Add(new AddOnDataProcessingConfiguration());

            Table.PresentationData = new ObservableCollection<object>();
            Table.PresentationData.Add(new PresentationData());





            InitializeComponent();
            DataContext = this;

        }
        public TableConfiguration Table { get; set; }
        public ObservableCollection<LuiAccordionItem> ItemList { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
