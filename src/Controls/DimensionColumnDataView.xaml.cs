﻿namespace daVinci.Controls
{
    #region Usings
    using System.Windows.Controls;
    using System.Windows.Input;
    using daVinci.ConfigData;
    using leonardo.Resources;
    #endregion

    /// <summary>
    /// Interaktionslogik für DimensionColumnDataView.xaml
    /// </summary>
    public partial class DimensionColumnDataView : UserControl
    {
        public DimensionColumnDataView()
        {
            UnlinkCommand = new RelayCommand(
                (o) =>
                {
                    if (DataContext is DimensionColumnData dimensionconfig)
                    {
                        dimensionconfig.FieldDef = dimensionconfig.DimensionMeasure?.DimensionField ?? "";
                        dimensionconfig.FieldLabel = dimensionconfig.DimensionMeasure.Text;
                        dimensionconfig.IsExpression = true;
                    }
                }, (o) => true);

            InitializeComponent();
        }

        public ICommand UnlinkCommand { get; set; }
    }
}