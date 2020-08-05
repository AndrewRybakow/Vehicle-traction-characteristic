using System;
using System.Drawing;
using System.Windows.Forms;
using VehicleTractionCharacteristicBl.Controller;
using VehicleTractionCharacteristicBl.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using VehicleTractionCharacteristicCustomControls;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;

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

            GetGearsOfGearbox();

            CalculateSpeedCharacteristic();

            CalculateTractionForceCharacteristic();
            BuildTractionForceCharacteristicGraph();

            CalculateDynamicFactorCharacterisctic();
            BuildDynamicFactorCharacteristicGraph();

            //CalculateAccelerationCharacterisctic();
            //BuildAccelerationCharacteristicGraph();
        }

        private void btnAddGearToGearbox_Click(object sender, EventArgs e)
        {
            AddGearToGearbox();
        }

        private void btnDeleteGearInGearbox_Click(object sender, EventArgs e)
        {
            DeleteGearInGearbox();
        }

        private void rdoTransferBoxNo_CheckedChanged(object sender, EventArgs e)
        {
            DisableTrasferBox();
        }

        private void rdoTransferBoxYes_CheckedChanged(object sender, EventArgs e)
        {
            EnableTrasferBox();
        }

        private void btnSaveExcelExternalCharacteristic_Click(object sender, EventArgs e)
        {
            SaveExternalEngienCharacteristicToExcel();
        }

        private void btnSaveExcelTractionCharacteristic_Click(object sender, EventArgs e)
        {
            SaveTractionCharacteristicToExcel();
        }

        private void btnSaveExcelDynamicCharacteristic_Click(object sender, EventArgs e)
        {
            SaveDynamicFactorCharacteristicToExcel();
        }

        private void btnSaveExcelAccelerationCharacteristic_Click(object sender, EventArgs e)
        {
            //SaveAccelerationCharacteristicToExcel();
        }


        private void CalculateExternalEngineCharacteristic()
        {
            EngineController engine = new EngineController(Convert.ToInt32(txtMaxFrequency.Text),
                                                               Convert.ToInt32(txtMinFrequency.Text),
                                                               Convert.ToInt32(txtStep.Text),
                                                               Convert.ToDouble(txtMaxTorque.Text),
                                                               Convert.ToDouble(txtTorqueMaxPower.Text),
                                                               Convert.ToDouble(txtFrequencyMaxPower.Text),
                                                               Convert.ToDouble(txtFrequencyMaxTorque.Text),
                                                               Convert.ToDouble(txtMaxPower.Text),
                                                               Convert.ToDouble(txtMinFConsumption.Text));

            Vehicle.Engine = engine.Calculate();
        }
        
        private void BuildExternalEngineCharacteristicGraph()
        {
            chrtPower.Series["Power"].Points.Clear();
            chrtTorque.Series["Torque"].Points.Clear();
            chrtConsumption.Series["Consumption"].Points.Clear();

            for (int i = 0; i < Vehicle.Engine.Count; i++)
            {
                chrtPower.Series["Power"].Points.AddXY(Vehicle.Engine[i].Frequency, Vehicle.Engine[i].Power);
                chrtTorque.Series["Torque"].Points.AddXY(Vehicle.Engine[i].Frequency, Vehicle.Engine[i].Torque);
                chrtConsumption.Series["Consumption"].Points.AddXY(Vehicle.Engine[i].Frequency, Vehicle.Engine[i].Consumption);
            }
        }      

        private void SaveExternalEngienCharacteristicToExcel()
        {
            using (var ExcelFile = new ExcelPackage())
            {
                ExcelWorksheet workSheet = ExcelFile.Workbook.Worksheets.Add("ХАРАКТЕРИСТИКА ДВИГАТЕЛЯ");

                #region Table headers

                workSheet.Cells["B1"].Value = "ВНЕШНЯЯ СКОРОСТНАЯ ХАРАКТЕРИСТИКА ДВИГАТЕЛЯ";
                workSheet.Cells["B1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B1:E1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                workSheet.Cells["B2"].Value = "Модель автомобиля:";
                workSheet.Cells["B2:D2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["E2"].Value = txtCarModel.Text;
                workSheet.Cells["E2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["E2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                workSheet.Cells["B4"].Value = "Обороты, об/мин";
                workSheet.Cells["B4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["C4"].Value = "Мощность, кВт";
                workSheet.Cells["C4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["C4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["D4"].Value = "Момент, Нм";
                workSheet.Cells["D4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["D4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["E4"].Value = "Уд. расход, г/кВтч";
                workSheet.Cells["E4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["E4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                double headerCellWidth = 16.71;
                workSheet.Column(2).Width = headerCellWidth;
                workSheet.Column(3).Width = headerCellWidth;
                workSheet.Column(4).Width = headerCellWidth;
                workSheet.Column(5).Width = headerCellWidth;

                #endregion

                #region Table data

                workSheet.Cells["B5"].LoadFromCollection(Vehicle.Engine);

                #endregion

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
                GearName = $"{flpGearRatioInGearbox.Controls.Count + 1}:",
                GearNumber = flpGearRatioInGearbox.Controls.Count + 1
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

        private void GetGearsOfGearbox()
        {
            List<Gear> gears = new List<Gear>();

            foreach (GearRatioBox gear in flpGearRatioInGearbox.Controls)
            {
                gears.Add(new Gear
                {
                    GearNumber = gear.GearNumber,
                    GearRatio = gear.GearRatio
                });
            }

            Vehicle.Gears = gears;
        }

        private void DisableTrasferBox()
        {
            txtTransferBoxTopGearRatio.Text = Convert.ToString(1);
            txtTransferBoxTopGearRatio.Enabled = false;

            txtTransferBoxLowerGearRatio.Text = Convert.ToString(1);
            txtTransferBoxLowerGearRatio.Enabled = false;
        }

        private void EnableTrasferBox()
        {
            txtTransferBoxTopGearRatio.Text = String.Empty;
            txtTransferBoxTopGearRatio.Enabled = true;

            txtTransferBoxLowerGearRatio.Text = String.Empty;
            txtTransferBoxLowerGearRatio.Enabled = true;
        }


        private void CalculateSpeedCharacteristic()
        {
            SpeedContoller speed = new SpeedContoller(Convert.ToDouble(txtWheelRadius.Text),
                                                          Convert.ToDouble(txtTransferBoxTopGearRatio.Text),
                                                          Convert.ToDouble(txtTransferBoxLowerGearRatio.Text),
                                                          Convert.ToDouble(txtFinalDriveRatio.Text),
                                                          Vehicle.Engine,
                                                          Vehicle.Gears);

            Vehicle.Speed = speed.Calculate();
        }


        private void CalculateTractionForceCharacteristic()
        {
            TractionForceController tractionForce = new TractionForceController(Convert.ToDouble(txtTransferBoxTopGearRatio.Text),
                                                                                    Convert.ToDouble(txtTransferBoxLowerGearRatio.Text),
                                                                                    Convert.ToDouble(txtFinalDriveRatio.Text),
                                                                                    Convert.ToDouble(txtCoefOfTransEfficiency.Text),
                                                                                    Convert.ToDouble(txtWheelRadius.Text),
                                                                                    Vehicle.Engine,
                                                                                    Vehicle.Gears,
                                                                                    Vehicle.Speed);

            Vehicle.TractionForce = tractionForce.Calulate();
        }

        private void BuildTractionForceCharacteristicGraph()
        {
            chrtTractionForce.Series.Clear();

            // Add series to chart

            if (rdoTransferBoxYes.Checked)
            {
                chrtTractionForce.Series.Add(new Series
                {
                    Name = "lower Gear #1",
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 3
                });
            }

            for (int i = 1; i <= Vehicle.Gears.Count; i++)
            {
                chrtTractionForce.Series.Add(new Series
                {
                    Name = $"Gear #{i}",
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 3
                });
            }

            // Get points

            List<List<TractionForce>> tractionForceByGear = new List<List<TractionForce>>();

            if (rdoTransferBoxYes.Checked)
            {
                var list = (from tractionForce in Vehicle.TractionForce
                            where tractionForce.GearNumber == 0
                            select new TractionForce
                            {
                                Speed = Math.Round(tractionForce.Speed, 2),
                                TractionForceValue = tractionForce.TractionForceValue / 1000
                            }).ToList();

                tractionForceByGear.Add(list);
            }

            for (int i = 1; i <= Vehicle.Gears.Count; i++)
            {
                var list = (from tractionForce in Vehicle.TractionForce
                            where tractionForce.GearNumber == i
                            select new TractionForce
                            {
                                Speed = Math.Round(tractionForce.Speed, 2),
                                TractionForceValue = tractionForce.TractionForceValue / 1000
                            }).ToList();

                tractionForceByGear.Add(list);
            }

            // Add points to series

            if (rdoTransferBoxYes.Checked)
            {
                foreach (TractionForce item in tractionForceByGear[0])
                {
                    chrtTractionForce.Series["lower Gear #1"].Points.AddXY(item.Speed, item.TractionForceValue);
                }

                for (int i = 1; i < Vehicle.Gears.Count + 1; i++)
                {
                    foreach (TractionForce item in tractionForceByGear[i])
                    {
                        chrtTractionForce.Series[$"Gear #{i}"].Points.AddXY(item.Speed, item.TractionForceValue);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    foreach (TractionForce item in tractionForceByGear[i])
                    {
                        chrtTractionForce.Series[$"Gear #{i + 1}"].Points.AddXY(item.Speed, item.TractionForceValue);
                    }
                }
            }
        }

        private void SaveTractionCharacteristicToExcel()
        {
            using (var ExcelFile = new ExcelPackage())
            {
                ExcelWorksheet workSheet = ExcelFile.Workbook.Worksheets.Add("ТЯГОВАЯ ХАРАКТЕРИСТИКА");

                char step;
                int indent = 0; // it's 0 if transfer box is OFF and 2 if transfer box is ON

                #region Table headers

                workSheet.Cells["B1"].Value = "ТЯГОВАЯ ХАРАКТЕРИСТИКА АВТОМОБИЛЯ";
                workSheet.Cells["B1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B1:F1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                workSheet.Cells["B2"].Value = "Модель автомобиля:";
                workSheet.Cells["B2:D2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["E2"].Value = txtCarModel.Text;
                workSheet.Cells["E2:F2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["E2:F2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                workSheet.Cells["B4"].Value = "Сила тяги Р и скорость автомобиля V при движении на передаче:";
                workSheet.Cells["B4:H4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B4:H4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                if (rdoTransferBoxYes.Checked)
                {
                    // Set header for lower gear

                    workSheet.Cells["B5"].Value = Convert.ToString($"Передача #1 пониж.");
                    workSheet.Cells["B5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["B5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);
                    workSheet.Cells["B5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells["B5:C5"].Merge = true;


                    workSheet.Cells["B6"].Value = "V";
                    workSheet.Cells["B6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["B6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheet.Cells["B7"].Value = "км/ч";
                    workSheet.Cells["B7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["B7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));


                    workSheet.Cells["C6"].Value = "P";
                    workSheet.Cells["C6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["C6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheet.Cells["C7"].Value = "кН";
                    workSheet.Cells["C7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["C7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));


                    workSheet.Cells[$"C6:C{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;


                    // Get data for lower gear

                    List<TractionForce> tractionForceOnLowerGear = new List<TractionForce>();

                    tractionForceOnLowerGear = (from tractionForce in Vehicle.TractionForce
                                                where tractionForce.GearNumber == 0
                                                select new TractionForce
                                                {
                                                    Speed = tractionForce.Speed,
                                                    TractionForceValue = tractionForce.TractionForceValue / 1000
                                                }).ToList();


                    // Write data to file

                    step = 'B';
                    for (int j = 0; j < Vehicle.Engine.Count; j++)
                    {
                        workSheet.Cells[$"{step}{8 + j}"].Value = (tractionForceOnLowerGear[j].Speed);
                        workSheet.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (tractionForceOnLowerGear[j].TractionForceValue);
                    }

                    // Set indent for other gears

                    indent = 2;
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}5"].Value = Convert.ToString($"Передача #{Vehicle.Gears[i].GearNumber}");

                    workSheet.Cells[$"{step}5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    workSheet.Cells[$"{step}5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    workSheet.Cells[$"{step}5:{(char)(((int)step) + 1)}5"].Merge = true;

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count - 1; i++)
                {
                    workSheet.Cells[$"{step}6:{step}{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    step = (char)(((int)step) + 2);
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}6"].Value = "V";
                    workSheet.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheet.Cells[$"{step}7"].Value = "км/ч";
                    workSheet.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}6"].Value = "P";
                    workSheet.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheet.Cells[$"{step}7"].Value = "кН";
                    workSheet.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    step = (char)(((int)step) + 2);
                }

                #endregion

                #region Table data                

                List<List<TractionForce>> tractionForceByGear = new List<List<TractionForce>>();

                for (int i = 1; i <= Vehicle.Gears.Count; i++)
                {
                    var list = (from tractionForce in Vehicle.TractionForce
                                where tractionForce.GearNumber == i
                                select new TractionForce
                                {
                                    Speed = tractionForce.Speed,
                                    TractionForceValue = tractionForce.TractionForceValue / 1000
                                }).ToList();

                    tractionForceByGear.Add(list);
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < tractionForceByGear.Count; i++)
                {
                    for (int j = 0; j < Vehicle.Engine.Count; j++)
                    {
                        workSheet.Cells[$"{step}{8 + j}"].Value = (tractionForceByGear[i][j].Speed);
                        workSheet.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (tractionForceByGear[i][j].TractionForceValue);
                    }

                    step = (char)(((int)step) + 2);
                }

                #endregion

                #region Save dialog

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files|*.xlsx|All files|*.*";
                saveFileDialog.FileName = "Тяговая характеристика автомобиля " + txtCarModel.Text + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    ExcelFile.SaveAs(file);
                }

                #endregion
            }
        }


        private void CalculateDynamicFactorCharacterisctic()
        {
            DynamicFactorController dynamicFactorCharacteristic = new DynamicFactorController(Convert.ToDouble(txtWeightOnWheels.Text),
                                                                                                  Convert.ToDouble(txtDragCoefficient.Text),
                                                                                                  Convert.ToDouble(txtAirDensity.Text),
                                                                                                  Convert.ToDouble(txtProjectionHeight.Text),
                                                                                                  Convert.ToDouble(txtProjectionWidth.Text),
                                                                                                  Convert.ToDouble(txtFillingCoefficient.Text),
                                                                                                  Vehicle.TractionForce);

            Vehicle.DynamicFactor = dynamicFactorCharacteristic.Calculate();
        }

        private void BuildDynamicFactorCharacteristicGraph()
        {
            chrtDynamicCharacteristic.Series.Clear();

            // Add series to chart

            if (rdoTransferBoxYes.Checked)
            {
                chrtDynamicCharacteristic.Series.Add(new Series
                {
                    Name = "lower Gear #1",
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 3
                });
            }

            for (int i = 1; i <= Vehicle.Gears.Count; i++)
            {
                chrtDynamicCharacteristic.Series.Add(new Series
                {
                    Name = $"Gear #{i}",
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 3
                });
            }

            // Get points

            List<List<DynamicFactor>> dynamicFactorByGear = new List<List<DynamicFactor>>();

            if (rdoTransferBoxYes.Checked)
            {
                var list = (from dynamicFactor in Vehicle.DynamicFactor
                            where dynamicFactor.GearNumber == 0
                            select new DynamicFactor
                            {
                                Speed = Math.Round(dynamicFactor.Speed, 2),
                                DynamicFactorValue = dynamicFactor.DynamicFactorValue
                            }).ToList();

                dynamicFactorByGear.Add(list);
            }

            for (int i = 1; i <= Vehicle.Gears.Count; i++)
            {
                var list = (from dynamicFactor in Vehicle.DynamicFactor
                            where dynamicFactor.GearNumber == i
                            select new DynamicFactor
                            {
                                Speed = Math.Round(dynamicFactor.Speed, 2),
                                DynamicFactorValue = dynamicFactor.DynamicFactorValue
                            }).ToList();

                dynamicFactorByGear.Add(list);
            }

            // Add points to series

            if (rdoTransferBoxYes.Checked)
            {
                foreach (DynamicFactor item in dynamicFactorByGear[0])
                {
                    chrtDynamicCharacteristic.Series["lower Gear #1"].Points.AddXY(item.Speed, item.DynamicFactorValue);
                }

                for (int i = 1; i < Vehicle.Gears.Count + 1; i++)
                {
                    foreach (DynamicFactor item in dynamicFactorByGear[i])
                    {
                        chrtDynamicCharacteristic.Series[$"Gear #{i}"].Points.AddXY(item.Speed, item.DynamicFactorValue);
                    }
                }
            }
            else
            {
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    foreach (DynamicFactor item in dynamicFactorByGear[i])
                    {
                        chrtDynamicCharacteristic.Series[$"Gear #{i + 1}"].Points.AddXY(item.Speed, item.DynamicFactorValue);
                    }
                }
            }
        }

        private void SaveDynamicFactorCharacteristicToExcel()
        {
            using (var ExcelFile = new ExcelPackage())
            {
                ExcelWorksheet workSheet = ExcelFile.Workbook.Worksheets.Add("ДИНАМИЧЕСКАЯ ХАРАКТЕРИСТИКА");

                char step;
                int indent = 0; // it's 0 if transfer box is OFF and 2 if transfer box is ON

                #region Table headers

                workSheet.Cells["B1"].Value = "ДИНАМИЧЕСКАЯ ХАРАКТЕРИСТИКА АВТОМОБИЛЯ";
                workSheet.Cells["B1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B1:G1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                workSheet.Cells["B2"].Value = "Модель автомобиля:";
                workSheet.Cells["B2:E2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B2:E2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["F2"].Value = txtCarModel.Text;
                workSheet.Cells["F2:G2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["F2:G2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                workSheet.Cells["B4"].Value = "Скорость V и динамический фактор D при движении на передаче:";
                workSheet.Cells["B4:H4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B4:H4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);



                if (rdoTransferBoxYes.Checked)
                {
                    // Set header for lower gear

                    workSheet.Cells["B5"].Value = Convert.ToString("Передача #1 пониж.");
                    workSheet.Cells["B5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["B5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);
                    workSheet.Cells["B5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells[$"B5:C5"].Merge = true;

                    workSheet.Cells["B6"].Value = "V";
                    workSheet.Cells["B6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["B6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheet.Cells["B7"].Value = "км/ч";
                    workSheet.Cells["B7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["B7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheet.Cells["C6"].Value = "D";
                    workSheet.Cells["C6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["C6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheet.Cells["C7"].Value = "%";
                    workSheet.Cells["C7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells["C7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheet.Cells[$"C6:C{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;


                    // Get data for lower gear

                    List<DynamicFactor> dynamicFactorOnLowerGear = new List<DynamicFactor>();

                    dynamicFactorOnLowerGear = (from dynamicFactor in Vehicle.DynamicFactor
                                                where dynamicFactor.GearNumber == 0
                                                select new DynamicFactor
                                                {
                                                    Speed = dynamicFactor.Speed,
                                                    DynamicFactorValue = dynamicFactor.DynamicFactorValue
                                                }).ToList();


                    // Write data to file

                    step = 'B';
                    for (int j = 0; j < Vehicle.Engine.Count; j++)
                    {
                        workSheet.Cells[$"{step}{8 + j}"].Value = (dynamicFactorOnLowerGear[j].Speed);
                        workSheet.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (dynamicFactorOnLowerGear[j].DynamicFactorValue);
                    }


                    // Set indent for other gears

                    indent = 2;
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}5"].Value = Convert.ToString($"Передача #{Vehicle.Gears[i].GearNumber}");

                    workSheet.Cells[$"{step}5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    workSheet.Cells[$"{step}5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    workSheet.Cells[$"{step}5:{(char)(((int)step) + 1)}5"].Merge = true;

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count - 1; i++)
                {
                    workSheet.Cells[$"{step}6:{step}{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    step = (char)(((int)step) + 2);
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}6"].Value = "V";
                    workSheet.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheet.Cells[$"{step}7"].Value = "км/ч";
                    workSheet.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}6"].Value = "D";
                    workSheet.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheet.Cells[$"{step}7"].Value = "%";
                    workSheet.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    step = (char)(((int)step) + 2);
                }

                #endregion

                #region Table data                

                List<List<DynamicFactor>> dynamicFactorByGear = new List<List<DynamicFactor>>();

                for (int i = 1; i <= Vehicle.Gears.Count; i++)
                {
                    var list = (from dynamicFactor in Vehicle.DynamicFactor
                                where dynamicFactor.GearNumber == i
                                select new DynamicFactor
                                {
                                    Speed = dynamicFactor.Speed,
                                    DynamicFactorValue = dynamicFactor.DynamicFactorValue
                                }).ToList();

                    dynamicFactorByGear.Add(list);
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < dynamicFactorByGear.Count; i++)
                {
                    for (int j = 0; j < Vehicle.Engine.Count; j++)
                    {
                        workSheet.Cells[$"{step}{8 + j}"].Value = (dynamicFactorByGear[i][j].Speed);
                        workSheet.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (dynamicFactorByGear[i][j].DynamicFactorValue);
                    }

                    step = (char)(((int)step) + 2);
                }

                #endregion

                #region Save dialog

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files|*.xlsx|All files|*.*";
                saveFileDialog.FileName = "Динамическая характеристика автомобиля " + txtCarModel.Text + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    ExcelFile.SaveAs(file);
                }

                #endregion
            }
        }


        private void CalculateAccelerationCharacterisctic()
        {
            AccelerationController accelerationCharacteristic = new AccelerationController(Convert.ToDouble(txtVehicleMass.Text),
                                                                                           Convert.ToInt32(txtNumberOfWheels.Text),
                                                                                           Convert.ToDouble(txtWheelRadius.Text),
                                                                                           Convert.ToDouble(txtRollingResistanceCoefficient.Text),
                                                                                           Convert.ToDouble(txtWheelMomentOfInertia.Text),
                                                                                           Convert.ToDouble(txtMotorMomentOfInertia.Text),
                                                                                           Convert.ToDouble(txtFinalDriveRatio.Text),
                                                                                           Convert.ToDouble(txtCoefOfTransEfficiency.Text),
                                                                                           Vehicle.Engine,
                                                                                           Vehicle.Gears,
                                                                                           Vehicle.DynamicFactor);

            Vehicle.Acceleration = accelerationCharacteristic.Caclculate();
        }

        private void BuildAccelerationCharacteristicGraph()
        {
            chrtAccelerationCharacteristic.Series.Clear();

            // Add series to chart

            for (int i = 1; i <= Vehicle.Gears.Count; i++)
            {
                chrtAccelerationCharacteristic.Series.Add(new Series
                {
                    Name = $"Gear #{i}",
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 3
                });
            }

            // Get points

            List<List<Acceleration>> accelerationByGear = new List<List<Acceleration>>();

            for (int i = 1; i <= Vehicle.Gears.Count; i++)
            {
                var list = (from acceleration in Vehicle.Acceleration
                            where acceleration.GearNumber == i
                            select new Acceleration
                            {
                                Speed = Math.Round(acceleration.Speed, 2),
                                AccelerationValue = acceleration.AccelerationValue
                            }).ToList();

                accelerationByGear.Add(list);
            }

            // Add points to series

            for (int i = 0; i < Vehicle.Gears.Count; i++)
            {
                foreach (Acceleration item in accelerationByGear[i])
                {
                    chrtAccelerationCharacteristic.Series[$"Gear #{i + 1}"].Points.AddXY(item.Speed, item.AccelerationValue);
                }
            }
        }

        private void SaveAccelerationCharacteristicToExcel()
        {
            using (var ExcelFile = new ExcelPackage())
            {
                ExcelWorksheet workSheet = ExcelFile.Workbook.Worksheets.Add("ХАРАКТЕРИСТИКА УСКОРЕНИЙ");

                char step;

                #region Table headers                

                workSheet.Cells["B1"].Value = "ХАРАКТЕРИСТИКА УСКОРЕНИЙ АВТОМОБИЛЯ";
                workSheet.Cells["B1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B1:F1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                workSheet.Cells["B2"].Value = "Модель автомобиля:";
                workSheet.Cells["B2:D2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheet.Cells["E2"].Value = txtCarModel.Text;
                workSheet.Cells["E2:F2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["E2:F2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                workSheet.Cells["B4"].Value = "Зависимость ускорений j и обратных ускорений 1/j от скорости V при разгоне автомобиля на каждой передаче:";
                workSheet.Cells["B4:M4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["B4:M4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                step = 'B';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}5"].Value = Convert.ToString($"Передача #{Vehicle.Gears[i].GearNumber}");

                    workSheet.Cells[$"{step}5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    workSheet.Cells[$"{step}5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    workSheet.Cells[$"{step}5:{(char)(((int)step) + 2)}5"].Merge = true;

                    step = (char)(((int)step) + 3);
                }

                step = 'B';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}6"].Value = "V";
                    workSheet.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheet.Cells[$"{step}7"].Value = "км/ч";
                    workSheet.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    step = (char)(((int)step) + 3);
                }

                step = 'C';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}6"].Value = "j";
                    workSheet.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheet.Cells[$"{step}7"].Value = "м/с^2";
                    workSheet.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    step = (char)(((int)step) + 3);
                }

                step = 'D';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}6"].Value = "1/j";
                    workSheet.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#8EA9DB"));

                    workSheet.Cells[$"{step}7"].Value = "с^2/м";
                    workSheet.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#8EA9DB"));

                    step = (char)(((int)step) + 3);
                }

                #endregion

                #region Table data                

                List<List<Acceleration>> accelerationByGear = new List<List<Acceleration>>();

                for (int i = 1; i <= Vehicle.Gears.Count; i++)
                {
                    var list = (from acceleration in Vehicle.Acceleration
                                where acceleration.GearNumber == i
                                select new Acceleration
                                {
                                    Speed = acceleration.Speed,
                                    AccelerationValue = acceleration.AccelerationValue,
                                    ReciprocalAccelerationValue = acceleration.ReciprocalAccelerationValue
                                }).ToList();

                    accelerationByGear.Add(list);
                }

                step = 'B';
                for (int i = 0; i < accelerationByGear.Count; i++)
                {
                    for (int j = 0; j < Vehicle.Engine.Count; j++)
                    {
                        workSheet.Cells[$"{step}{8 + j}"].Value = (accelerationByGear[i][j].Speed);
                        workSheet.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (accelerationByGear[i][j].AccelerationValue);
                        workSheet.Cells[$"{(char)(((int)step) + 2)}{8 + j}"].Value = (accelerationByGear[i][j].ReciprocalAccelerationValue);
                    }

                    step = (char)(((int)step) + 3);
                }

                #endregion

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files|*.xlsx|All files|*.*";
                saveFileDialog.FileName = "Характеристика ускорений автомобиля " + txtCarModel.Text + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    ExcelFile.SaveAs(file);
                }
            }
        }

        
    }
}
