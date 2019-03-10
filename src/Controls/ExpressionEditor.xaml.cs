namespace daVinci.Controls
{
    #region Usings
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    using leonardo.Resources;
    #endregion

    /// <summary>
    /// Interaktionslogik für ExpressionEditor.xaml
    /// </summary>
    public partial class ExpressionEditor : Window
    {
        public ExpressionEditor()
        {
            InitializeComponent();
        }

        #region ExpressionText - DP
        public string ExpressionText
        {
            get { return (string)this.GetValue(ExpressionTextProperty); }
            set { this.SetValue(ExpressionTextProperty, value); }
        }

        public static readonly DependencyProperty ExpressionTextProperty = DependencyProperty.Register(
         "ExpressionText", typeof(string), typeof(ExpressionEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region OKCommand - DP
        public ICommand OKCommand
        {
            get { return (ICommand)this.GetValue(OKCommandProperty); }
            set { this.SetValue(OKCommandProperty, value); }
        }

        public static readonly DependencyProperty OKCommandProperty = DependencyProperty.Register(
         "OKCommand", typeof(ICommand), typeof(ExpressionEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region CancelCommand - DP
        public ICommand CancelCommand
        {
            get { return (ICommand)this.GetValue(CancelCommandProperty); }
            set { this.SetValue(CancelCommandProperty, value); }
        }

        public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(
         "CancelCommand", typeof(ICommand), typeof(ExpressionEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region statics
        public static string ShowModal(string text, int hwnd = 0)
        {
            var wnd = new ExpressionEditor()
            {
                WindowStyle = WindowStyle.None,
                ExpressionText = text,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            new WindowInteropHelper(wnd).Owner = new IntPtr(hwnd);

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            outputTextBox.Focus();
        }
    }
}
