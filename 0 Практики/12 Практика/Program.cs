using System;

namespace _12_Практика
{
    class Point3D
    {
        int x;
        int y;
        int z;

        public Point3D()
        {
            x = 5;
            y = 10;
            z = 15;
        }

        private Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point3D Point(int x, int y, int z)
        {
            if (x % 5 == 0 || y % 5 == 0 || z % 5 == 0)
                return new Point3D(x, y, z);
            Console.WriteLine("Сработал конструктор по умолчанию.");
            return new Point3D();
        }

        public Point3D(decimal xy)
        {
            x = (int)xy;
            decimal tmp = xy - (int)xy;
            do
            {
                tmp *= 10;
            } while (tmp % (int)tmp != 0);
            y = (int)tmp;
        }

        public int setX
        {
            get { return x; }
            set { if (value >= 0) x = value; }
        }

        public int setY
        {
            get { return y; }
            set { if (value >= 0 && value < 100) y = value; else y = 100; }
        }

        public int setZ
        {
            get { return z; }
            set { if (value <= x + y) z = value; else Console.WriteLine("Z больше X+Y"); }
        }

        public void Move(char c, int s)
        {
            if (c == 'x')
                x += s;
            else if (c == 'y')
                y += s;
            else if (c == 'z')
                z += s;
        }

        public double RadiusVector()
        {
            double r = Math.Sqrt(x * x + y * y + z * z);
            return r;
        }

        public void AddDots(Point3D point2)
        {
            x += point2.x;
            y += point2.y;
            z += point2.z;
        }

        public void AddDots(int number)
        {
            x += number;
            y += number;
            z += number;
        }

        public void AddDots(int a, int b, int c)
        {
            x += a;
            y += b;
            z += c;
        }

        public bool InOutArea()
        {
            bool ok = false;
            if (y > 2 && x < 10 && x < y)
                ok = true;
            return ok;
        }
    }

    class Program
    {
        static void PrintXYZ(Point3D point)
        {
            Console.WriteLine($"X:{point.setX}, Y:{point.setY}, Z:{point.setZ}");
        }

        static void Main(string[] args)
        {
            Point3D point1 = new Point3D();
            Console.WriteLine("Введите 0 — без параметров");
            Console.WriteLine("Введите 1 — с параметрами");
            sbyte ok1 = sbyte.Parse(Console.ReadLine());
            if (ok1 == 0)
            {
                point1 = new Point3D();
                PrintXYZ(point1);
            }
            else if (ok1 == 1)
            {
                Console.WriteLine("Ввод даблом x,y (через запятую) - 1 или ввод отдельно x, y, z - 0");
                sbyte doubleorint = sbyte.Parse(Console.ReadLine());
                if (doubleorint == 1)
                {
                    decimal axises = decimal.Parse(Console.ReadLine());
                    point1 = new Point3D(axises);
                }
                else
                {
                    Console.Write("Введите координату по OX: ");
                    int x1 = int.Parse(Console.ReadLine());
                    Console.Write("Введите координату по OY: ");
                    int y1 = int.Parse(Console.ReadLine());
                    Console.Write("Введите координату по OZ: ");
                    int z1 = int.Parse(Console.ReadLine());
                    point1 = new Point3D();
                    point1.setX = x1;
                    point1.setY = y1;
                    point1.setZ = z1;
                }
                Console.WriteLine("Введите 0 — не сдвигать");
                Console.WriteLine("Введите 1 — сдвигать");
                int ok2 = int.Parse(Console.ReadLine());
                if (ok2 == 1)
                {
                    Console.WriteLine("Введите название оси (x, y, z)");
                    char c = char.Parse(Console.ReadLine());
                    Console.WriteLine("Расстояние");
                    int s = int.Parse(Console.ReadLine());
                    point1.Move(c, s);
                }
                PrintXYZ(point1);
                double radius1 = point1.RadiusVector();
                Console.WriteLine($"Длина радиус вектора: {radius1:F2}");

                Point3D point2 = new Point3D();
                Console.WriteLine("Ввод даблом x,y (через запятую) - 1 или ввод отдельно x, y, z - 0");
                doubleorint = sbyte.Parse(Console.ReadLine());
                if (doubleorint == 1)
                {
                    decimal axises = decimal.Parse(Console.ReadLine());
                    point2 = new Point3D(axises);
                }
                else
                {
                    Console.Write("Введите координату по OX: ");
                    int x2 = int.Parse(Console.ReadLine());
                    Console.Write("Введите координату по OY: ");
                    int y2 = int.Parse(Console.ReadLine());
                    Console.Write("Введите координату по OZ: ");
                    int z2 = int.Parse(Console.ReadLine());
                    point2 = new Point3D();
                    point2.setX = x2;
                    point2.setY = y2;
                    point2.setZ = z2;
                }
                PrintXYZ(point2);
                double radius2 = point2.RadiusVector();
                Console.WriteLine($"Длина радиус вектора второй точки: {radius2:F2}");
                Console.WriteLine("Если хотите сложить точку с точкой - 0, с другой точкой - 1 с числом - любая другая цифра");
                sbyte ok3 = sbyte.Parse(Console.ReadLine());
                if (ok3 == 0)
                {
                    point1.AddDots(point2);
                    Console.WriteLine("Сложение двух точек");
                    PrintXYZ(point1);
                }
                else if (ok3 == 1)
                {
                    Console.WriteLine("Введите координаты точки с которой хотите сложить первую точку");
                    int xX = int.Parse(Console.ReadLine());
                    int yY = int.Parse(Console.ReadLine());
                    int zZ = int.Parse(Console.ReadLine());
                    point1.AddDots(xX, yY, zZ);
                    PrintXYZ(point1);
                }
                else
                {
                    Console.WriteLine("Введите число на которое хотите увеличить каждую кооридинату");
                    int Number = int.Parse(Console.ReadLine());
                    point1.AddDots(Number);
                    PrintXYZ(point1);
                }
                if (point1.InOutArea())
                    Console.WriteLine("Точка находится в области");
                else
                    Console.WriteLine("Точка вне области");
                Console.WriteLine("Введите координаты так чтобы хотя бы одна из них была кратна пяти.");
                Console.Write("Введите координату по OX: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OY: ");
                int y = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OZ: ");
                int z = int.Parse(Console.ReadLine());
                Point3D point4 = Point3D.Point(x, y, z);
                PrintXYZ(point4);
            }
            Console.ReadKey();
        }
    }
}