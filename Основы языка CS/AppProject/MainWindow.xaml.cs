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

namespace AppProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer mp1;
        MediaPlayer mp2;
        MediaPlayer mp3;

        public MainWindow()
        {
            InitializeComponent();
            mp1 = new MediaPlayer();
            mp2 = new MediaPlayer();
            mp3 = new MediaPlayer();
        }

        private void butty_Click(object sender, RoutedEventArgs e) {
            try {
                if (double.TryParse(tb1.Text, out double res)) {
                    if (rb1.IsChecked == true)
                        tb2.Text = Convert.ToString($"{Math.Floor(res / 2.48)}");
                    else if (rb2.IsChecked == true)
                        tb2.Text = Convert.ToString($"{Math.Floor(res / 1.78)}");
                    else if (rb3.IsChecked == true)
                        tb2.Text = Convert.ToString($"{Math.Floor(res / 0.7112)}");
                    else if (rb4.IsChecked == true)
                        tb2.Text = Convert.ToString($"{Math.Floor(res / 0.3048)}");
                    else if (rb5.IsChecked == true)
                        tb2.Text = Convert.ToString($"{Math.Floor(res / 0.71)}");
                    else if (rb6.IsChecked == true)
                        tb2.Text = Convert.ToString($"{Math.Floor(res / 0.45)}");
                    else if (rb7.IsChecked == true)
                        tb2.Text = Convert.ToString($"{Math.Floor(res / 0.075)}");
                    else if (rb8.IsChecked == true)
                        tb2.Text = Convert.ToString($"{Math.Floor(res / 0.1778)}");
                }
                else {
                    tb2.Text = "Неверное значение";
                    throw new Exception("Error: WTF");
                }
            }
            catch (Exception error) {
                mp1.Pause();
                mp3.Open(new Uri(@"C:\Users\chels\Desktop\CP\Основы языка CS\AppProject\pics\Spongebob - sad nigga sound effect .mp3", UriKind.RelativeOrAbsolute));
                mp3.Play();
                mp1.Play();
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (tabitem2.IsSelected == true) {
                mp1.Stop();
                mp2.Open(new Uri(@"C:\Users\chels\Desktop\CP\Основы языка CS\AppProject\pics\Korn - Twist.mp3", UriKind.RelativeOrAbsolute));
                mp2.Play();
            }
            if(tabitem1.IsSelected == true) {
                mp2.Stop();
                mp1.Open(new Uri(@"C:\Users\chels\Desktop\CP\Основы языка CS\AppProject\pics\HBnKiwi - hours later sound effect _ All Spongebob Time Sound Effects.mp3", UriKind.RelativeOrAbsolute));
                mp1.Play();
            }
        }
    }
}
