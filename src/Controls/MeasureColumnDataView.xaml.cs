namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData;
    using leonardo.Resources;
    using System.Windows.Input;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaktionslogik für MeasureColumnDataView.xaml
    /// </summary>
    public partial class MeasureColumnDataView : UserControl
    {
        public MeasureColumnDataView()
        {
            UnlinkCommand = new RelayCommand(
                   (o) =>
                   {

                       if (DataContext is MeasureColumnData measureconfig)
                       {
                           measureconfig.FieldDef = measureconfig.DimensionMeasure?.Formula ?? "";
                           measureconfig.FieldLabel = measureconfig.DimensionMeasure.Text;
                           measureconfig.IsExpression = true;
                       }

                   }, (o) => true);
            InitializeComponent();
        }

        public ICommand UnlinkCommand { get; set; }

    }
}
