namespace daVinci.ConfigData.TableConfigurations
{
    using Newtonsoft.Json.Linq;
    #region Usings
    using NLog;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class MaxRowsData : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion
        private static Logger logger = LogManager.GetCurrentClassLogger();


        #region Properties & Variables
        private string maxRows;
        public string MaxRows
        {
            get
            {
                return maxRows;
            }
            set
            {
                if (maxRows != value)
                {
                    maxRows = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        public void ReadFromJSON(dynamic jsonConfig)
        {
            try
            {
                MaxRows = jsonConfig?.q2g?.maxrows ?? "1000000";
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
                logger.Trace($"JSON:{jsonConfig?.ToString() ?? ""}");
            }
        }

        public void SaveToJSON(dynamic jsonConfig)
        {
            try
            {
                jsonConfig.q2g.maxrows = maxRows;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
    }
}
