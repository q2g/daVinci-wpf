using daVinci.ConfigData.TableConfigurations;
using leonardo.Resources;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class DimensionColumnData : INotifyPropertyChanged, IHasSortCriteria
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();


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

        private bool allowNULLValues;
        public bool AllowNULLValues
        {
            get
            {
                return allowNULLValues;
            }
            set
            {
                if (allowNULLValues != value)
                {
                    allowNULLValues = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int limitMode;
        public int LimitModeIndex
        {
            get
            {
                return limitMode;
            }
            set
            {
                if (limitMode != value)
                {
                    limitMode = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///  
        /// fixed ColumnCount
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 
        private int topBottomIndex;
        public int TopBottomIndex
        {
            get
            {
                return topBottomIndex;
            }
            set
            {
                if (topBottomIndex != value)
                {
                    topBottomIndex = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string fixedColumnCountSize;
        public string FixedColumnCountSize
        {
            get
            {
                return fixedColumnCountSize;
            }
            set
            {
                if (fixedColumnCountSize != value)
                {
                    fixedColumnCountSize = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///  
        /// exact Value / relative Value
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 
        private int greatherThanLessThanIndex;
        public int GreatherThanLessThanIndex
        {
            get
            {
                return greatherThanLessThanIndex;
            }
            set
            {
                if (greatherThanLessThanIndex != value)
                {
                    greatherThanLessThanIndex = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string textValue;
        public string TextValue
        {
            get
            {
                return textValue;
            }
            set
            {
                if (textValue != value)
                {
                    textValue = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///  
        /// Others
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 
        private bool showOthers;
        public bool ShowOthers
        {
            get
            {
                return showOthers;
            }
            set
            {
                if (showOthers != value)
                {
                    showOthers = value;
                    RaisePropertyChanged();
                }
            }
        }


        private string othersLabel;
        public string OthersLabel
        {
            get
            {
                return othersLabel;
            }
            set
            {
                if (othersLabel != value)
                {
                    othersLabel = value;
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

        private int representationIndex;
        public int RepresentationIndex
        {
            get
            {
                return representationIndex;
            }
            set
            {
                if (representationIndex != value)
                {
                    representationIndex = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string urlLabel;
        public string UrlLabel
        {
            get
            {
                return urlLabel;
            }
            set
            {
                if (urlLabel != value)
                {
                    urlLabel = value;
                    RaisePropertyChanged();
                }
            }
        }

        public SortCriteria SortCriterias { get; set; }

        public DimensionColumnData()
        {
            SortCriterias = new SortCriteria();
        }

        public void ReadFromJSON(dynamic jsonConfig)
        {
            try
            {
                //libraryID = jsonConfig?.qLibraryId;
                if ((jsonConfig?.qDef?.qFieldDefs?.Count ?? 0) > 0)
                {
                    FieldDef = jsonConfig.qDef.qFieldDefs[0];
                }
                if ((jsonConfig.qDef.qFieldLabels.Count ?? 0) > 0)
                {
                    FieldLabel = jsonConfig.qDef.qFieldLabels[0];
                }
                if ((jsonConfig?.qDef?.qSortCriterias?.Count ?? 0) > 0)
                {
                    SortCriterias.ReadFromJSON(jsonConfig?.qDef?.qSortCriterias[0]);
                    SortCriterias.AutoSort = jsonConfig?.qDef?.autoSort ?? false;
                }

                AllowNULLValues = (jsonConfig?.qNullSuppression ?? false) == false ? true : false;
                switch (jsonConfig?.qOtherTotalSpec?.qOtherMode?.ToString() ?? "OTHER_OFF")
                {
                    case "OTHER_OFF":
                        LimitModeIndex = 0;
                        break;
                    case "OTHER_COUNTED":
                        LimitModeIndex = 1;
                        switch (jsonConfig?.qOtherTotalSpec?.qOtherSortMode?.ToString() ?? "OTHER_SORT_ASCENDING")
                        {
                            case "OTHER_SORT_ASCENDING":
                                TopBottomIndex = 0;
                                break;
                            case "OTHER_SORT_DESCENDING":
                                TopBottomIndex = 1;
                                break;
                            default:
                                TopBottomIndex = 0;
                                break;
                        }
                        FixedColumnCountSize = jsonConfig?.qOtherTotalSpec?.qOtherCounted?.qv ?? "";
                        break;
                    case "OTHER_ABS_LIMITED":
                        LimitModeIndex = 2;
                        TextValue = jsonConfig?.qOtherTotalSpec?.qOtherLimit?.qv ?? "";

                        break;
                    case "OTHER_REL_LIMITED":
                        TextValue = jsonConfig?.qOtherTotalSpec?.qOtherLimit?.qv ?? "";
                        LimitModeIndex = 3;
                        break;
                    default:
                        LimitModeIndex = 0;
                        break;
                }
                switch (jsonConfig?.qOtherTotalSpec?.qOtherMode?.ToString() ?? "")
                {
                    case "OTHER_ABS_LIMITED":
                    case "OTHER_REL_LIMITED":
                        switch (jsonConfig?.qOtherTotalSpec?.qOtherLimitMode?.ToString() ?? "OTHER_GE_LIMIT")
                        {
                            case "OTHER_GE_LIMIT":
                                GreatherThanLessThanIndex = 0;
                                break;
                            case "OTHER_GT_LIMIT":
                                GreatherThanLessThanIndex = 1;
                                break;
                            case "OTHER_LT_LIMIT":
                                GreatherThanLessThanIndex = 2;
                                break;
                            case "OTHER_LE_LIMIT":
                                GreatherThanLessThanIndex = 3;
                                break;
                            default:
                                GreatherThanLessThanIndex = 0;
                                break;
                        }
                        break;
                }


                ShowOthers = (jsonConfig?.qOtherTotalSpec?.qSuppressOther ?? false) == false;
                //OthersLabel = jsonConfig?.qDef?.othersLabel ?? "";
                //OthersLabel = jsonConfig?.qDef?.othersLabel ?? "";
                OthersLabel = !string.IsNullOrEmpty(OthersLabel) ? jsonConfig?.qOtherLabel?.qv ?? "" : "";

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

                RepresentationIndex = (jsonConfig?.qDef?.representation?.type ?? "text") == "text" ? 0 : 1;
                UrlLabel = jsonConfig?.qDef?.representation?.urlLabel ?? "";
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }

        public dynamic SaveToJson()
        {
            try
            {
                dynamic jsonConfig = new JObject();
                //jsonConfig.qLibraryId = LibraryID;
                jsonConfig.qDef = new JObject();
                jsonConfig.qDef.qFieldDefs = new JArray();
                jsonConfig.qDef.qFieldDefs.Add(FieldDef);
                jsonConfig.qDef.qFieldLabels = new JArray();
                jsonConfig.qDef.qFieldLabels.Add(FieldLabel);
                jsonConfig.qDef.qSortCriterias = new JArray();
                jsonConfig.qDef.qSortCriterias.Add(SortCriterias.SaveToJSON());
                jsonConfig.qDef.autoSort = SortCriterias.AutoSort;
                jsonConfig.qNullSuppression = !AllowNULLValues;

                jsonConfig.qOtherTotalSpec = new JObject();
                switch (LimitModeIndex)
                {
                    case 0:
                        jsonConfig.qOtherTotalSpec.qOtherMode = "OTHER_OFF";
                        switch (TopBottomIndex)
                        {
                            case 0:
                                jsonConfig.qOtherTotalSpec.qOtherSortMode = "OTHER_SORT_ASCENDING";
                                break;
                            case 1:
                                jsonConfig.qOtherTotalSpec.qOtherSortMode = "OTHER_SORT_DESCENDING";
                                break;
                            default:
                                break;
                        }

                        break;
                    case 1:
                        jsonConfig.qOtherTotalSpec.qOtherMode = "OTHER_COUNTED";
                        break;
                    case 2:
                        jsonConfig.qOtherTotalSpec.qOtherMode = "OTHER_ABS_LIMITED";
                        break;
                    case 3:
                        jsonConfig.qOtherTotalSpec.qOtherMode = "OTHER_REL_LIMITED";
                        break;
                    default:
                        jsonConfig.qOtherTotalSpec.qOtherMode = "OTHER_OFF";
                        break;
                }

                switch (LimitModeIndex)
                {
                    case 2:
                    case 3:
                        switch (GreatherThanLessThanIndex)
                        {
                            case 0:
                                jsonConfig.qOtherTotalSpec.qOtherLimitMode = "OTHER_GE_LIMIT";
                                break;
                            case 1:
                                jsonConfig.qOtherTotalSpec.qOtherLimitMode = "OTHER_GT_LIMIT";
                                break;
                            case 2:
                                jsonConfig.qOtherTotalSpec.qOtherLimitMode = "OTHER_LT_LIMIT";
                                break;
                            case 3:
                                jsonConfig.qOtherTotalSpec.qOtherLimitMode = "OTHER_LE_LIMIT";
                                break;
                            default:
                                jsonConfig.qOtherTotalSpec.qOtherLimitMode = "";
                                break;
                        }
                        break;
                    default:
                        break;
                }



                jsonConfig.qOtherTotalSpec.qSuppressOther = !ShowOthers;
                jsonConfig.qDef.othersLabel = OthersLabel;
                jsonConfig.qAttributeExpressions = new JArray();
                dynamic expr = new JObject();
                expr.qExpression = BackgroundColorExpression;
                jsonConfig.qAttributeExpressions.Add(expr);
                expr = new JObject();
                expr.qExpression = TextColorExpression;
                jsonConfig.qAttributeExpressions.Add(expr);

                jsonConfig.qDef.textAlign = new JObject();
                jsonConfig.qDef.textAlign.auto = TextAllignment;
                jsonConfig.qDef.textAlign.align = AllignmentIndex == 0 ? "left" : "right";

                jsonConfig.qDef.representation = new JObject();
                jsonConfig.qDef.representation.type = RepresentationIndex == 0 ? "text" : "url";
                jsonConfig.qDef.representation.urlLabel = UrlLabel;

                return jsonConfig;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
                return new JObject();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
