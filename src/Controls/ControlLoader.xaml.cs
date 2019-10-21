namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData.TableConfigurations;
    using leonardo.AttachedProperties;
    using NLog;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;
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

                    Dispatcher dispi = this.GetValue(ThemeProperties.DispatcherProperty) as Dispatcher;

                    if (dispi != null)
                    {
                        dispi.BeginInvoke((Action)(() =>
                        {
                            try
                            {
                                CreateControl();
                            }
                            catch (Exception ex)
                            {
                                logger.Error(ex);
                            }
                        }));
                    }
                    else
                    {
                        CreateControl();
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }

        private void CreateControl()
        {
            try
            {
                Control control = null;
                control = (Control)Activator.CreateInstance(TypeToCreate);
                control.SetValue(ThemeProperties.HwndProperty, Hwnd);
                control.DataContext = DataContext;
                Content = control;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
