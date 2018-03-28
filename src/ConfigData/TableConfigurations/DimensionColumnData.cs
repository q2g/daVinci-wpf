using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{
    public class DimensionColumnData : INotifyPropertyChanged
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
        /// Feste Spaltenanzahl
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
        /// Genauer Wert / Relativer Wert
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

        private int representation;
        public int RepresentationIndex
        {
            get
            {
                return representation;
            }
            set
            {
                if (representation != value)
                {
                    representation = value;
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
