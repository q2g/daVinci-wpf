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

        public void ReadFromJSON(dynamic jsonConfig)
        {
            var value = jsonConfig?.qSortByNumeric ?? 0;
            SortByNumeric = (value != 0);
            SortByNumericDirection = 0;
            SortByNumericDirection = value == -1 ? 1 : 0;

            value = jsonConfig?.qSortByAscii ?? 0;
            SortByAscii = (value != 0);
            SortByAsciiDirection = 0;
            SortByAsciiDirection = value == -1 ? 1 : 0;

            value = jsonConfig?.qSortByExpression;
            SortByExpression = (value != 0);
            SortByExpressionDirection = 0;
            SortByExpressionDirection = value == -1 ? 1 : 0;
            SortByExpressionText = jsonConfig?.qExpression?.qv ?? "";
        }

        public dynamic SaveToJSON()
        {
            dynamic jsonConfig = new JObject();
            jsonConfig.qSortByNumeric = 0;
            if (SortByNumericDirection == 1)
            {
                jsonConfig.qSortByNumeric = -1;
            }
            if (SortByNumericDirection == 0)
            {
                jsonConfig.qSortByNumeric = 1;
            }

            jsonConfig.qSortByAscii = 0;
            if (SortByAsciiDirection == 1)
            {
                jsonConfig.qSortByAscii = -1;
            }
            if (SortByAsciiDirection == 0)
            {
                jsonConfig.qSortByAscii = 1;
            }

            jsonConfig.qSortByExpression = 0;
            if (SortByExpressionDirection == 1)
            {
                jsonConfig.qSortByExpression = -1;
            }
            if (SortByExpressionDirection == 0)
            {
                jsonConfig.qSortByExpression = 1;
            }
            jsonConfig.qExpression = new JObject();
            jsonConfig.qExpression.qv = SortByExpressionText;
            return jsonConfig;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
