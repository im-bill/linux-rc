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
    public partial class Rename : Form
    {
        public string filename;
        public Rename()
        {
            InitializeComponent();
        }

        private void RanameForm_Load(object sender, EventArgs e)
        {
            if (filename != null)
                textBox1.Text = filename;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("文件名不为空。");
                return;
            }
            if (textBox1.Text == filename)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
            filename = textBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
