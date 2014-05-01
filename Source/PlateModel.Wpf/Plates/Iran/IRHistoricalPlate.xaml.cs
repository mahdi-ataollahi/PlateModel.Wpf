using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PlateModel.Wpf.Plates.Iran
{
    [ContentProperty("Plate")]
    public partial class IRHistoricalPlate : UserControl
    {
        #region Plate
        public readonly static DependencyProperty PlateProperty = DependencyProperty.Register("Plate", typeof(string), typeof(IRHistoricalPlate),
            new PropertyMetadata("", (obj, e) =>
            {
                var ir_plate = obj as IRHistoricalPlate;

                ir_plate.digits.Text = "";

                if (e.NewValue != null)
                {
                    string plate = e.NewValue.ToString().Replace(" ", "").Replace("_", "").Replace("-", "").Replace(",", "").Replace(".", "").ToUpper();
                    ir_plate.digits.Text = plate;
                }
            }));

        [Category("Common")]
        public string Plate
        {
            get { return (string)GetValue(PlateProperty); }
            set { SetValue(PlateProperty, value); }
        }
        #endregion

        public IRHistoricalPlate()
        {
            InitializeComponent();
        }
    }
}
