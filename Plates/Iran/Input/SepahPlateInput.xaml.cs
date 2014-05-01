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
    public partial class SepahPlateInput : UserControl
    {
        #region Plate
        public readonly static DependencyProperty PlateProperty = DependencyProperty.Register("Plate", typeof(string), typeof(SepahPlateInput),
            new PropertyMetadata("", (obj, e) =>
            {
                if (e.NewValue != e.OldValue)
                {
                    var ir_plate = obj as SepahPlateInput;

                    ir_plate.UnhandleAll();

                    try
                    {
                        if (e.NewValue != null)
                        {
                            string plate = e.NewValue.ToString().Replace("_", "").Replace("-", "").Replace(",", "").Replace(".", "").ToUpper()
                                .Replace("P", "");

                            string s = "";
                            int l = plate.Length;

                            if (l > 0)
                            {
                                if (l >= 5)
                                {
                                    s = plate.Substring(0, 5).Trim();
                                    if (ir_plate.digits.Text != s)
                                        ir_plate.digits.Text = s;

                                    if (l >= 7)
                                    {
                                        s = plate.Substring(5, 2).Trim();
                                        if (ir_plate.top_digits.Text != s)
                                            ir_plate.top_digits.Text = s;
                                    }
                                    else
                                    {
                                        s = plate.Substring(5).Trim();
                                        if (ir_plate.top_digits.Text != s)
                                            ir_plate.top_digits.Text = s;
                                    }
                                }
                                else
                                {
                                    s = plate.Trim();
                                    if (ir_plate.digits.Text != s)
                                        ir_plate.digits.Text = s;
                                    ir_plate.top_digits.Text = "";
                                }
                            }
                            else
                            {
                                ir_plate.digits.Text = "";
                                ir_plate.top_digits.Text = "";
                            }
                        }
                        else
                        {
                            ir_plate.digits.Text = "";
                            ir_plate.top_digits.Text = "";
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

        public SepahPlateInput()
        {
            InitializeComponent();
        }

        #region HandleAll/UnhandleAll
        void HandleAll()
        {
            this.digits.TextChanged += digits_TextChanged;
            this.top_digits.TextChanged += top_digits_TextChanged;
        }

        void UnhandleAll()
        {
            this.digits.TextChanged -= digits_TextChanged;
            this.top_digits.TextChanged -= top_digits_TextChanged;
        }
        #endregion

        #region SetPlate
        private void digits_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetPlate();
            if (this.digits.Text.Length >= 5)
                this.top_digits.Focus();
        }

        private void top_digits_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetPlate();
        }

        void SetPlate()
        {
            string plate =
                ((this.digits.Text + "     ").Substring(0, 5) +
                this.top_digits.Text).TrimEnd();

            if (plate != Plate)
                Plate = plate;
        }

        private void digits_KeyDown(object sender, KeyEventArgs e)
        {
            var txt = sender as TextBox;
            if (e.Key == Key.Right && txt.SelectionStart == txt.Text.Length)
            {
                this.top_digits.Focus();
                this.top_digits.SelectionStart = 0;
            }
        }

        private void top_digits_KeyDown(object sender, KeyEventArgs e)
        {
            var txt = sender as TextBox;
            if (e.Key == Key.Left && txt.SelectionStart == 0)
            {
                this.digits.Focus();
                this.digits.SelectionStart = this.digits.Text.Length;
            }
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Validates plate string with standard Latin letters.
        /// </summary>
        public static bool ValidateStandardPlate(string plate)
        {
            return Regex.Match(plate, @"^[1-9]{7}$").Success;
        }
        #endregion
    }
}
