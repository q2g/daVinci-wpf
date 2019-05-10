namespace daVinci.ConfigData.Loop
{
    #region Usings
    using Hjson;
    using leonardo.Resources;
    using Newtonsoft.Json.Linq;
    using NLog;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    #endregion

    public class RangeLoopConfig : INotifyPropertyChanged
    {
        #region LoggerInit
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
            FillValues(caller);
        }
        #endregion

        #region Properties & Variables


        private string expressionText;
        public string ExpressionText
        {
            get => expressionText;
            set
            {
                if (expressionText != value)
                {
                    expressionText = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool jsonValid;
        public bool JsonValid
        {
            get => jsonValid;
            set
            {
                if (jsonValid != value)
                {
                    jsonValid = value;
                    RaisePropertyChanged();
                }
            }
        }
        private DimensionMeasure loopOver;
        public DimensionMeasure LoopOver
        {
            get => loopOver;
            set
            {
                if (loopOver != value)
                {
                    loopOver = value;
                    RaisePropertyChanged();
                }
            }
        }
        private bool dontProcessFill;
        #endregion

        #region private Functions

        private void FillValues(string propertyName)
        {
            if (dontProcessFill)
                return;
            if (propertyName == nameof(JsonValid))
                return;

            dynamic data = null;
            try
            {
                if (string.IsNullOrEmpty(ExpressionText))
                {
                    ExpressionText = $"selections:\n[\n  {{\n    type: dynamic\n  \n  }}\n]";
                }
                var value = HjsonValue.Parse(ExpressionText);
                data = JObject.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                JsonValid = false;
            }
            if (propertyName != nameof(ExpressionText))
            {
                try
                {
                    if (data != null)
                    {
                        if ((data?.selections?.Count ?? 0) > 0)
                        {
                            if (propertyName == nameof(LoopOver))
                                data.selections[0].name = LoopOver.Text;
                        }
                        var text = HjsonValue.Parse(data.ToString()).ToString(Stringify.Hjson);
                        dontProcessFill = true;
                        ExpressionText = text.Substring(1, text.Length - 2).Trim();
                        dontProcessFill = false;
                        JsonValid = true;
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    JsonValid = false;
                    dontProcessFill = false;
                }
            }
            else
            {
                try
                {
                    if (data != null)
                    {
                        if ((data?.selections?.Count ?? 0) > 0)
                        {
                            dontProcessFill = true;
                            //
                            dontProcessFill = false;
                            JsonValid = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    dontProcessFill = false;
                    JsonValid = false;
                }
            }
        }
        #endregion
    }
}
