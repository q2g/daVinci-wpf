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
    /// Interaktionslogik für SelectionItem.xaml
    /// </summary>
    public partial class SelectionItem : UserControl
    {
        public SelectionItem()
        {
            InitializeComponent();
        }

        #region ClearCommand - DP        
        public ICommand ClearCommand
        {
            get { return (ICommand)this.GetValue(ClearCommandProperty); }
            set { this.SetValue(ClearCommandProperty, value); }
        }

        public static readonly DependencyProperty ClearCommandProperty = DependencyProperty.Register(
         "ClearCommand", typeof(ICommand), typeof(SelectionItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region MultiSelect - DP        
        public bool MultiSelect
        {
            get { return (bool)this.GetValue(MultiSelectProperty); }
            set { this.SetValue(MultiSelectProperty, value); }
        }

        public static readonly DependencyProperty MultiSelectProperty = DependencyProperty.Register(
         "MultiSelect", typeof(bool), typeof(SelectionItem), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
