using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace IRPlateModel.Wpf.Plates.Iran.Input
{
    [ContentProperty("Plate")]
    public partial class IRNationalPlateInput : UserControl
    {
        #region Plate
        public readonly static DependencyProperty PlateProperty = DependencyProperty.Register("Plate", typeof(string), typeof(IRNationalPlateInput),
            new PropertyMetadata("", (obj, e) =>
            {
                if (e.NewValue != e.OldValue)
                {
                    var ir_plate = obj as IRNationalPlateInput;

                    ir_plate.UnhandleAll();

                    try
                    {
                        if (e.NewValue != null)
                        {
                            string plate = e.NewValue.ToString().Replace("_", "").Replace("-", "").Replace(",", "").Replace(".", "").ToUpper();
                            string s = "";
                            int l = plate.Length;

                            if (l > 0)
                            {
                                if (l >= 2)
                                {
                                    s = plate.Substring(0, 2).Trim();
                                    if (ir_plate.left_digits.Text != s)
                                        ir_plate.left_digits.Text = s;

                                    if (l >= 3)
                                    {
                                        char ch = plate.Substring(2, 1).Single();
                                        string mch = PlateLetterConverter.ConvertToDisplayLetter(ch);

                                        if (string.IsNullOrEmpty(mch) == false)
                                        {
                                            if (ir_plate.mid_char.SelectedValue as string != mch)
                                            {
                                                ir_plate.mid_char.SelectedValue = mch;
                                            }
                                        }
                                        else
                                        {
                                            ir_plate.mid_char.SelectedValue = null;
                                        }

                                        if (l >= 6)
                                        {
                                            s = plate.Substring(3, 3).Trim();
                                            if (ir_plate.mid_digits.Text != s)
                                                ir_plate.mid_digits.Text = s;

                                            if (l >= 8)
                                            {
                                                s = plate.Substring(6, 2).Trim();
                                                if (ir_plate.right_digits.Text != s)
                                                    ir_plate.right_digits.Text = s;
                                            }
                                            else
                                            {
                                                s = plate.Substring(6).Trim();
                                                if (ir_plate.right_digits.Text != s)
                                                    ir_plate.right_digits.Text = s;
                                            }
                                        }
                                        else if (l >= 4)
                                        {
                                            s = plate.Substring(3).Trim();
                                            if (ir_plate.mid_digits.Text != s)
                                                ir_plate.mid_digits.Text = s;
                                            ir_plate.ResetPlate(3);
                                        }
                                        else
                                        {
                                            ir_plate.ResetPlate(2);
                                        }
                                    }
                                    else
                                    {
                                        ir_plate.ResetPlate(1);
                                    }
                                }
                                else
                                {
                                    s = plate.Trim();
                                    if (ir_plate.left_digits.Text != s)
                                        ir_plate.left_digits.Text = s;
                                    ir_plate.ResetPlate(1);
                                }
                            }
                            else
                            {
                                ir_plate.ResetPlate();
                            }
                        }
                        else
                        {
                            ir_plate.ResetPlate();
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

        public IRNationalPlateInput()
        {
            InitializeComponent();
        }

        #region HandleAll/UnhandleAll
        void HandleAll()
        {
            this.left_digits.TextChanged += left_digits_TextChanged;
            this.mid_digits.TextChanged += mid_digits_TextChanged;
            this.right_digits.TextChanged += right_digits_TextChanged;
            this.mid_char.SelectionChanged += mid_char_SelectionChanged;
        }

        void UnhandleAll()
        {
            this.left_digits.TextChanged -= left_digits_TextChanged;
            this.mid_digits.TextChanged -= mid_digits_TextChanged;
            this.right_digits.TextChanged -= right_digits_TextChanged;
            this.mid_char.SelectionChanged -= mid_char_SelectionChanged;
        }
        #endregion

        #region ResetPlate
        void ResetPlate(int level = 0)
        {
            if (level == 0)
                this.left_digits.Text = "";
            if (level == 1)
                this.mid_char.SelectedValue = null;
            if (level == 2)
                this.mid_digits.Text = "";
            if (level == 3)
                this.right_digits.Text = "";
        }
        #endregion

        #region SetPlate
        private void left_digits_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetPlate();
            if (this.left_digits.Text.Length >= 2)
                this.mid_char.Focus();
        }

        private void mid_digits_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetPlate();
            if (this.mid_digits.Text.Length >= 3)
                this.right_digits.Focus();
        }

        private void right_digits_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetPlate();
        }

        private void mid_char_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetPlate();
        }

        private void mid_char_DropDownClosed(object sender, EventArgs e)
        {
            this.mid_digits.Focus();
        }

        void SetPlate()
        {
            string plate =
                ((this.left_digits.Text + "  ").Substring(0, 2) +
                (this.mid_char.SelectedValue != null ? PlateLetterConverter.ConvertToStandardLetter(this.mid_char.SelectedValue.ToString()) : ' ') +
                (this.mid_digits.Text + "   ").Substring(0, 3) +
                this.right_digits.Text).TrimEnd();

            if (plate != Plate)
                Plate = plate;
        }

        private void left_digits_KeyDown(object sender, KeyEventArgs e)
        {
            var txt = sender as TextBox;
            if (e.Key == Key.Right && txt.SelectionStart == txt.Text.Length)
            {
                this.mid_char.Focus();
            }
        }

        private void mid_digits_KeyDown(object sender, KeyEventArgs e)
        {
            var txt = sender as TextBox;
            if (e.Key == Key.Right && txt.SelectionStart == txt.Text.Length)
            {
                this.right_digits.Focus();
                this.right_digits.SelectionStart = 0;
            }
            else if (e.Key == Key.Left && txt.SelectionStart == 0)
            {
                this.mid_char.Focus();
            }
        }

        private void right_digits_KeyDown(object sender, KeyEventArgs e)
        {
            var txt = sender as TextBox;
            if (e.Key == Key.Left && txt.SelectionStart == 0)
            {
                this.mid_digits.Focus();
                this.mid_digits.SelectionStart = this.mid_digits.Text.Length;
            }
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Validates plate string with both Latin and Persian letters.
        /// </summary>
        public static bool ValidatePlate(string plate)
        {
            return Regex.Match(plate, @"^[1-9]{2}[اآبپتجدسصطعقکكلمنوهیيچثشفز]{1}[1-9]{5}$").Success;
        }

        /// <summary>
        /// Converts a plate string to standard format.
        /// </summary>
        public static string ConvertToStandard(string plate)
        {
            plate = plate.Replace(" ", "").Replace("_", "").Replace("-", "").Replace(",", "").Replace(".", "").ToUpper();

            if (ValidatePlate(plate) == false) return "";

            char mid_char = PlateLetterConverter.ConvertToStandardLetter(plate[2].ToString());

            plate = plate.Substring(0, 2) + mid_char + plate.Substring(3);

            return plate;
        }
        #endregion

    }
}
