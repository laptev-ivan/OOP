using System;

namespace _12_Практика
{
    class Point3D
    {
        public int x;
        public int y;
        public int z;

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
            if (ok1==0)
            {
                Point3D point1 = new Point3D();
                point1.PrintXYZ();
            }
            else if(ok1==1)
            {
                Console.Write("Введите координату по OX: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OY: ");
                int y = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OZ: ");
                int z = int.Parse(Console.ReadLine());
                Point3D point2 = new Point3D(x, y, z);
                Console.WriteLine("Введите 0 — не сдвигать");
                Console.WriteLine("Введите 1 — сдвигать");
                int ok2 = int.Parse(Console.ReadLine());
                if(ok2==1)
                {
                    Console.WriteLine("Введите название оси (x, y, z)"); 
                    char c = char.Parse(Console.ReadLine());
                    Console.WriteLine("Расстояние");
                    int s = int.Parse(Console.ReadLine());
                    point2.Move(c, s);
                }
                point2.PrintXYZ();
            }
            Console.ReadKey();
        }
    }
}
