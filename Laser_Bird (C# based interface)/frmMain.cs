using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Management;

namespace LaserBird
{

    public partial class frmMain : Form
    {
        byte[] cmdLeft = new byte[] { 0x00 };
        byte[] cmdRight = new byte[] { 0x01 };
        byte[] cmdUp = new byte[] { 0x02 };
        byte[] cmdDown = new byte[] { 0x03 };
        byte[] cmdStop = new byte[] { 0x04 };
        byte[] cmdGetPosition = new byte[] { 0x06, 0x00 };
        byte[] cmdGetPresets = new byte[] { 0x08 };
        byte[] cmdClearPresets = new byte[] { 0x09, 0xFF };
        byte[] cmdAutoMode = new byte[] { 0x0A, 0x00 };
        byte[] cmdReset = new byte[] { 0x0C };

        bool deviceIsResetting = false;
        bool stopReading = false;
        byte presetCounter = 0;
        byte[] tmpBuffer = new byte[0];
        byte[] currentStatusBuffer = new byte[14];
        int currentPanPosition = 0, currentTiltPosition = 0;
        String portName;
        float min_tilt = 40;

        private delegate void DisplayPresetsDelegate(byte[] buffer);
        private delegate void DisplaySerialDataReceivedDelegate(byte[] data);
        private delegate void DisplayPanTiltDelegate(byte[] buffer);
        public frmMain()
        {
            InitializeComponent();
        }

        private Boolean openComPort()
        {

            portName = AutodetectArduinoPort();
            if (!(portName == null || portName == String.Empty))
            {
                serialPort.PortName = portName;
            }
            else if (cmbPorts.Items.Count > 0)
            {
                serialPort.PortName = cmbPorts.Text;
            }
            else return false;

            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                    Thread.Sleep(20);
                   // sendStandardPacket(cmdStop);
                    //sendStandardPacket(cmdAutoMode);
                    Thread.Sleep(10);
                    sendStandardPacket(cmdGetPosition);
                    Thread.Sleep(30);

                    if (!deviceIsResetting)
                    {
                        sendStandardPacket(cmdGetPresets);
                        sendStandardPacket(cmdReset);
                    }

                    btnClosePort.Text = "Close Port";

                    btnClearPresets.Enabled = true;
                    btnDown.Enabled = true;
                    btnUp.Enabled = true;
                    btnLeft.Enabled = true;
                    btnRight.Enabled = true;
                    btnLoadPresets.Enabled = true;
                    btnSave.Enabled = true;
                    chkLaserOn.Enabled = true;
                    chkAutoMode.Enabled = true;

                    int conut = lstPresets.Items.Count;

                    for (int i = 0; i < conut; i++)
                    {
                        lstPresets.Items[0].Remove();
                        presetCounter--;
                    }


                }
                catch (Exception ex)
                {
                    btnClearPresets.Enabled = false;
                    btnDown.Enabled = false;
                    btnUp.Enabled = false;
                    btnLeft.Enabled = false;
                    btnRight.Enabled = false;
                    btnLoadPresets.Enabled = false;
                    btnSave.Enabled = false;
                    chkLaserOn.Enabled = false;
                    chkAutoMode.Enabled = false;
                    lblErrors.Text = ex.Message;
                    lblErrors.Visible = true;
                    btnClosePort.Text = "Open Port";

                    return false;
                }
            }
            return true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            cmbPorts.Items.AddRange(ports);
            if (cmbPorts.Items.Count > 0) cmbPorts.SelectedIndex = 0;
            //timerGetPosition.Enabled = true;

            //add items to ListView

        }

        /*
         Commands:

         Left = 0x00
         Right= 0x01
         Up= 0x02
         Down= 0x03
         Stop= 0x04
         GotoPosition = 0x5 pan(0x0000-2BC) tilt(0x00-8C) wait(0x00-0xFF)
         Get Current Position= 0x6
         Set Preset= 0x7 pan(0x0000-2BC) tilt(0x00-8C) wait(0x00-0xFF) LaserOn/Off(0-1) PresetId(0x00-0xFF)
         get Presets= 0x08
         Clear Preset=0x09 PresetId(0x00-0xFF)
         setAutoMode= 0x0A 0x1/0x0(on/off)
         setLaserOn=0x0B 
         setReset=0x0C 
        ------------------------------------------------------
        Response:
        sendPresets= 0x18 highByte(pan) lowByte(pan) tilt waitTime laserOn
        sendCurrentPosition=  0x016 highByte(currentPanPosition) lowByte(currentPanPosition) currentTiltPosition laserOn
         -------------------------------------------------
         0xFF | CMD | Para1 | Para2 | Para3 | Para4 | SUM
         -------------------------------------------------
      */

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            sendStandardPacket(cmdUp);
            // sendStandardPacket(cmdGetPosition);

        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            sendStop();
            // sendStandardPacket(cmdGetPosition);

            //  timerDisplayPanTilt.Enabled = false;
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            sendStandardPacket(cmdDown);
            //sendStandardPacket(cmdGetPosition);

        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            sendStop();
            //sendStandardPacket(cmdGetPosition);

            // timerDisplayPanTilt.Enabled = false;
        }


        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            sendStandardPacket(cmdRight);
            //sendStandardPacket(cmdGetPosition);

        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            sendStop();
            //sendStandardPacket(cmdGetPosition);

            // timerDisplayPanTilt.Enabled = false;
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            sendStandardPacket(cmdLeft);
            //sendStandardPacket(cmdGetPosition);

        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            sendStop();
            //sendStandardPacket(cmdGetPosition);

            // timerDisplayPanTilt.Enabled = false;
        }

        void sendStop()
        {
            sendStandardPacket(cmdStop);
        }

        private void chkAutoMode_CheckedChanged(object sender, EventArgs e)
        {

        }

        void sendStandardPacket(byte[] cmd)
        {
            byte[] finalCmd = new byte[14];
            finalCmd[0] = 0xFF;
            finalCmd[13] = 0xFF;

            if (!serialPort.IsOpen)
            {
                lblErrors.Text = "LASER BIRD is not connected";
                lblErrors.Visible = true;
            }
            else
            {
                lblErrors.Visible = false;
                for (int i = 0; i < cmd.Length; i++)
                {
                    finalCmd[i + 1] = cmd[i];
                    finalCmd[12] ^= cmd[i];
                }
                try
                {
                    serialPort.Write(finalCmd, 0, finalCmd.Length);
                    //Thread.Sleep(50);
                }
                catch (TimeoutException ex)
                {
                    lblErrors.Text = "LASER BIRD is not connected\n" + ex.Message;
                    lblErrors.Visible = true;
                }
            }

        }

        private void readStandardPacket(byte[] buffer)
        {

            byte chkSum = 0;
            for (int i = 1; i < 12; i++)
            {
                chkSum ^= buffer[i];
            }

            if (chkSum == buffer[12])
            {
                parsResponse(buffer);
            }

        }

        private void btnStopReading_Click(object sender, EventArgs e)
        {
            stopReading = !stopReading;
        }

        private void btnAddPreset_Click(object sender, EventArgs e)
        {
            if ((presetCounter > 0) &&
                (lstPresets.Items[presetCounter - 1].SubItems[1].Text == lblPan.Text) &&
                (lstPresets.Items[presetCounter - 1].SubItems[2].Text == lblTilt.Text) &&
                (lstPresets.Items[presetCounter - 1].SubItems[3].Text == chkLaserOn.Checked.ToString()))
            {
                return;
            }

            string[] arr = new string[5];
            ListViewItem itm;
            //add items to ListView
            if (presetCounter > 99)
            {
                lblPresetWarning.Visible = true;
                return;
            }
            arr[0] = (++presetCounter).ToString();
            if (chkRandomPan.Checked)
            {
                arr[1] = numRandomPanStartAngle.Value + "," + numRandomPanEndAngle.Value;
            }
            else
            {
                arr[1] = lblPan.Text;
            }
            if (chkRandomTilt.Checked)
            {
                arr[2] = numRandomTiltStartAngle.Value + "," + numRandomTiltEndAngle.Value;
            }
            else
            {
                arr[2] = lblTilt.Text;
            }
            arr[3] = chkLaserOn.Checked.ToString();
            arr[4] = cmbWaitPreset.Text=="" ? "0":cmbWaitPreset.Text;
            itm = new ListViewItem(arr);
            lstPresets.Items.Add(itm);
        }

        private void btnRemovePreset_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lstPresets.Items.Count; i++)
            {
                if (lstPresets.Items[i].Selected)
                {
                    lstPresets.Items[i].Remove();
                    i--;
                }
            }
            if (presetCounter != lstPresets.Items.Count)
            {
                presetCounter = 0;
                for (int i = 0; i < lstPresets.Items.Count; i++)
                {
                    lstPresets.Items[i].SubItems[0].Text = (++presetCounter).ToString();
                }
            }

            if (presetCounter < 100)
            {
                lblPresetWarning.Visible = false;
                return;
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            byte[] buffer = new byte[14];
            try
            {
                while (serialPort.BytesToRead > 0)
                {
                    buffer[0] = (byte)serialPort.ReadByte();

                    DisplaySerialDataReceived(buffer);

                    if (buffer[0] == 0xFF && serialPort.BytesToRead > 12)
                    {
                        serialPort.Read(buffer, 1, 13);
                        if (buffer[13] == 0xFF)
                        {
                            //buffer[0] = 0xFF;
                            DisplaySerialDataReceived(buffer);
                            readStandardPacket(buffer);
                        }
                    }
                }
            }
            catch
            {

            }

        }

        /*
                ------------------------------------------------------
        Response:
        sendPresets= 0x18 highByte(pan) lowByte(pan) tilt waitTime laserOn
        sendCurrentPosition=  0x16 highByte(currentPanPosition) lowByte(currentPanPosition) currentTiltPosition laserOn
         -------------------------------------------------
         0xFF | CMD | Para1 | Para2 | Para3 | Para4 | SUM
         -------------------------------------------------
      */

        void parsResponse(byte[] buffer)
        {

            switch (buffer[1])
            {
                case 0x16:
                    DisplayPanTilt(buffer);
                    //timerDisplayPanTilt.Enabled = true;
                    break;
                case 0x18:
                    DisplayPresets(buffer);
                    break;

                default:
                    Debug.WriteLine("No True Message");
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.Red;
            // 0x7 panStart(0x0000 - 2BC) panEnd(0x0000 - 2BC) tiltStart(0x00 - 8C) tiltEnd(0x00 - 8C) LaserOn / Off(0 - 1) wait(0x00 - 0xFF) RandomMode(0-1-2-3) PresetId(0x00 - 0xFF) 
            byte[] cmdSetPreset = new byte[11];
            cmdSetPreset[10] = 0;

            for (int i = 0; i < lstPresets.Items.Count; i++)
            {
                cmdSetPreset[0] = 0x07;
                if (lstPresets.Items[i].SubItems[1].Text.Contains(','))
                {
                    float[] pan = Array.ConvertAll(lstPresets.Items[i].SubItems[1].Text.Split(','), s => float.Parse(s));

                    cmdSetPreset[1] = (byte)((int)(pan[0] * 2) >> 8);
                    cmdSetPreset[2] = (byte)(pan[0] * 2);

                    cmdSetPreset[3] = (byte)((int)(pan[1] * 2) >> 8);
                    cmdSetPreset[4] = (byte)(pan[1] * 2);

                }
                else
                {
                    cmdSetPreset[1] = (byte)((int)((float.Parse(lstPresets.Items[i].SubItems[1].Text)) * 2) >> 8);
                    cmdSetPreset[2] = (byte)((float.Parse(lstPresets.Items[i].SubItems[1].Text)) * 2);
                    cmdSetPreset[3] = 0;
                    cmdSetPreset[4] = 0;
                }


                if (lstPresets.Items[i].SubItems[2].Text.Contains(','))
                {
                    float[] tilt = Array.ConvertAll(lstPresets.Items[i].SubItems[2].Text.Split(','), s => float.Parse(s));
                    cmdSetPreset[5] = (byte) ((int)(tilt[0] * 2) + min_tilt);
                    cmdSetPreset[6] = (byte) ((int)(tilt[1] * 2) + min_tilt);

                }
                else
                {
                    cmdSetPreset[5] = (byte)((int)((float.Parse(lstPresets.Items[i].SubItems[2].Text)*2) + min_tilt));
                    cmdSetPreset[6] = 0;


                }
                cmdSetPreset[7] = (byte)(lstPresets.Items[i].SubItems[3].Text == "True" ? 1 : 0); //Laser on/off

                cmdSetPreset[8] = (byte)short.Parse(lstPresets.Items[i].SubItems[4].Text); // wait time
                cmdSetPreset[10] = (byte)(short.Parse(lstPresets.Items[i].SubItems[0].Text) - 1); //preset ID

                if (lstPresets.Items[i].SubItems[1].Text.Contains(',') && lstPresets.Items[i].SubItems[2].Text.Contains(','))
                {
                    cmdSetPreset[9] = 3;
                }
                else if (lstPresets.Items[i].SubItems[1].Text.Contains(','))
                {
                    cmdSetPreset[9] = 1;
                }
                else if (lstPresets.Items[i].SubItems[2].Text.Contains(','))
                {
                    cmdSetPreset[9] = 2;
                }
                else
                {
                    cmdSetPreset[9] = 0;
                }

                sendStandardPacket(cmdSetPreset);
                Thread.Sleep(100);
            }
            btnSave.BackColor = Color.Transparent;

        }

        private void DisplaySerialDataReceived(byte[] data)
        {
            //Console.Write(BitConverter.ToString(data));
            if (this.InvokeRequired && !stopReading)
            {
                this.Invoke(new DisplaySerialDataReceivedDelegate(DisplaySerialDataReceived), new object[] { data });
            }
            else
            {
                if (!stopReading)
                {
                    txtSerialInput.AppendText(Encoding.Default.GetString(data));
                    txtSerialInput.AppendText("\r\n--------------------\r\n");

                    txtSerialInputeHex.AppendText(BitConverter.ToString(data));
                    txtSerialInputeHex.AppendText("\r\n--------------------\r\n");
                }

            }
        }

        private void btnLoadPresets_Click(object sender, EventArgs e)
        {
            int conut = lstPresets.Items.Count;
            for (int i = 0; i < conut; i++)
            {
                lstPresets.Items[0].Remove();
                presetCounter--;
            }

            sendStandardPacket(cmdGetPresets);
            

        }

        private void btnClearPresets_Click(object sender, EventArgs e)
        {
            int conut = lstPresets.Items.Count;
            for (int i = 0; i < conut; i++)
            {
                lstPresets.Items[0].Remove();
                presetCounter--;
            }
            sendStandardPacket(cmdClearPresets);
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Close();
                btnClosePort.Text = "Open Port";
                lblErrors.Text = "LASER BIRD is not connected";
                lblErrors.Visible = true;

                btnClearPresets.Enabled = false;
                btnDown.Enabled = false;
                btnUp.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                btnLoadPresets.Enabled = false;
                btnSave.Enabled = false;
                chkLaserOn.Enabled = false;
                chkAutoMode.Enabled = false;

            }
            else
            {
                if (openComPort())
                {
                    lblErrors.Visible = false;
                    btnClosePort.Text = "Close Port";
                }
                else
                {
                    btnClosePort.Text = "Open Port";
                    lblErrors.Text = "LASER BIRD is not connected";
                    lblErrors.Visible = true;
                }

            }

        }


        //        sendPresets= 0x18 highByte(pan) lowByte(pan) tilt laserOn waitTime 
        private void DisplayPresets(byte[] buffer)
        {

            if (this.lstPresets.InvokeRequired)
            {
                this.lstPresets.Invoke(new DisplayPresetsDelegate(DisplayPresets), new object[] { buffer });
                Thread.Sleep(50);
            }
            else
            {
                string[] arr = new string[5];
                ListViewItem itm;
                //add items to ListView
                if (presetCounter > 99)
                {
                    lblPresetWarning.Visible = true;
                    return;
                }
                //if (lstPresets.Items.Count == buffer[11])
                //{
                arr[0] = (buffer[11] + 1).ToString();
                // arr[0] = (++presetCounter).ToString();
                if (buffer[10] == 0)
                {
                    arr[1] = (((float)(buffer[3] | buffer[2] << 8))/2).ToString();
                    arr[2] = ((((float)buffer[6]) - min_tilt) /2 ).ToString();
                }   
                else if (buffer[10] == 1)
                {
                    arr[1] = (((float)(buffer[3] | buffer[2] << 8))/2).ToString() + "," +
                        (((float)(buffer[5] | buffer[4] << 8))/2).ToString();
                    arr[2] = ((((float)buffer[6]) - min_tilt) / 2).ToString();
                }
                else if (buffer[10] == 2)
                {
                    arr[1] = (((float)(buffer[3] | buffer[2] << 8))/2).ToString();
                    arr[2] = ((((float)buffer[6]) - min_tilt) / 2).ToString() + "," + ((((float)buffer[7]) - min_tilt) / 2).ToString();
                }
                else if (buffer[10] == 3)
                {
                    arr[1] = (((float)(buffer[3] | buffer[2] << 8))/2).ToString() + "," +
                        (((float)(buffer[5] | buffer[4] << 8))/2).ToString();
                    arr[2] = ((((float)buffer[6]) - min_tilt) / 2).ToString() + "," + ((((float)buffer[7]) - min_tilt) /2 ).ToString();
                }

                arr[3] = buffer[8] == 1 ? "True" : "False";
                arr[4] = buffer[9].ToString();
                //


                itm = new ListViewItem(arr);
                lstPresets.Items.Insert(presetCounter, itm);
                presetCounter++;

            }

        }

        private string AutodetectArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino") || desc.Contains("CH340"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                Application.Exit();
            }

            return null;
        }

        private void numRandomPanEndAngle_ValueChanged(object sender, EventArgs e)
        {

            if (numRandomPanEndAngle.Value - numRandomPanStartAngle.Value < 5)
            {
                numRandomPanStartAngle.Value = numRandomPanEndAngle.Value - 5;
            }
        }

        private void numRandomTiltStartAngle_ValueChanged(object sender, EventArgs e)
        {

            if (numRandomTiltEndAngle.Value - numRandomTiltStartAngle.Value < 2)
            {
                numRandomTiltEndAngle.Value = numRandomTiltStartAngle.Value + 2;
            }
        }

        private void numRandomTiltEndAngle_ValueChanged(object sender, EventArgs e)
        {

            if (numRandomTiltEndAngle.Value - numRandomTiltStartAngle.Value < 2)
            {
                numRandomTiltStartAngle.Value = numRandomTiltEndAngle.Value - 2;
            }
        }


        private void cmbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            portName = cmbPorts.Text;
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (openComPort())
            {
                lblErrors.Visible = false;

            }
            else
            {
                lblErrors.Text = "LASER BIRD is not connected";
                lblErrors.Visible = true;
            }
        }

        private void DisplayPanTilt(byte[] buffer)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DisplayPanTiltDelegate(DisplayPanTilt), new object[] { buffer });
            }
            else
            {
                currentPanPosition = (buffer[2] << 8) | buffer[3];
                currentTiltPosition = buffer[4];
                lblPan.Text = ((float)currentPanPosition / 2).ToString();
                lblTilt.Text = (((float)currentTiltPosition - min_tilt) / 2 ).ToString();

                if (buffer[5] == 1)
                {
                    chkLaserOn.Text = "Laser On";
                    chkLaserOn.Checked = true;
                }
                else
                {
                    chkLaserOn.Text = "Laser Off";
                    chkLaserOn.Checked = false;
                }

                if (buffer[6] == 1) //automode
                {
                    timerAutomode.Enabled = true;
                    chkAutoMode.Text = "AutoMode On";
                    chkAutoMode.Checked = true;
                    btnClearPresets.Enabled = false;
                    btnDown.Enabled = false;
                    btnUp.Enabled = false;
                    btnLeft.Enabled = false;
                    btnRight.Enabled = false;
                    //btnLoadPresets.Enabled = false;
                    btnSave.Enabled = false;
                    chkLaserOn.Enabled = false;
                    btnAddPreset.Enabled = false;
                    btnRemovePreset.Enabled = false;

                    if (lstPresets.Items.Count > buffer[7])
                    {
                        lstPresets.Items[buffer[7]].Selected = true;
                        lstPresets.Select();
                        lstPresets.HideSelection = true;

                    }
                }
                else
                {
                    timerAutomode.Enabled = false;
                    chkAutoMode.Text = "AutoMode Off";
                    chkAutoMode.Checked = false;
                    btnClearPresets.Enabled = true;
                    btnDown.Enabled = true;
                    btnUp.Enabled = true;
                    btnLeft.Enabled = true;
                    btnRight.Enabled = true;
                    btnLoadPresets.Enabled = true;
                    btnSave.Enabled = true;
                    chkLaserOn.Enabled = true;
                    btnAddPreset.Enabled = true;
                    btnRemovePreset.Enabled = true;
                }

                if (buffer[9] == 1)
                {
                    lblErrors.Text = "LASER BIRD is in calibration proccess.... please wait\n";
                    lblErrors.Visible = true;
                    deviceIsResetting = true;
                }
                else
                {
                    lblErrors.Visible = false;
                    deviceIsResetting = false;
                }

            }
        }

        private void chkLaserOn_Click(object sender, EventArgs e)
        {
            byte[] cmdLaserOn = new byte[] { 0x0B, 0x00 };


            if (chkLaserOn.Checked)
            {
                cmdLaserOn[1] = 1;
            }
            else
            {
                cmdLaserOn[1] = 0;
            }
            sendStandardPacket(cmdLaserOn);
            //Thread.Sleep(50);
            //sendStandardPacket(cmdGetPosition);
        }

        private void chkAutoMode_Click(object sender, EventArgs e)
        {

            if (chkAutoMode.Checked)
            {
                cmdAutoMode[1] = 1;
            }
            else
            {
                cmdAutoMode[1] = 0;
            }

            sendStandardPacket(cmdAutoMode);
            Thread.Sleep(50);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer();
                serialPort.DiscardOutBuffer();
                serialPort.Close();
            }

        }

        private void timerAutomode_Tick(object sender, EventArgs e)
        {
            sendStandardPacket(cmdGetPosition);
        }


        private void numRandomPanStartAngle_ValueChanged(object sender, EventArgs e)
        {


            if (numRandomPanEndAngle.Value - numRandomPanStartAngle.Value < 5)
            {
                numRandomPanEndAngle.Value = numRandomPanStartAngle.Value + 5;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chkRandomPan_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
