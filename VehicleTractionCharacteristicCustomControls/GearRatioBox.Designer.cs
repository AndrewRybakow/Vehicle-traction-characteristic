namespace VehicleTractionCharacteristicCustomControls
{
    partial class GearRatioBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGearNumber = new System.Windows.Forms.Label();
            this.txtGearRatio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblGearNumber
            // 
            this.lblGearNumber.AutoSize = true;
            this.lblGearNumber.Location = new System.Drawing.Point(2, 7);
            this.lblGearNumber.Name = "lblGearNumber";
            this.lblGearNumber.Size = new System.Drawing.Size(22, 13);
            this.lblGearNumber.TabIndex = 0;
            this.lblGearNumber.Text = "18:";
            // 
            // txtGearRatio
            // 
            this.txtGearRatio.Location = new System.Drawing.Point(23, 3);
            this.txtGearRatio.Name = "txtGearRatio";
            this.txtGearRatio.Size = new System.Drawing.Size(100, 20);
            this.txtGearRatio.TabIndex = 1;
            // 
            // GearRatioBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtGearRatio);
            this.Controls.Add(this.lblGearNumber);
            this.Name = "GearRatioBox";
            this.Size = new System.Drawing.Size(130, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGearNumber;
        private System.Windows.Forms.TextBox txtGearRatio;
    }
}
