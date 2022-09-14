using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Пистолет.Класс_Gun {
    public class Gun {
        int g;
        int v0;
        int alpha;
        int h;

        public Gun() {
            g = 10;
            v0 = 30;
            alpha = 45;
            h = 20;
        }

        public Gun(int g, int v0, int alpha, int h) {
            this.g = g;
            this.v0 = v0;
            this.alpha = alpha;
            this.h = h;
        }

        public int V0 {
            set {
                if (value > 0) v0 = value;
                else 
                    try { throw new Exception(@"скорость не может быть меньше нуля."); }
                    catch (Exception e) { MessageBox.Show("Ошибка: " + e.Message); }
            }
        }

        public int Alpha {
            set {
                if (value >= 0 && value <= 90) alpha = value;
                else
                    try { throw new Exception(@"угол не может быть меньше нуля или больше 90 градусов."); }
                    catch (Exception e) { MessageBox.Show("Ошибка: " + e.Message); }
            }
        }

        public int H {
            set {
                if (value > 0) alpha = value;
                else
                    try { throw new Exception(@"высота не может быть меньше нуля."); }
                    catch (Exception e) { MessageBox.Show("Ошибка: " + e.Message); }
            }
        }

        public double Distance {
            get {
                return Math.Pow(v0, 2) * Math.Sin(2 * alpha * 0.0174533) / g;
            }
        }

        public double Time {
            get {
                return v0 * Math.Sin(2 * alpha * 0.0174533) + Math.Sqrt(Math.Pow(v0, 2) * Math.Pow(57.2958 * Math.Sin(2 * alpha * 0.0174533), 2) + 2 * g * h);
            }
        }

        public double MaxDistance {
            get {
                return v0 * Time / g * Math.Sin(2 * alpha * 0.0174533);
            }
        }

        public string Shoot(int target) {
            if (target < Distance) return "ПЕРЕЛЕТ";
            else if (target == Distance) return "ПОПАЛ";
            else return "НЕДОЛЕТ";
        }

        public bool Aim(int target) {
            if (target < MaxDistance) return true;
            else throw new Exception("fsldkjf");
        }

        public bool Aim(int target, int radius) {
            if (target < MaxDistance * radius) return true;
            else throw new Exception("fsldkjf");
        }
    }
}
