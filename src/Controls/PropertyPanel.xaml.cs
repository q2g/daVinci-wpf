using leonardo.Resources;
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

namespace daVinci.Controls
{
    /// <summary>
    /// Interaktionslogik für PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : UserControl
    {
        public PropertyPanel()
        {
            InitializeComponent();
        }

        #region DimensionMeasures DP
        public ObservableCollection<DimensionMeasure> DimensionMeasures
        {
            get { return (ObservableCollection<DimensionMeasure>)this.GetValue(DimensionMeasuresProperty); }
            set { this.SetValue(DimensionMeasuresProperty, value); }
        }

        public static readonly DependencyProperty DimensionMeasuresProperty = DependencyProperty.Register(
         "DimensionMeasures", typeof(ObservableCollection<DimensionMeasure>), typeof(PropertyPanel), new FrameworkPropertyMetadata(new ObservableCollection<DimensionMeasure>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
