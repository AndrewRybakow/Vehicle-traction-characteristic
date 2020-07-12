using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTractionCharacteristicBl.Controller;
using VehicleTractionCharacteristicBl.Model;

namespace VehicleTractionCharacteristicUi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            CalculateExternalEngineCharacteristic();
            BuildExternalEngineCharacteristicGraph();
        }



        private void CalculateExternalEngineCharacteristic()
        {
            using (var db = new VTCContext())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Engines");
                db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ( '[dbo].[Engines]', RESEED, 0 )");

                EngineController engine = new EngineController(Convert.ToInt32(txtMaxFrequency.Text),
                                                               Convert.ToInt32(txtMinFrequency.Text),
                                                               Convert.ToInt32(txtStep.Text),
                                                               Convert.ToDouble(txtMaxTorque.Text),
                                                               Convert.ToDouble(txtTorqueMaxPower.Text),
                                                               Convert.ToDouble(txtFrequencyMaxPower.Text),
                                                               Convert.ToDouble(txtFrequencyMaxTorque.Text),
                                                               Convert.ToDouble(txtMaxPower.Text),
                                                               Convert.ToDouble(txtMinFConsumption.Text));

                db.Engine.AddRange(engine.Calculate());
                db.SaveChanges();
            }
        }

        private void BuildExternalEngineCharacteristicGraph()
        {
            using (var db = new VTCContext())
            {
                var Frequency = db.Engine.Select(Engine => Engine.Frequency).ToList();
                var Power = db.Engine.Select(Engine => Engine.Power).ToList();
                var Torque = db.Engine.Select(Engine => Engine.Torque).ToList();
                var Consumption = db.Engine.Select(Engine => Engine.Consumption).ToList();

                chrtPower.Series["Power"].Points.Clear();
                chrtTorque.Series["Torque"].Points.Clear();
                chrtConsumption.Series["Consumption"].Points.Clear();

                for (int i = 0; i < Frequency.Count; i++)
                {
                    chrtPower.Series["Power"].Points.AddXY(Frequency[i], Power[i]);
                    chrtTorque.Series["Torque"].Points.AddXY(Frequency[i], Torque[i]);
                    chrtConsumption.Series["Consumption"].Points.AddXY(Frequency[i], Consumption[i]);
                }
            }
        }
    }
}
