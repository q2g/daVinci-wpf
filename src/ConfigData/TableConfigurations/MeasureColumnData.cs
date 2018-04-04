using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class MeasureColumnData : INotifyPropertyChanged
    {

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

        public void ReadFromJSON(string JSONstring)
        {
            dynamic jsonConfig = JObject.Parse(JSONstring);
            libraryID = jsonConfig?.qLibraryId;
            if ((jsonConfig?.qDef?.qFieldDefs?.Count ?? 0) > 0)
            {
                fieldDef = jsonConfig?.qDef?.qFieldDefs[0] ?? "";
            }
            if ((jsonConfig?.qDef?.qFieldLabels?.Count ?? 0) > 0)
            {
                fieldLabel = jsonConfig?.qDef?.qFieldLabels[0] ?? "";
            }
            SortCriterias.ReadFromJSON(jsonConfig.ToString());

            switch (jsonConfig?.qDef?.qNumFormat?.qType?.ToString() ?? "U")
            {
                case "U":
                    NumberFormatIndex = 0;
                    break;
                case "F":
                    NumberFormatIndex = 1;
                    dynamic value = jsonConfig?.qDef?.qNumFormat?.qFmt ?? "#,##0.0";
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
                            StandardFormatIndex = 3;
                            break;
                        case "#,##0.0":
                            StandardFormatIndex = 2;
                            break;
                        case "#,##0":
                            StandardFormatIndex = 1;
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
                    DateFormatText = jsonConfig?.qDef?.qNumFormat?.qFmt ?? "";
                    NumberFormatIndex = 3;
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

        }

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
