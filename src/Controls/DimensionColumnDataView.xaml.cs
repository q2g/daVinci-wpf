using daVinci.ConfigData;
using leonardo.Controls;
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
    /// Interaktionslogik für DimensionColumnDataView.xaml
    /// </summary>
    public partial class DimensionColumnDataView : UserControl
    {
        public DimensionColumnDataView()
        {
            UnlinkCommand = new RelayCommand(
                (o) =>
                {
                    if (DataContext is DimensionColumnData dimensionconfig)
                    {
                        dimensionconfig.FieldDef = $"Formel von {dimensionconfig.DimensionMeasure.LibID}";
                        dimensionconfig.FieldLabel = dimensionconfig.DimensionMeasure.LibID;
                        dimensionconfig.DimensionMeasure.LibID = "";
                    }
                }, (o) => true);
            InitializeComponent();


        }

        public ICommand UnlinkCommand { get; set; }

    }
}


