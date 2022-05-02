using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Приветствие1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (tb1.Text == "")
                tb2.Text = "Hello, world!!!";
            else
                tb2.Text = "Hello, " + tb1.Text + "!!!";
        }
    }
}
