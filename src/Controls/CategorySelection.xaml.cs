namespace daVinci.Controls
{
    #region Usings
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using NLog;

    /// <summary> 
    #endregion
    /// Interaktionslogik für CategorySelection.xaml
    /// </summary>
    public partial class CategorySelection : UserControl, INotifyPropertyChanged
    {
        #region LoggerInit
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public CategorySelection()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Properties
        private List<CategoryItem> categoryItems = new List<CategoryItem>();
        public List<CategoryItem> CategoryItems
        {
            get { return categoryItems; }
            set
            {
                if (categoryItems != value)
                {
                    categoryItems = value;
                    RaisePropertyChanged();
                }
            }

        }
        #endregion

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

    public class CategoryItem
    {
        public string CategoryName { get; set; }
        public string CategoryParameter { get; set; }
    }
}
