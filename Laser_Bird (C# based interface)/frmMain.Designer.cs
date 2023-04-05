namespace LaserBird
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.chkAutoMode = new System.Windows.Forms.CheckBox();
            this.btnStopReading = new System.Windows.Forms.Button();
            this.txtSerialInputeHex = new System.Windows.Forms.TextBox();
            this.txtSerialInput = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblTilt = new System.Windows.Forms.Label();
            this.lblPan = new System.Windows.Forms.Label();
            this.lable2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLaserOn = new System.Windows.Forms.CheckBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClosePort = new System.Windows.Forms.Button();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.numRandomTiltEndAngle = new System.Windows.Forms.NumericUpDown();
            this.numRandomTiltStartAngle = new System.Windows.Forms.NumericUpDown();
            this.numRandomPanEndAngle = new System.Windows.Forms.NumericUpDown();
            this.numRandomPanStartAngle = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkRandomTilt = new System.Windows.Forms.CheckBox();
            this.chkRandomPan = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWaitPreset = new System.Windows.Forms.ComboBox();
            this.lblPresetWarning = new System.Windows.Forms.Label();
            this.btnLoadPresets = new System.Windows.Forms.Button();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearPresets = new System.Windows.Forms.Button();
            this.btnRemovePreset = new System.Windows.Forms.Button();
            this.btnAddPreset = new System.Windows.Forms.Button();
            this.lblErrors = new System.Windows.Forms.Label();
            this.lstPresets = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timerAutomode = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomTiltEndAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomTiltStartAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomPanEndAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomPanStartAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.splitContainer3.Panel1.Controls.Add(this.chkAutoMode);
            this.splitContainer3.Panel1.Controls.Add(this.btnStopReading);
            this.splitContainer3.Panel1.Controls.Add(this.txtSerialInputeHex);
            this.splitContainer3.Panel1.Controls.Add(this.txtSerialInput);
            this.splitContainer3.Panel1.Controls.Add(this.pictureBox5);
            this.splitContainer3.Panel1.Controls.Add(this.lblTilt);
            this.splitContainer3.Panel1.Controls.Add(this.lblPan);
            this.splitContainer3.Panel1.Controls.Add(this.lable2);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer3.Panel2.Controls.Add(this.chkLaserOn);
            this.splitContainer3.Panel2.Controls.Add(this.btnUp);
            this.splitContainer3.Panel2.Controls.Add(this.btnDown);
            this.splitContainer3.Panel2.Controls.Add(this.btnLeft);
            this.splitContainer3.Panel2.Controls.Add(this.btnRight);
            // 
            // chkAutoMode
            // 
            resources.ApplyResources(this.chkAutoMode, "chkAutoMode");
            this.chkAutoMode.Checked = true;
            this.chkAutoMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoMode.FlatAppearance.BorderSize = 3;
            this.chkAutoMode.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.chkAutoMode.ForeColor = System.Drawing.Color.White;
            this.chkAutoMode.Name = "chkAutoMode";
            this.chkAutoMode.UseVisualStyleBackColor = false;
            this.chkAutoMode.Click += new System.EventHandler(this.chkAutoMode_Click);
            // 
            // btnStopReading
            // 
            resources.ApplyResources(this.btnStopReading, "btnStopReading");
            this.btnStopReading.Name = "btnStopReading";
            this.btnStopReading.UseVisualStyleBackColor = true;
            this.btnStopReading.Click += new System.EventHandler(this.btnStopReading_Click);
            // 
            // txtSerialInputeHex
            // 
            resources.ApplyResources(this.txtSerialInputeHex, "txtSerialInputeHex");
            this.txtSerialInputeHex.Name = "txtSerialInputeHex";
            // 
            // txtSerialInput
            // 
            resources.ApplyResources(this.txtSerialInput, "txtSerialInput");
            this.txtSerialInput.Name = "txtSerialInput";
            // 
            // pictureBox5
            // 
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // lblTilt
            // 
            resources.ApplyResources(this.lblTilt, "lblTilt");
            this.lblTilt.ForeColor = System.Drawing.Color.White;
            this.lblTilt.Name = "lblTilt";
            // 
            // lblPan
            // 
            resources.ApplyResources(this.lblPan, "lblPan");
            this.lblPan.ForeColor = System.Drawing.Color.White;
            this.lblPan.Name = "lblPan";
            // 
            // lable2
            // 
            resources.ApplyResources(this.lable2, "lable2");
            this.lable2.BackColor = System.Drawing.Color.Transparent;
            this.lable2.ForeColor = System.Drawing.Color.White;
            this.lable2.Name = "lable2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // chkLaserOn
            // 
            resources.ApplyResources(this.chkLaserOn, "chkLaserOn");
            this.chkLaserOn.BackColor = System.Drawing.Color.Black;
            this.chkLaserOn.FlatAppearance.BorderSize = 3;
            this.chkLaserOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.chkLaserOn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.chkLaserOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.chkLaserOn.ForeColor = System.Drawing.Color.White;
            this.chkLaserOn.Name = "chkLaserOn";
            this.chkLaserOn.UseVisualStyleBackColor = false;
            this.chkLaserOn.Click += new System.EventHandler(this.chkLaserOn_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.btnUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(184)))), ((int)(((byte)(180)))));
            this.btnUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnUp.Name = "btnUp";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseUp);
            // 
            // btnDown
            // 
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.btnDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(184)))), ((int)(((byte)(180)))));
            this.btnDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnDown.Name = "btnDown";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            this.btnDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseUp);
            // 
            // btnLeft
            // 
            resources.ApplyResources(this.btnLeft, "btnLeft");
            this.btnLeft.FlatAppearance.BorderSize = 0;
            this.btnLeft.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.btnLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(184)))), ((int)(((byte)(180)))));
            this.btnLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseUp);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnRight, "btnRight");
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.btnRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(184)))), ((int)(((byte)(180)))));
            this.btnRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnRight.Name = "btnRight";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseUp);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblErrors);
            this.splitContainer2.Panel2.Controls.Add(this.lstPresets);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClosePort);
            this.panel1.Controls.Add(this.cmbPorts);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnClosePort
            // 
            resources.ApplyResources(this.btnClosePort, "btnClosePort");
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.UseVisualStyleBackColor = true;
            this.btnClosePort.Click += new System.EventHandler(this.btnClosePort_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.cmbPorts, "cmbPorts");
            this.cmbPorts.ForeColor = System.Drawing.Color.White;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.SelectedIndexChanged += new System.EventHandler(this.cmbPorts_SelectedIndexChanged);
            // 
            // splitContainer4
            // 
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.numRandomTiltEndAngle);
            this.splitContainer4.Panel1.Controls.Add(this.numRandomTiltStartAngle);
            this.splitContainer4.Panel1.Controls.Add(this.numRandomPanEndAngle);
            this.splitContainer4.Panel1.Controls.Add(this.numRandomPanStartAngle);
            this.splitContainer4.Panel1.Controls.Add(this.label8);
            this.splitContainer4.Panel1.Controls.Add(this.label7);
            this.splitContainer4.Panel1.Controls.Add(this.label6);
            this.splitContainer4.Panel1.Controls.Add(this.label5);
            this.splitContainer4.Panel1.Controls.Add(this.chkRandomTilt);
            this.splitContainer4.Panel1.Controls.Add(this.chkRandomPan);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            this.splitContainer4.Panel1.Controls.Add(this.label2);
            this.splitContainer4.Panel1.Controls.Add(this.cmbWaitPreset);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.lblPresetWarning);
            this.splitContainer4.Panel2.Controls.Add(this.btnLoadPresets);
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Panel2.Controls.Add(this.btnRemovePreset);
            this.splitContainer4.Panel2.Controls.Add(this.btnAddPreset);
            // 
            // numRandomTiltEndAngle
            // 
            this.numRandomTiltEndAngle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numRandomTiltEndAngle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numRandomTiltEndAngle.DecimalPlaces = 1;
            resources.ApplyResources(this.numRandomTiltEndAngle, "numRandomTiltEndAngle");
            this.numRandomTiltEndAngle.ForeColor = System.Drawing.Color.White;
            this.numRandomTiltEndAngle.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numRandomTiltEndAngle.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numRandomTiltEndAngle.Minimum = new decimal(new int[] {
            19,
            0,
            0,
            -2147483648});
            this.numRandomTiltEndAngle.Name = "numRandomTiltEndAngle";
            this.numRandomTiltEndAngle.ReadOnly = true;
            this.numRandomTiltEndAngle.Value = new decimal(new int[] {
            19,
            0,
            0,
            -2147483648});
            this.numRandomTiltEndAngle.ValueChanged += new System.EventHandler(this.numRandomTiltEndAngle_ValueChanged);
            // 
            // numRandomTiltStartAngle
            // 
            this.numRandomTiltStartAngle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numRandomTiltStartAngle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numRandomTiltStartAngle.DecimalPlaces = 1;
            resources.ApplyResources(this.numRandomTiltStartAngle, "numRandomTiltStartAngle");
            this.numRandomTiltStartAngle.ForeColor = System.Drawing.Color.White;
            this.numRandomTiltStartAngle.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numRandomTiltStartAngle.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numRandomTiltStartAngle.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.numRandomTiltStartAngle.Name = "numRandomTiltStartAngle";
            this.numRandomTiltStartAngle.ReadOnly = true;
            this.numRandomTiltStartAngle.Value = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.numRandomTiltStartAngle.ValueChanged += new System.EventHandler(this.numRandomTiltStartAngle_ValueChanged);
            // 
            // numRandomPanEndAngle
            // 
            this.numRandomPanEndAngle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numRandomPanEndAngle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numRandomPanEndAngle.DecimalPlaces = 1;
            resources.ApplyResources(this.numRandomPanEndAngle, "numRandomPanEndAngle");
            this.numRandomPanEndAngle.ForeColor = System.Drawing.Color.White;
            this.numRandomPanEndAngle.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numRandomPanEndAngle.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numRandomPanEndAngle.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRandomPanEndAngle.Name = "numRandomPanEndAngle";
            this.numRandomPanEndAngle.ReadOnly = true;
            this.numRandomPanEndAngle.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRandomPanEndAngle.ValueChanged += new System.EventHandler(this.numRandomPanEndAngle_ValueChanged);
            // 
            // numRandomPanStartAngle
            // 
            this.numRandomPanStartAngle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.numRandomPanStartAngle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numRandomPanStartAngle.DecimalPlaces = 1;
            resources.ApplyResources(this.numRandomPanStartAngle, "numRandomPanStartAngle");
            this.numRandomPanStartAngle.ForeColor = System.Drawing.Color.White;
            this.numRandomPanStartAngle.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numRandomPanStartAngle.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numRandomPanStartAngle.Name = "numRandomPanStartAngle";
            this.numRandomPanStartAngle.ReadOnly = true;
            this.numRandomPanStartAngle.ValueChanged += new System.EventHandler(this.numRandomPanStartAngle_ValueChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // chkRandomTilt
            // 
            resources.ApplyResources(this.chkRandomTilt, "chkRandomTilt");
            this.chkRandomTilt.FlatAppearance.BorderSize = 3;
            this.chkRandomTilt.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.chkRandomTilt.ForeColor = System.Drawing.Color.White;
            this.chkRandomTilt.Name = "chkRandomTilt";
            this.chkRandomTilt.UseVisualStyleBackColor = false;
            // 
            // chkRandomPan
            // 
            resources.ApplyResources(this.chkRandomPan, "chkRandomPan");
            this.chkRandomPan.FlatAppearance.BorderSize = 3;
            this.chkRandomPan.FlatAppearance.CheckedBackColor = System.Drawing.Color.DodgerBlue;
            this.chkRandomPan.ForeColor = System.Drawing.Color.White;
            this.chkRandomPan.Name = "chkRandomPan";
            this.chkRandomPan.UseVisualStyleBackColor = false;
            this.chkRandomPan.CheckedChanged += new System.EventHandler(this.chkRandomPan_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // cmbWaitPreset
            // 
            this.cmbWaitPreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbWaitPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbWaitPreset, "cmbWaitPreset");
            this.cmbWaitPreset.ForeColor = System.Drawing.Color.White;
            this.cmbWaitPreset.FormatString = "N0";
            this.cmbWaitPreset.FormattingEnabled = true;
            this.cmbWaitPreset.Items.AddRange(new object[] {
            resources.GetString("cmbWaitPreset.Items"),
            resources.GetString("cmbWaitPreset.Items1"),
            resources.GetString("cmbWaitPreset.Items2"),
            resources.GetString("cmbWaitPreset.Items3"),
            resources.GetString("cmbWaitPreset.Items4"),
            resources.GetString("cmbWaitPreset.Items5")});
            this.cmbWaitPreset.Name = "cmbWaitPreset";
            // 
            // lblPresetWarning
            // 
            resources.ApplyResources(this.lblPresetWarning, "lblPresetWarning");
            this.lblPresetWarning.BackColor = System.Drawing.Color.Red;
            this.lblPresetWarning.ForeColor = System.Drawing.Color.White;
            this.lblPresetWarning.Name = "lblPresetWarning";
            // 
            // btnLoadPresets
            // 
            this.btnLoadPresets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLoadPresets.FlatAppearance.BorderSize = 3;
            resources.ApplyResources(this.btnLoadPresets, "btnLoadPresets");
            this.btnLoadPresets.ForeColor = System.Drawing.Color.White;
            this.btnLoadPresets.Name = "btnLoadPresets";
            this.btnLoadPresets.UseVisualStyleBackColor = false;
            this.btnLoadPresets.Click += new System.EventHandler(this.btnLoadPresets_Click);
            // 
            // splitContainer5
            // 
            resources.ApplyResources(this.splitContainer5, "splitContainer5");
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.btnSave);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.btnClearPresets);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(184)))), ((int)(((byte)(180)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnSave.Name = "btnSave";
            this.toolTip1.SetToolTip(this.btnSave, resources.GetString("btnSave.ToolTip"));
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearPresets
            // 
            this.btnClearPresets.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnClearPresets, "btnClearPresets");
            this.btnClearPresets.FlatAppearance.BorderSize = 0;
            this.btnClearPresets.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(88)))), ((int)(((byte)(131)))));
            this.btnClearPresets.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnClearPresets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(88)))), ((int)(((byte)(131)))));
            this.btnClearPresets.Name = "btnClearPresets";
            this.toolTip1.SetToolTip(this.btnClearPresets, resources.GetString("btnClearPresets.ToolTip"));
            this.btnClearPresets.UseVisualStyleBackColor = false;
            this.btnClearPresets.Click += new System.EventHandler(this.btnClearPresets_Click);
            // 
            // btnRemovePreset
            // 
            this.btnRemovePreset.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnRemovePreset, "btnRemovePreset");
            this.btnRemovePreset.FlatAppearance.BorderSize = 0;
            this.btnRemovePreset.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(88)))), ((int)(((byte)(131)))));
            this.btnRemovePreset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnRemovePreset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(88)))), ((int)(((byte)(131)))));
            this.btnRemovePreset.Name = "btnRemovePreset";
            this.toolTip1.SetToolTip(this.btnRemovePreset, resources.GetString("btnRemovePreset.ToolTip"));
            this.btnRemovePreset.UseVisualStyleBackColor = false;
            this.btnRemovePreset.Click += new System.EventHandler(this.btnRemovePreset_Click);
            // 
            // btnAddPreset
            // 
            this.btnAddPreset.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnAddPreset, "btnAddPreset");
            this.btnAddPreset.FlatAppearance.BorderSize = 0;
            this.btnAddPreset.FlatAppearance.CheckedBackColor = System.Drawing.Color.Teal;
            this.btnAddPreset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(184)))), ((int)(((byte)(180)))));
            this.btnAddPreset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnAddPreset.Name = "btnAddPreset";
            this.toolTip1.SetToolTip(this.btnAddPreset, resources.GetString("btnAddPreset.ToolTip"));
            this.btnAddPreset.UseVisualStyleBackColor = false;
            this.btnAddPreset.Click += new System.EventHandler(this.btnAddPreset_Click);
            // 
            // lblErrors
            // 
            resources.ApplyResources(this.lblErrors, "lblErrors");
            this.lblErrors.BackColor = System.Drawing.Color.Red;
            this.lblErrors.ForeColor = System.Drawing.Color.White;
            this.lblErrors.Name = "lblErrors";
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
            resources.ApplyResources(this.lstPresets, "lstPresets");
            this.lstPresets.ForeColor = System.Drawing.Color.Black;
            this.lstPresets.FullRowSelect = true;
            this.lstPresets.GridLines = true;
            this.lstPresets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstPresets.HoverSelection = true;
            this.lstPresets.MultiSelect = false;
            this.lstPresets.Name = "lstPresets";
            this.lstPresets.UseCompatibleStateImageBehavior = false;
            this.lstPresets.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM5";
            this.serialPort.ReadBufferSize = 10240;
            this.serialPort.ReceivedBytesThreshold = 14;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // timerAutomode
            // 
            this.timerAutomode.Interval = 500;
            this.timerAutomode.Tick += new System.EventHandler(this.timerAutomode_Tick);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numRandomTiltEndAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomTiltStartAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomPanEndAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRandomPanStartAngle)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView lstPresets;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblTilt;
        private System.Windows.Forms.Label lblPan;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label lblPresetWarning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWaitPreset;
        private System.Windows.Forms.Button btnRemovePreset;
        private System.Windows.Forms.Button btnAddPreset;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearPresets;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnStopReading;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.CheckBox chkLaserOn;
        private System.Windows.Forms.CheckBox chkRandomTilt;
        private System.Windows.Forms.CheckBox chkRandomPan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numRandomPanStartAngle;
        private System.Windows.Forms.NumericUpDown numRandomTiltEndAngle;
        private System.Windows.Forms.NumericUpDown numRandomTiltStartAngle;
        private System.Windows.Forms.NumericUpDown numRandomPanEndAngle;
        private System.Windows.Forms.Button btnLoadPresets;
        private System.Windows.Forms.Button btnClosePort;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.Timer timerAutomode;
        private System.Windows.Forms.CheckBox chkAutoMode;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.TextBox txtSerialInputeHex;
        private System.Windows.Forms.TextBox txtSerialInput;
    }
}