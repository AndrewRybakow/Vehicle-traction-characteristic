﻿using System;
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
        }

        private void btnAddGearToGearbox_Click(object sender, EventArgs e)
        {
            AddGearToGearbox();
        }

        private void btnDeleteGearInGearbox_Click(object sender, EventArgs e)
        {
            DeleteGearInGearbox();
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


        private void CalculateSpeedCharacteristic()
        {
            SpeedContoller speed = new SpeedContoller(Convert.ToDouble(txtWheelRadius.Text),
                                                          Convert.ToDouble(txtTransferBoxTopGearRatio.Text),
                                                          Convert.ToDouble(txtFinalDriveRatio.Text),
                                                          Vehicle.Engine,
                                                          Vehicle.Gears);

            Vehicle.Speed = speed.Calculate();
        }


        private void CalculateTractionForceCharacteristic()
        {
            TractionForceController tractionForce = new TractionForceController(Convert.ToDouble(txtTransferBoxTopGearRatio.Text),
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

            for (int i = 1; i <= flpGearRatioInGearbox.Controls.Count; i++)
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

            for (int i = 1; i <= flpGearRatioInGearbox.Controls.Count; i++)
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

            for (int i = 0; i < flpGearRatioInGearbox.Controls.Count; i++)
            {
                foreach (TractionForce item in tractionForceByGear[i])
                {
                    chrtTractionForce.Series[$"Gear #{i + 1}"].Points.AddXY(item.Speed, item.TractionForceValue);
                }
            }
        }

        private void SaveTractionCharacteristicToExcel()
        {
            using (var ExcelFile = new ExcelPackage())
            {
                ExcelWorksheet workSheet = ExcelFile.Workbook.Worksheets.Add("ТЯГОВАЯ ХАРАКТЕРИСТИКА");

                char step;

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

                step = 'B';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}5"].Value = Convert.ToString($"Передача #{Vehicle.Gears[i].GearNumber}");

                    workSheet.Cells[$"{step}5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    workSheet.Cells[$"{step}5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    workSheet.Cells[$"{step}5:{(char)(((int)step) + 1)}5"].Merge = true;

                    step = (char)(((int)step) + 2);
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

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
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

                for (int i = 1; i <= flpGearRatioInGearbox.Controls.Count; i++)
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

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files|*.xlsx|All files|*.*";
                saveFileDialog.FileName = "Тяговая характеристика автомобиля " + txtCarModel.Text + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    ExcelFile.SaveAs(file);
                }
            }
        }


        private void CalculateDynamicFactorCharacterisctic()
        {
            DynamicFactorController dynamicFactorCharacteristic = new DynamicFactorController(Convert.ToDouble(txtWeightOnWheels.Text),
                                                                                                  Convert.ToDouble(txtDragCoefficient.Text),
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

            for (int i = 0; i < Vehicle.Gears.Count; i++)
            {
                foreach (DynamicFactor item in dynamicFactorByGear[i])
                {
                    chrtDynamicCharacteristic.Series[$"Gear #{i + 1}"].Points.AddXY(item.Speed, item.DynamicFactorValue);
                }
            }
        }

        private void SaveDynamicFactorCharacteristicToExcel()
        {
            using (var ExcelFile = new ExcelPackage())
            {
                ExcelWorksheet workSheet = ExcelFile.Workbook.Worksheets.Add("ДИНАМИЧЕСКАЯ ХАРАКТЕРИСТИКА");

                char step;

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

                step = 'B';
                for (int i = 0; i < Vehicle.Gears.Count; i++)
                {
                    workSheet.Cells[$"{step}5"].Value = Convert.ToString($"Передача #{Vehicle.Gears[i].GearNumber}");

                    workSheet.Cells[$"{step}5"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    workSheet.Cells[$"{step}5"].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);

                    workSheet.Cells[$"{step}5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    workSheet.Cells[$"{step}5:{(char)(((int)step) + 1)}5"].Merge = true;

                    step = (char)(((int)step) + 2);
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

                    step = (char)(((int)step) + 2);
                }

                step = 'C';
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

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files|*.xlsx|All files|*.*";
                saveFileDialog.FileName = "Динамическая характеристика автомобиля " + txtCarModel.Text + " " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    ExcelFile.SaveAs(file);
                }
            }
        }
    }
}
