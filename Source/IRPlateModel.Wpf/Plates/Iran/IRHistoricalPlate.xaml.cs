using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IRPlateModel.Wpf.Plates.Iran
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
