namespace daVinci.Controls
{
    #region Usings
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using leonardo.AttachedProperties;
    using NLog;
    #endregion

    /// <summary>
    /// Interaction logic for ControlLoader.xaml
    /// </summary>
    public partial class ControlLoader : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ControlLoader()
        {
            InitializeComponent();
        }

        public Type TypeToCreate { get; set; }
        public int Hwnd { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TypeToCreate != null)
                {
                    var control = (Control)Activator.CreateInstance(TypeToCreate);
                    control.SetValue(ThemeProperties.HwndProperty, Hwnd);
                    control.DataContext = DataContext;
                    Content = control;
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
    }
}
