using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ctrl_server
{
    public partial class ModifyTime : Form
    {
        public ModifyTime()
        {
            InitializeComponent();
        }
        string time;
        private void ModifyTime_Load(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now.ToLocalTime();
            txtYY.Text = datetime.Year.ToString();
            txtMM.Text = datetime.Month.ToString();
            txtDD.Text = datetime.Day.ToString();
            txtHH.Text = datetime.Hour.ToString();
            txtmin.Text = datetime.Hour.ToString();
            txtsec.Text = datetime.Second.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            time = "";
            if (txtYY.Text.Length != 4)
            {
                MessageBox.Show("年份是4位数");
                return;
            }
            time += txtYY.Text;
            if (txtMM.Text.Length != 2)
            {
                MessageBox.Show("月份是2位数");
                return;
            }
            time += txtMM.Text;
            if (txtDD.Text.Length != 4)
            {
                MessageBox.Show("天是2位数");
                return;
            }
            time += txtDD.Text;
            if (txtHH.Text.Length != 4)
            {
                MessageBox.Show("时是2位数");
                return;
            }
            time += txtHH.Text;           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
            return;
        }
    }
}
