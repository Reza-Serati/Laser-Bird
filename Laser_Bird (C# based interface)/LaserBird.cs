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

    public partial class LaserBird : Form
    {
        int i = 0;
        byte[] cmdLeft = new byte[] { 0x00 };
        byte[] cmdRight = new byte[] { 0x01 };
        byte[] cmdUp = new byte[] { 0x02 };
        byte[] cmdDown = new byte[] { 0x03 };
        byte[] cmdStop = new byte[] { 0x04 };
        byte[] cmdGetPosition = new byte[] { 0x06, 0x00 };
        byte[] cmdGetPresets = new byte[] { 0x08 };
        byte[] cmdClearPresets = new byte[] { 0x09, 0x00 };

        bool stopReading = false;
        byte presetCounter = 0;
        byte presetId = 0;
        byte[] tmpBuffer = new byte[0];
        int currentPanPosition = 0, currentTiltPosition = 0;

        public LaserBird()
        {
            InitializeComponent();
            openComPort();
        }

        void openComPort()
        {
            String[] ports = SerialPort.GetPortNames();
            //cmbPorts.Items.AddRange(ports);
            String portName = AutodetectArduinoPort();
            if (!(portName == null || portName == String.Empty))
            {
                serialPort.PortName = portName;
                serialPort.Open();
            }

        }

        private void LaserBird_Load(object sender, EventArgs e)
        {
            sendStandardPacket(cmdGetPresets);
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
            // timerGetPosition.Enabled = true;
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            sendStop();
            // timerGetPosition.Enabled = false;
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            sendStandardPacket(cmdDown);
            // timerGetPosition.Enabled = true;
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            sendStop();
            // timerGetPosition.Enabled = false;
        }


        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            sendStandardPacket(cmdRight);
            // timerGetPosition.Enabled = true;
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            sendStop();
            // timerGetPosition.Enabled = false;
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            sendStandardPacket(cmdLeft);
            //  timerGetPosition.Enabled = true;
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            sendStop();
            // timerGetPosition.Enabled = false;
        }

        void sendStop()
        {
            sendStandardPacket(cmdStop);    
        }

        private void chkAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            byte[] cmdAutoMode = new byte[] { 0x0A, 0x00 };

            if (chkAutoMode.Checked)
            {
                cmdAutoMode[1] = 1;
            }
            else
            {
                cmdAutoMode[1] = 0;
            }

            sendStandardPacket(cmdAutoMode);
        }

        void sendStandardPacket(byte[] cmd)
        {

            byte[] finalCmd = new byte[14];
            finalCmd[0] = 0xFF;
            finalCmd[13] = 0xFF;
            for (int i = 0; i < cmd.Length; i++)
            {
                finalCmd[i + 1] = cmd[i];
                finalCmd[12] ^= cmd[i];
            }
            try
            {
                serialPort.Write(finalCmd, 0, finalCmd.Length);
                Thread.Sleep(50);

            }
            catch (TimeoutException ex)
            {
                // Log info or display info based on ex.Message
            }

        }

        private void timerGetPosition_Tick(object sender, EventArgs e)
        {
            sendStandardPacket(cmdGetPosition);
            cmdGetPosition[1] = 0x01;
        }

        private void readStandardPacket(byte[] buffer)
        {
            DisplaySerialDataReceived(buffer);
            int lastIndex = tmpBuffer.Length;
            Array.Resize(ref tmpBuffer, buffer.Length + tmpBuffer.Length);
            System.Buffer.BlockCopy(buffer, 0, tmpBuffer, lastIndex, buffer.Length);

            //Array.Copy(buffer, 0, tmpBuffer, tmpBuffer.Length, buffer.Length);

            if (tmpBuffer.Length < 10)
            {
                return;
            }

            for (int i = 0; i < tmpBuffer.Length; i++)
            {

                if (tmpBuffer.Length > i + 9 && tmpBuffer[i] == 0xFF && tmpBuffer[i + 9] == 0xFF)
                {
                    System.Buffer.BlockCopy(tmpBuffer, i, tmpBuffer, 0, 10);
                    Array.Resize(ref tmpBuffer, 10);
                    byte chkSum = new byte();

                    for (int j = 1; j < 8; j++)
                    {
                        chkSum ^= tmpBuffer[j];
                    }

                    if (chkSum == tmpBuffer[8])
                    {
                        parsResponse(tmpBuffer);
                    }
                    Array.Resize(ref tmpBuffer, 0);
                }
            }


        }

        private void btnStopReading_Click(object sender, EventArgs e)
        {
            stopReading = !stopReading;
        }

        private void lstPresets_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            arr[1] = lblPan.Text;
            arr[2] = lblTilt.Text;
            arr[3] = chkLaserOn.Checked.ToString();
            arr[4] = cmbWaitPreset.Text;
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
            SerialPort spL = (SerialPort)sender;
            int bytes = spL.BytesToRead;
            byte[] buffer = new byte[bytes];
            spL.Read(buffer, 0, bytes);
            readStandardPacket(buffer);
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

                    break;
                case 0x18:
                    DisplayPresets(buffer);
                    break;

                default:
                    Debug.WriteLine("No True Message");
                    break;
            }
        }

        private void DisplayPanTilt(byte[] buffer)
        {
            Invoke(new EventHandler(delegate
            {
                currentPanPosition = (buffer[2] << 8) | buffer[3];
                currentTiltPosition = buffer[4];
                lblPan.Text = ((float)currentPanPosition / 2).ToString();
                lblTilt.Text = (((float)currentTiltPosition / 2) - 35).ToString();
                chkAutoMode.Checked = buffer[6] == 1 ? true : false;
            }));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 0x7 pan(0x0000 - 2BC) tilt(0x00 - 8C) LaserOn / Off(0 - 1) wait(0x00 - 0xFF) PresetId(0x00 - 0xFF)
            byte[] cmdSetPreset = new byte[7];
            for (int i = 0; i < lstPresets.Items.Count; i++)
            {
                cmdSetPreset[0] = 0x07;
                cmdSetPreset[1] = (byte)((int)((float.Parse(lstPresets.Items[i].SubItems[1].Text)) * 2) >> 8);
                cmdSetPreset[2] = (byte)((float.Parse(lstPresets.Items[i].SubItems[1].Text)) * 2);
                cmdSetPreset[3] = (byte)((int)((float.Parse(lstPresets.Items[i].SubItems[2].Text) + 35) * 2));
                cmdSetPreset[4] = (byte)(lstPresets.Items[i].SubItems[3].Text == "True" ? 1 : 0);
                cmdSetPreset[5] = (byte)short.Parse(lstPresets.Items[i].SubItems[4].Text);
                cmdSetPreset[6] = (byte)(short.Parse(lstPresets.Items[i].SubItems[0].Text) - 1);
                sendStandardPacket(cmdSetPreset);
                Thread.Sleep(50);
            }

        }

        private void DisplaySerialDataReceived(byte[] data)
        {
            BeginInvoke(new EventHandler(delegate
            {
                if (!stopReading && data != null)
                {
                    txtSerialInput.AppendText(Encoding.Default.GetString(data));
                    txtSerialInput.AppendText("\r\n--------------------\r\n");

                    txtSerialInputeHex.AppendText(BitConverter.ToString(data));
                    txtSerialInputeHex.AppendText("\r\n--------------------\r\n");
                }
            }));

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
            for (byte i = 0; i < 100; i++)
            {
                cmdClearPresets[1] = i;
                sendStandardPacket(cmdClearPresets);
            }
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                btnClosePort.Text = "Open";
            }
            else
            {
                serialPort.Open();
                btnClosePort.Text = "Close";
            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        //        sendPresets= 0x18 highByte(pan) lowByte(pan) tilt laserOn waitTime 

        private void DisplayPresets(byte[] buffer)
        {
            BeginInvoke(new EventHandler(delegate
            {
                string[] arr = new string[5];
                ListViewItem itm;
                //add items to ListView
                if (presetCounter > 99)
                {
                    lblPresetWarning.Visible = true;
                    return;
                }
                arr[0] = (buffer[7] + 1).ToString();
                // arr[0] = (++presetCounter).ToString();
                arr[1] = ((float)(buffer[3] | buffer[2] << 8) / 2).ToString();
                arr[2] = ((float)buffer[4] / 2 - 35).ToString();
                arr[3] = buffer[5] == 1 ? "True" : "False";
                arr[4] = buffer[6].ToString();
                //
                itm = new ListViewItem(arr);
                lstPresets.Items.Add(itm);
                presetCounter++;
            }));
        }

        private void btnRight_Click(object sender, EventArgs e)
        {

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

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
            }

            return null;
        }
    }
}
