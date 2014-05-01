using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PlateModel.Wpf.Plates.Iran.Input
{
    [ContentProperty("Plate")]
    public partial class IRProtocolPlateInput : UserControl
    {
        #region Plate
        public readonly static DependencyProperty PlateProperty = DependencyProperty.Register("Plate", typeof(string), typeof(IRProtocolPlateInput),
            new PropertyMetadata("", (obj, e) =>
            {
                if (e.NewValue != e.OldValue)
                {
                    var ir_plate = obj as IRProtocolPlateInput;

                    ir_plate.UnhandleAll();

                    try
                    {
                        if (e.NewValue != null)
                        {
                            string plate = e.NewValue.ToString().Replace(" ", "").Replace("_", "").Replace("-", "").Replace(",", "").Replace(".", "").ToUpper()
                                .Replace("F", "");
                            string s = "";
                            int l = plate.Length;

                            if (l >= 4)
                            {
                                s = plate.Substring(0, 4).Trim();
                                if (ir_plate.digits.Text != s)
                                    ir_plate.digits.Text = s;
                            }
                            else
                            {
                                s = plate.Trim();
                                if (ir_plate.digits.Text != s)
                                    ir_plate.digits.Text = s;
                            }

                        }
                        else
                        {
                            ir_plate.digits.Text = "";
                        }
                    }
                    finally
                    {
                        ir_plate.HandleAll();
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

        public IRProtocolPlateInput()
        {
            InitializeComponent();
        }

        #region HandleAll/UnhandleAll
        void HandleAll()
        {
            this.digits.TextChanged += digits_TextChanged;
        }

        void UnhandleAll()
        {
            this.digits.TextChanged -= digits_TextChanged;
        }
        #endregion

        #region SetPlate
        private void digits_TextChanged(object sender, TextChangedEventArgs e)
        {
            string plate = this.digits.Text;
            if (plate != Plate)
                Plate = plate;
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Validates plate string with standard Latin letters.
        /// </summary>
        public static bool ValidateStandardPlate(string plate)
        {
            return Regex.Match(plate, @"^[1-9]{4}$").Success;
        }
        #endregion
    }
}
