namespace daVinci.Controls
{
    #region Using
    using System.Windows;
    using System.Windows.Controls;
    using daVinci.ConfigData.TableConfigurations;
    #endregion

    /// <summary>
    /// Interaktionslogik für TableImport.xaml
    /// </summary>
    public partial class TableImport : UserControl
    {
        public TableImport()
        {
            InitializeComponent();
        }

        #region SelectedTable DP
        public TableImportData SelectedTable
        {
            get { return (TableImportData)this.GetValue(SelectedTableProperty); }
            set { this.SetValue(SelectedTableProperty, value); }
        }

        public static readonly DependencyProperty SelectedTableProperty = DependencyProperty.Register(
         "SelectedTable", typeof(TableImportData), typeof(TableImport), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
