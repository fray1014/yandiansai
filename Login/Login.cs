using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WFPlot;

namespace Login
{
    public partial class Login : Form
    {
        Plot w;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(idBox.Text=="123")
            {
                MessageBox.Show("账号信息错误或无权限访问！", "错误");
            }
            else
            {
                w = new Plot();
                w.Show();
                this.Hide();
            }
            
        }
    }
}
