using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp34 {
    class Trapezoid {
        private double d1;
        private double d2;
        private double h;
        public double D1 {
            get {
                return d1;
            }
            set {
                if (d1 > d2) {
                    double c = d1;
                    d1 = d2;
                    d2 = c;
                }
            }
        }
        public double D2 {
            get {
                return d2;
            }
            set {
                if (d2 < d1) {
                    double c = d1;
                    d1 = d2;
                    d2 = c;
                }
            }
        }
        public Trapezoid() {
            D1 = 5;
            D2 = 7;
            h = 3;
        }
        public Trapezoid(double d, double d0, double h0) {
            D1 = d;
            D2 = d0;
            h = h0;
        }
        public void OutPut() {
            Console.WriteLine("Верхнее основание трапеции равно " + d1);
            Console.WriteLine("Нижнее основание трапеции равно " + d2);
            Console.WriteLine("Высота трапеции равна " + h);
        }
        public double perimeter() {
            double periphery = d1 + d2 + 2 * Math.Sqrt(h * h + (0.5 * d1 - 0.5 * d2) * (0.5 * d1 - 0.5 * d2));
            return periphery;
        }
        public double area() {
            double square = 0.5 * h * (d1 + d2);
            return square;
        }
        public double srlinia() {
            double srlinia = (d1 + d2) / 2;
            return srlinia;
        }
        public double bokstor() {
            double bokstor = Math.Sqrt(h * h + (0.5 * d1 - 0.5 * d2) * (0.5 * d1 - 0.5 * d2));
            return bokstor;
        }
        public double diag() {
            double diag = Math.Sqrt(h * h + (0.5 * d1 - 0.5 * d2) * (0.5 * d1 - 0.5 * d2) + d1 * d2);
            return diag;
        }
        public double radiusopis() {
            double p = perimeter() / 2;
            double radiusopis = (diag() * bokstor() * d2) / (4 * Math.Sqrt(p * (p - diag()) * (p - bokstor()) * (p - d2)));
            return radiusopis;
        }
        public bool MZH() {
            double bokstor = bokstor();
            if (d1 + d2 == bokstor * 2) {
                return true;
            }
            else {
                return false;
            }
        }
        public double rvpis() {
            double rvpis = h / 2;
            return rvpis;
        }
    }
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Если вы хотите задать трапецию без параметров, нажмите 0, если хотите задать трапецию с параметрами, нажмите 1");
            int otvet = int.Parse(Console.ReadLine());
            if (otvet == 0) {

                Trapezoid trapbezparametrov = new Trapezoid();

            }
            else if (otvet == 1) {
                Console.WriteLine("Введите верхнее основание трапеции ");
                double d1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите нижнее основание трапеции ");
                double d2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите высоту трапеции ");
                double h = double.Parse(Console.ReadLine());
                Trapezoid trapsparametrami = new Trapezoid(d1, d2, h);
            }
            trapsparametrami.OutPut();
            Console.WriteLine("Периметр заданной трапеции равен " + String.Format("{0:F3}", trapsparametrami.perimeter()));
            Console.WriteLine("Площадь заданной трапеции равна " + String.Format("{0:F3}", trapsparametrami.area()));
            Console.WriteLine("Средняя линия заданной трапеции равна " + String.Format("{0:F3}", trapsparametrami.srlinia()));
            Console.WriteLine("Боковая сторона заданной трапеции равна " + String.Format("{0:F3}", trapsparametrami.bokstor()));
            Console.WriteLine("Диагональ заданной трапеции равна " + String.Format("{0:F3}", trapsparametrami.diag()));
            Console.WriteLine("Радиус описанной окружности около заданной трапеции равен " + String.Format("{0:F3}", trapsparametrami.radiusopis()));
            if (trapsparametrami.MZH == true) {
                Console.WriteLine("Радиус вписанной окружности в заданной трапеции равен " + String.Format("{0:F3}", trapsparametrami.rvpis()));
            }
            else {
                Console.WriteLine("В заданную трапецию нельзя вписать окружность");
            }
            Console.ReadKey();
        }
    }
}