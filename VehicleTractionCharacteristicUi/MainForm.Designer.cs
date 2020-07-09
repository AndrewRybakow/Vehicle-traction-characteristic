﻿namespace VehicleTractionCharacteristicUi
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grpModelStep = new System.Windows.Forms.GroupBox();
            this.tlpModelStep = new System.Windows.Forms.TableLayoutPanel();
            this.lblCarModel = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.txtCarModel = new System.Windows.Forms.TextBox();
            this.txtStep = new System.Windows.Forms.TextBox();
            this.grpInitialData = new System.Windows.Forms.GroupBox();
            this.grpEngineCharacteristic = new System.Windows.Forms.GroupBox();
            this.tlpEngineCharacteristic = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaxFrequency = new System.Windows.Forms.Label();
            this.lblMinFrequency = new System.Windows.Forms.Label();
            this.lblMinFConsumption = new System.Windows.Forms.Label();
            this.lblTorqueMaxPower = new System.Windows.Forms.Label();
            this.lblMaxTorque = new System.Windows.Forms.Label();
            this.txtMinFConsumption = new System.Windows.Forms.TextBox();
            this.txtTorqueMaxPower = new System.Windows.Forms.TextBox();
            this.txtMaxTorque = new System.Windows.Forms.TextBox();
            this.txtMaxFrequency = new System.Windows.Forms.TextBox();
            this.txtMinFrequency = new System.Windows.Forms.TextBox();
            this.lblFrequencyMaxPower = new System.Windows.Forms.Label();
            this.txtFrequencyMaxPower = new System.Windows.Forms.TextBox();
            this.lblMaxPower = new System.Windows.Forms.Label();
            this.txtMaxPower = new System.Windows.Forms.TextBox();
            this.lblFrequencyMaxTorque = new System.Windows.Forms.Label();
            this.txtFrequencyMaxTorque = new System.Windows.Forms.TextBox();
            this.grpExternalCharacteristic = new System.Windows.Forms.GroupBox();
            this.btnSaveExcelExternalCharacteristic = new System.Windows.Forms.Button();
            this.btnOpenExcelExternalCharacteristic = new System.Windows.Forms.Button();
            this.tabExternalCharacteristic = new System.Windows.Forms.TabControl();
            this.tpPower = new System.Windows.Forms.TabPage();
            this.tpTorque = new System.Windows.Forms.TabPage();
            this.tpConsumption = new System.Windows.Forms.TabPage();
            this.chrtPower = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chrtTorque = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chrtConsumption = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.grpModelStep.SuspendLayout();
            this.tlpModelStep.SuspendLayout();
            this.grpInitialData.SuspendLayout();
            this.grpEngineCharacteristic.SuspendLayout();
            this.tlpEngineCharacteristic.SuspendLayout();
            this.grpExternalCharacteristic.SuspendLayout();
            this.tabExternalCharacteristic.SuspendLayout();
            this.tpPower.SuspendLayout();
            this.tpTorque.SuspendLayout();
            this.tpConsumption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTorque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtConsumption)).BeginInit();
            this.SuspendLayout();
            // 
            // grpModelStep
            // 
            this.grpModelStep.Controls.Add(this.tlpModelStep);
            this.grpModelStep.Location = new System.Drawing.Point(10, 12);
            this.grpModelStep.Name = "grpModelStep";
            this.grpModelStep.Size = new System.Drawing.Size(299, 76);
            this.grpModelStep.TabIndex = 8;
            this.grpModelStep.TabStop = false;
            // 
            // tlpModelStep
            // 
            this.tlpModelStep.ColumnCount = 2;
            this.tlpModelStep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.28986F));
            this.tlpModelStep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.71014F));
            this.tlpModelStep.Controls.Add(this.lblCarModel, 0, 0);
            this.tlpModelStep.Controls.Add(this.lblStep, 0, 1);
            this.tlpModelStep.Controls.Add(this.txtCarModel, 1, 0);
            this.tlpModelStep.Controls.Add(this.txtStep, 1, 1);
            this.tlpModelStep.Location = new System.Drawing.Point(8, 12);
            this.tlpModelStep.Name = "tlpModelStep";
            this.tlpModelStep.RowCount = 2;
            this.tlpModelStep.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpModelStep.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpModelStep.Size = new System.Drawing.Size(276, 60);
            this.tlpModelStep.TabIndex = 2;
            // 
            // lblCarModel
            // 
            this.lblCarModel.AutoSize = true;
            this.lblCarModel.Location = new System.Drawing.Point(3, 5);
            this.lblCarModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblCarModel.Name = "lblCarModel";
            this.lblCarModel.Size = new System.Drawing.Size(113, 13);
            this.lblCarModel.TabIndex = 0;
            this.lblCarModel.Text = "Модель автомобиля:";
            // 
            // lblStep
            // 
            this.lblStep.AutoSize = true;
            this.lblStep.Location = new System.Drawing.Point(3, 35);
            this.lblStep.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(116, 13);
            this.lblStep.TabIndex = 1;
            this.lblStep.Text = "Шаг расчёта, об/мин:";
            // 
            // txtCarModel
            // 
            this.txtCarModel.Location = new System.Drawing.Point(128, 3);
            this.txtCarModel.Name = "txtCarModel";
            this.txtCarModel.Size = new System.Drawing.Size(145, 20);
            this.txtCarModel.TabIndex = 2;
            // 
            // txtStep
            // 
            this.txtStep.Location = new System.Drawing.Point(128, 33);
            this.txtStep.Name = "txtStep";
            this.txtStep.Size = new System.Drawing.Size(61, 20);
            this.txtStep.TabIndex = 3;
            this.txtStep.Text = "100";
            // 
            // grpInitialData
            // 
            this.grpInitialData.Controls.Add(this.btnCalculate);
            this.grpInitialData.Controls.Add(this.grpEngineCharacteristic);
            this.grpInitialData.Location = new System.Drawing.Point(10, 94);
            this.grpInitialData.Name = "grpInitialData";
            this.grpInitialData.Size = new System.Drawing.Size(1188, 350);
            this.grpInitialData.TabIndex = 9;
            this.grpInitialData.TabStop = false;
            this.grpInitialData.Text = "Исходные данные:";
            // 
            // grpEngineCharacteristic
            // 
            this.grpEngineCharacteristic.Controls.Add(this.tlpEngineCharacteristic);
            this.grpEngineCharacteristic.Location = new System.Drawing.Point(9, 24);
            this.grpEngineCharacteristic.Name = "grpEngineCharacteristic";
            this.grpEngineCharacteristic.Size = new System.Drawing.Size(455, 254);
            this.grpEngineCharacteristic.TabIndex = 6;
            this.grpEngineCharacteristic.TabStop = false;
            this.grpEngineCharacteristic.Text = "Характеристики двигателя:";
            // 
            // tlpEngineCharacteristic
            // 
            this.tlpEngineCharacteristic.ColumnCount = 2;
            this.tlpEngineCharacteristic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.08238F));
            this.tlpEngineCharacteristic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.91762F));
            this.tlpEngineCharacteristic.Controls.Add(this.lblMaxFrequency, 0, 0);
            this.tlpEngineCharacteristic.Controls.Add(this.lblMinFrequency, 0, 1);
            this.tlpEngineCharacteristic.Controls.Add(this.lblMinFConsumption, 0, 7);
            this.tlpEngineCharacteristic.Controls.Add(this.lblTorqueMaxPower, 0, 6);
            this.tlpEngineCharacteristic.Controls.Add(this.lblMaxTorque, 0, 5);
            this.tlpEngineCharacteristic.Controls.Add(this.txtMinFConsumption, 1, 7);
            this.tlpEngineCharacteristic.Controls.Add(this.txtTorqueMaxPower, 1, 6);
            this.tlpEngineCharacteristic.Controls.Add(this.txtMaxTorque, 1, 5);
            this.tlpEngineCharacteristic.Controls.Add(this.txtMaxFrequency, 1, 0);
            this.tlpEngineCharacteristic.Controls.Add(this.txtMinFrequency, 1, 1);
            this.tlpEngineCharacteristic.Controls.Add(this.lblFrequencyMaxPower, 0, 3);
            this.tlpEngineCharacteristic.Controls.Add(this.txtFrequencyMaxPower, 1, 3);
            this.tlpEngineCharacteristic.Controls.Add(this.lblMaxPower, 0, 4);
            this.tlpEngineCharacteristic.Controls.Add(this.txtMaxPower, 1, 4);
            this.tlpEngineCharacteristic.Controls.Add(this.lblFrequencyMaxTorque, 0, 2);
            this.tlpEngineCharacteristic.Controls.Add(this.txtFrequencyMaxTorque, 1, 2);
            this.tlpEngineCharacteristic.Location = new System.Drawing.Point(12, 18);
            this.tlpEngineCharacteristic.Name = "tlpEngineCharacteristic";
            this.tlpEngineCharacteristic.RowCount = 8;
            this.tlpEngineCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86962F));
            this.tlpEngineCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86963F));
            this.tlpEngineCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86963F));
            this.tlpEngineCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.78224F));
            this.tlpEngineCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86963F));
            this.tlpEngineCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86963F));
            this.tlpEngineCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86963F));
            this.tlpEngineCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEngineCharacteristic.Size = new System.Drawing.Size(437, 228);
            this.tlpEngineCharacteristic.TabIndex = 0;
            // 
            // lblMaxFrequency
            // 
            this.lblMaxFrequency.AutoSize = true;
            this.lblMaxFrequency.Location = new System.Drawing.Point(3, 5);
            this.lblMaxFrequency.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblMaxFrequency.Name = "lblMaxFrequency";
            this.lblMaxFrequency.Size = new System.Drawing.Size(309, 13);
            this.lblMaxFrequency.TabIndex = 0;
            this.lblMaxFrequency.Text = "Максимальная частота вращения коленвала ДВС, об/мин:";
            // 
            // lblMinFrequency
            // 
            this.lblMinFrequency.AutoSize = true;
            this.lblMinFrequency.Location = new System.Drawing.Point(3, 33);
            this.lblMinFrequency.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblMinFrequency.Name = "lblMinFrequency";
            this.lblMinFrequency.Size = new System.Drawing.Size(303, 13);
            this.lblMinFrequency.TabIndex = 1;
            this.lblMinFrequency.Text = "Минимальная частота вращения коленвала ДВС, об/мин:";
            // 
            // lblMinFConsumption
            // 
            this.lblMinFConsumption.AutoSize = true;
            this.lblMinFConsumption.Location = new System.Drawing.Point(3, 207);
            this.lblMinFConsumption.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblMinFConsumption.Name = "lblMinFConsumption";
            this.lblMinFConsumption.Size = new System.Drawing.Size(204, 13);
            this.lblMinFConsumption.TabIndex = 6;
            this.lblMinFConsumption.Text = "Минимальный расход топлива, г/кВтч:";
            // 
            // lblTorqueMaxPower
            // 
            this.lblTorqueMaxPower.AutoSize = true;
            this.lblTorqueMaxPower.Location = new System.Drawing.Point(3, 179);
            this.lblTorqueMaxPower.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblTorqueMaxPower.Name = "lblTorqueMaxPower";
            this.lblTorqueMaxPower.Size = new System.Drawing.Size(274, 13);
            this.lblTorqueMaxPower.TabIndex = 5;
            this.lblTorqueMaxPower.Text = "Момент при при максимальной мощности ДВС, Нм:";
            // 
            // lblMaxTorque
            // 
            this.lblMaxTorque.AutoSize = true;
            this.lblMaxTorque.Location = new System.Drawing.Point(3, 151);
            this.lblMaxTorque.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblMaxTorque.Name = "lblMaxTorque";
            this.lblMaxTorque.Size = new System.Drawing.Size(179, 13);
            this.lblMaxTorque.TabIndex = 4;
            this.lblMaxTorque.Text = "Максимальный момент ДВС, Нм:";
            // 
            // txtMinFConsumption
            // 
            this.txtMinFConsumption.Location = new System.Drawing.Point(318, 205);
            this.txtMinFConsumption.Name = "txtMinFConsumption";
            this.txtMinFConsumption.Size = new System.Drawing.Size(100, 20);
            this.txtMinFConsumption.TabIndex = 13;
            this.txtMinFConsumption.Text = "326";
            // 
            // txtTorqueMaxPower
            // 
            this.txtTorqueMaxPower.Location = new System.Drawing.Point(318, 177);
            this.txtTorqueMaxPower.Name = "txtTorqueMaxPower";
            this.txtTorqueMaxPower.Size = new System.Drawing.Size(100, 20);
            this.txtTorqueMaxPower.TabIndex = 12;
            this.txtTorqueMaxPower.Text = "328";
            // 
            // txtMaxTorque
            // 
            this.txtMaxTorque.Location = new System.Drawing.Point(318, 149);
            this.txtMaxTorque.Name = "txtMaxTorque";
            this.txtMaxTorque.Size = new System.Drawing.Size(100, 20);
            this.txtMaxTorque.TabIndex = 11;
            this.txtMaxTorque.Text = "402";
            // 
            // txtMaxFrequency
            // 
            this.txtMaxFrequency.Location = new System.Drawing.Point(318, 3);
            this.txtMaxFrequency.Name = "txtMaxFrequency";
            this.txtMaxFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtMaxFrequency.TabIndex = 7;
            this.txtMaxFrequency.Text = "3200";
            // 
            // txtMinFrequency
            // 
            this.txtMinFrequency.Location = new System.Drawing.Point(318, 31);
            this.txtMinFrequency.Name = "txtMinFrequency";
            this.txtMinFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtMinFrequency.TabIndex = 8;
            this.txtMinFrequency.Text = "850";
            // 
            // lblFrequencyMaxPower
            // 
            this.lblFrequencyMaxPower.AutoSize = true;
            this.lblFrequencyMaxPower.Location = new System.Drawing.Point(3, 85);
            this.lblFrequencyMaxPower.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblFrequencyMaxPower.Name = "lblFrequencyMaxPower";
            this.lblFrequencyMaxPower.Size = new System.Drawing.Size(289, 26);
            this.lblFrequencyMaxPower.TabIndex = 3;
            this.lblFrequencyMaxPower.Text = "Частота вращения коленвала ДВС при максимальной мощности, об/мин:";
            // 
            // txtFrequencyMaxPower
            // 
            this.txtFrequencyMaxPower.Location = new System.Drawing.Point(318, 87);
            this.txtFrequencyMaxPower.Name = "txtFrequencyMaxPower";
            this.txtFrequencyMaxPower.Size = new System.Drawing.Size(100, 20);
            this.txtFrequencyMaxPower.TabIndex = 10;
            this.txtFrequencyMaxPower.Text = "3200";
            // 
            // lblMaxPower
            // 
            this.lblMaxPower.AutoSize = true;
            this.lblMaxPower.Location = new System.Drawing.Point(3, 123);
            this.lblMaxPower.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblMaxPower.Name = "lblMaxPower";
            this.lblMaxPower.Size = new System.Drawing.Size(192, 13);
            this.lblMaxPower.TabIndex = 2;
            this.lblMaxPower.Text = "Максимальная мощность ДВС, кВт:";
            // 
            // txtMaxPower
            // 
            this.txtMaxPower.Location = new System.Drawing.Point(318, 121);
            this.txtMaxPower.Name = "txtMaxPower";
            this.txtMaxPower.Size = new System.Drawing.Size(100, 20);
            this.txtMaxPower.TabIndex = 9;
            this.txtMaxPower.Text = "110";
            // 
            // lblFrequencyMaxTorque
            // 
            this.lblFrequencyMaxTorque.AutoSize = true;
            this.lblFrequencyMaxTorque.Location = new System.Drawing.Point(3, 57);
            this.lblFrequencyMaxTorque.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.lblFrequencyMaxTorque.Name = "lblFrequencyMaxTorque";
            this.lblFrequencyMaxTorque.Size = new System.Drawing.Size(291, 26);
            this.lblFrequencyMaxTorque.TabIndex = 14;
            this.lblFrequencyMaxTorque.Text = "Частота вращения коленвала ДВС при максимальном моменте, об/мин:";
            // 
            // txtFrequencyMaxTorque
            // 
            this.txtFrequencyMaxTorque.Location = new System.Drawing.Point(318, 59);
            this.txtFrequencyMaxTorque.Name = "txtFrequencyMaxTorque";
            this.txtFrequencyMaxTorque.Size = new System.Drawing.Size(100, 20);
            this.txtFrequencyMaxTorque.TabIndex = 15;
            this.txtFrequencyMaxTorque.Text = "1800";
            // 
            // grpExternalCharacteristic
            // 
            this.grpExternalCharacteristic.Controls.Add(this.btnSaveExcelExternalCharacteristic);
            this.grpExternalCharacteristic.Controls.Add(this.btnOpenExcelExternalCharacteristic);
            this.grpExternalCharacteristic.Controls.Add(this.tabExternalCharacteristic);
            this.grpExternalCharacteristic.Location = new System.Drawing.Point(10, 464);
            this.grpExternalCharacteristic.Name = "grpExternalCharacteristic";
            this.grpExternalCharacteristic.Size = new System.Drawing.Size(560, 468);
            this.grpExternalCharacteristic.TabIndex = 10;
            this.grpExternalCharacteristic.TabStop = false;
            this.grpExternalCharacteristic.Text = "Внешняя скоростная характеристика двигателя:";
            // 
            // btnSaveExcelExternalCharacteristic
            // 
            this.btnSaveExcelExternalCharacteristic.Location = new System.Drawing.Point(336, 434);
            this.btnSaveExcelExternalCharacteristic.Name = "btnSaveExcelExternalCharacteristic";
            this.btnSaveExcelExternalCharacteristic.Size = new System.Drawing.Size(114, 23);
            this.btnSaveExcelExternalCharacteristic.TabIndex = 1;
            this.btnSaveExcelExternalCharacteristic.Text = "Сохранить в Excel";
            this.btnSaveExcelExternalCharacteristic.UseVisualStyleBackColor = true;
            // 
            // btnOpenExcelExternalCharacteristic
            // 
            this.btnOpenExcelExternalCharacteristic.Location = new System.Drawing.Point(456, 434);
            this.btnOpenExcelExternalCharacteristic.Name = "btnOpenExcelExternalCharacteristic";
            this.btnOpenExcelExternalCharacteristic.Size = new System.Drawing.Size(97, 23);
            this.btnOpenExcelExternalCharacteristic.TabIndex = 1;
            this.btnOpenExcelExternalCharacteristic.Text = "Открыть в Excel";
            this.btnOpenExcelExternalCharacteristic.UseVisualStyleBackColor = true;
            // 
            // tabExternalCharacteristic
            // 
            this.tabExternalCharacteristic.Controls.Add(this.tpPower);
            this.tabExternalCharacteristic.Controls.Add(this.tpTorque);
            this.tabExternalCharacteristic.Controls.Add(this.tpConsumption);
            this.tabExternalCharacteristic.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabExternalCharacteristic.Location = new System.Drawing.Point(3, 16);
            this.tabExternalCharacteristic.Name = "tabExternalCharacteristic";
            this.tabExternalCharacteristic.SelectedIndex = 0;
            this.tabExternalCharacteristic.Size = new System.Drawing.Size(554, 412);
            this.tabExternalCharacteristic.TabIndex = 0;
            // 
            // tpPower
            // 
            this.tpPower.Controls.Add(this.chrtPower);
            this.tpPower.Location = new System.Drawing.Point(4, 22);
            this.tpPower.Name = "tpPower";
            this.tpPower.Padding = new System.Windows.Forms.Padding(3);
            this.tpPower.Size = new System.Drawing.Size(546, 386);
            this.tpPower.TabIndex = 0;
            this.tpPower.Text = "Мощность";
            this.tpPower.UseVisualStyleBackColor = true;
            // 
            // tpTorque
            // 
            this.tpTorque.Controls.Add(this.chrtTorque);
            this.tpTorque.Location = new System.Drawing.Point(4, 22);
            this.tpTorque.Name = "tpTorque";
            this.tpTorque.Padding = new System.Windows.Forms.Padding(3);
            this.tpTorque.Size = new System.Drawing.Size(546, 386);
            this.tpTorque.TabIndex = 1;
            this.tpTorque.Text = "Момент";
            this.tpTorque.UseVisualStyleBackColor = true;
            // 
            // tpConsumption
            // 
            this.tpConsumption.Controls.Add(this.chrtConsumption);
            this.tpConsumption.Location = new System.Drawing.Point(4, 22);
            this.tpConsumption.Name = "tpConsumption";
            this.tpConsumption.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsumption.Size = new System.Drawing.Size(546, 386);
            this.tpConsumption.TabIndex = 2;
            this.tpConsumption.Text = "Удельный расход топлива";
            this.tpConsumption.UseVisualStyleBackColor = true;
            // 
            // chrtPower
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtPower.ChartAreas.Add(chartArea1);
            this.chrtPower.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chrtPower.Legends.Add(legend1);
            this.chrtPower.Location = new System.Drawing.Point(3, 3);
            this.chrtPower.Name = "chrtPower";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrtPower.Series.Add(series1);
            this.chrtPower.Size = new System.Drawing.Size(540, 380);
            this.chrtPower.TabIndex = 0;
            this.chrtPower.Text = "chart1";
            // 
            // chrtTorque
            // 
            chartArea2.Name = "ChartArea1";
            this.chrtTorque.ChartAreas.Add(chartArea2);
            this.chrtTorque.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chrtTorque.Legends.Add(legend2);
            this.chrtTorque.Location = new System.Drawing.Point(3, 3);
            this.chrtTorque.Name = "chrtTorque";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chrtTorque.Series.Add(series2);
            this.chrtTorque.Size = new System.Drawing.Size(540, 380);
            this.chrtTorque.TabIndex = 0;
            this.chrtTorque.Text = "chart1";
            // 
            // chrtConsumption
            // 
            chartArea3.Name = "ChartArea1";
            this.chrtConsumption.ChartAreas.Add(chartArea3);
            this.chrtConsumption.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chrtConsumption.Legends.Add(legend3);
            this.chrtConsumption.Location = new System.Drawing.Point(3, 3);
            this.chrtConsumption.Name = "chrtConsumption";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chrtConsumption.Series.Add(series3);
            this.chrtConsumption.Size = new System.Drawing.Size(540, 380);
            this.chrtConsumption.TabIndex = 0;
            this.chrtConsumption.Text = "chart1";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(1107, 321);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1224, 641);
            this.Controls.Add(this.grpExternalCharacteristic);
            this.Controls.Add(this.grpInitialData);
            this.Controls.Add(this.grpModelStep);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тягово-динамическая характеристика автомобиля";
            this.grpModelStep.ResumeLayout(false);
            this.tlpModelStep.ResumeLayout(false);
            this.tlpModelStep.PerformLayout();
            this.grpInitialData.ResumeLayout(false);
            this.grpEngineCharacteristic.ResumeLayout(false);
            this.tlpEngineCharacteristic.ResumeLayout(false);
            this.tlpEngineCharacteristic.PerformLayout();
            this.grpExternalCharacteristic.ResumeLayout(false);
            this.tabExternalCharacteristic.ResumeLayout(false);
            this.tpPower.ResumeLayout(false);
            this.tpTorque.ResumeLayout(false);
            this.tpConsumption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTorque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chrtConsumption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpModelStep;
        private System.Windows.Forms.TableLayoutPanel tlpModelStep;
        private System.Windows.Forms.Label lblCarModel;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.TextBox txtCarModel;
        private System.Windows.Forms.TextBox txtStep;
        private System.Windows.Forms.GroupBox grpInitialData;
        private System.Windows.Forms.GroupBox grpEngineCharacteristic;
        private System.Windows.Forms.TableLayoutPanel tlpEngineCharacteristic;
        private System.Windows.Forms.Label lblMaxFrequency;
        private System.Windows.Forms.Label lblMinFrequency;
        private System.Windows.Forms.Label lblMinFConsumption;
        private System.Windows.Forms.Label lblTorqueMaxPower;
        private System.Windows.Forms.Label lblMaxTorque;
        public System.Windows.Forms.TextBox txtMinFConsumption;
        public System.Windows.Forms.TextBox txtTorqueMaxPower;
        public System.Windows.Forms.TextBox txtMaxTorque;
        public System.Windows.Forms.TextBox txtMaxFrequency;
        public System.Windows.Forms.TextBox txtMinFrequency;
        private System.Windows.Forms.Label lblFrequencyMaxPower;
        public System.Windows.Forms.TextBox txtFrequencyMaxPower;
        private System.Windows.Forms.Label lblMaxPower;
        public System.Windows.Forms.TextBox txtMaxPower;
        private System.Windows.Forms.Label lblFrequencyMaxTorque;
        public System.Windows.Forms.TextBox txtFrequencyMaxTorque;
        private System.Windows.Forms.GroupBox grpExternalCharacteristic;
        private System.Windows.Forms.Button btnSaveExcelExternalCharacteristic;
        private System.Windows.Forms.Button btnOpenExcelExternalCharacteristic;
        private System.Windows.Forms.TabControl tabExternalCharacteristic;
        private System.Windows.Forms.TabPage tpPower;
        private System.Windows.Forms.TabPage tpTorque;
        private System.Windows.Forms.TabPage tpConsumption;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPower;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtTorque;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtConsumption;
    }
}
