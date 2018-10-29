namespace daVinci.ConfigData.TableConfigurations
{

    #region MyRegion
    using leonardo.Resources;
    using Newtonsoft.Json.Linq;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class ColumnData : INotifyPropertyChanged, IHasSortCriteria
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Properties & Variables
        private bool isExpression;
        public bool IsExpression
        {
            get
            {
                return isExpression;
            }
            set
            {
                if (isExpression != value)
                {
                    isExpression = value;
                    RaisePropertyChanged();
                }
            }
        }

        private DimensionMeasure dimensionMeasure;
        public DimensionMeasure DimensionMeasure
        {
            get
            {
                return dimensionMeasure;
            }
            set
            {
                if (dimensionMeasure != value)
                {
                    dimensionMeasure = value;
                    RaisePropertyChanged();
                }
            }
        }

        private PivotType pivotType;
        public PivotType PivotType
        {
            get
            {
                return pivotType;
            }
            set
            {
                if (pivotType != value)
                {
                    pivotType = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string libraryID;
        public string LibraryID
        {
            get
            {
                return libraryID;
            }
            set
            {
                if (libraryID != value)
                {
                    libraryID = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string fieldDef;
        public string FieldDef
        {
            get
            {
                return fieldDef;
            }
            set
            {
                if (fieldDef != value)
                {
                    fieldDef = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string fieldLabel;
        public string FieldLabel
        {
            get
            {
                return fieldLabel;
            }
            set
            {
                if (fieldLabel != value)
                {
                    fieldLabel = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string backgroundColorExpression;
        public string BackgroundColorExpression
        {
            get
            {
                return backgroundColorExpression;
            }
            set
            {
                if (backgroundColorExpression != value)
                {
                    backgroundColorExpression = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string textColorExpression;
        public string TextColorExpression
        {
            get
            {
                return textColorExpression;
            }
            set
            {
                if (textColorExpression != value)
                {
                    textColorExpression = value;
                    RaisePropertyChanged();
                }
            }
        }

        private SortCriteria sortCriterias = new SortCriteria();
        public SortCriteria SortCriterias
        {
            get { return sortCriterias; }
            set
            {
                if (sortCriterias != value)
                {
                    sortCriterias = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool textAllignment;
        public bool TextAllignment
        {
            get
            {
                return textAllignment;
            }
            set
            {
                if (textAllignment != value)
                {
                    textAllignment = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int allignmentIndex;
        public int AllignmentIndex
        {
            get
            {
                return allignmentIndex;
            }
            set
            {
                if (allignmentIndex != value)
                {
                    allignmentIndex = value;
                    RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region public functions
        public virtual void ReadBaseDataFromJSON(dynamic jsonConfig)
        {
            string libid = jsonConfig?.qLibraryId ?? "";
            if (string.IsNullOrEmpty(libid))
            {
                IsExpression = true;
            }
            else
            {
                LibraryID = libid;
            }

            if ((jsonConfig?.qAttributeExpressions?.Count ?? 0) > 0)
            {
                BackgroundColorExpression = jsonConfig?.qAttributeExpressions[0]?.qExpression ?? "";
            }
            if ((jsonConfig?.qAttributeExpressions?.Count ?? 0) > 1)
            {
                TextColorExpression = jsonConfig?.qAttributeExpressions[1]?.qExpression ?? "";
            }

            TextAllignment = jsonConfig?.qDef?.textAlign?.auto ?? false;
            AllignmentIndex = (jsonConfig?.qDef?.textAlign?.align ?? "left") == "left" ? 0 : 1;
        }
        public dynamic SaveBaseDataToJson()
        {
            dynamic jsonConfig = new JObject();

            jsonConfig.qDef = new JObject();

            if (!IsExpression && !string.IsNullOrEmpty(DimensionMeasure?.LibID?.ToString() ?? ""))
                jsonConfig.qLibraryId = DimensionMeasure?.LibID?.ToString() ?? "";

            jsonConfig.qAttributeExpressions = new JArray();
            if (!string.IsNullOrEmpty(BackgroundColorExpression))
            {
                dynamic expr = new JObject();
                expr.qExpression = BackgroundColorExpression;
                jsonConfig.qAttributeExpressions.Add(expr);
            }
            if (!string.IsNullOrEmpty(TextColorExpression))
            {
                dynamic expr = new JObject();
                expr.qExpression = TextColorExpression;
                jsonConfig.qAttributeExpressions.Add(expr);
            }

            jsonConfig.qDef.textAlign = new JObject();
            if (TextAllignment)
                jsonConfig.qDef.textAlign.auto = TextAllignment;
            if (AllignmentIndex != 0)
                jsonConfig.qDef.textAlign.align = AllignmentIndex == 0 ? "left" : "right";

            return jsonConfig;
        }
        #endregion
    }
}
