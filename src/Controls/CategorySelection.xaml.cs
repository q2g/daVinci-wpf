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
    /// Interaktionslogik für CategorySelection.xaml
    /// </summary>
    public partial class CategorySelection : UserControl
    {
        public CategorySelection()
        {
            InitializeComponent();
        }

        #region SelectedCommand - DP        
        public ICommand SelectedCommand
        {
            get { return (ICommand)this.GetValue(SelectedCommandProperty); }
            set { this.SetValue(SelectedCommandProperty, value); }
        }

        public static readonly DependencyProperty SelectedCommandProperty = DependencyProperty.Register(
         "SelectedCommand", typeof(ICommand), typeof(CategorySelection), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
