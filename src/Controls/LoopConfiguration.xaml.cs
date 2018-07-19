using Hjson;
using leonardo.Resources;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace daVinci.Controls
{
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
        public string ExpressionText
        {
            get { return (string)this.GetValue(ExpressionTextProperty); }
            set { this.SetValue(ExpressionTextProperty, value); }
        }

        public static readonly DependencyProperty ExpressionTextProperty = DependencyProperty.Register(
         "ExpressionText", typeof(string), typeof(LoopConfiguration), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
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

        #region statics
        public static string ShowModal(string text, List<DimensionMeasure> list, ConfigData.Loop.LoopConfiguration loopconfig = null)
        {

            if (loopconfig == null)
            {
                loopconfig = new ConfigData.Loop.LoopConfiguration();
            }

            var wnd = new LoopConfiguration()
            {
                WindowStyle = WindowStyle.None,
                ExpressionText = text,
                LoopConfigurationSelected = loopconfig,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            var mainHwnd = GlobalAppData.Instance.DataHolder.Get<object>("MainHwnd");
            if (mainHwnd != null && mainHwnd is int)
            {
                new WindowInteropHelper(wnd).Owner = new IntPtr((int)mainHwnd);
            }

            var handler = new PropertyChangedEventHandler((s, e) =>
            {
                dynamic data = null;
                try
                {
                    if (string.IsNullOrEmpty(wnd.ExpressionText))
                    {
                        wnd.ExpressionText = $"selections:\n[\n  {{\n    type: dynamic\n  \n  }}\n]";
                    }
                    var value = HjsonValue.Parse(wnd.ExpressionText);
                    data = JObject.Parse(value.ToString());
                }
                catch (Exception ex)
                {
                    logger.Trace(ex);
                }
                if (data != null)
                {
                    if ((data?.selections?.Count ?? 0) > 0)
                    {
                        if (e.PropertyName == nameof(ConfigData.Loop.LoopConfiguration.LoopOver))
                            data.selections[0].name = loopconfig.LoopOver.Text;
                        if (e.PropertyName == nameof(ConfigData.Loop.LoopConfiguration.ExportRootNode))
                            data.selections[0].exportRootNode = loopconfig.ExportRootNode;
                        if (e.PropertyName == nameof(ConfigData.Loop.LoopConfiguration.SheetNameExpression))
                            data.selections[0].sheetName = loopconfig.SheetNameExpression;
                    }
                    wnd.ExpressionText = HjsonValue.Parse(data.ToString()).ToString(Stringify.Hjson);
                    wnd.ExpressionText = wnd.ExpressionText.Substring(1, wnd.ExpressionText.Length - 2).Trim();
                }
            });
            (loopconfig as INotifyPropertyChanged).PropertyChanged += handler;
            list.OrderBy(ele => ele.Text).ToList()
                        .ForEach(ele => wnd.Dimensions.Add(ele));

            string retval = text;
            wnd.OKCommand = new RelayCommand((o) =>
                    {
                        retval = wnd.ExpressionText;
                        wnd.Close();
                    });
            wnd.CancelCommand = new RelayCommand((o) => { wnd.Close(); });
            wnd.ShowDialog();


            return retval;

        }
        #endregion
    }
}
