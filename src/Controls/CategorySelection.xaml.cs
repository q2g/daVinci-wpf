namespace daVinci.Controls
{
    #region Usings
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Controls;
    /// <summary> 
	#endregion
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
