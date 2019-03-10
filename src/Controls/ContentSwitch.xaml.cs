namespace daVinci.Controls
{
    #region Usings
    using System.Windows;
    using System.Windows.Controls;
    #endregion
    /// <summary>
    /// Interaktionslogik für ContentSwitch.xaml
    /// </summary>
    public partial class ContentSwitch : UserControl
    {
        public ContentSwitch()
        {
            InitializeComponent();
        }

        #region IsChecked - DP
        public bool IsChecked
        {
            get { return (bool)this.GetValue(IsCheckedProperty); }
            set { this.SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(
         "IsChecked", typeof(bool), typeof(ContentSwitch), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region CheckedText - DP       
        public string CheckedText
        {
            get { return (string)this.GetValue(CheckedTextProperty); }
            set { this.SetValue(CheckedTextProperty, value); }
        }

        public static readonly DependencyProperty CheckedTextProperty = DependencyProperty.Register(
         "CheckedText", typeof(string), typeof(ContentSwitch), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region UnCheckedText - DP       
        public string UnCheckedText
        {
            get { return (string)this.GetValue(UnCheckedTextProperty); }
            set { this.SetValue(UnCheckedTextProperty, value); }
        }

        public static readonly DependencyProperty UnCheckedTextProperty = DependencyProperty.Register(
         "UnCheckedText", typeof(string), typeof(ContentSwitch), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region TitleText - DP       
        public string TitleText
        {
            get { return (string)this.GetValue(TitleTextProperty); }
            set { this.SetValue(TitleTextProperty, value); }
        }

        public static readonly DependencyProperty TitleTextProperty = DependencyProperty.Register(
         "TitleText", typeof(string), typeof(ContentSwitch), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region UnCheckedContent - DP       
        public object UnCheckedContent
        {
            get { return this.GetValue(UnCheckedContentProperty); }
            set { this.SetValue(UnCheckedContentProperty, value); }
        }

        public static readonly DependencyProperty UnCheckedContentProperty = DependencyProperty.Register(
         "UnCheckedContent", typeof(object), typeof(ContentSwitch), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
