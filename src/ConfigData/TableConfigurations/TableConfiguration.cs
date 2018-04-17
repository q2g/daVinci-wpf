using daVinci_wpf.ConfigData.TableConfigurations;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.ConfigData
{

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
                int counter = 0;

                foreach (var dimension in jsonConfig?.qHyperCubeDef?.qDimensions)
                {
                    var newone = new DimensionColumnData();
                    newone.ReadFromJSON(dimension);
                    newone.SortCriterias.ColumnOrderIndex = jsonConfig?.qHyperCubeDef?.columnOrder[counter] ?? 0;
                    newone.SortCriterias.SortOrderIndex = jsonConfig?.qHyperCubeDef?.qInterColumnSortOrder[counter] ?? 0;
                    counter++;
                    columns.Add(newone);
                }

                foreach (var dimension in jsonConfig?.qHyperCubeDef?.qMeasures)
                {
                    var newone = new MeasureColumnData();
                    newone.ReadFromJSON(dimension);
                    newone.SortCriterias.ColumnOrderIndex = jsonConfig?.qHyperCubeDef?.columnOrder[counter] ?? 0;
                    newone.SortCriterias.SortOrderIndex = jsonConfig?.qHyperCubeDef?.qInterColumnSortOrder[counter] ?? 0;
                    counter++;
                    columns.Add(newone);
                }




                var addonConfig = new AddOnDataProcessingConfiguration();
                addonConfig.ReadFromJSON(jsonConfig?.qHyperCubeDef);
                AddOnData.Add(addonConfig);

                var presentationConfig = new PresentationData();
                presentationConfig.ReadFromJSON(jsonConfig?.totals);
                PresentationData.Add(presentationConfig);
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
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
                jsonData.qHyperCubeDef.columnOrder = new JArray();
                int counter = 0;

                foreach (var item in Columns)
                {
                    if (item is DimensionColumnData dimensionData)
                    {
                        jsonData.qHyperCubeDef.qDimensions.Add(dimensionData.SaveToJson());
                        jsonData.qHyperCubeDef.qInterColumnSortOrder.Add(counter);
                        jsonData.qHyperCubeDef.columnOrder.Add(counter);
                        counter++;
                    }
                }

                foreach (var item in Columns)
                {
                    if (item is MeasureColumnData measureData)
                    {
                        jsonData.qHyperCubeDef.qMeasures.Add(measureData.SaveToJson());
                        jsonData.qHyperCubeDef.columnOrder.Add(counter);
                        jsonData.qHyperCubeDef.qInterColumnSortOrder.Add(counter);
                        counter++;
                    }
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
}
