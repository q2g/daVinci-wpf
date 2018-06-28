namespace daVinci.Controls
{
    #region Usings
    using System.Windows;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaktionslogik für BusyCircle.xaml
    /// </summary>
    public partial class BusyCircle : UserControl
    {
        public BusyCircle()
        {
            InitializeComponent();
        }

        #region Circlethickness - DP       
        public Thickness Circlethickness
        {
            get { return (Thickness)this.GetValue(CirclethicknessProperty); }
            set { this.SetValue(CirclethicknessProperty, value); }
        }

        public static readonly DependencyProperty CirclethicknessProperty = DependencyProperty.Register(
         "Circlethickness", typeof(Thickness), typeof(BusyCircle), new FrameworkPropertyMetadata(new Thickness(1), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
