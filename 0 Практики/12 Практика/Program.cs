using System;

namespace _12_Практика
{
    class Point3D
    {
        private int x;
        private int y;
        private int z;

        public Point3D()
        {
            x = y = z = 0;
        }

        public Point3D(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
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

        public void PrintXYZ()
        {
            Console.WriteLine($"X:{x}, Y:{y}, Z:{z}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 0 — без параметров");
            Console.WriteLine("Введите 1 — с параметрами");
            int ok1 = int.Parse(Console.ReadLine());
            if (ok1 == 0)
            {
                Point3D point1 = new Point3D();
                point1.PrintXYZ();
            }
            else if (ok1 == 1)
            {
                Console.Write("Введите координату по OX: ");
                int x1 = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OY: ");
                int y1 = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OZ: ");
                int z1 = int.Parse(Console.ReadLine());
                Point3D point1 = new Point3D(x1, y1, z1);
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
                point1.PrintXYZ();
                double radius1 = point1.RadiusVector();
                Console.WriteLine($"Длина радиус вектора: {radius1:F2}");
                Console.Write("Введите координату по OX для второй точки: ");
                int x2 = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OY для второй точки: ");
                int y2 = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OZ для второй точки: ");
                int z2 = int.Parse(Console.ReadLine());
                Point3D point2 = new Point3D(x2, y2, z2);
                double radius2 = point2.RadiusVector();
                Console.WriteLine($"Длина радиус вектора второй точки: {radius2:F2}");
                point1.AddDots(point2);
                point1.PrintXYZ();
            }
            Console.ReadKey();
        }
    }
}

