namespace daVinci.Controls
{
    #region Usings
    using ICSharpCode.AvalonEdit;
    using ICSharpCode.AvalonEdit.CodeCompletion;
    using ICSharpCode.AvalonEdit.Folding;
    using ICSharpCode.AvalonEdit.Highlighting;
    using ICSharpCode.AvalonEdit.Highlighting.Xshd;
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Xml;
    #endregion

    /// <summary>
    /// Interaktionslogik für CodeEditor.xaml
    /// </summary>
    public partial class CodeEditor : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises a new <see cref="E:INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables & Properties
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public RelayCommand UnComment { get; private set; }
        public RelayCommand Redo { get; private set; }
        public RelayCommand Undo { get; private set; }

        public RelayCommand<CodeTab> RemoveTabCommand { get; private set; }
        public RelayCommand AddTabCommand { get; private set; }

        public RelayCommand Indent { get; private set; }
        public RelayCommand Outdent { get; private set; }

        private string code;
        public string Code
        {
            get
            {
                return codeTabs.CombinedCode();
            }
            set
            {
                if (value != code)
                {
                    code = value;
                    codeTabs.Clear();
                    foreach (var item in CodeTab.ParseCode(code))
                        codeTabs.Add(item);

                    RaisePropertyChanged(nameof(Code));
                    RaisePropertyChanged(nameof(CodeTabs));
                    Selected = CodeTabs.FirstOrDefault();
                }
            }
        }

        private ObservableCollection<CodeTab> codeTabs = new ObservableCollection<CodeTab>();
        public ObservableCollection<CodeTab> CodeTabs
        {
            get
            {
                return codeTabs;
            }
        }

        public string Text
        {
            get { return TextEditor.Text; }
        }

        private CodeTab selected = null;
        public CodeTab Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (value != selected)
                {
                    SelectedCodeTab = value;
                    if (selected != null)
                    {
                        selected.Code = TextEditor.Text;
                    }

                    selected = value;
                    RaisePropertyChanged(nameof(Selected));
                    if (value != null)
                    {
                        TextEditor.Text = value.Code;
                    }
                    else
                        TextEditor.Text = "";
                }
            }
        }
        #endregion

        #region SelectedCodeTab - DP        
        public CodeTab SelectedCodeTab
        {
            get { return (CodeTab)this.GetValue(SelectedCodeTabProperty); }
            set { this.SetValue(SelectedCodeTabProperty, value); }
        }

        public static readonly DependencyProperty SelectedCodeTabProperty = DependencyProperty.Register(
         "SelectedCodeTab", typeof(CodeTab), typeof(CodeEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region HighlightingLanguage - DP        
        public string HighlightingLanguage
        {
            get { return (string)this.GetValue(HighlightingLanguageProperty); }
            set { this.SetValue(HighlightingLanguageProperty, value); }
        }

        public static readonly DependencyProperty HighlightingLanguageProperty = DependencyProperty.Register(
         "HighlightingLanguage", typeof(string), typeof(CodeEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback((d, e) =>
         {
             try
             {
                 if (d is CodeEditor obj)
                 {
                     if (e.NewValue is string highlightingLanguage)
                     {
                         if (!string.IsNullOrEmpty(highlightingLanguage))
                         {
                             var typeConverter = new HighlightingDefinitionTypeConverter();
                             obj.TextEditor.SyntaxHighlighting = (IHighlightingDefinition)typeConverter.ConvertFrom(highlightingLanguage);
                         }
                     }
                 }
             }
             catch (Exception ex)
             {
                 logger.Error(ex);
             }
         })));
        #endregion

        #region CodeTabsItemsSource - DP        
        public ObservableCollection<CodeTab> CodeTabsItemsSource
        {
            get { return (ObservableCollection<CodeTab>)this.GetValue(CodeTabsItemsSourceProperty); }
            set { this.SetValue(CodeTabsItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty CodeTabsItemsSourceProperty = DependencyProperty.Register(
         "CodeTabsItemsSource", typeof(ObservableCollection<CodeTab>), typeof(CodeEditor), new FrameworkPropertyMetadata(new ObservableCollection<CodeTab>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback((d, e) =>
           {
               try
               {
                   if (d is CodeEditor obj)
                   {
                       if (e.NewValue is ObservableCollection<CodeTab> newvalue)
                       {
                           obj.codeTabs = newvalue;
                           obj.RaisePropertyChanged("CodeTabs");
                       }
                   }
               }
               catch (Exception ex)
               {
                   logger.Error(ex);
               }
           })));
        #endregion

        #region Constructor
        public CodeEditor()
        {
            InitializeComponent();
            this.DataContext = this;

            #region Redo & Undo
            Redo = new RelayCommand(() => { TextEditor.Redo(); }, () => { return TextEditor.CanRedo; });

            Undo = new RelayCommand(() => { TextEditor.Undo(); }, () => { return TextEditor.CanUndo; });
            #endregion

            #region Add / Remove Tab Command
            AddTabCommand = new RelayCommand(() =>
            {
                var ct = new CodeTab() { Name = "Region" };

                if (Selected != null)
                {
                    codeTabs.Insert(codeTabs.IndexOf(Selected) + 1, ct);
                }
                else
                    codeTabs.Add(ct);

                Selected = ct;
            });

            RemoveTabCommand = new RelayCommand<CodeTab>((ct) =>
            {
                var idx = codeTabs.IndexOf(ct);

                CodeTabs.Remove(ct);
                try
                {
                    if (idx >= codeTabs.Count)
                        idx--;

                    if (idx >= 0)
                        Selected = codeTabs[idx];
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            });
            #endregion

            #region Indent & Outdent
            Indent = new RelayCommand(() =>
            {
                try
                {
                    foreach (var item in TextEditor.GetSelectedLineNumbers())
                    {
                        var line = TextEditor.Document.GetLineByNumber(item);
                        TextEditor.Document.Insert(line.Offset, "  ");
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            });

            Outdent = new RelayCommand(() =>
            {
                try
                {
                    foreach (var item in TextEditor.GetSelectedLineNumbers())
                    {
                        var line = TextEditor.Document.GetLineByNumber(item);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }, () => false);
            #endregion

            #region UnComment
            UnComment = new RelayCommand(() =>
            {
                try
                {
                    bool? insert = null;

                    foreach (var item in TextEditor.GetSelectedLineNumbers())
                    {
                        var line = TextEditor.Document.GetLineByNumber(item);

                        if (!insert.HasValue)
                            insert = !TextEditor.Document.Text.Substring(line.Offset, line.Length).Replace("\t", "").Trim().StartsWith("//");

                        if (insert ?? true)
                            TextEditor.Document.Insert(line.Offset, "//");
                        else
                        {
                            // TODO check if alle character before // are space or tab
                            var idx = TextEditor.Document.Text.Substring(line.Offset, line.Length).IndexOf("//");

                            if (idx >= 0)
                                TextEditor.Document.Remove(idx + line.Offset, 2);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            });
            #endregion

            TextEditor.TextArea.TextEntering += TextEditor_TextArea_TextEntering;
            TextEditor.TextArea.TextEntered += TextEditor_TextArea_TextEntered;

            var foldingManager = FoldingManager.Install(TextEditor.TextArea);
            var foldingStrategy = new XmlFoldingStrategy();

            foldingStrategy.UpdateFoldings(foldingManager, TextEditor.Document);
        }

        CompletionWindow completionWindow = null;

        void TextEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (selected != null)
            {
                selected.Code = TextEditor.Text;
            }
            //if (e.Text == ".")
            //{
            //    // Open code completion after the user has pressed dot  :
            //    completionWindow = new CompletionWindow(TextEditor.TextArea);
            //    IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;
            //    data.Add(new MyCompletionData("Item1"));
            //    data.Add(new MyCompletionData("Item2"));
            //    data.Add(new MyCompletionData("Item3"));
            //    completionWindow.Show();
            //    completionWindow.Closed += delegate
            //    {
            //        completionWindow = null;
            //    };
            //}
        }

        void TextEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
            // Do not set e.Handled=true.
            // We still want to insert the character that was typed.
        }

        #endregion
    }

    #region CodeTab
    public static class CodeTabExtensions
    {
        public static string CombinedCode(this IEnumerable<CodeTab> data)
        {
            string result = "";
            foreach (var item in data)
            {
                result += "///$tab " + item.Name + "\r\n" + item.Code;
            }
            return result;
        }
    }

    public class CodeTab : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises a new <see cref="E:INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        private void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variable & Properties
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string id;
        public string ID
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                if (value != code)
                {
                    code = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Helper
        private static string tabRegex = @"///\$tab\s(?<name>.*)\r\n";

        public static IEnumerable<CodeTab> ParseCode(string FullCode)
        {
            var rx = new Regex(tabRegex, RegexOptions.IgnoreCase);

            var mtList = new List<Match>();

            var mt = rx.Matches(FullCode).OfType<Match>().ToList();

            for (int i = 0; i < mt.Count; i++)
            {
                var itm = mt[i];
                int codeStart = itm.Index + itm.Length;
                int codeEnde = FullCode.Length;
                if (i < mt.Count - 1)
                    codeEnde = mt[i + 1].Index;

                yield return new CodeTab() { Name = itm.Groups["name"].Value, Code = FullCode.Substring(codeStart, codeEnde - codeStart) };
            }
        }
        #endregion
    }

    public static class AvalonEditExtensions
    {
        public static List<int> GetSelectedLineNumbers(this ICSharpCode.AvalonEdit.TextEditor textEditor)
        {
            var document = textEditor.Document;

            return (from c in document.Lines
                    where (c.EndOffset >= textEditor.SelectionStart) && (c.Offset <= (textEditor.SelectionStart + textEditor.SelectionLength))
                    select c.LineNumber).ToList();
        }

        public static IHighlightingDefinition AddCustomHighlighting(this TextEditor textEditor, Stream xshdStream)
        {
            if (xshdStream == null)
                throw new InvalidOperationException("Could not find embedded resource");

            IHighlightingDefinition customHighlighting;

            // Load our custom highlighting definition
            using (XmlReader reader = new XmlTextReader(xshdStream))
            {
                customHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
            }

            // And register it in the HighlightingManager
            HighlightingManager.Instance.RegisterHighlighting("Custom Highlighting", null, customHighlighting);

            return customHighlighting;
        }

        public static IHighlightingDefinition AddCustomHighlighting(this TextEditor textEditor, Stream xshdStream, string[] extensions)
        {
            if (xshdStream == null)
                throw new InvalidOperationException("Could not find embedded resource");

            IHighlightingDefinition customHighlighting;

            // Load our custom highlighting definition
            using (XmlReader reader = new XmlTextReader(xshdStream))
            {
                customHighlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);
            }

            // And register it in the HighlightingManager
            HighlightingManager.Instance.RegisterHighlighting("Custom Highlighting", extensions, customHighlighting);

            return customHighlighting;
        }
    }
    #endregion
}
