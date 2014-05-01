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
    public partial class IRProtocolPlate : UserControl
    {
        #region Plate
        public readonly static DependencyProperty PlateProperty = DependencyProperty.Register("Plate", typeof(string), typeof(IRProtocolPlate),
            new PropertyMetadata("", (obj, e) =>
            {
                var ir_plate = obj as IRProtocolPlate;

                ir_plate.ResetPlate();

                if (e.NewValue != null)
                {
                    string plate = e.NewValue.ToString().Replace(" ", "").Replace("_", "").Replace("-", "").Replace(",", "").Replace(".", "").ToUpper()
                        .Replace("F","");

                    if (plate.Length > 0)
                    {
                        int i = 0;
                        int l = plate.Length;

                        ir_plate.digit1.Text = plate[i].ToString();
                        if (++i >= l) return;

                        ir_plate.digit2.Text = plate[i].ToString();
                        if (++i >= l) return;

                        ir_plate.digit3.Text = plate[i].ToString();
                        if (++i >= l) return;

                        ir_plate.digit4.Text = plate[i].ToString();
                    }
                }
            }));

        [Category("Common")]
        public string Plate
        {
            get { return (string)GetValue(PlateProperty); }
            set { SetValue(PlateProperty, value); }
        }
        #endregion

        public IRProtocolPlate()
        {
            InitializeComponent();
        }

        #region ResetPlate
        void ResetPlate()
        {
            this.digit1.Text = "";
            this.digit2.Text = "";
            this.digit3.Text = "";
            this.digit4.Text = "";
        }
        #endregion

    }
}
