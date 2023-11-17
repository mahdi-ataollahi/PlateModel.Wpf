using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace IRPlateModel.Wpf.Plates.Iran
{
    [ContentProperty("Plate")]
    public partial class IRFreeTradeZonePlate : UserControl
    {
        public enum IranFreeTradeZones
        {
            None = 0,
            Anzali,
            Aras,
            Arvand,
            Kish,
        }

        #region FreeTradeZone
        public readonly static DependencyProperty FreeTradeZoneProperty = DependencyProperty.Register("FreeTradeZone", typeof(IranFreeTradeZones), typeof(IRFreeTradeZonePlate),
            new PropertyMetadata(IranFreeTradeZones.None, (obj, e) =>
            {
                var ir_plate = obj as IRFreeTradeZonePlate;

                ir_plate.zone_name.Text = "";
                ir_plate.zone_logo.Source = null;

                if (e.NewValue != null)
                {
                    var zone = (IranFreeTradeZones)e.NewValue;
                    if (zone != IranFreeTradeZones.None)
                    {
                        ir_plate.zone_name.Text = zone.ToString().ToUpper();
                        ir_plate.zone_logo.Source = new BitmapImage(new Uri("/IRPlateModel.Wpf;component/Pic/Iran/" + zone.ToString() + ".PNG", UriKind.Relative));
                    }
                }
            }));

        [Category("Common")]
        public IranFreeTradeZones FreeTradeZone
        {
            get { return (IranFreeTradeZones)GetValue(FreeTradeZoneProperty); }
            set { SetValue(FreeTradeZoneProperty, value); }
        }
        #endregion

        #region Plate
        public readonly static DependencyProperty PlateProperty = DependencyProperty.Register("Plate", typeof(string), typeof(IRFreeTradeZonePlate),
            new PropertyMetadata("", (obj, e) =>
            {
                var ir_plate = obj as IRFreeTradeZonePlate;

                ir_plate.top_digits.Text = ir_plate.bottom_digits.Text = "";

                if (e.NewValue != null)
                {
                    string plate = e.NewValue.ToString().Replace(" ", "").Replace("_", "").Replace("-", "").Replace(",", "").Replace(".", "").ToUpper();
                    ir_plate.top_digits.Text = ir_plate.bottom_digits.Text = plate;
                }
            }));

        [Category("Common")]
        public string Plate
        {
            get { return (string)GetValue(PlateProperty); }
            set { SetValue(PlateProperty, value); }
        }
        #endregion

        public IRFreeTradeZonePlate()
        {
            InitializeComponent();
        }
    }
}
