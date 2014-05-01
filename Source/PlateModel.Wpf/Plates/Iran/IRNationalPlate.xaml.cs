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
    public partial class IRNationalPlate : UserControl
    {
        char PlateMidChar = (char)0;

        #region Plate
        public readonly static DependencyProperty PlateProperty = DependencyProperty.Register("Plate", typeof(string), typeof(IRNationalPlate),
            new PropertyMetadata("", (obj, e) =>
            {
                var ir_plate = obj as IRNationalPlate;

                ir_plate.ResetPlate();

                if (e.NewValue != null)
                {
                    string plate = e.NewValue.ToString().Replace("_", "").Replace("-", "").Replace(",", "").Replace(".", "").ToUpper();

                    if (plate.Length > 0)
                    {
                        int i = 0;
                        int l = plate.Length;

                        ir_plate.left_digit1.Text = plate[i].ToString();
                        if (++i >= l) return;

                        ir_plate.left_digit2.Text = plate[i].ToString();
                        if (++i >= l) return;

                        ir_plate.SetMidChar(plate[i]);
                        if (++i >= l) return;

                        ir_plate.mid_digit1.Text = plate[i].ToString();
                        if (++i >= l) return;

                        ir_plate.mid_digit2.Text = plate[i].ToString();
                        if (++i >= l) return;

                        ir_plate.mid_digit3.Text = plate[i].ToString();
                        if (++i >= l) return;

                        ir_plate.right_digit1.Text = plate[i].ToString();
                        if (++i >= l) return;

                        ir_plate.right_digit2.Text = plate[i].ToString();
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

        public IRNationalPlate()
        {
            InitializeComponent();
        }

        #region ResetPlate
        void ResetPlate()
        {
            this.Foreground = new SolidColorBrush(Colors.Black);
            this.brdMain.Background = new SolidColorBrush(Colors.White);
            this.left_digit1.Text = "";
            this.left_digit2.Text = "";
            this.mid_digit1.Text = "";
            this.mid_digit2.Text = "";
            this.mid_digit3.Text = "";
            this.right_digit1.Text = "";
            this.right_digit2.Text = "";

            this.char_A.Visibility = System.Windows.Visibility.Collapsed;
            this.char_B.Visibility = System.Windows.Visibility.Collapsed;
            this.char_P.Visibility = System.Windows.Visibility.Collapsed;
            this.char_X.Visibility = System.Windows.Visibility.Collapsed;
            this.char_J.Visibility = System.Windows.Visibility.Collapsed;
            this.char_D.Visibility = System.Windows.Visibility.Collapsed;
            this.char_C.Visibility = System.Windows.Visibility.Collapsed;
            this.char_S.Visibility = System.Windows.Visibility.Collapsed;
            this.char_T.Visibility = System.Windows.Visibility.Collapsed;
            this.char_E.Visibility = System.Windows.Visibility.Collapsed;
            this.char_G.Visibility = System.Windows.Visibility.Collapsed;
            this.char_K.Visibility = System.Windows.Visibility.Collapsed;
            this.char_L.Visibility = System.Windows.Visibility.Collapsed;
            this.char_M.Visibility = System.Windows.Visibility.Collapsed;
            this.char_N.Visibility = System.Windows.Visibility.Collapsed;
            this.char_V.Visibility = System.Windows.Visibility.Collapsed;
            this.char_H.Visibility = System.Windows.Visibility.Collapsed;
            this.char_Y.Visibility = System.Windows.Visibility.Collapsed;
            this.char_Z.Visibility = System.Windows.Visibility.Collapsed;
        }
        #endregion

        #region SetMidChar
        void SetMidChar(char ch)
        {
            switch (ch)
            {
                case 'A':
                case 'ا':
                case 'آ':
                    this.PlateMidChar = 'A';
                    this.char_A.Visibility = Visibility.Visible;
                    break;
                case 'B':
                case 'ب':
                    this.PlateMidChar = 'B';
                    this.char_B.Visibility = Visibility.Visible;
                    break;
                case 'P':
                case 'پ':
                    this.PlateMidChar = 'P';
                    this.char_P.Visibility = Visibility.Visible;
                    break;
                case 'X':
                case 'ت':
                    this.PlateMidChar = 'X';
                    this.char_X.Visibility = Visibility.Visible;
                    break;
                case 'J':
                case 'ج':
                    this.PlateMidChar = 'J';
                    this.char_J.Visibility = Visibility.Visible;
                    break;
                case 'D':
                case 'د':
                    this.PlateMidChar = 'D';
                    this.char_D.Visibility = Visibility.Visible;
                    break;
                case 'C':
                case 'س':
                    this.PlateMidChar = 'C';
                    this.char_C.Visibility = Visibility.Visible;
                    break;
                case 'S':
                case 'ص':
                    this.PlateMidChar = 'S';
                    this.char_S.Visibility = Visibility.Visible;
                    break;
                case 'T':
                case 'ط':
                    this.PlateMidChar = 'T';
                    this.char_T.Visibility = Visibility.Visible;
                    break;
                case 'E':
                case 'ع':
                    this.PlateMidChar = 'E';
                    this.char_E.Visibility = Visibility.Visible;
                    break;
                case 'G':
                case 'ق':
                    this.PlateMidChar = 'G';
                    this.char_G.Visibility = Visibility.Visible;
                    break;
                case 'K':
                case 'ک':
                case 'ك':
                    this.PlateMidChar = 'K';
                    this.char_K.Visibility = Visibility.Visible;
                    break;
                case 'L':
                case 'ل':
                    this.PlateMidChar = 'L';
                    this.char_L.Visibility = Visibility.Visible;
                    break;
                case 'M':
                case 'م':
                    this.PlateMidChar = 'M';
                    this.char_M.Visibility = Visibility.Visible;
                    break;
                case 'N':
                case 'ن':
                    this.PlateMidChar = 'N';
                    this.char_N.Visibility = Visibility.Visible;
                    break;
                case 'V':
                case 'و':
                    this.PlateMidChar = 'V';
                    this.char_V.Visibility = Visibility.Visible;
                    break;
                case 'H':
                case 'ه':
                    this.PlateMidChar = 'H';
                    this.char_H.Visibility = Visibility.Visible;
                    break;
                case 'Y':
                case 'ی':
                case 'ي':
                    this.PlateMidChar = 'Y';
                    this.char_Y.Visibility = Visibility.Visible;
                    break;
                case 'Z':
                case 'چ':
                case 'ز':
                    this.PlateMidChar = 'Z';
                    this.char_Z.Visibility = Visibility.Visible;
                    break;
            }

            if (this.PlateMidChar == 'A')
            {
                this.Foreground = new SolidColorBrush(Colors.White);
                this.brdMain.Background = new SolidColorBrush(Colors.Red);
            }
            else if (this.PlateMidChar == 'P')
            {
                this.Foreground = new SolidColorBrush(Colors.White);
                this.brdMain.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x53, 0x23));
            }
            else if (this.PlateMidChar == 'X' || this.PlateMidChar == 'E' || this.PlateMidChar == 'K')
            {
                this.Foreground = new SolidColorBrush(Colors.Black);
                this.brdMain.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xBE, 0x00));
            }
            else
            {
                this.Foreground = new SolidColorBrush(Colors.Black);
                this.brdMain.Background = new SolidColorBrush(Colors.White);
            }
        }
        #endregion

    }
}
