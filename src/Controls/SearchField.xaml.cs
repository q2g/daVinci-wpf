namespace daVinci.Controls
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaktionslogik für SearchField.xaml
    /// </summary>
    public partial class SearchField : UserControl
    {
        public SearchField()
        {
            InitializeComponent();
        }

        #region Autofocus - DP
        public bool Autofocus
        {
            get { return (bool)this.GetValue(AutofocusProperty); }
            set { this.SetValue(AutofocusProperty, value); }
        }

        public static readonly DependencyProperty AutofocusProperty = DependencyProperty.Register(
         "Autofocus", typeof(bool), typeof(SearchField), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
