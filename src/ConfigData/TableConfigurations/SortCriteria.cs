using daVinci.Resources;
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
    public class SortCriteria : INotifyPropertyChanged
    {
        private bool autoSort;
        public bool AutoSort
        {
            get
            {
                return autoSort;
            }
            set
            {
                if (autoSort != value)
                {
                    autoSort = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool sortByExpression;
        public bool SortByExpression
        {
            get
            {
                return sortByExpression;
            }
            set
            {
                if (sortByExpression != value)
                {
                    sortByExpression = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string sortByExpressionText;
        public string SortByExpressionText
        {
            get
            {
                return sortByExpressionText;
            }
            set
            {
                if (sortByExpressionText != value)
                {
                    sortByExpressionText = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int sortByExpressionDirection;
        public int SortByExpressionDirection
        {
            get
            {
                return sortByExpressionDirection;
            }
            set
            {
                if (sortByExpressionDirection != value)
                {
                    sortByExpressionDirection = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool sortByNumeric;
        public bool SortByNumeric
        {
            get
            {
                return sortByNumeric;
            }
            set
            {
                if (sortByNumeric != value)
                {
                    sortByNumeric = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int sortByNumericDirection;
        public int SortByNumericDirection
        {
            get
            {
                return sortByNumericDirection;
            }
            set
            {
                if (sortByNumericDirection != value)
                {
                    sortByNumericDirection = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool sortByAscii;
        public bool SortByAscii
        {
            get
            {
                return sortByAscii;
            }
            set
            {
                if (sortByAscii != value)
                {
                    sortByAscii = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int sortByAsciiDirection;
        public int SortByAsciiDirection
        {
            get
            {
                return sortByAsciiDirection;
            }
            set
            {
                if (sortByAsciiDirection != value)
                {
                    sortByAsciiDirection = value;
                    RaisePropertyChanged();
                }
            }
        }



        private int columnOrderIndex;
        public int ColumnOrderIndex
        {
            get
            {
                return columnOrderIndex;
            }
            set
            {
                columnOrderIndex = value;
                RaisePropertyChanged();

            }
        }


        private int sortOrderIndex;
        public int SortOrderIndex
        {
            get
            {
                return sortOrderIndex;
            }
            set
            {
                sortOrderIndex = value;
                RaisePropertyChanged();


            }
        }

        public void ReadFromJSON(string JSONstring)
        {
            dynamic jsonConfig = JObject.Parse(JSONstring);

            AutoSort = jsonConfig.autoSort != 0;
            var value = jsonConfig.qDef.qSortCriterias[0].qSortByNumeric;
            SortByNumeric = (value != 0);
            SortByNumericDirection = value == 1 ? 0 : value == -1 ? 1 : 0;

            value = jsonConfig.qDef.qSortCriterias[0].qSortByAscii;
            SortByAscii = (value != 0);
            SortByAsciiDirection = value == 1 ? 0 : value == -1 ? 1 : 0;

            value = jsonConfig.qDef.qSortCriterias[0].qSortByExpression;
            SortByExpression = (value != 0);
            SortByExpressionDirection = value == 1 ? 0 : value == -1 ? 1 : 0;
            SortByExpressionText = jsonConfig.qDef.qSortCriterias[0].qExpression.qv;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
