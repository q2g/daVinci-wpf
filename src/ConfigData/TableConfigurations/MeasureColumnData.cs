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
    public class MeasureColumnData : INotifyPropertyChanged, IHasSortCriteria
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

        private int numberFormatIndex;
        public int NumberFormatIndex
        {
            get
            {
                return numberFormatIndex;
            }
            set
            {
                if (numberFormatIndex != value)
                {
                    numberFormatIndex = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///  
        /// Number
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 

        private bool isStandardFormat;
        public bool IsStandardFormat
        {
            get
            {
                return isStandardFormat;
            }
            set
            {
                if (isStandardFormat != value)
                {
                    isStandardFormat = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int standardFormatIndex;
        public int StandardFormatIndex
        {
            get
            {
                return standardFormatIndex;
            }
            set
            {
                if (standardFormatIndex != value)
                {
                    standardFormatIndex = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string numberFormatText;
        public string NumberFormatText
        {
            get
            {
                return numberFormatText;
            }
            set
            {
                if (numberFormatText != value)
                {
                    numberFormatText = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///  
        /// Currency
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 
        private string currencyFormatText;
        public string CurrencyFormatText
        {
            get
            {
                return currencyFormatText;
            }
            set
            {
                if (currencyFormatText != value)
                {
                    currencyFormatText = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///  
        /// Date
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 
        private bool isStandardDateFormat;
        public bool IsStandardDateFormat
        {
            get
            {
                return isStandardDateFormat;
            }
            set
            {
                if (isStandardDateFormat != value)
                {
                    isStandardDateFormat = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int dateStandardFormatIndex;
        public int DateStandardFormatIndex
        {
            get
            {
                return dateStandardFormatIndex;
            }
            set
            {
                if (dateStandardFormatIndex != value)
                {
                    dateStandardFormatIndex = value;
                    if (DateToIndex.ContainsKey(value))
                    {
                        DateFormatText = DateToIndex[value];
                    }
                    RaisePropertyChanged();
                }
            }
        }

        private string dateFormatText;
        public string DateFormatText
        {
            get
            {
                return dateFormatText;
            }
            set
            {
                if (dateFormatText != value)
                {
                    dateFormatText = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///  
        /// Duration
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 
        private string durationFormatText;
        public string DurationFormatText
        {
            get
            {
                return durationFormatText;
            }
            set
            {
                if (durationFormatText != value)
                {
                    durationFormatText = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// ///  
        /// Custom
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 

        private string customNumberFormatText;
        public string CustomNumberFormatText
        {
            get
            {
                return customNumberFormatText;
            }
            set
            {
                if (customNumberFormatText != value)
                {
                    customNumberFormatText = value;
                    RaisePropertyChanged();
                }
            }
        }


        private string dec_SplitterSign;
        public string Dec_SplitterSign
        {
            get
            {
                return dec_SplitterSign;
            }
            set
            {
                if (dec_SplitterSign != value)
                {
                    dec_SplitterSign = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string thou_SplitterSign;
        public string Thou_SplitterSign
        {
            get
            {
                return thou_SplitterSign;
            }
            set
            {
                if (thou_SplitterSign != value)
                {
                    thou_SplitterSign = value;
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

        private int totalValueFunctionIndex;
        public int TotalValueFunctionIndex
        {
            get
            {
                return totalValueFunctionIndex;
            }
            set
            {
                if (totalValueFunctionIndex != value)
                {
                    totalValueFunctionIndex = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool isTotalValueSettingsTextVisible;
        public bool IsTotalValueSettingsTextVisible
        {
            get
            {
                return isTotalValueSettingsTextVisible;
            }
            set
            {
                if (isTotalValueSettingsTextVisible != value)
                {
                    isTotalValueSettingsTextVisible = value;
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

        public void ReadFromJSON(dynamic jsonConfig)
        {
            try
            {
                //libraryID = jsonConfig?.qLibraryId;
                fieldDef = jsonConfig?.qDef?.qDef ?? "";
                fieldLabel = jsonConfig?.qDef?.qLabel ?? "";

                SortCriterias.ReadFromJSON(jsonConfig?.qSortBy);
                SortCriterias.AutoSort = jsonConfig?.autoSort ?? false;

                switch (jsonConfig?.qDef?.qNumFormat?.qType?.ToString() ?? "U")
                {
                    case "U":
                        NumberFormatIndex = 0;
                        break;
                    case "F":
                        NumberFormatIndex = 1;
                        IsStandardFormat = jsonConfig?.qDef?.numFormatFromTemplate ?? false;
                        string value = jsonConfig?.qDef?.qNumFormat?.qFmt?.ToString() ?? "#,##0.0";
                        switch (value?.ToString())
                        {
                            case "0.00%":
                                StandardFormatIndex = 5;
                                break;
                            case "0.0%":
                                StandardFormatIndex = 4;
                                break;
                            case "0%":
                                StandardFormatIndex = 3;
                                break;
                            case "#,##0.00":
                                StandardFormatIndex = 2;
                                break;
                            case "#,##0.0":
                                StandardFormatIndex = 1;
                                break;
                            case "#,##0":
                                StandardFormatIndex = 0;
                                break;
                            default:
                                break;
                        }
                        NumberFormatText = jsonConfig?.qDef?.qNumFormat?.qFmt ?? "";
                        break;
                    case "M":
                        NumberFormatIndex = 2;
                        CurrencyFormatText = jsonConfig?.qDef?.qNumFormat?.qFmt ?? "";
                        break;
                    case "D":
                        IsStandardDateFormat = jsonConfig?.qDef?.numFormatFromTemplate ?? false;
                        DateFormatText = jsonConfig?.qDef?.qNumFormat?.qFmt ?? "";
                        NumberFormatIndex = 3;
                        value = jsonConfig?.qDef?.qNumFormat?.qFmt?.ToString() ?? "#,##0.0";
                        DateStandardFormatIndex = DateToIndex.Where(ele => ele.Value == value).DefaultIfEmpty(new KeyValuePair<int, string>(0, "notUsed")).Single().Key;
                        break;
                    case "IV":
                        DurationFormatText = jsonConfig?.qDef?.qNumFormat?.qFmt ?? "";
                        NumberFormatIndex = 4;
                        break;
                    case "R":
                        CustomNumberFormatText = jsonConfig?.qDef?.qNumFormat?.qFmt ?? "";
                        Dec_SplitterSign = jsonConfig?.qDef?.qNumFormat?.qDec ?? ".";
                        Thou_SplitterSign = jsonConfig?.qDef?.qNumFormat?.qThou ?? ",";
                        NumberFormatIndex = 5;
                        break;
                    default:
                        break;
                }

                if ((jsonConfig?.qAttributeExpressions?.Count ?? 0) > 0)
                {
                    BackgroundColorExpression = jsonConfig?.qAttributeExpressions[0]?.qExpression ?? "";
                }
                if ((jsonConfig?.qAttributeExpressions?.Count ?? 0) > 1)
                {
                    TextColorExpression = jsonConfig?.qAttributeExpressions[1]?.qExpression ?? "";
                }

                switch (jsonConfig?.qDef?.qAggrFunc?.ToString() ?? "Expr")
                {
                    case "Expr":
                        TotalValueFunctionIndex = 0;
                        break;
                    case "Avg":
                        TotalValueFunctionIndex = 1;
                        break;
                    case "Count":
                        TotalValueFunctionIndex = 2;
                        break;
                    case "Max":
                        TotalValueFunctionIndex = 3;
                        break;
                    case "Min":
                        TotalValueFunctionIndex = 4;
                        break;
                    case "Sum":
                        TotalValueFunctionIndex = 5;
                        break;
                    case "None":
                        TotalValueFunctionIndex = 6;
                        break;
                    default:
                        break;
                }


                IsTotalValueSettingsTextVisible = true;

                TextAllignment = jsonConfig?.qDef?.textAlign?.auto ?? false;
                AllignmentIndex = (jsonConfig?.qDef?.textAlign?.align ?? "left") == "left" ? 0 : 1;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }

        public dynamic SaveToJson()
        {
            dynamic jsonConfig = new JObject();

            try
            {
                //jsonConfig.qLibraryId = libraryID;
                jsonConfig.qDef = new JObject();
                jsonConfig.qDef.qLabel = FieldLabel;
                jsonConfig.qDef.qDef = FieldDef;

                jsonConfig.qSortBy = SortCriterias.SaveToJSON();
                jsonConfig.autosort = SortCriterias.AutoSort;

                switch (TotalValueFunctionIndex)
                {
                    case 0:
                        jsonConfig.qDef.qAggrFunc = "Expr";
                        break;
                    case 1:
                        jsonConfig.qDef.qAggrFunc = "Avg";
                        break;
                    case 2:
                        jsonConfig.qDef.qAggrFunc = "Count";
                        break;
                    case 3:
                        jsonConfig.qDef.qAggrFunc = "Max";
                        break;
                    case 4:
                        jsonConfig.qDef.qAggrFunc = "Min";
                        break;
                    case 5:
                        jsonConfig.qDef.qAggrFunc = "Sum";
                        break;
                    case 6:
                        jsonConfig.qDef.qAggrFunc = "None";
                        break;
                    default:
                        break;
                }

                jsonConfig.qDef.qNumFormat = new JObject();
                switch (NumberFormatIndex)
                {
                    case 0:
                        jsonConfig.qDef.qNumFormat.qType = "U";
                        break;
                    case 1:
                        jsonConfig.qDef.qNumFormat.qType = "F";
                        if (IsStandardFormat)
                        {
                            jsonConfig.qDef.qNumFormat = new JObject();
                            switch (StandardFormatIndex)
                            {
                                case 0:
                                    jsonConfig.qDef.qNumFormat.qFmt = "#,##0";
                                    break;
                                case 1:
                                    jsonConfig.qDef.qNumFormat.qFmt = "#,##0.0";
                                    break;
                                case 2:
                                    jsonConfig.qDef.qNumFormat.qFmt = "#,##0.00";
                                    break;
                                case 3:
                                    jsonConfig.qDef.qNumFormat.qFmt = "0%";
                                    break;
                                case 4:
                                    jsonConfig.qDef.qNumFormat.qFmt = "0.0%";
                                    break;
                                case 5:
                                    jsonConfig.qDef.qNumFormat.qFmt = "0.00%";
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            jsonConfig.qDef.qNumFormat.qFmt = NumberFormatText;
                        }
                        jsonConfig.qDef.numFormatFromTemplate = IsStandardFormat;
                        break;
                    case 2:
                        jsonConfig.qDef.qNumFormat.qType = "M";
                        jsonConfig.qDef.qNumFormat.qFmt = CurrencyFormatText;
                        break;
                    case 3:
                        jsonConfig.qDef.qNumFormat.qType = "D";
                        if (IsStandardDateFormat)
                        {
                            if (DateToIndex.ContainsKey(DateStandardFormatIndex))
                            {
                                jsonConfig.qDef.qNumFormat.qFmt = DateToIndex[DateStandardFormatIndex];
                            }
                            else
                            {
                                jsonConfig.qDef.qNumFormat.qFmt = "";
                            }
                        }
                        else
                        {
                            jsonConfig.qDef.qNumFormat.qFmt = DateFormatText;
                        }
                        jsonConfig.qDef.numFormatFromTemplate = IsStandardDateFormat;
                        break;
                    case 4:
                        jsonConfig.qDef.qNumFormat.qType = "IV";
                        jsonConfig.qDef.qNumFormat.qFmt = DurationFormatText;
                        break;
                    case 5:
                        jsonConfig.qDef.qNumFormat.qType = "R";
                        jsonConfig.qDef.qNumFormat.qFmt = CustomNumberFormatText;
                        jsonConfig.qDef.qNumFormat.qDec = Dec_SplitterSign;
                        jsonConfig.qDef.qNumFormat.qThou = Thou_SplitterSign;
                        break;
                    default:
                        break;
                }

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
                jsonConfig.qDef.textAlign.auto = TextAllignment;
                jsonConfig.qDef.textAlign.align = AllignmentIndex == 0 ? "left" : "right";
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return jsonConfig;
        }

        private Dictionary<int, string> DateToIndex = new Dictionary<int, string>()
        {
            { 0,"M/D/YYYY" },
            { 1,"YYYY-MM-DD" },
            { 2,"DD MM YYYY" },
            { 3,"DD MMMM YYYY" },
            { 4,"M/DD/YYYY" },
            { 5,"MM/DD/YYYY" },
            { 6,"MMMM DD, YYYY" },
            { 7,"M/D/YYYY h:mm:ss[.fff] TT" },
            { 8,"YYYY-MM-DD hh:mm:ss[.fff]" },
            { 9,"h:mm:ss TT" },
            { 10,"hh:mm:ss" },
            { 11,"h:mm:ss tt" }
        };



        public SortCriteria SortCriterias { get; set; }

        public MeasureColumnData()
        {
            SortCriterias = new SortCriteria();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
