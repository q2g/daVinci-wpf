using daVinci.ConfigData;
using leonardo.Resources;
using System;
using System.Collections.Generic;
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
    /// Interaktionslogik für MeasureColumnDataView.xaml
    /// </summary>
    public partial class MeasureColumnDataView : UserControl
    {
        public MeasureColumnDataView()
        {
            UnlinkCommand = new RelayCommand((o) => true,
                   (o) =>
                   {
                       if (DataContext is ColumnConfiguration column)
                       {
                           if (column.ColumnData is MeasureColumnData measureconfig)
                           {
                               measureconfig.FieldDef = $"Formel von {measureconfig.LibraryID}";
                               measureconfig.FieldLabel = measureconfig.LibraryID;
                               measureconfig.LibraryID = "";
                           }
                       }
                   });
            InitializeComponent();
        }

        public ICommand UnlinkCommand { get; set; }

    }
}
