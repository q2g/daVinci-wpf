namespace daVinci.Controls
{
    #region Usings
    using leonardo.Resources;
    using System.Windows;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaktionslogik für PropertyPanel.xaml
    /// </summary>
    public partial class PropertyPanel : UserControl
    {
        public PropertyPanel()
        {
            InitializeComponent();
        }

        #region OwnerHwndHwnd DP
        public int OwnerHwnd
        {
            get { return (int)this.GetValue(OwnerHwndProperty); }
            set { this.SetValue(OwnerHwndProperty, value); }
        }

        public static readonly DependencyProperty OwnerHwndProperty = DependencyProperty.Register(
         "OwnerHwnd", typeof(int), typeof(PropertyPanel), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
