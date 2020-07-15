using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VehicleTractionCharacteristicBl.Controller;
using VehicleTractionCharacteristicBl.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using VehicleTractionCharacteristicCustomControls;

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

        private void btnSaveExcelExternalCharacteristic_Click(object sender, EventArgs e)
        {
            SaveExternalEngienCharacteristicToExcel();
        }

        private void btnAddGearToGearbox_Click(object sender, EventArgs e)
        {
            AddGearToGearbox();
        }

        private void btnDeleteGearInGearbox_Click(object sender, EventArgs e)
        {
            DeleteGearInGearbox();
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

        private void SaveExternalEngienCharacteristicToExcel()
        {
            using (var ExcelFile = new ExcelPackage())
            {
                ExcelWorksheet workSheet = ExcelFile.Workbook.Worksheets.Add("ХАРАКТЕРИСТИКА ДВИГАТЕЛЯ");

                workSheet.Cells["B1"].Value = "ВНЕШНЯЯ СКОРОСТНАЯ ХАРАКТЕРИСТИКА ДВИГАТЕЛЯ";
                workSheet.Cells["B1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B1:E1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                workSheet.Cells["B2"].Value = "Модель автомобиля:";
                workSheet.Cells["B2:D2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["E2"].Value = txtCarModel.Text;
                workSheet.Cells["E2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["E2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                workSheet.Cells["B4"].Value = "id";
                workSheet.Cells["B4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["C4"].Value = "Обороты, об/мин";
                workSheet.Cells["C4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["C4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["D4"].Value = "Мощность, кВт";
                workSheet.Cells["D4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["D4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["E4"].Value = "Момент, Нм";
                workSheet.Cells["E4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["E4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["F4"].Value = "Уд. расход, г/кВтч";
                workSheet.Cells["F4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["F4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                double headerCellWidth = 16.71;
                workSheet.Column(3).Width = headerCellWidth;
                workSheet.Column(4).Width = headerCellWidth;
                workSheet.Column(5).Width = headerCellWidth;
                workSheet.Column(6).Width = headerCellWidth;

                using (var db = new VTCContext())
                {
                    workSheet.Cells["B5"].LoadFromCollection(db.Engine);
                }

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files|*.xlsx|All files|*.*";
                saveFileDialog.FileName = "Внешняя скоростная характеристика автомобиля " + txtCarModel.Text + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    ExcelFile.SaveAs(file);
                }
            }
        }

        private void AddGearToGearbox()
        {
            GearRatioBox gearRatioBox = new GearRatioBox
            {
                GearNum = $"{flpGearRatioInGearbox.Controls.Count + 1}:"
            };

            flpGearRatioInGearbox.Controls.Add(gearRatioBox);
        }

        private void DeleteGearInGearbox()
        {
            try
            {
                flpGearRatioInGearbox.Controls.RemoveAt(flpGearRatioInGearbox.Controls.Count - 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ступени доступные для удаления отсутствуют!", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
