using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Визуальное_программирование1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (int.TryParse(tb1.Text, out int res)) {
                if (kosSash.Checked)
                    tb2.Text = Convert.ToString(res * 2.48 + " м");
                else if(maxSash.Checked)
                    tb2.Text = Convert.ToString(res * 1.78 + " м");
                else if (arshin.Checked)
                    tb2.Text = Convert.ToString(res * 71.12 + " см");
                else if (foot.Checked)
                    tb2.Text = Convert.ToString(res * 30.48 + " см");
                else if (step.Checked)
                    tb2.Text = Convert.ToString(res * 71 + " см");
                else if (lokot.Checked)
                    tb2.Text = Convert.ToString(res * 45 + " см");
                else if (hand.Checked)
                    tb2.Text = Convert.ToString(res * 7.5 + " см");
                else if (pad.Checked)
                    tb2.Text = Convert.ToString(res * 17.78 + " см");
            }
            else {

                tb2.Text = "Неверное значение";
            }
        }
    }
}
