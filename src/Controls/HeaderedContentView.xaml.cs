namespace daVinci.Controls
{
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für HeaderedContentView.xaml
    /// </summary>
    public partial class HeaderedContentView : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public HeaderedContentView()
        {
            InitializeComponent();
        }

        #region Properties & Variables
        private string headerText;
        public string HeaderText
        {
            get
            {
                return headerText;
            }
            set
            {
                if (value != headerText)
                {
                    headerText = value;
                    RaisePropertyChanged();
                }
            }
        }
        private object contentControl;
        public object ContentControl
        {
            get
            {
                return contentControl;
            }
            set
            {
                if (value != contentControl)
                {
                    contentControl = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion
    }
}
