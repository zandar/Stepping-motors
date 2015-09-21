namespace MotorControl
{
    partial class MotorControl
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
            this.gbMotorControl = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.udSectors = new System.Windows.Forms.NumericUpDown();
            this.btRight = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.udSteps = new System.Windows.Forms.NumericUpDown();
            this.udSpeed = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMotorControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMotorControl
            // 
            this.gbMotorControl.Controls.Add(this.label3);
            this.gbMotorControl.Controls.Add(this.udSectors);
            this.gbMotorControl.Controls.Add(this.btRight);
            this.gbMotorControl.Controls.Add(this.btLeft);
            this.gbMotorControl.Controls.Add(this.udSteps);
            this.gbMotorControl.Controls.Add(this.udSpeed);
            this.gbMotorControl.Controls.Add(this.label2);
            this.gbMotorControl.Controls.Add(this.label1);
            this.gbMotorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMotorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbMotorControl.Location = new System.Drawing.Point(0, 0);
            this.gbMotorControl.Name = "gbMotorControl";
            this.gbMotorControl.Size = new System.Drawing.Size(332, 70);
            this.gbMotorControl.TabIndex = 0;
            this.gbMotorControl.TabStop = false;
            this.gbMotorControl.Text = "MOTOR x";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(155, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Počet úseků";
            // 
            // udSectors
            // 
            this.udSectors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.udSectors.Location = new System.Drawing.Point(158, 32);
            this.udSectors.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.udSectors.Name = "udSectors";
            this.udSectors.Size = new System.Drawing.Size(70, 20);
            this.udSectors.TabIndex = 6;
            this.udSectors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udSectors.ValueChanged += new System.EventHandler(this.udSectors_ValueChanged);
            // 
            // btRight
            // 
            this.btRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btRight.Location = new System.Drawing.Point(291, 32);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(35, 23);
            this.btRight.TabIndex = 5;
            this.btRight.Text = "->";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btLeft
            // 
            this.btLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btLeft.Location = new System.Drawing.Point(250, 32);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(35, 23);
            this.btLeft.TabIndex = 4;
            this.btLeft.Text = "<-";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // udSteps
            // 
            this.udSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.udSteps.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udSteps.Location = new System.Drawing.Point(82, 32);
            this.udSteps.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.udSteps.Name = "udSteps";
            this.udSteps.Size = new System.Drawing.Size(70, 20);
            this.udSteps.TabIndex = 3;
            this.udSteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udSteps.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udSteps.ValueChanged += new System.EventHandler(this.udSteps_ValueChanged);
            // 
            // udSpeed
            // 
            this.udSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.udSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udSpeed.Location = new System.Drawing.Point(6, 32);
            this.udSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udSpeed.Name = "udSpeed";
            this.udSpeed.Size = new System.Drawing.Size(70, 20);
            this.udSpeed.TabIndex = 2;
            this.udSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udSpeed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(79, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Počet kroků";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rychlost (ms)";
            // 
            // MotorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMotorControl);
            this.Name = "MotorControl";
            this.Size = new System.Drawing.Size(332, 70);
            this.gbMotorControl.ResumeLayout(false);
            this.gbMotorControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMotorControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.NumericUpDown udSteps;
        private System.Windows.Forms.NumericUpDown udSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown udSectors;
    }
}
