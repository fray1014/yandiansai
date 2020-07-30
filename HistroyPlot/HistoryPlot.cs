using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace History
{
    public partial class HistoryPlot : Form
    {
        public HistoryPlot()
        {
            InitializeComponent();
        }

        private void HistoryPlot_Load(object sender, EventArgs e)
        {
            Random r1 = new Random();
            double[] dataHB = new double[r1.Next(55, 75)];
            double[] dataB = new double[dataHB.Length];
            for(int i=0;i<dataHB.Length;i++)
            {
                dataHB[i] = r1.Next(60,75);
                dataB[i] = r1.Next(10, 20);
            }
            chHB.Series[0].Points.DataBindY(dataHB);
            chB.Series[0].Points.DataBindY(dataB);
        }
    }
}
