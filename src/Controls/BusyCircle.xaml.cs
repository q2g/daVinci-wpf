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
        public double Circlethickness
        {
            get { return (double)this.GetValue(CirclethicknessProperty); }
            set { this.SetValue(CirclethicknessProperty, value); }
        }

        public static readonly DependencyProperty CirclethicknessProperty = DependencyProperty.Register(
         "Circlethickness", typeof(double), typeof(BusyCircle), new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
