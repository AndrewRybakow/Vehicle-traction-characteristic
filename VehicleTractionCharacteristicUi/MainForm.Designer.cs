namespace VehicleTractionCharacteristicUi
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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.grpModelStep = new System.Windows.Forms.GroupBox();
            this.tlpModelStep = new System.Windows.Forms.TableLayoutPanel();
            this.lblCarModel = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.txtCarModel = new System.Windows.Forms.TextBox();
            this.txtStep = new System.Windows.Forms.TextBox();
            this.grpInitialData = new System.Windows.Forms.GroupBox();
            this.grpGearboxCharacteristic = new System.Windows.Forms.GroupBox();
            this.grpGearRatioInGearbox = new System.Windows.Forms.GroupBox();
            this.flpGearRatioInGearbox = new System.Windows.Forms.FlowLayoutPanel();
            this.grpGearsInGearbox = new System.Windows.Forms.GroupBox();
            this.btnDeleteGearInGearbox = new System.Windows.Forms.Button();
            this.btnAddGearToGearbox = new System.Windows.Forms.Button();
            this.grpTransferBoxGearRatio = new System.Windows.Forms.GroupBox();
            this.tlpTransferBoxGearRatio = new System.Windows.Forms.TableLayoutPanel();
            this.lblTransferBoxTopGearRatio = new System.Windows.Forms.Label();
            this.lblTransferBoxLowerGearRatio = new System.Windows.Forms.Label();
            this.txtTransferBoxTopGearRatio = new System.Windows.Forms.TextBox();
            this.txtTransferBoxLowerGearRatio = new System.Windows.Forms.TextBox();
            this.grpTransferBox = new System.Windows.Forms.GroupBox();
            this.rdoTransferBoxNo = new System.Windows.Forms.RadioButton();
            this.rdoTransferBoxYes = new System.Windows.Forms.RadioButton();
            this.grpVehicleCharacteristic = new System.Windows.Forms.GroupBox();
            this.tlpVehicleCharacteristic = new System.Windows.Forms.TableLayoutPanel();
            this.lblFinalDriveRatio = new System.Windows.Forms.Label();
            this.txtFinalDriveRatio = new System.Windows.Forms.TextBox();
            this.lblWeightOnWheels = new System.Windows.Forms.Label();
            this.txtWeightOnWheels = new System.Windows.Forms.TextBox();
            this.lblWheelRadius = new System.Windows.Forms.Label();
            this.txtWheelRadius = new System.Windows.Forms.TextBox();
            this.lblCoefOfTransEfficiency = new System.Windows.Forms.Label();
            this.txtCoefOfTransEfficiency = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
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
            this.tabExternalCharacteristic = new System.Windows.Forms.TabControl();
            this.tpPower = new System.Windows.Forms.TabPage();
            this.chrtPower = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tpTorque = new System.Windows.Forms.TabPage();
            this.chrtTorque = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tpConsumption = new System.Windows.Forms.TabPage();
            this.chrtConsumption = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpModelStep.SuspendLayout();
            this.tlpModelStep.SuspendLayout();
            this.grpInitialData.SuspendLayout();
            this.grpGearboxCharacteristic.SuspendLayout();
            this.grpGearRatioInGearbox.SuspendLayout();
            this.grpGearsInGearbox.SuspendLayout();
            this.grpTransferBoxGearRatio.SuspendLayout();
            this.tlpTransferBoxGearRatio.SuspendLayout();
            this.grpTransferBox.SuspendLayout();
            this.grpVehicleCharacteristic.SuspendLayout();
            this.tlpVehicleCharacteristic.SuspendLayout();
            this.grpEngineCharacteristic.SuspendLayout();
            this.tlpEngineCharacteristic.SuspendLayout();
            this.grpExternalCharacteristic.SuspendLayout();
            this.tabExternalCharacteristic.SuspendLayout();
            this.tpPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPower)).BeginInit();
            this.tpTorque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTorque)).BeginInit();
            this.tpConsumption.SuspendLayout();
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
            this.grpInitialData.Controls.Add(this.grpGearboxCharacteristic);
            this.grpInitialData.Controls.Add(this.grpTransferBoxGearRatio);
            this.grpInitialData.Controls.Add(this.grpTransferBox);
            this.grpInitialData.Controls.Add(this.grpVehicleCharacteristic);
            this.grpInitialData.Controls.Add(this.btnCalculate);
            this.grpInitialData.Controls.Add(this.grpEngineCharacteristic);
            this.grpInitialData.Location = new System.Drawing.Point(10, 94);
            this.grpInitialData.Name = "grpInitialData";
            this.grpInitialData.Size = new System.Drawing.Size(1188, 350);
            this.grpInitialData.TabIndex = 9;
            this.grpInitialData.TabStop = false;
            this.grpInitialData.Text = "Исходные данные:";
            // 
            // grpGearboxCharacteristic
            // 
            this.grpGearboxCharacteristic.Controls.Add(this.grpGearRatioInGearbox);
            this.grpGearboxCharacteristic.Controls.Add(this.grpGearsInGearbox);
            this.grpGearboxCharacteristic.Location = new System.Drawing.Point(937, 24);
            this.grpGearboxCharacteristic.Name = "grpGearboxCharacteristic";
            this.grpGearboxCharacteristic.Size = new System.Drawing.Size(200, 254);
            this.grpGearboxCharacteristic.TabIndex = 13;
            this.grpGearboxCharacteristic.TabStop = false;
            this.grpGearboxCharacteristic.Text = "Характиристики коробки передач:";
            // 
            // grpGearRatioInGearbox
            // 
            this.grpGearRatioInGearbox.Controls.Add(this.flpGearRatioInGearbox);
            this.grpGearRatioInGearbox.Location = new System.Drawing.Point(6, 79);
            this.grpGearRatioInGearbox.Name = "grpGearRatioInGearbox";
            this.grpGearRatioInGearbox.Size = new System.Drawing.Size(188, 169);
            this.grpGearRatioInGearbox.TabIndex = 11;
            this.grpGearRatioInGearbox.TabStop = false;
            this.grpGearRatioInGearbox.Text = "Передаточные числа передач:";
            // 
            // flpGearRatioInGearbox
            // 
            this.flpGearRatioInGearbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpGearRatioInGearbox.Location = new System.Drawing.Point(3, 16);
            this.flpGearRatioInGearbox.Name = "flpGearRatioInGearbox";
            this.flpGearRatioInGearbox.Size = new System.Drawing.Size(182, 150);
            this.flpGearRatioInGearbox.TabIndex = 0;
            // 
            // grpGearsInGearbox
            // 
            this.grpGearsInGearbox.Controls.Add(this.btnDeleteGearInGearbox);
            this.grpGearsInGearbox.Controls.Add(this.btnAddGearToGearbox);
            this.grpGearsInGearbox.Location = new System.Drawing.Point(6, 19);
            this.grpGearsInGearbox.Name = "grpGearsInGearbox";
            this.grpGearsInGearbox.Size = new System.Drawing.Size(188, 54);
            this.grpGearsInGearbox.TabIndex = 10;
            this.grpGearsInGearbox.TabStop = false;
            this.grpGearsInGearbox.Text = "Ступени коробки передач";
            // 
            // btnDeleteGearInGearbox
            // 
            this.btnDeleteGearInGearbox.Location = new System.Drawing.Point(102, 20);
            this.btnDeleteGearInGearbox.Name = "btnDeleteGearInGearbox";
            this.btnDeleteGearInGearbox.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteGearInGearbox.TabIndex = 11;
            this.btnDeleteGearInGearbox.Text = "Удалить";
            this.btnDeleteGearInGearbox.UseVisualStyleBackColor = true;
            // 
            // btnAddGearToGearbox
            // 
            this.btnAddGearToGearbox.Location = new System.Drawing.Point(12, 20);
            this.btnAddGearToGearbox.Name = "btnAddGearToGearbox";
            this.btnAddGearToGearbox.Size = new System.Drawing.Size(75, 23);
            this.btnAddGearToGearbox.TabIndex = 10;
            this.btnAddGearToGearbox.Text = "Добавить";
            this.btnAddGearToGearbox.UseVisualStyleBackColor = true;
            // 
            // grpTransferBoxGearRatio
            // 
            this.grpTransferBoxGearRatio.Controls.Add(this.tlpTransferBoxGearRatio);
            this.grpTransferBoxGearRatio.Location = new System.Drawing.Point(549, 208);
            this.grpTransferBoxGearRatio.Name = "grpTransferBoxGearRatio";
            this.grpTransferBoxGearRatio.Size = new System.Drawing.Size(247, 70);
            this.grpTransferBoxGearRatio.TabIndex = 12;
            this.grpTransferBoxGearRatio.TabStop = false;
            this.grpTransferBoxGearRatio.Text = "Передаточные числа раздаточной коробки:";
            // 
            // tlpTransferBoxGearRatio
            // 
            this.tlpTransferBoxGearRatio.ColumnCount = 2;
            this.tlpTransferBoxGearRatio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.22821F));
            this.tlpTransferBoxGearRatio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.77179F));
            this.tlpTransferBoxGearRatio.Controls.Add(this.lblTransferBoxTopGearRatio, 0, 0);
            this.tlpTransferBoxGearRatio.Controls.Add(this.lblTransferBoxLowerGearRatio, 0, 1);
            this.tlpTransferBoxGearRatio.Controls.Add(this.txtTransferBoxTopGearRatio, 1, 0);
            this.tlpTransferBoxGearRatio.Controls.Add(this.txtTransferBoxLowerGearRatio, 1, 1);
            this.tlpTransferBoxGearRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTransferBoxGearRatio.Location = new System.Drawing.Point(3, 16);
            this.tlpTransferBoxGearRatio.Name = "tlpTransferBoxGearRatio";
            this.tlpTransferBoxGearRatio.RowCount = 2;
            this.tlpTransferBoxGearRatio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTransferBoxGearRatio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTransferBoxGearRatio.Size = new System.Drawing.Size(241, 51);
            this.tlpTransferBoxGearRatio.TabIndex = 0;
            // 
            // lblTransferBoxTopGearRatio
            // 
            this.lblTransferBoxTopGearRatio.AutoSize = true;
            this.lblTransferBoxTopGearRatio.Location = new System.Drawing.Point(3, 5);
            this.lblTransferBoxTopGearRatio.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblTransferBoxTopGearRatio.Name = "lblTransferBoxTopGearRatio";
            this.lblTransferBoxTopGearRatio.Size = new System.Drawing.Size(101, 13);
            this.lblTransferBoxTopGearRatio.TabIndex = 0;
            this.lblTransferBoxTopGearRatio.Text = "Высшая передача:";
            // 
            // lblTransferBoxLowerGearRatio
            // 
            this.lblTransferBoxLowerGearRatio.AutoSize = true;
            this.lblTransferBoxLowerGearRatio.Location = new System.Drawing.Point(3, 30);
            this.lblTransferBoxLowerGearRatio.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblTransferBoxLowerGearRatio.Name = "lblTransferBoxLowerGearRatio";
            this.lblTransferBoxLowerGearRatio.Size = new System.Drawing.Size(100, 13);
            this.lblTransferBoxLowerGearRatio.TabIndex = 1;
            this.lblTransferBoxLowerGearRatio.Text = "Низшая передача:";
            // 
            // txtTransferBoxTopGearRatio
            // 
            this.txtTransferBoxTopGearRatio.Location = new System.Drawing.Point(111, 3);
            this.txtTransferBoxTopGearRatio.Name = "txtTransferBoxTopGearRatio";
            this.txtTransferBoxTopGearRatio.Size = new System.Drawing.Size(100, 20);
            this.txtTransferBoxTopGearRatio.TabIndex = 2;
            // 
            // txtTransferBoxLowerGearRatio
            // 
            this.txtTransferBoxLowerGearRatio.Location = new System.Drawing.Point(111, 28);
            this.txtTransferBoxLowerGearRatio.Name = "txtTransferBoxLowerGearRatio";
            this.txtTransferBoxLowerGearRatio.Size = new System.Drawing.Size(100, 20);
            this.txtTransferBoxLowerGearRatio.TabIndex = 3;
            // 
            // grpTransferBox
            // 
            this.grpTransferBox.Controls.Add(this.rdoTransferBoxNo);
            this.grpTransferBox.Controls.Add(this.rdoTransferBoxYes);
            this.grpTransferBox.Location = new System.Drawing.Point(549, 160);
            this.grpTransferBox.Name = "grpTransferBox";
            this.grpTransferBox.Size = new System.Drawing.Size(247, 42);
            this.grpTransferBox.TabIndex = 11;
            this.grpTransferBox.TabStop = false;
            this.grpTransferBox.Text = "Раздаточная коробка:";
            // 
            // rdoTransferBoxNo
            // 
            this.rdoTransferBoxNo.AutoSize = true;
            this.rdoTransferBoxNo.Location = new System.Drawing.Point(107, 19);
            this.rdoTransferBoxNo.Name = "rdoTransferBoxNo";
            this.rdoTransferBoxNo.Size = new System.Drawing.Size(87, 17);
            this.rdoTransferBoxNo.TabIndex = 9;
            this.rdoTransferBoxNo.TabStop = true;
            this.rdoTransferBoxNo.Text = "Отсутствует";
            this.rdoTransferBoxNo.UseVisualStyleBackColor = true;
            // 
            // rdoTransferBoxYes
            // 
            this.rdoTransferBoxYes.AutoSize = true;
            this.rdoTransferBoxYes.Location = new System.Drawing.Point(7, 19);
            this.rdoTransferBoxYes.Name = "rdoTransferBoxYes";
            this.rdoTransferBoxYes.Size = new System.Drawing.Size(94, 17);
            this.rdoTransferBoxYes.TabIndex = 8;
            this.rdoTransferBoxYes.TabStop = true;
            this.rdoTransferBoxYes.Text = "Присутствует";
            this.rdoTransferBoxYes.UseVisualStyleBackColor = true;
            // 
            // grpVehicleCharacteristic
            // 
            this.grpVehicleCharacteristic.Controls.Add(this.tlpVehicleCharacteristic);
            this.grpVehicleCharacteristic.Location = new System.Drawing.Point(549, 24);
            this.grpVehicleCharacteristic.Name = "grpVehicleCharacteristic";
            this.grpVehicleCharacteristic.Size = new System.Drawing.Size(341, 132);
            this.grpVehicleCharacteristic.TabIndex = 9;
            this.grpVehicleCharacteristic.TabStop = false;
            this.grpVehicleCharacteristic.Text = "Характеристики автомобиля:";
            // 
            // tlpVehicleCharacteristic
            // 
            this.tlpVehicleCharacteristic.ColumnCount = 2;
            this.tlpVehicleCharacteristic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.44343F));
            this.tlpVehicleCharacteristic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.55658F));
            this.tlpVehicleCharacteristic.Controls.Add(this.lblFinalDriveRatio, 0, 3);
            this.tlpVehicleCharacteristic.Controls.Add(this.txtFinalDriveRatio, 1, 3);
            this.tlpVehicleCharacteristic.Controls.Add(this.lblWeightOnWheels, 0, 0);
            this.tlpVehicleCharacteristic.Controls.Add(this.txtWeightOnWheels, 1, 0);
            this.tlpVehicleCharacteristic.Controls.Add(this.lblWheelRadius, 0, 1);
            this.tlpVehicleCharacteristic.Controls.Add(this.txtWheelRadius, 1, 1);
            this.tlpVehicleCharacteristic.Controls.Add(this.lblCoefOfTransEfficiency, 0, 2);
            this.tlpVehicleCharacteristic.Controls.Add(this.txtCoefOfTransEfficiency, 1, 2);
            this.tlpVehicleCharacteristic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVehicleCharacteristic.Location = new System.Drawing.Point(3, 16);
            this.tlpVehicleCharacteristic.Name = "tlpVehicleCharacteristic";
            this.tlpVehicleCharacteristic.RowCount = 4;
            this.tlpVehicleCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpVehicleCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpVehicleCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpVehicleCharacteristic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpVehicleCharacteristic.Size = new System.Drawing.Size(335, 113);
            this.tlpVehicleCharacteristic.TabIndex = 0;
            // 
            // lblFinalDriveRatio
            // 
            this.lblFinalDriveRatio.AutoSize = true;
            this.lblFinalDriveRatio.Location = new System.Drawing.Point(3, 89);
            this.lblFinalDriveRatio.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblFinalDriveRatio.Name = "lblFinalDriveRatio";
            this.lblFinalDriveRatio.Size = new System.Drawing.Size(208, 13);
            this.lblFinalDriveRatio.TabIndex = 4;
            this.lblFinalDriveRatio.Text = "Передаточное число главной передачи:";
            // 
            // txtFinalDriveRatio
            // 
            this.txtFinalDriveRatio.Location = new System.Drawing.Point(222, 87);
            this.txtFinalDriveRatio.Name = "txtFinalDriveRatio";
            this.txtFinalDriveRatio.Size = new System.Drawing.Size(100, 20);
            this.txtFinalDriveRatio.TabIndex = 5;
            // 
            // lblWeightOnWheels
            // 
            this.lblWeightOnWheels.AutoSize = true;
            this.lblWeightOnWheels.Location = new System.Drawing.Point(3, 5);
            this.lblWeightOnWheels.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblWeightOnWheels.Name = "lblWeightOnWheels";
            this.lblWeightOnWheels.Size = new System.Drawing.Size(212, 13);
            this.lblWeightOnWheels.TabIndex = 6;
            this.lblWeightOnWheels.Text = "Вес на ведущих колёсах автомобиля, Н:";
            // 
            // txtWeightOnWheels
            // 
            this.txtWeightOnWheels.Location = new System.Drawing.Point(222, 3);
            this.txtWeightOnWheels.Name = "txtWeightOnWheels";
            this.txtWeightOnWheels.Size = new System.Drawing.Size(100, 20);
            this.txtWeightOnWheels.TabIndex = 7;
            // 
            // lblWheelRadius
            // 
            this.lblWheelRadius.AutoSize = true;
            this.lblWheelRadius.Location = new System.Drawing.Point(3, 33);
            this.lblWheelRadius.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblWheelRadius.Name = "lblWheelRadius";
            this.lblWheelRadius.Size = new System.Drawing.Size(99, 13);
            this.lblWheelRadius.TabIndex = 1;
            this.lblWheelRadius.Text = "Радиус колеса, м:";
            // 
            // txtWheelRadius
            // 
            this.txtWheelRadius.Location = new System.Drawing.Point(222, 31);
            this.txtWheelRadius.Name = "txtWheelRadius";
            this.txtWheelRadius.Size = new System.Drawing.Size(100, 20);
            this.txtWheelRadius.TabIndex = 3;
            // 
            // lblCoefOfTransEfficiency
            // 
            this.lblCoefOfTransEfficiency.AutoSize = true;
            this.lblCoefOfTransEfficiency.Location = new System.Drawing.Point(3, 61);
            this.lblCoefOfTransEfficiency.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lblCoefOfTransEfficiency.Name = "lblCoefOfTransEfficiency";
            this.lblCoefOfTransEfficiency.Size = new System.Drawing.Size(177, 13);
            this.lblCoefOfTransEfficiency.TabIndex = 0;
            this.lblCoefOfTransEfficiency.Text = "Коэффициент КПД трансмиссии:";
            // 
            // txtCoefOfTransEfficiency
            // 
            this.txtCoefOfTransEfficiency.Location = new System.Drawing.Point(222, 59);
            this.txtCoefOfTransEfficiency.Name = "txtCoefOfTransEfficiency";
            this.txtCoefOfTransEfficiency.Size = new System.Drawing.Size(100, 20);
            this.txtCoefOfTransEfficiency.TabIndex = 2;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(1107, 321);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 7;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // grpEngineCharacteristic
            // 
            this.grpEngineCharacteristic.Controls.Add(this.tlpEngineCharacteristic);
            this.grpEngineCharacteristic.Location = new System.Drawing.Point(46, 24);
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
            this.btnSaveExcelExternalCharacteristic.Location = new System.Drawing.Point(436, 436);
            this.btnSaveExcelExternalCharacteristic.Name = "btnSaveExcelExternalCharacteristic";
            this.btnSaveExcelExternalCharacteristic.Size = new System.Drawing.Size(114, 23);
            this.btnSaveExcelExternalCharacteristic.TabIndex = 1;
            this.btnSaveExcelExternalCharacteristic.Text = "Сохранить в Excel";
            this.btnSaveExcelExternalCharacteristic.UseVisualStyleBackColor = true;
            this.btnSaveExcelExternalCharacteristic.Click += new System.EventHandler(this.btnSaveExcelExternalCharacteristic_Click);
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
            // chrtPower
            // 
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MinorGrid.Enabled = true;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chrtPower.ChartAreas.Add(chartArea1);
            this.chrtPower.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chrtPower.Legends.Add(legend1);
            this.chrtPower.Location = new System.Drawing.Point(3, 3);
            this.chrtPower.Name = "chrtPower";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Power";
            this.chrtPower.Series.Add(series1);
            this.chrtPower.Size = new System.Drawing.Size(540, 380);
            this.chrtPower.TabIndex = 0;
            this.chrtPower.Text = "chart1";
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Frequency";
            title1.Text = "Частота вращения коленчатого вала, об/мин";
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title2.Name = "Power";
            title2.Text = "Мощность, кВт";
            this.chrtPower.Titles.Add(title1);
            this.chrtPower.Titles.Add(title2);
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
            // chrtTorque
            // 
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea2.AxisX.IsStartedFromZero = false;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.Name = "ChartArea1";
            this.chrtTorque.ChartAreas.Add(chartArea2);
            this.chrtTorque.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chrtTorque.Legends.Add(legend2);
            this.chrtTorque.Location = new System.Drawing.Point(3, 3);
            this.chrtTorque.Name = "chrtTorque";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Torque";
            this.chrtTorque.Series.Add(series2);
            this.chrtTorque.Size = new System.Drawing.Size(540, 380);
            this.chrtTorque.TabIndex = 0;
            this.chrtTorque.Text = "chart1";
            title3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title3.Name = "Frequency";
            title3.Text = "Частота вращения коленчатого вала, об/мин";
            title4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title4.Name = "Torque";
            title4.Text = "Момент, Нм";
            this.chrtTorque.Titles.Add(title3);
            this.chrtTorque.Titles.Add(title4);
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
            // chrtConsumption
            // 
            chartArea3.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea3.AxisX.IsStartedFromZero = false;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MinorGrid.Enabled = true;
            chartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MinorGrid.Enabled = true;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.Name = "ChartArea1";
            this.chrtConsumption.ChartAreas.Add(chartArea3);
            this.chrtConsumption.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chrtConsumption.Legends.Add(legend3);
            this.chrtConsumption.Location = new System.Drawing.Point(3, 3);
            this.chrtConsumption.Name = "chrtConsumption";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series3.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "Consumption";
            this.chrtConsumption.Series.Add(series3);
            this.chrtConsumption.Size = new System.Drawing.Size(540, 380);
            this.chrtConsumption.TabIndex = 0;
            this.chrtConsumption.Text = "chart1";
            title5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title5.Name = "Frequency";
            title5.Text = "Частота вращения коленчатого вала, об/мин";
            title6.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title6.Name = "Consumption";
            title6.Text = "Удельный расход топлива, г/кВтч";
            this.chrtConsumption.Titles.Add(title5);
            this.chrtConsumption.Titles.Add(title6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1241, 641);
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
            this.grpGearboxCharacteristic.ResumeLayout(false);
            this.grpGearRatioInGearbox.ResumeLayout(false);
            this.grpGearsInGearbox.ResumeLayout(false);
            this.grpTransferBoxGearRatio.ResumeLayout(false);
            this.tlpTransferBoxGearRatio.ResumeLayout(false);
            this.tlpTransferBoxGearRatio.PerformLayout();
            this.grpTransferBox.ResumeLayout(false);
            this.grpTransferBox.PerformLayout();
            this.grpVehicleCharacteristic.ResumeLayout(false);
            this.tlpVehicleCharacteristic.ResumeLayout(false);
            this.tlpVehicleCharacteristic.PerformLayout();
            this.grpEngineCharacteristic.ResumeLayout(false);
            this.tlpEngineCharacteristic.ResumeLayout(false);
            this.tlpEngineCharacteristic.PerformLayout();
            this.grpExternalCharacteristic.ResumeLayout(false);
            this.tabExternalCharacteristic.ResumeLayout(false);
            this.tpPower.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtPower)).EndInit();
            this.tpTorque.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtTorque)).EndInit();
            this.tpConsumption.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabExternalCharacteristic;
        private System.Windows.Forms.TabPage tpPower;
        private System.Windows.Forms.TabPage tpTorque;
        private System.Windows.Forms.TabPage tpConsumption;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPower;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtTorque;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtConsumption;
        private System.Windows.Forms.GroupBox grpGearboxCharacteristic;
        private System.Windows.Forms.GroupBox grpGearRatioInGearbox;
        private System.Windows.Forms.FlowLayoutPanel flpGearRatioInGearbox;
        private System.Windows.Forms.GroupBox grpGearsInGearbox;
        private System.Windows.Forms.Button btnDeleteGearInGearbox;
        private System.Windows.Forms.Button btnAddGearToGearbox;
        private System.Windows.Forms.GroupBox grpTransferBoxGearRatio;
        private System.Windows.Forms.TableLayoutPanel tlpTransferBoxGearRatio;
        private System.Windows.Forms.Label lblTransferBoxTopGearRatio;
        private System.Windows.Forms.Label lblTransferBoxLowerGearRatio;
        private System.Windows.Forms.TextBox txtTransferBoxTopGearRatio;
        private System.Windows.Forms.TextBox txtTransferBoxLowerGearRatio;
        private System.Windows.Forms.GroupBox grpTransferBox;
        private System.Windows.Forms.RadioButton rdoTransferBoxNo;
        private System.Windows.Forms.RadioButton rdoTransferBoxYes;
        private System.Windows.Forms.GroupBox grpVehicleCharacteristic;
        private System.Windows.Forms.TableLayoutPanel tlpVehicleCharacteristic;
        private System.Windows.Forms.Label lblFinalDriveRatio;
        private System.Windows.Forms.TextBox txtFinalDriveRatio;
        private System.Windows.Forms.Label lblWeightOnWheels;
        private System.Windows.Forms.TextBox txtWeightOnWheels;
        private System.Windows.Forms.Label lblWheelRadius;
        private System.Windows.Forms.TextBox txtWheelRadius;
        private System.Windows.Forms.Label lblCoefOfTransEfficiency;
        private System.Windows.Forms.TextBox txtCoefOfTransEfficiency;
    }
}

