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

namespace Group13
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] Baud = { "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "28800", "38400" };
        string[] hour = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
        string[] minute = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59" };
        string[] second = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" };
        string[] time = { "AM", "PM" };
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] nameport = SerialPort.GetPortNames();
            cbCom.Items.AddRange(nameport);
            cbBauDrate.Items.AddRange(Baud);

            cbHour1_Arch.Items.AddRange(hour);
            cbHour2_Arch.Items.AddRange(hour);
            cbMinute1_Arch.Items.AddRange(minute);
            cbMinute2_Arch.Items.AddRange(minute);
            cbSecond1_Arch.Items.AddRange(second);
            cbSecond2_Arch.Items.AddRange(second);
            cbTime1_Arch.Items.AddRange(time);
            cbTime2_Arch.Items.AddRange(time);

            cbHour1_Lamp1.Items.AddRange(hour);
            cbHour2_Lamp1.Items.AddRange(hour);
            cbMinute1_Lamp1.Items.AddRange(minute);
            cbMinute2_Lamp1.Items.AddRange(minute);
            cbSecond1_Lamp1.Items.AddRange(second);
            cbSecond2_Lamp1.Items.AddRange(second);
            cbTime1_Lamp1.Items.AddRange(time);
            cbTime2_Lamp1.Items.AddRange(time);

            cbHour1_Lamp2.Items.AddRange(hour);
            cbHour2_Lamp2.Items.AddRange(hour);
            cbMinute1_Lamp2.Items.AddRange(minute);
            cbMinute2_Lamp2.Items.AddRange(minute);
            cbSecond1_Lamp2.Items.AddRange(second);
            cbSecond2_Lamp2.Items.AddRange(second);
            cbTime1_Lamp2.Items.AddRange(time);
            cbTime2_Lamp2.Items.AddRange(time);

            cbHour1_Lamp3.Items.AddRange(hour);
            cbHour2_Lamp3.Items.AddRange(hour);
            cbMinute1_Lamp3.Items.AddRange(minute);
            cbMinute2_Lamp3.Items.AddRange(minute);
            cbSecond1_Lamp3.Items.AddRange(second);
            cbSecond2_Lamp3.Items.AddRange(second);
            cbTime1_Lamp3.Items.AddRange(time);
            cbTime2_Lamp3.Items.AddRange(time);

            cbHour1_Lamp4.Items.AddRange(hour);
            cbHour2_Lamp4.Items.AddRange(hour);
            cbMinute1_Lamp4.Items.AddRange(minute);
            cbMinute2_Lamp4.Items.AddRange(minute);
            cbSecond1_Lamp4.Items.AddRange(second);
            cbSecond2_Lamp4.Items.AddRange(second);
            cbTime1_Lamp4.Items.AddRange(time);
            cbTime2_Lamp4.Items.AddRange(time);

            timer1.Enabled = true;

            chart1.Series["Nhiet do"].Points.AddXY(1, 1);
            chart1.Series["Do am"].Points.AddXY(1, 1);
            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       


        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void standardControl1_Load(object sender, EventArgs e)
        {

        }
       
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbBauDrate.Text=="" || cbCom.Text=="")
                {
                    MessageBox.Show("Ban chua nhap du thong tin","Thong bao");
                }
                
                if(serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    btnConnect.Text = "CONNECT";

                    chart1.Series["Nhiet do"].Points.Clear();
                    chart1.Series["Do am"].Points.Clear();

                    lbTemp.Text = string.Format("Nhiệt độ = ... °C");
                    lbHum.Text = string.Format("Độ ẩm = ... %RH");

                    MessageBox.Show("Disconnected", "THONG BAO");
                }
                else
                {
                    serialPort1.PortName = cbCom.Text;
                    serialPort1.BaudRate = int.Parse(cbBauDrate.Text);
                    serialPort1.Open();

                    chart1.Series["Nhiet do"].Points.Clear();
                    chart1.Series["Do am"].Points.Clear();

                    btnConnect.Text = "DISCONNECT";

                    MessageBox.Show("Success Connected", "THONG BAO");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loi");
            }
        }

        bool Lamp1 = true;
        bool Lamp2 = true;
        bool Lamp3 = true;
        bool Lamp4 = true;
        bool Arch = true;
        bool Mode_Manual = true;
        private void btnLamp1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(Lamp1 == true)
                {
                    serialPort1.Write("a");
                    btnLamp1.Text = "ON";
                    Lamp1 = false;
                }
                else
                {
                    serialPort1.Write("b");
                    btnLamp1.Text = "OFF";
                    Lamp1 = true;
                }    
            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }

        private void btnLamp2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lamp2 == true)
                {
                    serialPort1.Write("c");
                    btnLamp2.Text = "ON";
                    Lamp2 = false;
                }
                else
                {
                    serialPort1.Write("d");
                    btnLamp2.Text = "OFF";
                    Lamp2 = true;
                }
            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }

        private void btnLamp3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lamp3 == true)
                {
                    serialPort1.Write("e");
                    btnLamp3.Text = "ON";
                    Lamp3 = false;
                }
                else
                {
                    serialPort1.Write("f");
                    btnLamp3.Text = "OFF";
                    Lamp3 = true;
                }
            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }

        private void btnLamp4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Lamp4 == true)
                {
                    serialPort1.Write("g");
                    btnLamp4.Text = "ON";
                    Lamp4 = false;
                }
                else
                {
                    serialPort1.Write("h");
                    btnLamp4.Text = "OFF";
                    Lamp4 = true;
                }
            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }

        private void btnArch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Arch == true)
                {
                    serialPort1.Write("j");
                    btnArch.Text = "OPEN";
                    Arch = false;
                }
                else
                {
                    serialPort1.Write("k");
                    btnArch.Text = "CLOSE";
                    Arch = true;
                }
            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToLongTimeString();
            lbDate.Text = DateTime.Now.ToLongDateString();

                        
            if (lbTime.Text==cbHour1_Lamp1.Text + ":" + cbMinute1_Lamp1.Text + ":" + cbSecond1_Lamp1.Text +" "+cbTime1_Lamp1.Text  )
            {
                serialPort1.Write("a");
                btnLamp1.Text = "ON";
                Lamp1 = false;
            }
            else if(lbTime.Text == cbHour2_Lamp1.Text + ":" + cbMinute2_Lamp1.Text + ":" + cbSecond2_Lamp1.Text + " " + cbTime2_Lamp1.Text)
            {
                serialPort1.Write("b");
                btnLamp1.Text = "OFF";
                Lamp1 = true;
            }
            else if (lbTime.Text == cbHour1_Lamp2.Text + ":" + cbMinute1_Lamp2.Text + ":" + cbSecond1_Lamp2.Text + " " + cbTime1_Lamp2.Text)
            {
                serialPort1.Write("c");
                btnLamp2.Text = "ON";
                Lamp2 = false;
            }
            else if (lbTime.Text == cbHour2_Lamp2.Text + ":" + cbMinute2_Lamp2.Text + ":" + cbSecond2_Lamp2.Text + " " + cbTime2_Lamp2.Text)
            {
                serialPort1.Write("d");
                btnLamp2.Text = "OFF";
                Lamp2 = true;
            }
            else if (lbTime.Text == cbHour1_Lamp3.Text + ":" + cbMinute1_Lamp3.Text + ":" + cbSecond1_Lamp3.Text + " " + cbTime1_Lamp3.Text)
            {
                serialPort1.Write("e");
                btnLamp3.Text = "ON";
                Lamp3 = false;
            }
            else if (lbTime.Text == cbHour2_Lamp3.Text + ":" + cbMinute2_Lamp3.Text + ":" + cbSecond2_Lamp3.Text + " " + cbTime2_Lamp3.Text)
            {
                serialPort1.Write("f");
                btnLamp3.Text = "OFF";
                Lamp3 = true;
            }
            else if (lbTime.Text == cbHour1_Lamp4.Text + ":" + cbMinute1_Lamp4.Text + ":" + cbSecond1_Lamp4.Text + " " + cbTime1_Lamp4.Text)
            {
                serialPort1.Write("g");
                btnLamp4.Text = "ON";
                Lamp4 = false;
            }
            else if (lbTime.Text == cbHour2_Lamp4.Text + ":" + cbMinute2_Lamp4.Text + ":" + cbSecond2_Lamp4.Text + " " + cbTime2_Lamp4.Text)
            {
                serialPort1.Write("h");
                btnLamp4.Text = "OFF";
                Lamp4 = true;
            }
            else if (lbTime.Text == cbHour1_Arch.Text + ":" + cbMinute1_Arch.Text + ":" + cbSecond1_Arch.Text + " " + cbTime1_Arch.Text)
            {
                serialPort1.Write("j");
                btnArch.Text = "ON";
                Arch = false;
            }
            else if (lbTime.Text == cbHour2_Arch.Text + ":" + cbMinute2_Arch.Text + ":" + cbSecond2_Arch.Text + " " + cbTime2_Arch.Text)
            {
                serialPort1.Write("k");
                btnArch.Text = "OFF";
                Arch = true;
            }
           
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string dataIn = serialPort1.ReadTo("\n");
            Data_Parsing(dataIn);
            this.BeginInvoke(new EventHandler(Show_Data));
         }

        private void Show_Data(object sender, EventArgs e)
        {
            if(updateData == true)
            {
                lbTemp.Text = string.Format("Nhiệt độ = {0} °C", nhietdo.ToString());
                lbHum.Text = string.Format("Độ ẩm = {0} %RH", doam.ToString());

                chart1.Series["Nhiet do"].Points.Add(nhietdo);
                chart1.Series["Do am"].Points.Add(doam);
            }
        }

        double nhietdo = 0;
        double doam = 0;
        bool updateData = false;

        private void Data_Parsing(string dataIn)
        {
            sbyte indexOf_startDataCharacter = (sbyte)dataIn.IndexOf("@");
            sbyte indexOfA = (sbyte)dataIn.IndexOf("A");
            sbyte indexOfB = (sbyte)dataIn.IndexOf("B");

            if(indexOfA != -1 && indexOfB != -1 && indexOf_startDataCharacter != -1 )
            {
                try
                {
                    string str_nhietdo = dataIn.Substring(indexOf_startDataCharacter + 1, (indexOfA - indexOf_startDataCharacter) - 1);
                    string str_doam = dataIn.Substring(indexOfA + 1, (indexOfB - indexOfA) - 1);

                    nhietdo = Convert.ToDouble(str_nhietdo);
                    doam = Convert.ToDouble(str_doam);

                    updateData = true;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                updateData = false;
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            if (Mode_Manual == true)
            {
                btnMode.Text = "Auto";
                btnLamp1.Enabled = false;
                btnLamp2.Enabled = false;
                btnLamp3.Enabled = false;
                btnLamp4.Enabled = false;
                btnArch.Enabled = false;
                

                gbLamp1_Auto.Enabled = true;
                gbLamp2_Auto.Enabled = true;
                gbLamp3_Auto.Enabled = true;
                gbLamp4_Auto.Enabled = true;
                gbArch_Auto.Enabled = true;
                Mode_Manual = false;
                
            }
            else
            {
                btnMode.Text = "Manual";
                btnLamp1.Enabled = true;
                btnLamp2.Enabled = true;
                btnLamp3.Enabled = true;
                btnLamp4.Enabled = true;
                btnArch.Enabled = true;
                

                gbLamp1_Auto.Enabled = false;
                gbLamp2_Auto.Enabled = false;
                gbLamp3_Auto.Enabled = false;
                gbLamp4_Auto.Enabled = false;
                gbArch_Auto.Enabled = false;
                Mode_Manual = true;
            }
        }
     
       
            

        private void lbTime_Click(object sender, EventArgs e)
        {

        }
        bool StopArch = false;
        private void btStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (StopArch == false)
                {
                    serialPort1.Write("m");
                    btStop.Text = "CONTINUE";
                    btnArch.Enabled = true;
                    gbArch_Auto.Enabled = true;
                    StopArch = true;
                }
                else
                {
                    serialPort1.Write("n");
                    btStop.Text = "STOP";
                    btnArch.Enabled = false;
                    gbArch_Auto.Enabled = false;
                    StopArch = false;
                }
            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }
    }
}
