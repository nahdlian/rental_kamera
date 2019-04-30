using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tgsbsr
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int ssd = 100000;
            int sld = 150000;
            int r = 100000;
            int b = 500000;
            int p = Int16.Parse(textBox6.Text);
            int k = Int16.Parse(textBox7.Text);
            textBox8.Text = (k - p).ToString();
            int drs = Int16.Parse(textBox8.Text);
            
            if (comboBox1.Text == "1100D")
            {
                textBox9.Text = (ssd * drs).ToString();
                if (checkBox1.Checked == true)
                {
                    textBox9.Text = (ssd * drs + r).ToString();
                }
                else if (checkBox2.Checked == true)
                {
                    textBox9.Text = (ssd * drs + b).ToString();
                }
                else if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    textBox9.Text = ((ssd * drs) + r + b).ToString();
                }
            }
            else if (comboBox1.Text == "1500D")
            {
                textBox9.Text = (sld * drs + r).ToString();
                if (checkBox1.Checked == true)
                {
                    textBox9.Text = (sld * drs + r).ToString();
                }
                else if (checkBox2.Checked == true)
                {
                    textBox9.Text = (sld * drs + b).ToString();
                }
                else if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    textBox9.Text = ((sld * drs) + r + b).ToString();
                }
            }
        }
    }
}
