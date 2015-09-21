namespace MotorVisualization
{
    partial class MotorVisualization
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
            this.components = new System.ComponentModel.Container();
            this.rbOpto = new System.Windows.Forms.RadioButton();
            this.lMotorName = new System.Windows.Forms.Label();
            this.pnlMotor = new System.Windows.Forms.Panel();
            this.rotateTimer = new System.Windows.Forms.Timer(this.components);
            this.lPosition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbOpto
            // 
            this.rbOpto.AutoCheck = false;
            this.rbOpto.AutoSize = true;
            this.rbOpto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbOpto.ForeColor = System.Drawing.Color.Red;
            this.rbOpto.Location = new System.Drawing.Point(9, 167);
            this.rbOpto.Name = "rbOpto";
            this.rbOpto.Size = new System.Drawing.Size(104, 20);
            this.rbOpto.TabIndex = 0;
            this.rbOpto.Text = "optozávora";
            this.rbOpto.UseVisualStyleBackColor = true;
            // 
            // lMotorName
            // 
            this.lMotorName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lMotorName.AutoSize = true;
            this.lMotorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lMotorName.Location = new System.Drawing.Point(25, 7);
            this.lMotorName.Name = "lMotorName";
            this.lMotorName.Size = new System.Drawing.Size(74, 16);
            this.lMotorName.TabIndex = 2;
            this.lMotorName.Text = "MOTOR x";
            this.lMotorName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMotor
            // 
            this.pnlMotor.BackColor = System.Drawing.Color.White;
            this.pnlMotor.Location = new System.Drawing.Point(0, 31);
            this.pnlMotor.Name = "pnlMotor";
            this.pnlMotor.Size = new System.Drawing.Size(130, 130);
            this.pnlMotor.TabIndex = 3;
            this.pnlMotor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMotor_Paint);
            // 
            // rotateTimer
            // 
            this.rotateTimer.Tick += new System.EventHandler(this.rotateTimer_Tick);
            // 
            // lPosition
            // 
            this.lPosition.AutoSize = true;
            this.lPosition.ForeColor = System.Drawing.Color.Black;
            this.lPosition.Location = new System.Drawing.Point(6, 199);
            this.lPosition.Name = "lPosition";
            this.lPosition.Size = new System.Drawing.Size(51, 13);
            this.lPosition.TabIndex = 4;
            this.lPosition.Text = "Pozice: 0";
            // 
            // MotorVisualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lPosition);
            this.Controls.Add(this.pnlMotor);
            this.Controls.Add(this.lMotorName);
            this.Controls.Add(this.rbOpto);
            this.Name = "MotorVisualization";
            this.Size = new System.Drawing.Size(130, 225);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbOpto;
        private System.Windows.Forms.Label lMotorName;
        private System.Windows.Forms.Panel pnlMotor;
        private System.Windows.Forms.Timer rotateTimer;
        private System.Windows.Forms.Label lPosition;
    }
}
