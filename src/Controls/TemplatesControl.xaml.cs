namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData.Connection;
    using daVinci.ConfigData.Hub;
    using leonardo.AttachedProperties;
    using NLog;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für TemplatesControl.xaml
    /// </summary>
    public partial class TemplatesControl : UserControl, INotifyPropertyChanged
    {
        #region LoggerInit
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region ctor
        public TemplatesControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties & Variables
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    RaisePropertyChanged();
                }
            }
        }

        private TemplateData selectedTemplate;
        public TemplateData SelectedTemplate
        {
            get { return selectedTemplate; }
            set
            {
                if (selectedTemplate != value)
                {
                    selectedTemplate = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region Templates DP
        public ObservableCollection<TemplateData> Templates
        {
            get { return (ObservableCollection<TemplateData>)this.GetValue(TemplatesProperty); }
            set { this.SetValue(TemplatesProperty, value); }
        }

        public static readonly DependencyProperty TemplatesProperty = DependencyProperty.Register(
         "Templates", typeof(ObservableCollection<TemplateData>), typeof(TemplatesControl), new FrameworkPropertyMetadata(new ObservableCollection<TemplateData>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

    }
}
