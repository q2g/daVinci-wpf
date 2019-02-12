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

        #region ExampleScript
        private readonly string exampleScript = @"namespace ScriptDemo
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Aspose.Cells;
    using Ser.Engine.Scripting;
    #endregion

    public class ScriptDemo : ISenseExcelScript
    {
        #region Properties
        public Workbook CurrentWorkbook { get; set; }
        public ScriptLogger Logger { get; set; }
        #endregion

        public void Main(IDictionary<string, ScriptValue> args)
        {
            try
            {
                var firstSheet = CurrentWorkbook.Worksheets.ElementAtOrDefault(0) ?? null;
                if (firstSheet == null)
                {
                    Logger.Error(""The workbook has no sheet."");
                    return;
                }
                //If there is a Variable defined with Name='msg'
                //var msg = args[""msg""].ConvertValueTo<string>();
                //WriteToCell(firstSheet, msg,""A1"");

                //If there is a Variable defined with Name='data'
                //var dd = args[""data""].ConvertValueTo<string>();                    
                //WriteToCell(firstSheet, dd,""A2"");
                //Logger.Info(""Script run successfully"");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ""C# Script failed."");
            }
        }

        private void WriteToCell(Worksheet sheet, string msg, string cellAdress)
        {
            sheet.Cells[cellAdress].Value = msg;
        }
    }
}";
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

            NewVariableCommand = new RelayCommand<KeyValuePair>((newone) =>
            {
                if (newone != null)
                {
                    newone.PropertyChanged += ScriptArg_PropertyChanged;
                    ScriptArgs.Add(newone);
                    WriteBackScriptArgs();
                }
            });
            DeleteVariableCommand = new RelayCommand<KeyValuePair>((toDelete) =>
             {
                 if (toDelete != null)
                 {
                     ScriptArgs.Remove(toDelete);
                     WriteBackScriptArgs();
                 }
             });
            ChangeVariableCommand = new RelayCommand<KeyValuePair>((newone) =>
            {
                if (newone != null)
                {
                    newone.PropertyChanged -= ScriptArg_PropertyChanged;
                    WriteBackScriptArgs();
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
        private ScriptOption scriptoption;
        public ScriptOption Scriptoption
        {
            get { return scriptoption; }
            set
            {
                if (scriptoption != value)
                {
                    scriptoption = value;
                    if (scriptoption != null)
                    {
                        ScriptArgs.Clear();
                        foreach (var item in scriptoption.ScriptArgs)
                        {
                            int equalsIndex = item.IndexOf("=");
                            if (equalsIndex > 0)
                            {
                                var newone = new KeyValuePair()
                                {
                                    Key = item.Substring(0, equalsIndex),
                                    Value = item.Substring(equalsIndex + 1)
                                };
                                newone.PropertyChanged += ScriptArg_PropertyChanged;
                                ScriptArgs.Add(newone);
                            }
                        }
                        RaisePropertyChanged();
                        RaisePropertyChanged(nameof(ScriptArgs));
                    }
                }
            }
        }
        public ObservableCollection<CodeTab> CodeTabs { get; set; }
        public ObservableCollection<KeyValuePair> ScriptArgs { get; set; } = new ObservableCollection<KeyValuePair>();
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
        private bool parameterListVisible;
        public bool ParameterListVisible
        {
            get { return parameterListVisible; }
            set
            {
                if (parameterListVisible != value)
                {
                    parameterListVisible = value;
                    RaisePropertyChanged();
                }
            }
        }
        public ICommand BrowseForKeyCommand { get; set; }
        public ICommand NewVariableCommand { get; set; }
        public ICommand ChangeVariableCommand { get; set; }
        public ICommand DeleteVariableCommand { get; set; }
        public Func<object, object> CopyVariable
        {
            get
            {
                return new Func<object, object>((copyfrom) =>
                {
                    if (copyfrom is KeyValuePair kvpair)
                    {
                        return new KeyValuePair()
                        {
                            Key = kvpair.Key,
                            Value = kvpair.Value
                        };
                    }
                    return null;
                });
            }
        }
        public Func<object> CreateVariable
        {
            get
            {
                return new Func<object>(() =>
                {
                    return new KeyValuePair();
                });
            }
        }
        public KeyValuePairFilter KeyValuePairFilter { get; set; } = new KeyValuePairFilter();
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
                            ScriptText = exampleScript,
                            ScriptType = preSelected ? ReportScriptType.PreScript : ReportScriptType.PostScript

                        };

                        ReportScripts.Add(newone);
                        codeTab.ID = newone.ScriptID;
                        codeTab.Name = newone.ScriptName;
                        codeTab.Code = exampleScript;
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
        private void WriteBackScriptArgs()
        {
            try
            {
                if (scriptoption != null)
                {
                    List<string> args = new List<string>();
                    foreach (var item in ScriptArgs)
                    {
                        var key = item.Key?.Trim();
                        var value = item.Value?.Trim();
                        if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                        {
                            args.Add($"{key}={value}");
                        }
                    }
                    scriptoption.ScriptArgs = args;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void ScriptArg_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            WriteBackScriptArgs();
        }
        #endregion
    }
}
