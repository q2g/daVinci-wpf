namespace daVinci.Controls
{
    using daVinci.ConfigData.ThemeConfig;
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



        public Point StartPoint
        {
            get
            {
                return new Point(0, -1 * ActualHeight / 2);
            }
        }
        public Point SpinnerPoint
        {
            get
            {
                return new Point(ActualHeight / 2, 0);
            }
        }
        public double BackGroundRadius
        {
            get
            {
                return ActualHeight / 2;
            }
        }
        public Size SpinnerSize
        {
            get
            {
                return new Size(ActualHeight / 2, ActualHeight / 2);
            }
        }
        public BaseTheme Theme
        {
            get
            {
                return BaseTheme.Instance.CurrentTheme;
            }

        }
    }
}
