using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace VehicleTractionCharacteristicCustomControls
{
    public partial class GearRatioBox : UserControl
    {
        public GearRatioBox()
        {
            InitializeComponent();
        }



        private string _gearName;
        private int _gearNumber;

        [Category("Custom Properties")]
        public string GearName
        {
            get { return _gearName; }
            set { _gearName = value; lblGearNumber.Text = Convert.ToString(value); }
        }

        [Category("Custom Properties")]
        public int GearNumber
        {
            get { return _gearNumber; }
            set { _gearNumber = value; }
        }

        [Category("Custom Properties")]
        public double GearRatio
        {
            get { return Convert.ToDouble(txtGearRatio.Text); }
            set { txtGearRatio.Text = Convert.ToString(value); }
        }
    }
}
