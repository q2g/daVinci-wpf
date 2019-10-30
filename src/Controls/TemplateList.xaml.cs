namespace daVinci.Controls
{
    using daVinci.ConfigData.Hub;
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    #endregion

    /// <summary>
    /// Interaktionslogik für TemplateList.xaml
    /// </summary>
    public partial class TemplateList : UserControl
    {
        public TemplateList()
        {
            InitializeComponent();
        }

        #region Item DP
        public ObservableCollection<object> Items
        {
            get { return (ObservableCollection<object>)this.GetValue(ItemsProperty); }
            set { this.SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
         "Items", typeof(ObservableCollection<object>), typeof(TemplateList), new FrameworkPropertyMetadata(new ObservableCollection<object>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
