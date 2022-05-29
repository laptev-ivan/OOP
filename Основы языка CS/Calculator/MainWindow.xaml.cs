using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                if (rb1.IsChecked == true) {
                    tBlock1.Text = Convert.ToString($"{double.Parse(tb1.Text) * double.Parse(tb2.Text) * double.Parse(tb3.Text):f4}");
                    tBlock2.Text = Convert.ToString($"{double.Parse(tb1.Text) * double.Parse(tb2.Text) * double.Parse(tb3.Text) * uint.Parse(tb4.Text):f4}");
                }
                if (rb2.IsChecked == true) {
                    tBlock1.Text = Convert.ToString($"{ double.Parse(tb1.Text) * double.Parse(tb2.Text) * double.Parse(tb3.Text) * 0.000001:f4}");
                    tBlock2.Text = Convert.ToString($"{double.Parse(tb1.Text) * double.Parse(tb2.Text) * double.Parse(tb3.Text) * uint.Parse(tb4.Text) * 0.000001:f4}");
                }
            }
            catch(Exception error) {
                MessageBox.Show(error.Message);
            }
        }
    }
}
