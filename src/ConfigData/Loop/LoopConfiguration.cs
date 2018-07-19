namespace daVinci.ConfigData.Loop
{
    using leonardo.Resources;
    #region Usings
    using NLog;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class LoopConfiguration : INotifyPropertyChanged
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

        #region Properties & Variables
        private bool exportRootNode = true;
        public bool ExportRootNode
        {
            get => exportRootNode;
            set
            {
                if (exportRootNode != value)
                {
                    exportRootNode = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string sheetNameExpression;
        public string SheetNameExpression
        {
            get => sheetNameExpression;
            set
            {
                if (sheetNameExpression != value)
                {
                    sheetNameExpression = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool enableExpression;
        public bool EnableExpression
        {
            get => enableExpression;
            set
            {
                if (enableExpression != value)
                {
                    enableExpression = value;
                    RaisePropertyChanged();
                }
            }
        }
        private DimensionMeasure loopOver;
        public DimensionMeasure LoopOver
        {
            get => loopOver;
            set
            {
                if (loopOver != value)
                {
                    loopOver = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

    }
}
