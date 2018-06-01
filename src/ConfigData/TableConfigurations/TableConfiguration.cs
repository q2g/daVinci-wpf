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

                int counter = 0;
                if ((jsonConfig?.qHyperCubeDef?.qColumnOrder?.Count ?? 0) != 0)
                {
                    foreach (int item in jsonConfig?.qHyperCubeDef?.qColumnOrder)
                    {
                        (cols[item] as IHasSortCriteria).SortCriterias.ColumnOrderIndex = counter + 1;
                        counter++;
                    }
                }

                counter = 0;
                if ((jsonConfig?.qHyperCubeDef?.qInterColumnSortOrder?.Count ?? 0) != 0)
                {
                    foreach (int item in jsonConfig?.qHyperCubeDef?.qInterColumnSortOrder)
                    {
                        (cols[item] as IHasSortCriteria).SortCriterias.SortOrderIndex = counter + 1;
                        counter++;
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
                var counter = 0;

                foreach (var item in Columns)
                {
                    var sortCrit = item as IHasSortCriteria;

                    qColumnOrder.Add(sortCrit.SortCriterias.ColumnOrderIndex - 1, counter);
                    qInterColumnSortOrder.Add(sortCrit.SortCriterias.SortOrderIndex - 1, counter);

                    jsonData.qHyperCubeDef.columnWidths.Add(-1);

                    if (item is DimensionColumnData dimensionData)
                    {
                        jsonData.qHyperCubeDef.qDimensions.Add(dimensionData.SaveToJson());
                    }
                    if (item is MeasureColumnData measureData)
                    {
                        jsonData.qHyperCubeDef.qMeasures.Add(measureData.SaveToJson());

                    }
                    counter++;
                }

                foreach (var item in qColumnOrder)
                    jsonData.qHyperCubeDef.qColumnOrder.Add(item.Value);

                foreach (var item in qInterColumnSortOrder)
                    jsonData.qHyperCubeDef.qInterColumnSortOrder.Add(item.Value);


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
}
