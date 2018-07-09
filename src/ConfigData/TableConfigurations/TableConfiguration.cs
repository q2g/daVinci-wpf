namespace daVinci.ConfigData
{
    #region Usings
    using NLog;
    using System;
    using System.Linq;
    using leonardo.Resources;
    using Newtonsoft.Json.Linq;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    #endregion
    using System.Runtime.CompilerServices;
    using daVinci.ConfigData.TableConfigurations;
    using System.Collections.Generic;

    public class TableConfiguration : INotifyPropertyChanged
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private ObservableCollection<object> columns = new ObservableCollection<object>();
        public ObservableCollection<object> Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<DimensionMeasure> dimensionMeasures = new ObservableCollection<DimensionMeasure>();
        public ObservableCollection<DimensionMeasure> DimensionMeasures
        {
            get
            {
                return dimensionMeasures;
            }
            set
            {
                dimensionMeasures = value;
                RaisePropertyChanged();
            }
        }

        public TableConfiguration()
        {
            Columns = new ObservableCollection<object>();
        }

        private ObservableCollection<object> presentationData = new ObservableCollection<object>();
        public ObservableCollection<object> PresentationData
        {
            get
            {
                return presentationData;
            }
            set
            {
                presentationData = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<object> addOnData = new ObservableCollection<object>();
        public ObservableCollection<object> AddOnData
        {
            get
            {
                return addOnData;
            }
            set
            {
                addOnData = value;
                RaisePropertyChanged();
            }
        }

        private string settingsID;
        public string SettingsID
        {
            get
            {
                return settingsID;
            }
            set
            {
                if (settingsID != value)
                {
                    settingsID = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string TableName { get; set; }

        public void ReadFromJSON(string JSONstring)
        {
            try
            {
                dynamic jsonConfig = JObject.Parse(JSONstring);
                SettingsID = jsonConfig?.qInfo?.qId ?? "";
                var columnOrderCount = (jsonConfig?.qHyperCubeDef?.qColumnOrder?.Count ?? 0);
                var interColumnSort = (jsonConfig?.qHyperCubeDef?.qInterColumnSortOrder?.Count ?? 0);

                List<object> cols = new List<object>();
                foreach (var dimension in jsonConfig?.qHyperCubeDef?.qDimensions)
                {
                    var newone = new DimensionColumnData();
                    newone.ReadFromJSON(dimension);
                    newone.DimensionMeasure = DimensionMeasure.GetDimensionMeasureByLibraryID(dimensionMeasures, (dimension?.qLibraryId?.ToString() ?? ""), true);
                    newone.LibraryID = dimension?.qLibraryId?.ToString() ?? "";
                    newone.IsExpression = string.IsNullOrEmpty(newone.LibraryID);
                    cols.Add(newone);
                }


                foreach (var measure in jsonConfig?.qHyperCubeDef?.qMeasures)
                {
                    var newone = new MeasureColumnData();
                    newone.ReadFromJSON(measure);
                    newone.DimensionMeasure = DimensionMeasure.GetDimensionMeasureByLibraryID(dimensionMeasures, measure?.qLibraryId?.ToString() ?? "", false);
                    newone.LibraryID = measure?.qLibraryId?.ToString() ?? "";
                    newone.IsExpression = string.IsNullOrEmpty(newone.LibraryID);
                    cols.Add(newone);
                }

                int count = jsonConfig?.qHyperCubeDef?.qColumnOrder?.Count ?? 0;
                if (count != 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        (cols[(int)jsonConfig.qHyperCubeDef.qColumnOrder[i]] as IHasSortCriteria).SortCriterias.ColumnOrderIndex = i + 1;
                    }
                }


                count = jsonConfig?.qHyperCubeDef?.qInterColumnSortOrder?.Count ?? 0;
                if (count != 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        (cols[(int)jsonConfig.qHyperCubeDef.qInterColumnSortOrder[i]] as IHasSortCriteria).SortCriterias.SortOrderIndex = i + 1;
                    }
                }

                cols.ForEach(ele => Columns.Add(ele));




                var addonConfig = new AddOnDataProcessingConfiguration();
                addonConfig.ReadFromJSON(jsonConfig?.qHyperCubeDef);
                AddOnData.Clear();
                AddOnData.Add(addonConfig);

                var presentationConfig = new PresentationData();
                PresentationData.Clear();
                presentationConfig.ReadFromJSON(jsonConfig?.totals);
                PresentationData.Add(presentationConfig);
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
                logger.Trace($"JSON:{JSONstring}");
            }
        }

        public string SaveToJSON()
        {
            dynamic jsonData = new JObject();
            try
            {
                jsonData.qInfo = new JObject();
                jsonData.qInfo.qId = SettingsID;
                jsonData.qInfo.qType = "table";


                jsonData.qHyperCubeDef = new JObject();
                jsonData.qHyperCubeDef.qDimensions = new JArray() as dynamic;
                jsonData.qHyperCubeDef.qMeasures = new JArray() as dynamic;

                jsonData.qHyperCubeDef.qInterColumnSortOrder = new JArray();
                jsonData.qHyperCubeDef.columnWidths = new JArray();
                jsonData.qHyperCubeDef.qColumnOrder = new JArray();

                var qColumnOrder = new SortedDictionary<int, int>();
                var qInterColumnSortOrder = new SortedDictionary<int, int>();

                Dictionary<int, int> IndexesColumn = new Dictionary<int, int>();
                Dictionary<int, int> IndexesSort = new Dictionary<int, int>();
                var index = 0;
                foreach (var item in Columns)
                {
                    if (item is DimensionColumnData dimensionData)
                    {
                        IndexesColumn.Add(index, dimensionData.SortCriterias.ColumnOrderIndex);
                        IndexesSort.Add(index, dimensionData.SortCriterias.SortOrderIndex);
                        jsonData.qHyperCubeDef.columnWidths.Add(-1);

                        jsonData.qHyperCubeDef.qDimensions.Add(dimensionData.SaveToJson());
                        index++;
                    }
                }
                foreach (var item in Columns)
                {
                    if (item is MeasureColumnData measureData)
                    {
                        IndexesColumn.Add(index, measureData.SortCriterias.ColumnOrderIndex);
                        IndexesSort.Add(index, measureData.SortCriterias.SortOrderIndex);
                        jsonData.qHyperCubeDef.columnWidths.Add(-1);

                        jsonData.qHyperCubeDef.qMeasures.Add(measureData.SaveToJson());
                        index++;
                    }
                }

                var orderedColumnindexes = IndexesColumn.OrderBy(ele => ele.Value).ToList();
                foreach (var item in orderedColumnindexes)
                {
                    jsonData.qHyperCubeDef.qColumnOrder.Add(item.Key);
                }
                var orderedSortindexes = IndexesSort.OrderBy(ele => ele.Value).ToList();
                foreach (var item in orderedSortindexes)
                {
                    jsonData.qHyperCubeDef.qInterColumnSortOrder.Add(item.Key);
                }
                var addonConfig = AddOnData.First() as AddOnDataProcessingConfiguration;
                addonConfig.SaveToJSON(jsonData.qHyperCubeDef);


                var presentationConfig = PresentationData.First() as PresentationData;
                jsonData.totals = presentationConfig.SaveToJSON();
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return jsonData.ToString();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }


    }

    public enum ColumnChooserMode
    {
        Combined,
        Pivot,
        Separeted
    }
}
