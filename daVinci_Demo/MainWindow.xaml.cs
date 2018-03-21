using daVinci.Controls;
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
            ColumnChooser cc = new ColumnChooser();
            cc.Columns.Add(new LuiAccordionItem() { Header = "TestDimension", Content = new DimensionColumnDataView() });
            ItemList = new ObservableCollection<LuiAccordionItem>()
            {
                new LuiAccordionItem(){Header="Daten", Content=cc}
            };
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<LuiAccordionItem> ItemList { get; set; }
    }
}
