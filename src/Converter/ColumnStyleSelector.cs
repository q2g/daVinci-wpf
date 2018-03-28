using daVinci.Resources;
using daVinci.ConfigData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace daVinci.Converter
{
    public class ColumnStyleSelector : StyleSelector
    {
        public Style MeasureColumnStyle { get; set; }
        public Style DimensionColumnStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (item is ColumnConfiguration config)
            {
                if (config.ValueType == ValueTypeEnum.Measure)
                {
                    return MeasureColumnStyle;
                }
                if (config.ValueType == ValueTypeEnum.Dimension)
                {
                    return DimensionColumnStyle;
                }
            }
            return null;
        }
    }
}
