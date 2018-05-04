namespace daVinci.Controls
{
    #region Usings
    using NLog;
    using System.Windows;
    using System.Windows.Controls;
    using daVinci.ConfigData.Bookmark; 
    #endregion

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
