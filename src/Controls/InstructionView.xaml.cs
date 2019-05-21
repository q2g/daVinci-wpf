namespace daVinci.Controls
{
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    #endregion

    /// <summary>
    /// Interaktionslogik für InstructionView.xaml
    /// </summary>
    public partial class InstructionView : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public InstructionView()
        {
            InitializeComponent();
        }

        #region Properties & Variables
        private BitmapImage helpImage;
        public BitmapImage HelpImage
        {
            get
            {
                return helpImage;
            }
            set
            {
                if (helpImage != value)
                {
                    helpImage = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion


    }
}
