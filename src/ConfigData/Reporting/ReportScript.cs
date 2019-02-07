namespace daVinci.ConfigData.Reporting
{
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    #endregion

    public class ReportScript : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & Variables
        private string scriptName;
        public string ScriptName
        {
            get
            {
                return scriptName;
            }
            set
            {
                if (scriptName != value)
                {
                    scriptName = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string scriptID;
        public string ScriptID
        {
            get
            {
                return scriptID;
            }
            set
            {
                if (scriptID != value)
                {
                    scriptID = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string scriptText;
        public string ScriptText
        {
            get
            {
                return scriptText;
            }
            set
            {
                if (scriptText != value)
                {
                    scriptText = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string signatedCode;
        public string SignatedCode
        {
            get
            {
                return signatedCode;
            }
            set
            {
                if (signatedCode != value)
                {
                    signatedCode = value;
                    RaisePropertyChanged();
                }
            }
        }
        private ReportScriptType scriptType;
        public ReportScriptType ScriptType
        {
            get
            {
                return scriptType;
            }
            set
            {
                if (scriptType != value)
                {
                    scriptType = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region static Functions
        public static void GetDiffernetScripts(IEnumerable<ReportScript> list1, IEnumerable<ReportScript> list2, out List<ReportScript> onlyInList1, out List<ReportScript> onlyInList2, out List<ReportScript> changed)
        {
            List<ReportScript> outOnlyInList1 = new List<ReportScript>();
            List<ReportScript> outOnlyInList2 = new List<ReportScript>();
            List<ReportScript> outchanged = new List<ReportScript>();
            foreach (var item in list1)
            {
                var cmbScript = list2.FirstOrDefault(ele => ele.ScriptID == item.ScriptID);
                if (cmbScript == null)
                {
                    outOnlyInList1.Add(item);
                }
                else
                {
                    if (item.SignatedCode != cmbScript.SignatedCode
                        || item.ScriptName != cmbScript.ScriptName
                        || item.ScriptText != cmbScript.ScriptText)
                    {
                        outchanged.Add(item);
                    }
                }
            }
            foreach (var item in list2)
            {
                if (!list1.Any(ele => ele.ScriptID == item.ScriptID))
                    outOnlyInList2.Add(item);
            }

            onlyInList1 = outOnlyInList1;
            onlyInList2 = outOnlyInList2;
            changed = outchanged;
        }
        #endregion
    }
}
