namespace KrokoveMotory
{
    /// <summary>
    /// 
    /// </summary>
    partial class FormKM
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelVizualization = new System.Windows.Forms.Panel();
            this.motorVisualization4 = new MotorVisualization.MotorVisualization();
            this.motorVisualization3 = new MotorVisualization.MotorVisualization();
            this.motorVisualization2 = new MotorVisualization.MotorVisualization();
            this.motorVisualization1 = new MotorVisualization.MotorVisualization();
            this.panelControl = new System.Windows.Forms.Panel();
            this.lRotStatus = new System.Windows.Forms.Label();
            this.tcControl = new System.Windows.Forms.TabControl();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.motorDependances1 = new MotorDependences.MotorDependences();
            this.gbDeviceManagement = new System.Windows.Forms.GroupBox();
            this.btDisconnectDevice = new System.Windows.Forms.Button();
            this.btConnectDevice = new System.Windows.Forms.Button();
            this.btFindDevice = new System.Windows.Forms.Button();
            this.lbDevice = new System.Windows.Forms.ListBox();
            this.tabPageControl = new System.Windows.Forms.TabPage();
            this.motorControl4 = new MotorControl.MotorControl();
            this.motorControl3 = new MotorControl.MotorControl();
            this.motorControl2 = new MotorControl.MotorControl();
            this.motorControl1 = new MotorControl.MotorControl();
            this.tabPageAddDevice = new System.Windows.Forms.TabPage();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.btLogClear = new System.Windows.Forms.Button();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.btStop = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.panelSignals = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelVizualization.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.tcControl.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.gbDeviceManagement.SuspendLayout();
            this.tabPageControl.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ApplicationToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(890, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ApplicationToolStripMenuItem
            // 
            this.ApplicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.ApplicationToolStripMenuItem.Name = "ApplicationToolStripMenuItem";
            this.ApplicationToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ApplicationToolStripMenuItem.Text = "Aplikace";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ExitToolStripMenuItem.Text = "Konec";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.HelpToolStripMenuItem1});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.HelpToolStripMenuItem.Text = "Nápověda";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.AboutToolStripMenuItem.Text = "O aplikaci";
            // 
            // HelpToolStripMenuItem1
            // 
            this.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1";
            this.HelpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.HelpToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.HelpToolStripMenuItem1.Text = "Nápověda";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 433);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(890, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slInfo
            // 
            this.slInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.slInfo.ForeColor = System.Drawing.Color.Red;
            this.slInfo.Name = "slInfo";
            this.slInfo.Size = new System.Drawing.Size(81, 17);
            this.slInfo.Text = "Nepřipojeno.";
            // 
            // panelVizualization
            // 
            this.panelVizualization.BackColor = System.Drawing.Color.White;
            this.panelVizualization.Controls.Add(this.motorVisualization4);
            this.panelVizualization.Controls.Add(this.motorVisualization3);
            this.panelVizualization.Controls.Add(this.motorVisualization2);
            this.panelVizualization.Controls.Add(this.motorVisualization1);
            this.panelVizualization.Location = new System.Drawing.Point(0, 24);
            this.panelVizualization.Name = "panelVizualization";
            this.panelVizualization.Size = new System.Drawing.Size(544, 264);
            this.panelVizualization.TabIndex = 2;
            // 
            // motorVisualization4
            // 
            this.motorVisualization4.Location = new System.Drawing.Point(411, 22);
            this.motorVisualization4.Name = "motorVisualization4";
            this.motorVisualization4.Size = new System.Drawing.Size(130, 222);
            this.motorVisualization4.TabIndex = 3;
            // 
            // motorVisualization3
            // 
            this.motorVisualization3.Location = new System.Drawing.Point(275, 22);
            this.motorVisualization3.Name = "motorVisualization3";
            this.motorVisualization3.Size = new System.Drawing.Size(130, 222);
            this.motorVisualization3.TabIndex = 2;
            // 
            // motorVisualization2
            // 
            this.motorVisualization2.Location = new System.Drawing.Point(139, 22);
            this.motorVisualization2.Name = "motorVisualization2";
            this.motorVisualization2.Size = new System.Drawing.Size(130, 222);
            this.motorVisualization2.TabIndex = 1;
            // 
            // motorVisualization1
            // 
            this.motorVisualization1.Location = new System.Drawing.Point(0, 22);
            this.motorVisualization1.Name = "motorVisualization1";
            this.motorVisualization1.Size = new System.Drawing.Size(130, 222);
            this.motorVisualization1.TabIndex = 0;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.lRotStatus);
            this.panelControl.Controls.Add(this.tcControl);
            this.panelControl.Controls.Add(this.btStop);
            this.panelControl.Controls.Add(this.btReset);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl.Location = new System.Drawing.Point(550, 24);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(340, 409);
            this.panelControl.TabIndex = 3;
            // 
            // lRotStatus
            // 
            this.lRotStatus.AutoSize = true;
            this.lRotStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lRotStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lRotStatus.Location = new System.Drawing.Point(5, 370);
            this.lRotStatus.Name = "lRotStatus";
            this.lRotStatus.Size = new System.Drawing.Size(113, 25);
            this.lRotStatus.TabIndex = 5;
            this.lRotStatus.Text = "Připraven";
            // 
            // tcControl
            // 
            this.tcControl.Controls.Add(this.tabPageSettings);
            this.tcControl.Controls.Add(this.tabPageControl);
            this.tcControl.Controls.Add(this.tabPageAddDevice);
            this.tcControl.Controls.Add(this.tabPageLog);
            this.tcControl.Location = new System.Drawing.Point(0, 0);
            this.tcControl.Name = "tcControl";
            this.tcControl.SelectedIndex = 0;
            this.tcControl.Size = new System.Drawing.Size(340, 358);
            this.tcControl.TabIndex = 0;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.motorDependances1);
            this.tabPageSettings.Controls.Add(this.gbDeviceManagement);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(332, 332);
            this.tabPageSettings.TabIndex = 3;
            this.tabPageSettings.Text = "Nastavení";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // motorDependances1
            // 
            this.motorDependances1.Location = new System.Drawing.Point(0, 131);
            this.motorDependances1.Name = "motorDependances1";
            this.motorDependances1.Size = new System.Drawing.Size(332, 118);
            this.motorDependances1.TabIndex = 10;
            // 
            // gbDeviceManagement
            // 
            this.gbDeviceManagement.Controls.Add(this.btDisconnectDevice);
            this.gbDeviceManagement.Controls.Add(this.btConnectDevice);
            this.gbDeviceManagement.Controls.Add(this.btFindDevice);
            this.gbDeviceManagement.Controls.Add(this.lbDevice);
            this.gbDeviceManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbDeviceManagement.Location = new System.Drawing.Point(0, 3);
            this.gbDeviceManagement.Name = "gbDeviceManagement";
            this.gbDeviceManagement.Size = new System.Drawing.Size(332, 122);
            this.gbDeviceManagement.TabIndex = 9;
            this.gbDeviceManagement.TabStop = false;
            this.gbDeviceManagement.Text = "Vybrat zařízení pro komunikaci";
            // 
            // btDisconnectDevice
            // 
            this.btDisconnectDevice.Enabled = false;
            this.btDisconnectDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btDisconnectDevice.Location = new System.Drawing.Point(228, 84);
            this.btDisconnectDevice.Name = "btDisconnectDevice";
            this.btDisconnectDevice.Size = new System.Drawing.Size(75, 23);
            this.btDisconnectDevice.TabIndex = 4;
            this.btDisconnectDevice.Text = "Odpojit";
            this.btDisconnectDevice.UseVisualStyleBackColor = true;
            this.btDisconnectDevice.Click += new System.EventHandler(this.btDisconnectDevice_Click);
            // 
            // btConnectDevice
            // 
            this.btConnectDevice.Enabled = false;
            this.btConnectDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btConnectDevice.Location = new System.Drawing.Point(228, 55);
            this.btConnectDevice.Name = "btConnectDevice";
            this.btConnectDevice.Size = new System.Drawing.Size(75, 23);
            this.btConnectDevice.TabIndex = 3;
            this.btConnectDevice.Text = "Připojit";
            this.btConnectDevice.UseVisualStyleBackColor = true;
            this.btConnectDevice.Click += new System.EventHandler(this.btConnectDevice_Click);
            // 
            // btFindDevice
            // 
            this.btFindDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btFindDevice.Location = new System.Drawing.Point(228, 26);
            this.btFindDevice.Name = "btFindDevice";
            this.btFindDevice.Size = new System.Drawing.Size(75, 23);
            this.btFindDevice.TabIndex = 2;
            this.btFindDevice.Text = "Najít";
            this.btFindDevice.UseVisualStyleBackColor = true;
            this.btFindDevice.Click += new System.EventHandler(this.btFindDevice_Click);
            // 
            // lbDevice
            // 
            this.lbDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbDevice.FormattingEnabled = true;
            this.lbDevice.Location = new System.Drawing.Point(6, 21);
            this.lbDevice.Name = "lbDevice";
            this.lbDevice.Size = new System.Drawing.Size(190, 82);
            this.lbDevice.TabIndex = 1;
            // 
            // tabPageControl
            // 
            this.tabPageControl.Controls.Add(this.motorControl4);
            this.tabPageControl.Controls.Add(this.motorControl3);
            this.tabPageControl.Controls.Add(this.motorControl2);
            this.tabPageControl.Controls.Add(this.motorControl1);
            this.tabPageControl.Location = new System.Drawing.Point(4, 22);
            this.tabPageControl.Name = "tabPageControl";
            this.tabPageControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageControl.Size = new System.Drawing.Size(332, 332);
            this.tabPageControl.TabIndex = 0;
            this.tabPageControl.Text = "Ovládání";
            this.tabPageControl.UseVisualStyleBackColor = true;
            // 
            // motorControl4
            // 
            this.motorControl4.Enabled = false;
            this.motorControl4.Location = new System.Drawing.Point(0, 235);
            this.motorControl4.Name = "motorControl4";
            this.motorControl4.Size = new System.Drawing.Size(332, 70);
            this.motorControl4.TabIndex = 4;
            // 
            // motorControl3
            // 
            this.motorControl3.Enabled = false;
            this.motorControl3.Location = new System.Drawing.Point(0, 159);
            this.motorControl3.Name = "motorControl3";
            this.motorControl3.Size = new System.Drawing.Size(332, 70);
            this.motorControl3.TabIndex = 3;
            // 
            // motorControl2
            // 
            this.motorControl2.Enabled = false;
            this.motorControl2.Location = new System.Drawing.Point(0, 83);
            this.motorControl2.Name = "motorControl2";
            this.motorControl2.Size = new System.Drawing.Size(332, 70);
            this.motorControl2.TabIndex = 2;
            // 
            // motorControl1
            // 
            this.motorControl1.Enabled = false;
            this.motorControl1.Location = new System.Drawing.Point(0, 7);
            this.motorControl1.Name = "motorControl1";
            this.motorControl1.Size = new System.Drawing.Size(332, 70);
            this.motorControl1.TabIndex = 1;
            // 
            // tabPageAddDevice
            // 
            this.tabPageAddDevice.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddDevice.Name = "tabPageAddDevice";
            this.tabPageAddDevice.Size = new System.Drawing.Size(332, 332);
            this.tabPageAddDevice.TabIndex = 4;
            this.tabPageAddDevice.Text = "Přidat zařízení";
            this.tabPageAddDevice.UseVisualStyleBackColor = true;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.btLogClear);
            this.tabPageLog.Controls.Add(this.lbLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Size = new System.Drawing.Size(332, 332);
            this.tabPageLog.TabIndex = 2;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            this.tabPageLog.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPageLog_Paint);
            // 
            // btLogClear
            // 
            this.btLogClear.Location = new System.Drawing.Point(249, 299);
            this.btLogClear.Name = "btLogClear";
            this.btLogClear.Size = new System.Drawing.Size(75, 23);
            this.btLogClear.TabIndex = 1;
            this.btLogClear.Text = "Vymazat";
            this.btLogClear.UseVisualStyleBackColor = true;
            this.btLogClear.Click += new System.EventHandler(this.btLogClear_Click);
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(3, 3);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(326, 290);
            this.lbLog.TabIndex = 0;
            // 
            // btStop
            // 
            this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStop.BackColor = System.Drawing.Color.Red;
            this.btStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btStop.Location = new System.Drawing.Point(136, 366);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(90, 40);
            this.btStop.TabIndex = 0;
            this.btStop.Text = "STOP";
            this.btStop.UseVisualStyleBackColor = false;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btReset
            // 
            this.btReset.BackColor = System.Drawing.Color.Lime;
            this.btReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btReset.Location = new System.Drawing.Point(238, 366);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(90, 40);
            this.btReset.TabIndex = 9;
            this.btReset.Text = "RESET";
            this.btReset.UseVisualStyleBackColor = false;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // panelSignals
            // 
            this.panelSignals.AutoScroll = true;
            this.panelSignals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelSignals.Location = new System.Drawing.Point(0, 294);
            this.panelSignals.Name = "panelSignals";
            this.panelSignals.Size = new System.Drawing.Size(544, 134);
            this.panelSignals.TabIndex = 4;
            // 
            // FormKM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 455);
            this.Controls.Add(this.panelSignals);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panelVizualization);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 480);
            this.Name = "FormKM";
            this.Text = "Krokové motory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormKM_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelVizualization.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.tcControl.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.gbDeviceManagement.ResumeLayout(false);
            this.tabPageControl.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slInfo;
        private System.Windows.Forms.Panel panelVizualization;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel panelSignals;
        private System.Windows.Forms.TabControl tcControl;
        private System.Windows.Forms.TabPage tabPageControl;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btLogClear;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.Button btDisconnectDevice;
        private System.Windows.Forms.Button btConnectDevice;
        private System.Windows.Forms.Button btFindDevice;
        private System.Windows.Forms.ListBox lbDevice;
        private MotorControl.MotorControl motorControl4;
        private MotorControl.MotorControl motorControl3;
        private MotorControl.MotorControl motorControl2;
        private MotorControl.MotorControl motorControl1;
        private System.Windows.Forms.Label lRotStatus;
        private System.Windows.Forms.Button btReset;
        private MotorVisualization.MotorVisualization motorVisualization4;
        private MotorVisualization.MotorVisualization motorVisualization3;
        private MotorVisualization.MotorVisualization motorVisualization2;
        private MotorVisualization.MotorVisualization motorVisualization1;
        private System.Windows.Forms.GroupBox gbDeviceManagement;
        private MotorDependences.MotorDependences motorDependances1;
        private System.Windows.Forms.TabPage tabPageAddDevice;
    }
}

