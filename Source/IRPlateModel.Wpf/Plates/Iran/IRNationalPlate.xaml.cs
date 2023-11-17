using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace IRPlateModel.Wpf.Plates.Iran
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

            this.char_A.Visibility = Visibility.Collapsed;
            this.char_B.Visibility = Visibility.Collapsed;
            this.char_X.Visibility = Visibility.Collapsed;
            this.char_J.Visibility = Visibility.Collapsed;
            this.char_D.Visibility = Visibility.Collapsed;
            this.char_C.Visibility = Visibility.Collapsed;
            this.char_S.Visibility = Visibility.Collapsed;
            this.char_T.Visibility = Visibility.Collapsed;
            this.char_E.Visibility = Visibility.Collapsed;
            this.char_G.Visibility = Visibility.Collapsed;
            this.char_K.Visibility = Visibility.Collapsed;
            this.char_L.Visibility = Visibility.Collapsed;
            this.char_M.Visibility = Visibility.Collapsed;
            this.char_N.Visibility = Visibility.Collapsed;
            this.char_V.Visibility = Visibility.Collapsed;
            this.char_H.Visibility = Visibility.Collapsed;
            this.char_Y.Visibility = Visibility.Collapsed;
            this.char_W.Visibility = Visibility.Collapsed;
            this.char_P.Visibility = Visibility.Collapsed;
            this.char_TH.Visibility = Visibility.Collapsed;
            this.char_SH.Visibility = Visibility.Collapsed;
            this.char_F.Visibility = Visibility.Collapsed;
            this.char_Z.Visibility = Visibility.Collapsed;
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
                    this.PlateMidChar = 'ا';
                    this.char_A.Visibility = Visibility.Visible;
                    break;
                case 'B':
                case 'ب':
                    this.PlateMidChar = 'ب';
                    this.char_B.Visibility = Visibility.Visible;
                    break;
                case 'X':
                case 'ت':
                    this.PlateMidChar = 'ت';
                    this.char_X.Visibility = Visibility.Visible;
                    break;
                case 'J':
                case 'ج':
                    this.PlateMidChar = 'ج';
                    this.char_J.Visibility = Visibility.Visible;
                    break;
                case 'D':
                case 'د':
                    this.PlateMidChar = 'د';
                    this.char_D.Visibility = Visibility.Visible;
                    break;
                case 'C':
                case 'س':
                    this.PlateMidChar = 'س';
                    this.char_C.Visibility = Visibility.Visible;
                    break;
                case 'S':
                case 'ص':
                    this.PlateMidChar = 'ص';
                    this.char_S.Visibility = Visibility.Visible;
                    break;
                case 'T':
                case 'ط':
                    this.PlateMidChar = 'ط';
                    this.char_T.Visibility = Visibility.Visible;
                    break;
                case 'E':
                case 'ع':
                    this.PlateMidChar = 'ع';
                    this.char_E.Visibility = Visibility.Visible;
                    break;
                case 'G':
                case 'ق':
                    this.PlateMidChar = 'ق';
                    this.char_G.Visibility = Visibility.Visible;
                    break;
                case 'K':
                case 'ک':
                case 'ك':
                    this.PlateMidChar = 'ک';
                    this.char_K.Visibility = Visibility.Visible;
                    break;
                case 'L':
                case 'ل':
                    this.PlateMidChar = 'ل';
                    this.char_L.Visibility = Visibility.Visible;
                    break;
                case 'M':
                case 'م':
                    this.PlateMidChar = 'م';
                    this.char_M.Visibility = Visibility.Visible;
                    break;
                case 'N':
                case 'ن':
                    this.PlateMidChar = 'ن';
                    this.char_N.Visibility = Visibility.Visible;
                    break;
                case 'V':
                case 'و':
                    this.PlateMidChar = 'و';
                    this.char_V.Visibility = Visibility.Visible;
                    break;
                case 'H':
                case 'ه':
                    this.PlateMidChar = 'ه';
                    this.char_H.Visibility = Visibility.Visible;
                    break;
                case 'Y':
                case 'ی':
                case 'ي':
                    this.PlateMidChar = 'ی';
                    this.char_Y.Visibility = Visibility.Visible;
                    break;
                case 'Z':
                case 'چ':
                    this.PlateMidChar = 'چ';
                    this.char_W.Visibility = Visibility.Visible;
                    break;
                case 'P':
                case 'پ':
                    this.PlateMidChar = 'پ';
                    this.char_P.Visibility = Visibility.Visible;
                    break;
                case 'ش':
                    this.PlateMidChar = 'ش';
                    this.char_SH.Visibility = Visibility.Visible;
                    break;
                case 'ز':
                    this.PlateMidChar = 'ز';
                    this.char_Z.Visibility = Visibility.Visible;
                    break;
                case 'ف':
                    this.PlateMidChar = 'ف';
                    this.char_F.Visibility = Visibility.Visible;
                    break;
                case 'ث':
                    this.PlateMidChar = 'ث';
                    this.char_TH.Visibility = Visibility.Visible;
                    break;
            }

            if (this.PlateMidChar == 'ا')
            {
                this.Foreground = new SolidColorBrush(Colors.White);
                this.brdMain.Background = new SolidColorBrush(Colors.Red);
            }
            else if (this.PlateMidChar == 'ت' || this.PlateMidChar == 'ع' || this.PlateMidChar == 'ک')
            {
                this.Foreground = new SolidColorBrush(Colors.Black);
                this.brdMain.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xBE, 0x00));
            }
            else if (this.PlateMidChar == 'پ' || this.PlateMidChar == 'ث')
            {
                this.Foreground = new SolidColorBrush(Colors.White);
                this.brdMain.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x53, 0x23));
            }
            else if (this.PlateMidChar == 'ش')
            {
                this.Foreground = new SolidColorBrush(Colors.Black);
                this.brdMain.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xCF, 0xAC, 0x60));
            }
            else if (this.PlateMidChar == 'ز' || this.PlateMidChar == 'ف')
            {
                this.Foreground = new SolidColorBrush(Colors.White);
                this.brdMain.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x79, 0xC1));
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
