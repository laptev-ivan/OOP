using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Пистолет.Класс_Gun
{
    public partial class Form1 : Form
    {
        Gun gun;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (tb1.Text + tb2.Text + tb3.Text == "") gun = new Gun();
            else {
                gun = new Gun(int.Parse(tb1.Text), int.Parse(tb2.Text), int.Parse(tb3.Text), int.Parse(tb4.Text));
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            gun.V0 = int.Parse(tb2.Text);
            gun.Alpha = int.Parse(tb3.Text);
            gun.H = int.Parse(tb4.Text);
        }
    }
}
