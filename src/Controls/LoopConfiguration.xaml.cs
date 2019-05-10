namespace daVinci.Controls
{
    #region Usings
    using leonardo.AttachedProperties;
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    #endregion

    /// <summary>
    /// Interaktionslogik für LoopConfiguration.xaml
    /// </summary>
    public partial class LoopConfiguration : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region ctor
        public LoopConfiguration()
        {
            Dimensions = new ObservableCollection<DimensionMeasure>();
            InitializeComponent();
        }
        #endregion

        #region Properties & Variables
        #endregion

        #region Dimensions - DP
        public ObservableCollection<DimensionMeasure> Dimensions
        {
            get { return (ObservableCollection<DimensionMeasure>)this.GetValue(DimensionsProperty); }
            set { this.SetValue(DimensionsProperty, value); }
        }

        public static readonly DependencyProperty DimensionsProperty = DependencyProperty.Register(
         "Dimensions", typeof(ObservableCollection<DimensionMeasure>), typeof(LoopConfiguration), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region SelectedDimension - DP
        public DimensionMeasure SelectedDimension
        {
            get { return (DimensionMeasure)this.GetValue(SelectedDimensionProperty); }
            set { this.SetValue(SelectedDimensionProperty, value); }
        }

        public static readonly DependencyProperty SelectedDimensionProperty = DependencyProperty.Register(
         "SelectedDimension", typeof(DimensionMeasure), typeof(LoopConfiguration), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ExpressionText - DP
        public ConfigData.Loop.LoopConfiguration LoopConfigurationSelected
        {
            get { return (ConfigData.Loop.LoopConfiguration)this.GetValue(LoopConfigurationSelectedProperty); }
            set { this.SetValue(LoopConfigurationSelectedProperty, value); }
        }

        public static readonly DependencyProperty LoopConfigurationSelectedProperty = DependencyProperty.Register(
         "LoopConfigurationSelected", typeof(ConfigData.Loop.LoopConfiguration), typeof(LoopConfiguration), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region OKCommand - DP
        public ICommand OKCommand
        {
            get { return (ICommand)this.GetValue(OKCommandProperty); }
            set { this.SetValue(OKCommandProperty, value); }
        }

        public static readonly DependencyProperty OKCommandProperty = DependencyProperty.Register(
         "OKCommand", typeof(ICommand), typeof(LoopConfiguration), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region CancelCommand - DP
        public ICommand CancelCommand
        {
            get { return (ICommand)this.GetValue(CancelCommandProperty); }
            set { this.SetValue(CancelCommandProperty, value); }
        }

        public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(
         "CancelCommand", typeof(ICommand), typeof(LoopConfiguration), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region static
        public static string ShowModal(string text, List<DimensionMeasure> list, int hwnd = 0)
        {

            var loopconfig = new ConfigData.Loop.LoopConfiguration()
            {
                ExpressionText = text
            };


            var wnd = new LoopConfiguration();
            wnd.WindowStyle = WindowStyle.None;
            wnd.LoopConfigurationSelected = loopconfig;
            wnd.WindowStartupLocation = WindowStartupLocation.CenterOwner;


            wnd.SetValue(ThemeProperties.HwndProperty, hwnd);
            new WindowInteropHelper(wnd).Owner = new IntPtr((int)hwnd);

            var handler = new PropertyChangedEventHandler((s, e) =>
            {
            });
            (loopconfig as INotifyPropertyChanged).PropertyChanged += handler;
            list.OrderBy(ele => ele.Text).ToList()
                        .ForEach(ele => wnd.Dimensions.Add(ele));

            string retval = text;
            wnd.OKCommand = new RelayCommand((o) =>
                            {
                                retval = loopconfig.ExpressionText;
                                wnd.Close();
                            });
            wnd.CancelCommand = new RelayCommand((o) => { wnd.Close(); });
            wnd.ShowDialog();

            return retval;
        }
        #endregion
    }
}
