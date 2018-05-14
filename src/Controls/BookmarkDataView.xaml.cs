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
    }
}
