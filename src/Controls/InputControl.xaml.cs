namespace daVinci.Controls
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaktionslogik für InputControl.xaml
    /// </summary>
    public partial class InputControl : UserControl
    {
        public InputControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Properties & Variables
        public string Message { get; set; }
        public string Text { get; set; }
        #endregion
    }
}
