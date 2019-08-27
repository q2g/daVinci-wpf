namespace daVinci.Controls
{
    #region Usings
    using daVinci.ConfigData.Connection;
    using daVinci.ConfigData.Version;
    using leonardo.AttachedProperties;
    using leonardo.Resources;
    using NLog;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für Versionlist.xaml
    /// </summary>
    public partial class Versionlist : UserControl, INotifyPropertyChanged
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

        #region ctor
        public Versionlist()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties & Variables
        public ObservableCollection<XllVersion> Versions { get; set; } = new ObservableCollection<XllVersion>();
        #endregion

    }

    public class VersionsRoomFilter : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            if (data is XllVersion ver)
                return (ver.Room + "") == (searchString + "");
            return false;
        }
    }
}
