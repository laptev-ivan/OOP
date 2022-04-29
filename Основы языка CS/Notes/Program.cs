using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25 {
    class Parallelogramm {
        protected double alfa;
        protected int h;
        protected int width;
        public Parallelogramm() {
            alfa = 87;
            h = 8;
            width = 9;
        }
        public Parallelogramm(double alfa, int h, int width) {
            this.alfa = alfa;
            this.h = h;
            this.width = width;
        }
        public double Alfa {
            get {
                return alfa;
            }
            set {
                if (alfa < 180 && alfa > 0) {
                    alfa = value;
                }
                else {
                    throw new Exception(@"Угол не может быть таковым");
                }
            }
        }
        public int H {
            get {
                return h;
            }
            set {
                if (h > 0) {
                    h = value;
                }
                else {
                    throw new Exception(@"Высота не может быть таковой");
                }
            }
        }
        public int Width {
            get {
                return width;
            }
            set {
                if (width > 0) {
                    width = value;
                }
                else {
                    throw new Exception(@"Ширина не может быть таковой");
                }
            }
        }
        public virtual bool isSquare {
            get {
                if (alfa == 90) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        public double Storona() {
            double storona = Math.Sin(Alfa * 0.01745329252) * H;
            return storona;
        }
        public double Area() {
            double area = H * Width;
            return area;
        }
        public virtual double Diagonal() {
            double diagonal = Width * Width + Storona() * Storona() - 2 * Width * Storona() * Math.Cos(Alfa * 0.01745329252);
            return diagonal;
        }
        public virtual double Perimetr() {
            double perimetr = Storona() * 2 + Width * 2;
            return perimetr;
        }
        public virtual void Show() {
            Console.WriteLine("Ширина равна " + Width);
            Console.WriteLine("Высота равна " + H);
            Console.WriteLine("Угол равен " + Alfa);
            Console.WriteLine($"Вторая сторона равна {Storona():F2}");
            Console.WriteLine($"Диагональ равна {Diagonal():F2}");
            Console.WriteLine($"Площадь равна {Area():F2}");
            Console.WriteLine($"Периметр равен {Perimetr():F2}");
        }
    }
    class Rectangle : Parallelogramm {
        public Rectangle(int h, int width) :
        base(90, h, width) {

        }
        public Rectangle() :
        base(90, 6, 5) {

        }
        public override double Diagonal() {
            double diag = Math.Sqrt(H * H + Width * Width);
            return diag;
        }
        public override bool isSquare {
            get {
                if (h == width) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        public override void Show() {
            base.Show();
            if (isSquare == true) {
                Console.WriteLine("Перед вами квадрат");
            }
            else {
                Console.WriteLine("Перед вами прямоугольник, не квадрат");
            }
        }
    }
    class Romb : Parallelogramm {
        public Romb(double alfa, int width) :
        base(alfa, (int)(Math.Sin(alfa * 0.01745329252) * width), width) {

        }
        public Romb() :
        base(30, (int)(0.5 * 45), 45) {

        }
        public override bool isSquare {
            get {
                if (Width == Math.Sin(Alfa * 0.01745329252) * Width) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        public override double Diagonal() {
            double diag = Width * Width + Width * Width - 2 * Width * Math.Cos((180 - Alfa) * 0.01745329252);
            return diag;
        }
        public override double Perimetr() {
            double p = 4 * Width;
            return p;
        }
        public override void Show() {
            base.Show();
            if (isSquare == true) {
                Console.WriteLine("Перед вами квадрат");
            }
            else {
                Console.WriteLine("Перед вами ромб, не квадрат");
            }
        }
    }
    class Program {
        static void Main(string[] args) {
            try {
                Parallelogramm[] par = new Parallelogramm[4];
                Console.WriteLine("Введите размерность угла");
                double alfa = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите размерность высоты");
                int h = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите размерность ширины");
                int width = int.Parse(Console.ReadLine());
                par[0] = new Rectangle();
                par[0].Show();
                Console.WriteLine();
                par[1] = new Rectangle(h, width);
                par[1].Show();
                Console.WriteLine();
                par[2] = new Romb();
                par[2].Show();
                Console.WriteLine();
                par[3] = new Romb(alfa, width);
                par[3].Show();
            }
            catch (Exception error) {
                Console.WriteLine($"Ошибка: {error.Message}");
            }
            Console.ReadKey();
        }
    }
}