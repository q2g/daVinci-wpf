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

namespace daVinci.Controls
{
    /// <summary>
    /// Interaktionslogik für ColumnChooser.xaml
    /// </summary>
    public partial class ColumnChooser : UserControl
    {
        public ColumnChooser()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Accordion
        public ObservableCollection<LuiAccordionItem> Columns { get; set; } = new ObservableCollection<LuiAccordionItem>();
        #endregion
    }
}
