using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using History;
using System.IO;

namespace WFPlot
{
    public partial class Plot : Form
    {
        string url = "http://219.228.57.89:8080/getHrWave?id=1";
        string type = "application/x-www-form-urlencoded;charset=utf-8";
        Dictionary<string, string> d = new Dictionary<string, string>() { { "id=1","321"} };
        public double[] d1Heartbeat = new double[900];
        public double[] d1Breathe = new double[900];
        public Queue<double> q1Heartbeat = new Queue<double>(25);
        public Queue<double> q1Breathe = new Queue<double>(100);
        bool isOK = false;
        public static int index = 0;
        public static int flag = 1;
        public static int HB1 = 0;
        public static int B1 = 0;
        public Plot()
        {
            InitializeComponent();
        }

        private void btnH1_Click(object sender, EventArgs e)
        {
            HistoryPlot tmp = new HistoryPlot();
            tmp.Text += cbHis1.Text;
            tmp.Show();
        }

        private void t1_Tick(object sender, EventArgs e)
        {
            index = index % 900;
            if (q1Heartbeat.Count == 25)
            {
                q1Heartbeat.Dequeue();
            }
            if (q1Breathe.Count == 100)
            {
                q1Breathe.Dequeue();
            }
            q1Breathe.Enqueue(d1Breathe[index]);
            q1Heartbeat.Enqueue(d1Heartbeat[index]);
            chHB1.Series[0].Points.DataBindY(q1Heartbeat);
            chB1.Series[0].Points.DataBindY(q1Breathe);
            
            index += flag;
            /*
            if (index == 900||index==0)
            {
                flag=-flag;
            }*/
        }

        private void btnID1En_Click(object sender, EventArgs e)
        {
            t1.Enabled = true;
            timerB1.Enabled = true;
            timerHB1.Enabled = true;
            labS1.Text = "状态：使用中";
        }

        private void Plot_Load(object sender, EventArgs e)
        {
            //心率
            StreamReader sr = new StreamReader("b.txt", Encoding.Default);
            String line;
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                d1Heartbeat[i] = Convert.ToDouble(line);
                i++;
            }
            sr.Close();
            sr = new StreamReader("huxi.txt", Encoding.Default);
            i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                d1Breathe[i] = Convert.ToDouble(line);
                i++;
            }
            sr.Close();
            string d = DateTime.Now.ToLongDateString();
            labDate.Text += "\n今日："+d;
        }

        private void timerHB1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            HB1 = r.Next(60, 75);
            labHB1.Text = Convert.ToString(HB1);
            t1.Interval = HB1 / 2;
        }

        private void timerB1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            B1 = r.Next(10, 20);
            labB1.Text = Convert.ToString(B1);
        }
    }
}
