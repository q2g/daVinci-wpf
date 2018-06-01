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
    /// Interaktionslogik für SearchField.xaml
    /// </summary>
    public partial class SearchField : UserControl
    {
        public SearchField()
        {
            InitializeComponent();
        }

        #region Autofocus - DP        
        public bool Autofocus
        {
            get { return (bool)this.GetValue(AutofocusProperty); }
            set { this.SetValue(AutofocusProperty, value); }
        }

        public static readonly DependencyProperty AutofocusProperty = DependencyProperty.Register(
         "Autofocus", typeof(bool), typeof(SearchField), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
