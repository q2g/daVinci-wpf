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



        private ColumnChooserMode tableMode;
        public ColumnChooserMode TableMode
        {
            get
            {
                return tableMode;
            }
            set
            {
                if (tableMode != value)
                {
                    tableMode = value;
                    RaisePropertyChanged();
                }
            }
        }

        private TableImportConfiguration tableImportConfiguration;
        public TableImportConfiguration TableImportConfiguration
        {
            get
            {
                return tableImportConfiguration;
            }
            set
            {
                if (tableImportConfiguration != value)
                {
                    tableImportConfiguration = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string tableName;
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                if (tableName != value)
                {
                    tableName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void ReadFromJSON(string JSONstring)
        {
            try
            {
                dynamic jsonConfig = JObject.Parse(JSONstring);
                string visualization = (jsonConfig?.visualization ?? "table");
                if (visualization == "table")
                {
                    TableMode = ColumnChooserMode.Combined;
                    LoadColumnsCombined(jsonConfig);
                }
                if (visualization == "pivot-table")
                {
                    TableMode = ColumnChooserMode.Pivot;
                    LoadColumnsPivot(jsonConfig);
                }
                if (visualization == "auto-chart")
                {
                    TableMode = ColumnChooserMode.Separated;
                }


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

        private void LoadColumnsCombined(dynamic jsonConfig)
        {
            int numberofRows = 0;
            if (TableMode == ColumnChooserMode.Pivot)
                numberofRows = jsonConfig?.qHyperCubeDef?.qNoOfLeftDims ?? 0;

            SettingsID = jsonConfig?.qInfo?.qId ?? "";
            var columnOrderCount = (jsonConfig?.qHyperCubeDef?.qColumnOrder?.Count ?? 0);
            var interColumnSort = (jsonConfig?.qHyperCubeDef?.qInterColumnSortOrder?.Count ?? 0);

            List<object> cols = new List<object>();
            int pivotrowCounter = 0;
            foreach (var dimension in jsonConfig?.qHyperCubeDef?.qDimensions)
            {
                var newone = new DimensionColumnData();
                newone.ReadFromJSON(dimension);
                newone.DimensionMeasure = DimensionMeasure.GetDimensionMeasureByLibraryID(dimensionMeasures, (dimension?.qLibraryId?.ToString() ?? ""), true);
                newone.LibraryID = dimension?.qLibraryId?.ToString() ?? "";
                newone.IsExpression = string.IsNullOrEmpty(newone.LibraryID);
                newone.PivotType = PivotType.None;
                if (TableMode == ColumnChooserMode.Pivot)
                {
                    if (pivotrowCounter < numberofRows)
                    {
                        newone.PivotType = PivotType.Row;
                        pivotrowCounter++;
                    }
                    else
                    {
                        newone.PivotType = PivotType.Column;
                    }
                }
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
        }

        private void LoadColumnsPivot(dynamic jsonConfig)
        {
            int numberofRows = 0;
            if (TableMode == ColumnChooserMode.Pivot)
                numberofRows = jsonConfig?.qHyperCubeDef?.qNoOfLeftDims ?? 0;

            SettingsID = jsonConfig?.qInfo?.qId ?? "";
            var columnOrderCount = (jsonConfig?.qHyperCubeDef?.qColumnOrder?.Count ?? 0);
            var interColumnSort = (jsonConfig?.qHyperCubeDef?.qInterColumnSortOrder?.Count ?? 0);

            List<object> cols = new List<object>();
            int pivotrowCounter = 0;
            foreach (var dimension in jsonConfig?.qHyperCubeDef?.qDimensions)
            {
                var newone = new DimensionColumnData();
                newone.ReadFromJSON(dimension);
                newone.DimensionMeasure = DimensionMeasure.GetDimensionMeasureByLibraryID(dimensionMeasures, (dimension?.qLibraryId?.ToString() ?? ""), true);
                newone.LibraryID = dimension?.qLibraryId?.ToString() ?? "";
                newone.IsExpression = string.IsNullOrEmpty(newone.LibraryID);
                newone.PivotType = PivotType.None;
                if (TableMode == ColumnChooserMode.Pivot)
                {
                    if (pivotrowCounter < numberofRows)
                    {
                        newone.PivotType = PivotType.Row;
                        pivotrowCounter++;
                    }
                    else
                    {
                        newone.PivotType = PivotType.Column;
                    }
                }
                cols.Add(newone);
            }

            int index = 0;
            foreach (var measure in jsonConfig?.qHyperCubeDef?.qMeasures)
            {
                var newone = new MeasureColumnData();
                newone.ReadFromJSON(measure);
                newone.DimensionMeasure = DimensionMeasure.GetDimensionMeasureByLibraryID(dimensionMeasures, measure?.qLibraryId?.ToString() ?? "", false);
                newone.LibraryID = measure?.qLibraryId?.ToString() ?? "";
                newone.IsExpression = string.IsNullOrEmpty(newone.LibraryID);
                newone.SortCriterias.ColumnOrderIndex = index + 1;
                index++;
                cols.Add(newone);
            }

            int count = jsonConfig?.qHyperCubeDef?.qInterColumnSortOrder?.Count ?? 0;
            if (count != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    (cols[(int)jsonConfig.qHyperCubeDef.qInterColumnSortOrder[i]] as IHasSortCriteria).SortCriterias.ColumnOrderIndex = i + 1;
                }
            }

            cols.ForEach(ele => Columns.Add(ele));
        }

        public string SaveToJSON()
        {
            dynamic jsonData = new JObject();
            try
            {
                jsonData.qInfo = new JObject();
                jsonData.qInfo.qId = SettingsID;



                jsonData.qHyperCubeDef = new JObject();


                switch (TableMode)
                {
                    case ColumnChooserMode.Separated:
                        FillDimensionMeasureAndOrderCombined(jsonData);
                        jsonData.visualization = "auto-chart";
                        jsonData.qInfo.qType = "auto-chart";
                        jsonData.qHyperCubeDef.qMode = "S";
                        jsonData.qHyperCubeDef.qPseudoDimPos = -1;
                        jsonData.qHyperCubeDef.qNoOfLeftDims = -1;
                        break;
                    case ColumnChooserMode.Combined:
                        FillDimensionMeasureAndOrderCombined(jsonData);
                        jsonData.visualization = "table";
                        jsonData.qInfo.qType = "table";
                        jsonData.qHyperCubeDef.qMode = "S";
                        jsonData.qHyperCubeDef.qPseudoDimPos = -1;
                        jsonData.qHyperCubeDef.qNoOfLeftDims = -1;
                        break;
                    case ColumnChooserMode.Pivot:
                        FillDimensionMeasureAndOrderPivot(jsonData);
                        jsonData.visualization = "pivot-table";
                        jsonData.qInfo.qType = "pivot-table";
                        jsonData.qHyperCubeDef.qMode = "P";
                        jsonData.qHyperCubeDef.qPseudoDimPos = -1;
                        jsonData.qHyperCubeDef.qAlwaysFullyExpanded = true;
                        jsonData.qHyperCubeDef.qMaxStackedCells = 5000;
                        jsonData.qHyperCubeDef.qNoOfLeftDims =
                       columns
                       .Where(ele => (ele as DimensionColumnData) != null && (ele as DimensionColumnData).PivotType == PivotType.Row)
                       .Count();
                        break;

                    default:
                        break;
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

        private void FillDimensionMeasureAndOrderPivot(dynamic jsonData)
        {
            jsonData.qHyperCubeDef.qDimensions = new JArray() as dynamic;
            jsonData.qHyperCubeDef.qMeasures = new JArray() as dynamic;

            jsonData.qHyperCubeDef.qInterColumnSortOrder = new JArray();
            jsonData.qHyperCubeDef.columnWidths = new JArray();
            jsonData.qHyperCubeDef.qColumnOrder = new JArray();

            var qColumnOrder = new SortedDictionary<int, int>();
            var qInterColumnSortOrder = new SortedDictionary<int, int>();

            Dictionary<int, int> IndexesColumn = new Dictionary<int, int>();

            var index = 0;
            var dimensions = Columns.Where(ele => (ele as DimensionColumnData) != null)
                .OrderBy(ele => (ele as DimensionColumnData).PivotType)
                .ThenBy(ele => (ele as IHasSortCriteria).SortCriterias.ColumnOrderIndex)
                .ToList();
            foreach (var item in dimensions)
            {
                if (item is DimensionColumnData dimensionData)
                {
                    jsonData.qHyperCubeDef.columnWidths.Add(-1);
                    jsonData.qHyperCubeDef.qDimensions.Add(dimensionData.SaveToJson());
                    index++;
                }
            }
            var measures = Columns.Where(ele => (ele as MeasureColumnData) != null)
                .OrderBy(ele => (ele as IHasSortCriteria).SortCriterias.ColumnOrderIndex)
                .ToList();

            foreach (var item in measures)
            {
                if (item is MeasureColumnData measureData)
                {
                    jsonData.qHyperCubeDef.qMeasures.Add(measureData.SaveToJson());
                }
            }


            for (int i = 0; i < dimensions.Count; i++)
            {
                jsonData.qHyperCubeDef.qInterColumnSortOrder.Add(i);
            }
        }

        private void FillDimensionMeasureAndOrderCombined(dynamic jsonData)
        {
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
        Separated

    }
}
