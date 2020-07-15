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



        private string _gearNum;

        [Category("Custom Properties")]
        public string GearNum
        {
            get { return _gearNum; }
            set { _gearNum = value; lblGearNumber.Text = Convert.ToString(value); }
        }

        [Category("Custom Properties")]
        public string GearRatio
        {
            get { return txtGearRatio.Text; }
            set { txtGearRatio.Text = Convert.ToString(value); }
        }
    }
}
