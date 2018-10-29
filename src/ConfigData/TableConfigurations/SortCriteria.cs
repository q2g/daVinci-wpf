namespace daVinci.ConfigData
{
    #region Usings
    using Newtonsoft.Json.Linq;
    using NLog;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class SortCriteria : INotifyPropertyChanged
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
            try
            {
                var value = jsonConfig?.qSortByNumeric ?? 0;
                SortByNumeric = (value != 0);
                SortByNumericDirection = value == -1 ? 1 : 0;

                value = jsonConfig?.qSortByAscii ?? 0;
                SortByAscii = (value != 0);
                SortByAsciiDirection = value == -1 ? 1 : 0;

                value = jsonConfig?.qSortByExpression ?? 0;
                SortByExpression = (value != 0);
                SortByExpressionDirection = value == -1 ? 1 : 0;
                SortByExpressionText = jsonConfig?.qExpression?.qv ?? "";
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
                logger.Trace($"JSON:{jsonConfig?.ToString() ?? ""}");
            }
        }

        public dynamic SaveToJSON()
        {
            dynamic jsonConfig = new JObject();
            try
            {
                if (SortByNumeric)
                {
                    if (SortByNumericDirection == 1)
                    {
                        jsonConfig.qSortByNumeric = -1;
                    }
                    else
                    {
                        jsonConfig.qSortByNumeric = 1;
                    }
                }

                if (sortByAscii)
                {
                    if (SortByAsciiDirection == 1)
                    {
                        jsonConfig.qSortByAscii = -1;
                    }
                    else
                    {
                        jsonConfig.qSortByAscii = 1;
                    }
                }
                if (SortByExpression)
                {
                    if (SortByExpressionDirection == 1)
                    {
                        jsonConfig.qSortByExpression = -1;
                    }
                    else
                    {
                        jsonConfig.qSortByExpression = 1;
                    }
                }

                jsonConfig.qExpression = new JObject();
                if (!string.IsNullOrEmpty(SortByExpressionText))
                    jsonConfig.qExpression.qv = SortByExpressionText;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return jsonConfig;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
