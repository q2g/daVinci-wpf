namespace daVinci.Components
{

    #region Usings
    using daVinci.ConfigData.Reporting;
    using daVinci.Controls;
    using leonardo.Resources;
    using Microsoft.Win32;
    using NLog;
    using Q2g.HelperPem;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Windows.Controls;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für ReportScriptEditor.xaml
    /// </summary>
    public partial class ReportScriptEditor : UserControl, INotifyPropertyChanged
    {
        #region Logger
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        public ReportScriptEditor()
        {
            BrowseForKeyCommand = new RelayCommand((o) =>
            {
                try
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    if (dlg.ShowDialog() == true)
                    {
                        var file = dlg.FileName;
                        if (File.Exists(file))
                        {
                            pemSigner = new PemSigner(file);
                            RaisePropertyChanged(nameof(IsPublicKeyChoosen));
                            foreach (var script in reportScripts)
                            {
                                var content = script.ScriptText;
                                //importent for xml content!!!
                                content = content.Replace("\r\n", "\n").Trim();
                                string signedCode = pemSigner.SignWithPrivateKey(content);
                                script.SignatedCode = signedCode;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            });

            CodeTabs = new ObservableCollection<CodeTab>();
            (CodeTabs as INotifyCollectionChanged).CollectionChanged += CodeTabs_CollectionChanged;

            InitializeComponent();
        }



        #region Properties & Variales
        private List<ReportScript> reportScripts;
        public List<ReportScript> ReportScripts
        {
            get { return reportScripts; }
            set
            {
                if (value != null)
                {
                    reportScripts = value;
                    RefreshCodetabs();
                }
                else
                {
                    var iterateover = CodeTabs.ToList();
                    foreach (var item in iterateover)
                    {
                        CodeTabs.Remove(item);
                    }

                }
            }
        }
        public ObservableCollection<CodeTab> CodeTabs { get; set; }
        private ReportScript selectedReportScript;
        public ReportScript SelectedReportScript
        {
            get
            {
                return selectedReportScript;
            }
            set
            {
                if (selectedReportScript != value)
                {
                    selectedReportScript = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(BrowseForKeyCommand));
                }
            }
        }
        public ICommand BrowseForKeyCommand { get; set; }
        private CodeTab selectedCodeTab;
        public CodeTab SelectedCodeTab
        {
            get
            {
                return selectedCodeTab;
            }
            set
            {
                if (selectedCodeTab != value)
                {
                    selectedCodeTab = value;
                    if (selectedCodeTab != null)
                    {
                        ReportScript script = ReportScripts.FirstOrDefault(ele => ele.ScriptID == selectedCodeTab.ID);
                        SelectedReportScript = script;
                    }
                    else
                    {
                        SelectedReportScript = null;
                    }
                    RaisePropertyChanged();
                }
            }
        }
        public bool IsPublicKeyChoosen
        {
            get { return pemSigner != null; }
        }
        private PemSigner pemSigner;
        private bool preSelected;
        public bool PreSelected
        {
            get { return preSelected; }
            set
            {
                if (preSelected != value)
                {
                    preSelected = value;
                    RefreshCodetabs();
                }
            }
        }
        private bool postSelected = true;
        public bool PostSelected
        {
            get { return postSelected; }
            set
            {
                if (postSelected != value)
                {
                    postSelected = value;
                    RefreshCodetabs();
                }
            }
        }
        #endregion

        #region private Functions
        private void CodeTab_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is CodeTab codeTab)
            {
                ReportScript script = ReportScripts.FirstOrDefault(ele => ele.ScriptID == codeTab.ID);
                if (script != null)
                {
                    switch (e.PropertyName)
                    {
                        case nameof(CodeTab.Name):
                            script.ScriptName = codeTab.Name;
                            break;
                        case nameof(CodeTab.Code):
                            script.ScriptText = codeTab.Code;
                            if (pemSigner != null)
                            {
                                var content = script.ScriptText;
                                //importent for xml content!!!
                                content = content.Replace("\r\n", "\n").Trim();
                                string signedCode = pemSigner.SignWithPrivateKey(content);
                                script.SignatedCode = signedCode;
                            }
                            else
                            {
                                script.SignatedCode = "";
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void RefreshCodetabs()
        {
            var tmptabs = CodeTabs.ToList();
            (CodeTabs as INotifyCollectionChanged).CollectionChanged -= CodeTabs_CollectionChanged;
            foreach (var item in tmptabs)
            {
                item.PropertyChanged -= CodeTab_PropertyChanged;
                CodeTabs.Remove(item);
            }
            (CodeTabs as INotifyCollectionChanged).CollectionChanged += CodeTabs_CollectionChanged;

            foreach (var item in reportScripts)
            {
                if (preSelected && item.ScriptType == ReportScriptType.PreScript
                    || PostSelected && item.ScriptType == ReportScriptType.PostScript)
                {
                    CodeTabs.Add(new CodeTab()
                    {
                        Code = item.ScriptText,
                        ID = item.ScriptID,
                        Name = item.ScriptName
                    });
                }
            }
        }
        private void CodeTabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
            if (e.NewItems != null)
            {
                foreach (CodeTab codeTab in e.NewItems)
                {
                    if (string.IsNullOrEmpty(codeTab.ID))
                    {
                        var guid = Guid.NewGuid();
                        var newone = new ReportScript()
                        {
                            ScriptID = guid.ToString(),
                            ScriptName = "Unnamed",
                            ScriptType = preSelected ? ReportScriptType.PreScript : ReportScriptType.PostScript

                        };

                        ReportScripts.Add(newone);
                        codeTab.ID = newone.ScriptID;
                        codeTab.Name = newone.ScriptName;
                    }
                    codeTab.PropertyChanged += CodeTab_PropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (CodeTab codeTab in e.OldItems)
                {
                    codeTab.PropertyChanged -= CodeTab_PropertyChanged;
                    var toRemove = ReportScripts.First(ele => ele.ScriptID == codeTab.ID);
                    if (toRemove != null)
                    {
                        reportScripts.Remove(toRemove);
                    }
                }
            }
        }
        #endregion
    }
}
