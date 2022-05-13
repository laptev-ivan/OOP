using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Работа_с_иерархией_классов_в_форме
{
    public partial class Form1 : Form
    {
        GruzovoeTransportnoeSredstvo car;

        public Form1()
        {
            InitializeComponent();
        }

        private void objButton_Click(object sender, EventArgs e) {
            try {
                if (rb1.Checked) {
                    int weight = int.Parse(textBox7.Text);
                    int pwrReserve = int.Parse(textBox8.Text);
                    int capacity = int.Parse(textBox9.Text);
                    int cargoWeight = int.Parse(textBox10.Text);
                    int numWheels = int.Parse(textBox1.Text);
                    int typeDriveUnit = int.Parse(textBox2.Text);
                    int numVoditeley = int.Parse(textBox3.Text);
                    car = new GruzovoiAutomobile("", weight, pwrReserve, capacity, cargoWeight, numWheels, (Type)typeDriveUnit, numVoditeley);
                    textBox11.Text = Convert.ToString(car.Weight) + " кг";
                    textBox12.Text = car.ZapasHodaSDannoiNagruzkoi() + " на 100 км";
                    textBox13.Text = Convert.ToString(car.CargoWeight) + " кг";
                }
                if (rb2.Checked) {
                    int weight = int.Parse(textBox7.Text);
                    int pwrReserve = int.Parse(textBox8.Text);
                    int capacity = int.Parse(textBox9.Text);
                    int cargoWeight = int.Parse(textBox10.Text);
                    int numWheels = int.Parse(textBox1.Text);
                    int typeDriveUnit = int.Parse(textBox2.Text);
                    int numCars = int.Parse(textBox4.Text);
                    car = new GruzovoiPoezd("", weight, pwrReserve, capacity, cargoWeight, numWheels, (Type)typeDriveUnit, numCars);
                    textBox11.Text = Convert.ToString(car.Weight) + " кг";
                    textBox12.Text = car.ZapasHodaSDannoiNagruzkoi() + " на 100 км";
                    textBox13.Text = Convert.ToString(car.CargoWeight) + " кг";
                }
                if (rb3.Checked) {
                    int weight = int.Parse(textBox7.Text);
                    int pwrReserve = int.Parse(textBox8.Text);
                    int capacity = int.Parse(textBox9.Text);
                    int cargoWeight = int.Parse(textBox10.Text);
                    int numWheels = int.Parse(textBox1.Text);
                    int typeDriveUnit = int.Parse(textBox2.Text);
                    int numVoditeley = int.Parse(textBox3.Text);
                    bool pass = int.Parse(textBox6.Text) >= 0 ? true : false;
                    car = new Pickup("", weight, pwrReserve, capacity, cargoWeight, numWheels, (Type)typeDriveUnit, numVoditeley, pass);
                    textBox11.Text = Convert.ToString(car.Weight) + " кг";
                    textBox12.Text = car.ZapasHodaSDannoiNagruzkoi() + " на 100 км";
                    textBox13.Text = Convert.ToString(car.CargoWeight) + " кг";
                }
                if (rb4.Checked) {
                    int weight = int.Parse(textBox7.Text);
                    int pwrReserve = int.Parse(textBox8.Text);
                    int capacity = int.Parse(textBox9.Text);
                    int cargoWeight = int.Parse(textBox10.Text);
                    int numWheels = int.Parse(textBox1.Text);
                    int typeDriveUnit = int.Parse(textBox2.Text);
                    int numVoditeley = int.Parse(textBox3.Text);
                    int numBuck = int.Parse(textBox5.Text);
                    car = new Bolshegruz("", weight, pwrReserve, capacity, cargoWeight, numWheels, (Type)typeDriveUnit, numVoditeley, numBuck);
                    textBox11.Text = Convert.ToString(car.Weight) + " кг";
                    textBox12.Text = car.ZapasHodaSDannoiNagruzkoi() + " на 100 км";
                    textBox13.Text = Convert.ToString(car.CargoWeight) + " кг";
                }
            }
            catch (Exception error) {
                MessageBox.Show(error.Message);
            }
        }

        private void changeButton_Click(object sender, EventArgs e) {
            try {
                if (rb1.Checked) {
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                    textBox4.ReadOnly = true;
                    textBox5.ReadOnly = true;
                    textBox6.ReadOnly = true;
                    textBox7.ReadOnly = true;
                    textBox8.ReadOnly = true;
                    textBox9.ReadOnly = true;
                    textBox10.ReadOnly = false;
                    car.CargoWeight = int.Parse(textBox10.Text);
                    textBox11.Text = Convert.ToString(car.Weight) + " кг";
                    textBox12.Text = car.ZapasHodaSDannoiNagruzkoi() + " на 100 км";
                    textBox13.Text = Convert.ToString(car.CargoWeight) + " кг";
                }
                if (rb2.Checked) {
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                    textBox4.ReadOnly = true;
                    textBox5.ReadOnly = true;
                    textBox6.ReadOnly = true;
                    textBox7.ReadOnly = true;
                    textBox8.ReadOnly = true;
                    textBox9.ReadOnly = true;
                    textBox10.ReadOnly = false;
                    car.CargoWeight = int.Parse(textBox10.Text);
                    textBox11.Text = Convert.ToString(car.Weight) + " кг";
                    textBox12.Text = car.ZapasHodaSDannoiNagruzkoi() + " на 100 км";
                    textBox13.Text = Convert.ToString(car.CargoWeight) + " кг";
                }
                if (rb3.Checked) {
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                    textBox4.ReadOnly = true;
                    textBox5.ReadOnly = true;
                    textBox6.ReadOnly = true;
                    textBox7.ReadOnly = true;
                    textBox8.ReadOnly = true;
                    textBox9.ReadOnly = true;
                    textBox10.ReadOnly = false;
                    car.CargoWeight = int.Parse(textBox10.Text);
                    textBox11.Text = Convert.ToString(car.Weight) + " кг";
                    textBox12.Text = car.ZapasHodaSDannoiNagruzkoi() + " на 100 км";
                    textBox13.Text = Convert.ToString(car.CargoWeight) + " кг";
                }
                if (rb4.Checked) {
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox3.ReadOnly = true;
                    textBox4.ReadOnly = true;
                    textBox5.ReadOnly = true;
                    textBox6.ReadOnly = true;
                    textBox7.ReadOnly = true;
                    textBox8.ReadOnly = true;
                    textBox9.ReadOnly = true;
                    textBox10.ReadOnly = false;
                    car.CargoWeight = int.Parse(textBox10.Text);
                    textBox11.Text = Convert.ToString(car.Weight) + " кг";
                    textBox12.Text = car.ZapasHodaSDannoiNagruzkoi() + " на 100 км";
                    textBox13.Text = Convert.ToString(car.CargoWeight) + " кг";
                }
            }
            catch (Exception error) {
                MessageBox.Show(error.Message);
            }
        }

        private void rb1_CheckedChanged(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";


            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = true; 
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
        }

        private void rb2_CheckedChanged(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = false; 
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
        }

        private void rb3_CheckedChanged(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = ""; 
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
        }

        private void rb4_CheckedChanged(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";

            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
        }
    }
}
