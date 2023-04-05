namespace LaserBird
{
    partial class LaserBird
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
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.chkAutoMode = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lable2 = new System.Windows.Forms.Label();
            this.lblTilt = new System.Windows.Forms.Label();
            this.lblPan = new System.Windows.Forms.Label();
            this.txtSerialInput = new System.Windows.Forms.TextBox();
            this.txtSerialInputeHex = new System.Windows.Forms.TextBox();
            this.btnStopReading = new System.Windows.Forms.Button();
            this.lstPresets = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddPreset = new System.Windows.Forms.Button();
            this.btnRemovePreset = new System.Windows.Forms.Button();
            this.lblPresetWarning = new System.Windows.Forms.Label();
            this.chkLaserOn = new System.Windows.Forms.CheckBox();
            this.cmbWaitPreset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoadPresets = new System.Windows.Forms.Button();
            this.btnClearPresets = new System.Windows.Forms.Button();
            this.btnClosePort = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM3";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(374, 92);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 0;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseUp);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(299, 92);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseUp);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(344, 121);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(344, 63);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // chkAutoMode
            // 
            this.chkAutoMode.AutoSize = true;
            this.chkAutoMode.Location = new System.Drawing.Point(603, 12);
            this.chkAutoMode.Name = "chkAutoMode";
            this.chkAutoMode.Size = new System.Drawing.Size(75, 17);
            this.chkAutoMode.TabIndex = 6;
            this.chkAutoMode.Text = "AutoMode";
            this.chkAutoMode.UseVisualStyleBackColor = true;
            this.chkAutoMode.CheckedChanged += new System.EventHandler(this.chkAutoMode_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Horizental:";
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.BackColor = System.Drawing.Color.White;
            this.lable2.Location = new System.Drawing.Point(12, 36);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(45, 13);
            this.lable2.TabIndex = 9;
            this.lable2.Text = "Vertical:";
            // 
            // lblTilt
            // 
            this.lblTilt.AutoSize = true;
            this.lblTilt.Location = new System.Drawing.Point(62, 36);
            this.lblTilt.Name = "lblTilt";
            this.lblTilt.Size = new System.Drawing.Size(13, 13);
            this.lblTilt.TabIndex = 11;
            this.lblTilt.Text = "0";
            // 
            // lblPan
            // 
            this.lblPan.AutoSize = true;
            this.lblPan.Location = new System.Drawing.Point(62, 9);
            this.lblPan.Name = "lblPan";
            this.lblPan.Size = new System.Drawing.Size(13, 13);
            this.lblPan.TabIndex = 10;
            this.lblPan.Text = "0";
            // 
            // txtSerialInput
            // 
            this.txtSerialInput.Location = new System.Drawing.Point(15, 63);
            this.txtSerialInput.Multiline = true;
            this.txtSerialInput.Name = "txtSerialInput";
            this.txtSerialInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSerialInput.Size = new System.Drawing.Size(278, 284);
            this.txtSerialInput.TabIndex = 12;
            // 
            // txtSerialInputeHex
            // 
            this.txtSerialInputeHex.Location = new System.Drawing.Point(10, 371);
            this.txtSerialInputeHex.Multiline = true;
            this.txtSerialInputeHex.Name = "txtSerialInputeHex";
            this.txtSerialInputeHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSerialInputeHex.Size = new System.Drawing.Size(283, 284);
            this.txtSerialInputeHex.TabIndex = 13;
            // 
            // btnStopReading
            // 
            this.btnStopReading.Location = new System.Drawing.Point(299, 192);
            this.btnStopReading.Name = "btnStopReading";
            this.btnStopReading.Size = new System.Drawing.Size(75, 23);
            this.btnStopReading.TabIndex = 14;
            this.btnStopReading.Text = "Stop/Start";
            this.btnStopReading.UseVisualStyleBackColor = true;
            this.btnStopReading.Click += new System.EventHandler(this.btnStopReading_Click);
            // 
            // lstPresets
            // 
            this.lstPresets.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstPresets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lstPresets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPresets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader4});
            this.lstPresets.ForeColor = System.Drawing.Color.Black;
            this.lstPresets.FullRowSelect = true;
            this.lstPresets.GridLines = true;
            this.lstPresets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstPresets.HoverSelection = true;
            this.lstPresets.Location = new System.Drawing.Point(491, 82);
            this.lstPresets.Name = "lstPresets";
            this.lstPresets.Size = new System.Drawing.Size(425, 306);
            this.lstPresets.TabIndex = 15;
            this.lstPresets.UseCompatibleStateImageBehavior = false;
            this.lstPresets.View = System.Windows.Forms.View.Details;
            this.lstPresets.SelectedIndexChanged += new System.EventHandler(this.lstPresets_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Row";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pan";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tilt";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Laser";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Wait (Second)";
            this.columnHeader4.Width = 100;
            // 
            // btnAddPreset
            // 
            this.btnAddPreset.Location = new System.Drawing.Point(455, 53);
            this.btnAddPreset.Name = "btnAddPreset";
            this.btnAddPreset.Size = new System.Drawing.Size(43, 23);
            this.btnAddPreset.TabIndex = 16;
            this.btnAddPreset.Text = "+";
            this.btnAddPreset.UseVisualStyleBackColor = true;
            this.btnAddPreset.Click += new System.EventHandler(this.btnAddPreset_Click);
            // 
            // btnRemovePreset
            // 
            this.btnRemovePreset.Location = new System.Drawing.Point(504, 53);
            this.btnRemovePreset.Name = "btnRemovePreset";
            this.btnRemovePreset.Size = new System.Drawing.Size(43, 23);
            this.btnRemovePreset.TabIndex = 17;
            this.btnRemovePreset.Text = "-";
            this.btnRemovePreset.UseVisualStyleBackColor = true;
            this.btnRemovePreset.Click += new System.EventHandler(this.btnRemovePreset_Click);
            // 
            // lblPresetWarning
            // 
            this.lblPresetWarning.AutoSize = true;
            this.lblPresetWarning.BackColor = System.Drawing.Color.Red;
            this.lblPresetWarning.ForeColor = System.Drawing.Color.White;
            this.lblPresetWarning.Location = new System.Drawing.Point(564, 58);
            this.lblPresetWarning.Name = "lblPresetWarning";
            this.lblPresetWarning.Size = new System.Drawing.Size(124, 13);
            this.lblPresetWarning.TabIndex = 18;
            this.lblPresetWarning.Text = "Reach Maximum Presets";
            this.lblPresetWarning.Visible = false;
            // 
            // chkLaserOn
            // 
            this.chkLaserOn.AutoSize = true;
            this.chkLaserOn.Location = new System.Drawing.Point(514, 8);
            this.chkLaserOn.Name = "chkLaserOn";
            this.chkLaserOn.Size = new System.Drawing.Size(69, 17);
            this.chkLaserOn.TabIndex = 19;
            this.chkLaserOn.Text = "Laser On";
            this.chkLaserOn.UseVisualStyleBackColor = true;
            // 
            // cmbWaitPreset
            // 
            this.cmbWaitPreset.FormattingEnabled = true;
            this.cmbWaitPreset.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbWaitPreset.Location = new System.Drawing.Point(313, 28);
            this.cmbWaitPreset.Name = "cmbWaitPreset";
            this.cmbWaitPreset.Size = new System.Drawing.Size(46, 21);
            this.cmbWaitPreset.TabIndex = 20;
            this.cmbWaitPreset.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Wait:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Second";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(455, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(201, 40);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save Presets";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoadPresets
            // 
            this.btnLoadPresets.Location = new System.Drawing.Point(665, 407);
            this.btnLoadPresets.Name = "btnLoadPresets";
            this.btnLoadPresets.Size = new System.Drawing.Size(201, 40);
            this.btnLoadPresets.TabIndex = 24;
            this.btnLoadPresets.Text = "Load Presets";
            this.btnLoadPresets.UseVisualStyleBackColor = true;
            this.btnLoadPresets.Click += new System.EventHandler(this.btnLoadPresets_Click);
            // 
            // btnClearPresets
            // 
            this.btnClearPresets.Location = new System.Drawing.Point(455, 453);
            this.btnClearPresets.Name = "btnClearPresets";
            this.btnClearPresets.Size = new System.Drawing.Size(201, 40);
            this.btnClearPresets.TabIndex = 25;
            this.btnClearPresets.Text = "Clear Presets";
            this.btnClearPresets.UseVisualStyleBackColor = true;
            this.btnClearPresets.Click += new System.EventHandler(this.btnClearPresets_Click);
            // 
            // btnClosePort
            // 
            this.btnClosePort.Location = new System.Drawing.Point(299, 324);
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.Size = new System.Drawing.Size(75, 23);
            this.btnClosePort.TabIndex = 26;
            this.btnClosePort.Text = "Close Port";
            this.btnClosePort.UseVisualStyleBackColor = true;
            this.btnClosePort.Click += new System.EventHandler(this.btnClosePort_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(2, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(925, 73);
            this.label4.TabIndex = 27;
            this.label4.Text = "LASER BIRD is not connected";
            this.label4.Visible = false;
            // 
            // LaserBird
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(928, 749);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClosePort);
            this.Controls.Add(this.btnClearPresets);
            this.Controls.Add(this.btnLoadPresets);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWaitPreset);
            this.Controls.Add(this.chkLaserOn);
            this.Controls.Add(this.lblPresetWarning);
            this.Controls.Add(this.btnRemovePreset);
            this.Controls.Add(this.btnAddPreset);
            this.Controls.Add(this.lstPresets);
            this.Controls.Add(this.btnStopReading);
            this.Controls.Add(this.txtSerialInputeHex);
            this.Controls.Add(this.txtSerialInput);
            this.Controls.Add(this.lblTilt);
            this.Controls.Add(this.lblPan);
            this.Controls.Add(this.lable2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAutoMode);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LaserBird";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LaserBird";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LaserBird_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.CheckBox chkAutoMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.Label lblTilt;
        private System.Windows.Forms.Label lblPan;
        private System.Windows.Forms.TextBox txtSerialInput;
        private System.Windows.Forms.TextBox txtSerialInputeHex;
        private System.Windows.Forms.Button btnStopReading;
        private System.Windows.Forms.ListView lstPresets;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnAddPreset;
        private System.Windows.Forms.Button btnRemovePreset;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblPresetWarning;
        private System.Windows.Forms.CheckBox chkLaserOn;
        private System.Windows.Forms.ComboBox cmbWaitPreset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoadPresets;
        private System.Windows.Forms.Button btnClearPresets;
        private System.Windows.Forms.Button btnClosePort;
        private System.Windows.Forms.Label label4;
    }
}

