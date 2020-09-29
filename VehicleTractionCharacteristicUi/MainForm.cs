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
            CalculateRollingResistanceForceCharacteristic();
            CalculateAirResistanceForceCharacteristic();

            CalculateTractionForceCharacteristic();
            BuildTractionForceCharacteristicGraph();

            BuildRollingResistanceForceCharacteristicFunction(chrtTractionForce, 1, 0.001);
            BuildAirResistanceForceCharacteristicFunction(chrtTractionForce, 1, 0.001);

            BuildResistanceForcesCharacteristicFunction(chrtTractionForce, 1, 0.001);

            CalculateDynamicFactorCharacterisctic();
            BuildDynamicFactorCharacteristicGraph();

            CalculateAccelerationCharacterisctic();
            BuildAccelerationCharacteristicGraph();
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            SaveReport();
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
            SaveAccelerationCharacteristicToExcel();
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


        private void CalculateRollingResistanceForceCharacteristic()
        {
            RollingResistanceForceController rollingResistanceForce = new RollingResistanceForceController(Convert.ToDouble(txtRollingResistanceCoefficient.Text),
                                                                                                               Convert.ToDouble(txtVehicleWeight.Text),
                                                                                                               Vehicle.Speed);

            Vehicle.RollingResistanceForce = rollingResistanceForce.Calculate();
        }

        /// <summary>
        /// Build rolling resistance force characteristic function.
        /// </summary>
        /// <param name="chart"> Chart for a function. </param>
        /// <param name="speedMultiplier"> Multiplier for speed axis. </param>
        /// <param name="forceMultiplier"> Multiplier for force axis. </param>
        private void BuildRollingResistanceForceCharacteristicFunction(Chart chart, double speedMultiplier, double forceMultiplier)
        {
            // Add series to chart

            chart.Series.Add(new Series
            {
                Name = "Rolling resistance",
                ChartType = SeriesChartType.Spline,
                Color = Color.Black,
                BorderWidth = 1
            });

            // Get points

            List<RollingResistanceForce> list = (from rollingResistanceForce in Vehicle.RollingResistanceForce
                                                 select new RollingResistanceForce
                                                 {
                                                     Speed = rollingResistanceForce.Speed * speedMultiplier,
                                                     RollingResistanceForcesValue = rollingResistanceForce.RollingResistanceForcesValue * forceMultiplier
                                                 }).ToList();

            // Add points to series

            for (int i = 0; i < list.Count; i++)
            {
                chart.Series["Rolling resistance"].Points.AddXY(list[i].Speed, list[i].RollingResistanceForcesValue);
            }
        }


        private void CalculateAirResistanceForceCharacteristic()
        {
            AirResistanceForceController airResistanceForce = new AirResistanceForceController(Convert.ToDouble(txtDragCoefficient.Text),
                                                                                                   Convert.ToDouble(txtAirDensity.Text),
                                                                                                   Convert.ToDouble(txtProjectionHeight.Text),
                                                                                                   Convert.ToDouble(txtProjectionWidth.Text),
                                                                                                   Convert.ToDouble(txtFillingCoefficient.Text),
                                                                                                   Vehicle.Speed);

            Vehicle.AirResistanceForce = airResistanceForce.Calculate();
        }

        /// <summary>
        /// Build air resistance force characteristic function.
        /// </summary>
        /// <param name="chart"> Chart for a function. </param>
        /// <param name="speedMultiplier"> Multiplier for speed axis. </param>
        /// <param name="forceMultiplier"> Multiplier for force axis. </param>
        private void BuildAirResistanceForceCharacteristicFunction(Chart chart, double speedMultiplier, double forceMultiplier)
        {
            // Add series to chart

            chart.Series.Add(new Series
            {
                Name = "Air resistance",
                ChartType = SeriesChartType.Spline,
                Color = Color.Blue,
                BorderWidth = 1
            });

            // Get points

            List<AirResistanceForce> list = (from airResistanceForce in Vehicle.AirResistanceForce
                                             select new AirResistanceForce
                                             {
                                                 Speed = airResistanceForce.Speed * speedMultiplier,
                                                 AirResistanceForceValue = airResistanceForce.AirResistanceForceValue * forceMultiplier
                                             }).ToList();

            // Add points to series

            for (int i = 0; i < list.Count; i++)
            {
                chart.Series["Air resistance"].Points.AddXY(list[i].Speed, list[i].AirResistanceForceValue);
            }
        }


        /// <summary>
        /// Build resistance forces characteristic function.
        /// </summary>
        /// <param name="chart"> Chart for a function. </param>
        /// <param name="speedMultiplier"> Multiplier for speed axis. </param>
        /// <param name="forceMultiplier"> Multiplier for force axis. </param>
        private void BuildResistanceForcesCharacteristicFunction(Chart chart, double speedMultiplier, double forceMultiplier)
        {
            // Add series to chart

            chart.Series.Add(new Series
            {
                Name = "Rolling + Air",
                ChartType = SeriesChartType.Spline,
                Color = Color.Red,
                BorderWidth = 1
            });

            // Add points to series

            for (int i = 0; i < Vehicle.AirResistanceForce.Count; i++)
            {
                chart.Series["Rolling + Air"].Points.AddXY(Vehicle.AirResistanceForce[i].Speed * speedMultiplier, (Vehicle.AirResistanceForce[i].AirResistanceForceValue + Vehicle.RollingResistanceForce[i].RollingResistanceForcesValue) * forceMultiplier);
            }
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
            DynamicFactorController dynamicFactorCharacteristic = new DynamicFactorController(Convert.ToDouble(txtVehicleWeight.Text),
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

                step = 'D';
                for (int i = 0; i < Vehicle.Gears.Count - 1; i++)
                {
                    workSheet.Cells[$"{step}6:{step}{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

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

                #region Save dialog

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files|*.xlsx|All files|*.*";
                saveFileDialog.FileName = "Характеристика ускорений автомобиля " + txtCarModel.Text + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    ExcelFile.SaveAs(file);
                }

                #endregion
            }
        }


        private void SaveReport()
        {
            using (var ExcelFile = new ExcelPackage())
            {
                char step;
                int indent = 0; // it's 0 if transfer box is OFF

                #region Initial data

                ExcelWorksheet worksheetInitialData = ExcelFile.Workbook.Worksheets.Add("ИСХОДНЫЕ ДАННЫЕ");

                worksheetInitialData.Cells["B1"].Value = "ИСХОДНЫЕ ДАННЫЕ ДЛЯ РАСЧЁТА";
                worksheetInitialData.Cells["B1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["B1:E1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                worksheetInitialData.Cells["B2"].Value = "Модель автомобиля:";
                worksheetInitialData.Cells["B2:D2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                worksheetInitialData.Cells["E2"].Value = txtCarModel.Text;
                worksheetInitialData.Cells["E2:F2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["E2:F2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                #region Engine characteristic

                worksheetInitialData.Cells["B4"].Value = "Характеристики двигателя:";
                worksheetInitialData.Cells["B4:D4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["B4:D4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                worksheetInitialData.Cells["B5"].Value = "Максимальная частота вращения коленвала, об/мин:";
                worksheetInitialData.Cells["H5"].Value = Convert.ToDouble(txtMaxFrequency.Text);
                worksheetInitialData.Cells["H5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["H5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B6"].Value = "Минимальная частота вращения коленвала, об / мин:";
                worksheetInitialData.Cells["H6"].Value = Convert.ToDouble(txtMinFrequency.Text);
                worksheetInitialData.Cells["H6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["H6"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B7"].Value = "Частота вращения коленвала при макс. моменте, об/мин:";
                worksheetInitialData.Cells["H7"].Value = Convert.ToDouble(txtFrequencyMaxTorque.Text);
                worksheetInitialData.Cells["H7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["H7"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B8"].Value = "Частота вращения коленвала при макс. мощности, об/мин:";
                worksheetInitialData.Cells["H8"].Value = Convert.ToDouble(txtFrequencyMaxPower.Text);
                worksheetInitialData.Cells["H8"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["H8"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B9"].Value = "Максимальная мощность ДВС, кВт:";
                worksheetInitialData.Cells["H9"].Value = Convert.ToDouble(txtMaxPower.Text);
                worksheetInitialData.Cells["H9"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["H9"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B10"].Value = "Максимальный момент ДВС, Нм:";
                worksheetInitialData.Cells["H10"].Value = Convert.ToDouble(txtMaxTorque.Text);
                worksheetInitialData.Cells["H10"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["H10"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B11"].Value = "Момент при при максимальной мощности, Нм:";
                worksheetInitialData.Cells["H11"].Value = Convert.ToDouble(txtTorqueMaxPower.Text);
                worksheetInitialData.Cells["H11"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["H11"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B12"].Value = "Минимальный расход топлива, г/кВтч:";
                worksheetInitialData.Cells["H12"].Value = Convert.ToDouble(txtMinFConsumption.Text);
                worksheetInitialData.Cells["H12"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["H12"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                #endregion

                #region Automobile characteristic

                worksheetInitialData.Cells["B15"].Value = "Характеристики автомобиля:";
                worksheetInitialData.Cells["B15:D15"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["B15:D15"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                worksheetInitialData.Cells["B16"].Value = "Полная масса, кг:";
                worksheetInitialData.Cells["F16"].Value = Convert.ToDouble(txtVehicleMass.Text);
                worksheetInitialData.Cells["F16"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F16"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B17"].Value = "Вес автомобиля, Н:";
                worksheetInitialData.Cells["F17"].Value = Convert.ToDouble(txtVehicleWeight.Text);
                worksheetInitialData.Cells["F17"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F17"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B18"].Value = "Количество колёс, шт:";
                worksheetInitialData.Cells["F18"].Value = Convert.ToDouble(txtNumberOfWheels.Text);
                worksheetInitialData.Cells["F18"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F18"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B19"].Value = "Радиус колеса, м:";
                worksheetInitialData.Cells["F19"].Value = Convert.ToDouble(txtWheelRadius.Text);
                worksheetInitialData.Cells["F19"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F19"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B20"].Value = "Коэф. аэродин. сопротивления:";
                worksheetInitialData.Cells["F20"].Value = Convert.ToDouble(txtDragCoefficient.Text);
                worksheetInitialData.Cells["F20"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F20"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B21"].Value = "Коэффициент КПД трансмиссии:";
                worksheetInitialData.Cells["F21"].Value = Convert.ToDouble(txtCoefOfTransEfficiency.Text);
                worksheetInitialData.Cells["F21"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F21"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B22"].Value = "Передаточное число главной передачи:";
                worksheetInitialData.Cells["F22"].Value = Convert.ToDouble(txtFinalDriveRatio.Text);
                worksheetInitialData.Cells["F22"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F22"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                #endregion

                #region Projection area

                worksheetInitialData.Cells["B25"].Value = "Площадь поперечной проекции автомобиля:";
                worksheetInitialData.Cells["B25:F25"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["B25:F25"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                worksheetInitialData.Cells["B26"].Value = "Высота проекции, м:";
                worksheetInitialData.Cells["F26"].Value = Convert.ToDouble(txtProjectionHeight.Text);
                worksheetInitialData.Cells["F26"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F26"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B27"].Value = "Ширина проекции, м:";
                worksheetInitialData.Cells["F27"].Value = Convert.ToDouble(txtProjectionWidth.Text);
                worksheetInitialData.Cells["F27"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F27"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B28"].Value = "Коэффициент заполнения площади:";
                worksheetInitialData.Cells["F28"].Value = Convert.ToDouble(txtFillingCoefficient.Text);
                worksheetInitialData.Cells["F28"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F28"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                #endregion

                #region Moments of inertia

                worksheetInitialData.Cells["B31"].Value = "Моменты инерции:";
                worksheetInitialData.Cells["B31:C31"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["B31:C31"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                worksheetInitialData.Cells["B32"].Value = "Момент инерции двигателя, кг*м^2:";
                worksheetInitialData.Cells["F32"].Value = Convert.ToDouble(txtMotorMomentOfInertia.Text);
                worksheetInitialData.Cells["F32"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F32"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["B33"].Value = "Момент инерции колеса, кг*м^2:";
                worksheetInitialData.Cells["F33"].Value = Convert.ToDouble(txtWheelMomentOfInertia.Text);
                worksheetInitialData.Cells["F33"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["F33"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                #endregion

                #region Transfer box and gearbox

                if (rdoTransferBoxYes.Checked)
                {
                    worksheetInitialData.Cells["K4"].Value = "Характеристики раздаточной коробки:";
                    worksheetInitialData.Cells["K4:N4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheetInitialData.Cells["K4:N4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                    worksheetInitialData.Cells["K5"].Value = "Высшая передача:";
                    worksheetInitialData.Cells["M5"].Value = Convert.ToDouble(txtTransferBoxTopGearRatio.Text);
                    worksheetInitialData.Cells["M5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheetInitialData.Cells["M5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    worksheetInitialData.Cells["K6"].Value = "Низшая передача:";
                    worksheetInitialData.Cells["M6"].Value = Convert.ToDouble(txtTransferBoxLowerGearRatio.Text);
                    worksheetInitialData.Cells["M6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheetInitialData.Cells["M6"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    indent = 5;
                }

                worksheetInitialData.Cells[$"K{4 + indent}"].Value = "Характеристики коробки передач:";
                worksheetInitialData.Cells[$"K{4 + indent}:N{4 + indent}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells[$"K{4 + indent}:N{4 + indent}"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                worksheetInitialData.Cells[$"K{5 + indent}"].Value = "Номер";
                worksheetInitialData.Cells[$"K{5 + indent}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheetInitialData.Cells[$"L{5 + indent}"].Value = "Передаточное число";

                foreach (GearRatioBox gear in flpGearRatioInGearbox.Controls)
                {
                    worksheetInitialData.Cells[$"K{6 + indent}"].Value = gear.GearNumber;
                    worksheetInitialData.Cells[$"K{6 + indent}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheetInitialData.Cells[$"L{6 + indent}"].Value = gear.GearRatio;
                    worksheetInitialData.Cells[$"L{6 + indent}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheetInitialData.Cells[$"L{6 + indent}"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    indent += 1;
                }

                #endregion

                #region Environmental characteristic

                worksheetInitialData.Cells["Q4"].Value = "Характеристики окружающей среды:";
                worksheetInitialData.Cells["Q4:T4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["Q4:T4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                worksheetInitialData.Cells["Q5"].Value = "Плотность воздуха, кг/м^3:";
                worksheetInitialData.Cells["T5"].Value = Convert.ToDouble(txtAirDensity.Text);
                worksheetInitialData.Cells["T5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["T5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                worksheetInitialData.Cells["Q6"].Value = "Коэф. сопротив. качению:";
                worksheetInitialData.Cells["T6"].Value = Convert.ToDouble(txtRollingResistanceCoefficient.Text);
                worksheetInitialData.Cells["T6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetInitialData.Cells["T6"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                #endregion

                #endregion

                #region External engine characteristic

                ExcelWorksheet workSheetExternalEngineCharacteristic = ExcelFile.Workbook.Worksheets.Add("ХАРАКТЕРИСТИКА ДВИГАТЕЛЯ");

                #region Table headers for external engine characteristic

                workSheetExternalEngineCharacteristic.Cells["B1"].Value = "ВНЕШНЯЯ СКОРОСТНАЯ ХАРАКТЕРИСТИКА ДВИГАТЕЛЯ";
                workSheetExternalEngineCharacteristic.Cells["B1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetExternalEngineCharacteristic.Cells["B1:E1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                workSheetExternalEngineCharacteristic.Cells["B2"].Value = "Модель автомобиля:";
                workSheetExternalEngineCharacteristic.Cells["B2:D2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetExternalEngineCharacteristic.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheetExternalEngineCharacteristic.Cells["E2"].Value = txtCarModel.Text;
                workSheetExternalEngineCharacteristic.Cells["E2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetExternalEngineCharacteristic.Cells["E2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                workSheetExternalEngineCharacteristic.Cells["B4"].Value = "Обороты, об/мин";
                workSheetExternalEngineCharacteristic.Cells["B4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetExternalEngineCharacteristic.Cells["B4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheetExternalEngineCharacteristic.Cells["C4"].Value = "Мощность, кВт";
                workSheetExternalEngineCharacteristic.Cells["C4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetExternalEngineCharacteristic.Cells["C4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheetExternalEngineCharacteristic.Cells["D4"].Value = "Момент, Нм";
                workSheetExternalEngineCharacteristic.Cells["D4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetExternalEngineCharacteristic.Cells["D4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheetExternalEngineCharacteristic.Cells["E4"].Value = "Уд. расход, г/кВтч";
                workSheetExternalEngineCharacteristic.Cells["E4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetExternalEngineCharacteristic.Cells["E4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                double headerCellWidth = 16.71;
                workSheetExternalEngineCharacteristic.Column(2).Width = headerCellWidth;
                workSheetExternalEngineCharacteristic.Column(3).Width = headerCellWidth;
                workSheetExternalEngineCharacteristic.Column(4).Width = headerCellWidth;
                workSheetExternalEngineCharacteristic.Column(5).Width = headerCellWidth;

                #endregion

                #region Table data for external engine characteristic

                workSheetExternalEngineCharacteristic.Cells["B5"].LoadFromCollection(Vehicle.Engine);

                #endregion

                #endregion

                #region Traction force characteristic

                ExcelWorksheet workSheetTractionCharacteristic = ExcelFile.Workbook.Worksheets.Add("ТЯГОВАЯ ХАРАКТЕРИСТИКА");

                #region Table headers

                workSheetTractionCharacteristic.Cells["B1"].Value = "ТЯГОВАЯ ХАРАКТЕРИСТИКА АВТОМОБИЛЯ";
                workSheetTractionCharacteristic.Cells["B1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetTractionCharacteristic.Cells["B1:F1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                workSheetTractionCharacteristic.Cells["B2"].Value = "Модель автомобиля:";
                workSheetTractionCharacteristic.Cells["B2:D2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetTractionCharacteristic.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheetTractionCharacteristic.Cells["E2"].Value = txtCarModel.Text;
                workSheetTractionCharacteristic.Cells["E2:F2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetTractionCharacteristic.Cells["E2:F2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                workSheetTractionCharacteristic.Cells["B4"].Value = "Сила тяги Р и скорость автомобиля V при движении на передаче:";
                workSheetTractionCharacteristic.Cells["B4:H4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetTractionCharacteristic.Cells["B4:H4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                if (rdoTransferBoxYes.Checked)
                {
                    // Set header for lower gear

                    workSheetTractionCharacteristic.Cells["B5"].Value = Convert.ToString($"Передача #1 пониж.");
                    workSheetTractionCharacteristic.Cells["B5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells["B5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);
                    workSheetTractionCharacteristic.Cells["B5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheetTractionCharacteristic.Cells["B5:C5"].Merge = true;


                    workSheetTractionCharacteristic.Cells["B6"].Value = "V";
                    workSheetTractionCharacteristic.Cells["B6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells["B6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheetTractionCharacteristic.Cells["B7"].Value = "км/ч";
                    workSheetTractionCharacteristic.Cells["B7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells["B7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));


                    workSheetTractionCharacteristic.Cells["C6"].Value = "P";
                    workSheetTractionCharacteristic.Cells["C6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells["C6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheetTractionCharacteristic.Cells["C7"].Value = "кН";
                    workSheetTractionCharacteristic.Cells["C7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells["C7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));


                    workSheetTractionCharacteristic.Cells[$"C6:C{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;


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
                        workSheetTractionCharacteristic.Cells[$"{step}{8 + j}"].Value = (tractionForceOnLowerGear[j].Speed);
                        workSheetTractionCharacteristic.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (tractionForceOnLowerGear[j].TractionForceValue);
                    }

                    // Set indent for other gears

                    indent = 2;
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetTractionCharacteristic.Cells[$"{step}5"].Value = Convert.ToString($"Передача #{Vehicle.Gears[i].GearNumber}");

                    workSheetTractionCharacteristic.Cells[$"{step}5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells[$"{step}5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    workSheetTractionCharacteristic.Cells[$"{step}5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    workSheetTractionCharacteristic.Cells[$"{step}5:{(char)(((int)step) + 1)}5"].Merge = true;

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count - 1; i++)
                {
                    workSheetTractionCharacteristic.Cells[$"{step}6:{step}{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    step = (char)(((int)step) + 2);
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetTractionCharacteristic.Cells[$"{step}6"].Value = "V";
                    workSheetTractionCharacteristic.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheetTractionCharacteristic.Cells[$"{step}7"].Value = "км/ч";
                    workSheetTractionCharacteristic.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetTractionCharacteristic.Cells[$"{step}6"].Value = "P";
                    workSheetTractionCharacteristic.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheetTractionCharacteristic.Cells[$"{step}7"].Value = "кН";
                    workSheetTractionCharacteristic.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetTractionCharacteristic.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

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
                        workSheetTractionCharacteristic.Cells[$"{step}{8 + j}"].Value = (tractionForceByGear[i][j].Speed);
                        workSheetTractionCharacteristic.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (tractionForceByGear[i][j].TractionForceValue);
                    }

                    step = (char)(((int)step) + 2);
                }

                #endregion

                #endregion

                #region Dynamic factor characteristic

                ExcelWorksheet workSheetDynamicFactor = ExcelFile.Workbook.Worksheets.Add("ДИНАМИЧЕСКАЯ ХАРАКТЕРИСТИКА");

                #region Table headers

                workSheetDynamicFactor.Cells["B1"].Value = "ДИНАМИЧЕСКАЯ ХАРАКТЕРИСТИКА АВТОМОБИЛЯ";
                workSheetDynamicFactor.Cells["B1:G1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetDynamicFactor.Cells["B1:G1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                workSheetDynamicFactor.Cells["B2"].Value = "Модель автомобиля:";
                workSheetDynamicFactor.Cells["B2:E2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetDynamicFactor.Cells["B2:E2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheetDynamicFactor.Cells["F2"].Value = txtCarModel.Text;
                workSheetDynamicFactor.Cells["F2:G2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetDynamicFactor.Cells["F2:G2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                workSheetDynamicFactor.Cells["B4"].Value = "Скорость V и динамический фактор D при движении на передаче:";
                workSheetDynamicFactor.Cells["B4:H4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetDynamicFactor.Cells["B4:H4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);



                if (rdoTransferBoxYes.Checked)
                {
                    // Set header for lower gear

                    workSheetDynamicFactor.Cells["B5"].Value = Convert.ToString("Передача #1 пониж.");
                    workSheetDynamicFactor.Cells["B5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells["B5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);
                    workSheetDynamicFactor.Cells["B5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheetDynamicFactor.Cells[$"B5:C5"].Merge = true;

                    workSheetDynamicFactor.Cells["B6"].Value = "V";
                    workSheetDynamicFactor.Cells["B6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells["B6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheetDynamicFactor.Cells["B7"].Value = "км/ч";
                    workSheetDynamicFactor.Cells["B7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells["B7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheetDynamicFactor.Cells["C6"].Value = "D";
                    workSheetDynamicFactor.Cells["C6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells["C6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheetDynamicFactor.Cells["C7"].Value = "%";
                    workSheetDynamicFactor.Cells["C7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells["C7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheetDynamicFactor.Cells[$"C6:C{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;


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
                        workSheetDynamicFactor.Cells[$"{step}{8 + j}"].Value = (dynamicFactorOnLowerGear[j].Speed);
                        workSheetDynamicFactor.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (dynamicFactorOnLowerGear[j].DynamicFactorValue);
                    }


                    // Set indent for other gears

                    indent = 2;
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetDynamicFactor.Cells[$"{step}5"].Value = Convert.ToString($"Передача #{Vehicle.Gears[i].GearNumber}");

                    workSheetDynamicFactor.Cells[$"{step}5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells[$"{step}5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    workSheetDynamicFactor.Cells[$"{step}5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    workSheetDynamicFactor.Cells[$"{step}5:{(char)(((int)step) + 1)}5"].Merge = true;

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count - 1; i++)
                {
                    workSheetDynamicFactor.Cells[$"{step}6:{step}{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    step = (char)(((int)step) + 2);
                }

                step = 'B';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetDynamicFactor.Cells[$"{step}6"].Value = "V";
                    workSheetDynamicFactor.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheetDynamicFactor.Cells[$"{step}7"].Value = "км/ч";
                    workSheetDynamicFactor.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
                step = (char)(((int)step) + indent);
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetDynamicFactor.Cells[$"{step}6"].Value = "D";
                    workSheetDynamicFactor.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheetDynamicFactor.Cells[$"{step}7"].Value = "%";
                    workSheetDynamicFactor.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetDynamicFactor.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

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
                        workSheetDynamicFactor.Cells[$"{step}{8 + j}"].Value = (dynamicFactorByGear[i][j].Speed);
                        workSheetDynamicFactor.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (dynamicFactorByGear[i][j].DynamicFactorValue);
                    }

                    step = (char)(((int)step) + 2);
                }

                #endregion

                #endregion

                #region Acceleration characteristic

                ExcelWorksheet workSheetAccelerationCharacteristic = ExcelFile.Workbook.Worksheets.Add("ХАРАКТЕРИСТИКА УСКОРЕНИЙ");

                #region Table headers                

                workSheetAccelerationCharacteristic.Cells["B1"].Value = "ХАРАКТЕРИСТИКА УСКОРЕНИЙ АВТОМОБИЛЯ";
                workSheetAccelerationCharacteristic.Cells["B1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetAccelerationCharacteristic.Cells["B1:F1"].Style.Fill.BackgroundColor.SetColor(Color.Red);

                workSheetAccelerationCharacteristic.Cells["B2"].Value = "Модель автомобиля:";
                workSheetAccelerationCharacteristic.Cells["B2:D2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetAccelerationCharacteristic.Cells["B2:D2"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                workSheetAccelerationCharacteristic.Cells["E2"].Value = txtCarModel.Text;
                workSheetAccelerationCharacteristic.Cells["E2:F2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetAccelerationCharacteristic.Cells["E2:F2"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                workSheetAccelerationCharacteristic.Cells["B4"].Value = "Зависимость ускорений j и обратных ускорений 1/j от скорости V при разгоне автомобиля на каждой передаче:";
                workSheetAccelerationCharacteristic.Cells["B4:M4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheetAccelerationCharacteristic.Cells["B4:M4"].Style.Fill.BackgroundColor.SetColor(Color.Orange);

                step = 'B';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetAccelerationCharacteristic.Cells[$"{step}5"].Value = Convert.ToString($"Передача #{Vehicle.Gears[i].GearNumber}");

                    workSheetAccelerationCharacteristic.Cells[$"{step}5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetAccelerationCharacteristic.Cells[$"{step}5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    workSheetAccelerationCharacteristic.Cells[$"{step}5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    workSheetAccelerationCharacteristic.Cells[$"{step}5:{(char)(((int)step) + 2)}5"].Merge = true;

                    step = (char)(((int)step) + 3);
                }

                step = 'D';
                for (int i = 0; i < Vehicle.Gears.Count - 1; i++)
                {
                    workSheetAccelerationCharacteristic.Cells[$"{step}6:{step}{7 + Vehicle.Engine.Count}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    step = (char)(((int)step) + 3);
                }

                step = 'B';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetAccelerationCharacteristic.Cells[$"{step}6"].Value = "V";
                    workSheetAccelerationCharacteristic.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetAccelerationCharacteristic.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    workSheetAccelerationCharacteristic.Cells[$"{step}7"].Value = "км/ч";
                    workSheetAccelerationCharacteristic.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetAccelerationCharacteristic.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B050"));

                    step = (char)(((int)step) + 3);
                }

                step = 'C';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetAccelerationCharacteristic.Cells[$"{step}6"].Value = "j";
                    workSheetAccelerationCharacteristic.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetAccelerationCharacteristic.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    workSheetAccelerationCharacteristic.Cells[$"{step}7"].Value = "м/с^2";
                    workSheetAccelerationCharacteristic.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetAccelerationCharacteristic.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#00B0F0"));

                    step = (char)(((int)step) + 3);
                }

                step = 'D';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheetAccelerationCharacteristic.Cells[$"{step}6"].Value = "1/j";
                    workSheetAccelerationCharacteristic.Cells[$"{step}6"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetAccelerationCharacteristic.Cells[$"{step}6"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#8EA9DB"));

                    workSheetAccelerationCharacteristic.Cells[$"{step}7"].Value = "с^2/м";
                    workSheetAccelerationCharacteristic.Cells[$"{step}7"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheetAccelerationCharacteristic.Cells[$"{step}7"].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#8EA9DB"));

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
                        workSheetAccelerationCharacteristic.Cells[$"{step}{8 + j}"].Value = (accelerationByGear[i][j].Speed);
                        workSheetAccelerationCharacteristic.Cells[$"{(char)(((int)step) + 1)}{8 + j}"].Value = (accelerationByGear[i][j].AccelerationValue);
                        workSheetAccelerationCharacteristic.Cells[$"{(char)(((int)step) + 2)}{8 + j}"].Value = (accelerationByGear[i][j].ReciprocalAccelerationValue);
                    }

                    step = (char)(((int)step) + 3);
                }

                #endregion

                #endregion

                #region Save dialog

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files|*.xlsx|All files|*.*";
                saveFileDialog.FileName = "Тягово-динамическая характеристика автомобиля " + txtCarModel.Text + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    ExcelFile.SaveAs(file);
                }

                #endregion
            }
        }
    }
}