namespace daVinci.ConfigData.Reporting
{
    #region Usings
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class ScriptOption : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & Variables
        private string input;
        public string Input
        {
            get
            {
                return input;
            }
            set
            {
                if (input != value)
                {
                    input = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string output;
        public string Output
        {
            get
            {
                return output;
            }
            set
            {
                if (output != value)
                {
                    output = value;
                    RaisePropertyChanged();
                }
            }
        }
        private List<string> scriptKeys = new List<string>();
        public List<string> ScriptKeys
        {
            get
            {
                return scriptKeys;
            }
            set
            {
                if (scriptKeys != value)
                {
                    scriptKeys = value;
                    RaisePropertyChanged();
                }
            }
        }
        private List<string> scriptArgs = new List<string>();
        public List<string> ScriptArgs
        {
            get
            {
                return scriptArgs;
            }
            set
            {
                if (scriptArgs != value)
                {
                    scriptArgs = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region static Functions
        public static bool Different(ScriptOption s1, ScriptOption s2)
        {
            if (s1 != null && s2 != null)
            {
                var s1json = JsonConvert.SerializeObject(s1);
                var s2json = JsonConvert.SerializeObject(s2);
                return s1json != s2json;
            }
            return true;
        }
        #endregion
    }
}
