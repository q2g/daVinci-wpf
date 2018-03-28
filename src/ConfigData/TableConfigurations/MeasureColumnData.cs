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





        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
