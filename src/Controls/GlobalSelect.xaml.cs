namespace daVinci.Controls
{
    #region Usings
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using System.Windows.Input;
    using leonardo.Resources;

    #endregion
    /// <summary>
    /// Interaktionslogik für GlobalSelect.xaml
    /// </summary>
    public partial class GlobalSelect : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public GlobalSelect()
        {
            ToggleShortStatelistCommand = new RelayCommand(() =>
            {
                ShortStateList = !ShortStateList;
            });
            InitializeComponent();
        }

        #region Properties & Variables
        private bool shortStateList = true;
        public bool ShortStateList
        {
            get { return shortStateList; }
            set
            {
                shortStateList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand ToggleShortStatelistCommand { get; set; }
        #endregion
    }
}
