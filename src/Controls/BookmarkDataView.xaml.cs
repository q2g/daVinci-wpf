using daVinci_wpf.ConfigData.Bookmark;
using NLog;
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
    /// Interaction logic for BookmarkDataView.xaml
    /// </summary>
    public partial class BookmarkDataView : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public BookmarkDataView()
        {
            InitializeComponent();
        }


        #region IsEditMode DP
        public bool IsEditMode
        {
            get { return (bool)this.GetValue(IsEditModeProperty); }
            set { this.SetValue(IsEditModeProperty, value); }
        }

        public static readonly DependencyProperty IsEditModeProperty = DependencyProperty.Register(
         "IsEditMode", typeof(bool), typeof(BookmarkDataView), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region BookmarkToEdit DP
        public BookmarkData BookmarkToEdit
        {
            get { return (BookmarkData)this.GetValue(BookmarkToEditProperty); }
            set { this.SetValue(BookmarkToEditProperty, value); }
        }

        public static readonly DependencyProperty BookmarkToEditProperty = DependencyProperty.Register(
         "BookmarkToEdit", typeof(BookmarkData), typeof(BookmarkDataView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion  
    }
}
