﻿namespace daVinci.Controls
{
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using leonardo.AttachedProperties;
    using leonardo.Controls;
    using leonardo.Resources;
    using NLog;
    #endregion

    /// <summary>
    /// Interaktionslogik für DavInputbox.xaml
    /// </summary>
    public partial class DavInputbox : UserControl
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

        public DavInputbox()
        {
            openEditorCommand = new RelayCommand((o) =>
            {
                if (o is LuiInputGroup inputGroup)
                {
                    var hwnd = (int)(this.GetValue(ThemeProperties.HwndProperty) ?? 0);
                    Text = ExpressionEditor.ShowModal(Text, hwnd);
                }
            });
            InitializeComponent();
        }

        #region Text - DP
        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
         "Text", typeof(string), typeof(DavInputbox), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region IsInputEnabled - DP
        public bool IsInputEnabled
        {
            get { return (bool)this.GetValue(IsInputEnabledProperty); }
            set { this.SetValue(IsInputEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsInputEnabledProperty = DependencyProperty.Register(
         "IsInputEnabled", typeof(bool), typeof(DavInputbox), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region LabelText - DP
        public string LabelText
        {
            get { return (string)this.GetValue(LabelTextProperty); }
            set { this.SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
         "LabelText", typeof(string), typeof(DavInputbox), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region RightCommandForeground - DP
        public Brush RightCommandForeground
        {
            get { return (Brush)this.GetValue(RightCommandForegroundProperty); }
            set { this.SetValue(RightCommandForegroundProperty, value); }
        }

        public static readonly DependencyProperty RightCommandForegroundProperty = DependencyProperty.Register(
         "RightCommandForeground", typeof(Brush), typeof(DavInputbox), new FrameworkPropertyMetadata(LuiPalette.Brushes.GRAYSCALE30, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        private ICommand openEditorCommand;
        public ICommand OpenEditorCommand
        {
            get
            {
                return openEditorCommand;
            }
            set
            {
                if (openEditorCommand != value)
                {
                    openEditorCommand = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
