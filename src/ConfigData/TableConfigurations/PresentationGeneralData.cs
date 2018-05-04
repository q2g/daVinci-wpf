namespace daVinci.ConfigData
{
    #region Usings
    using System.ComponentModel; 
    #endregion

    public class PresentationGeneralData : INotifyPropertyChanged
    {
        public PresentationGeneralData()
        {
            if (PropertyChanged != null) {/* Make the Compiler Happy */ }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
