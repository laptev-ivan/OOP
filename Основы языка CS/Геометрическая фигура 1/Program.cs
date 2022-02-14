using System;

namespace Геометрическая_фигура
{
    class Program
    {
        class Cuboid
        {
            private int a; //длина
            private int b; //ширина
            private int h; //высота
            private int c; //боковое ребро

            public Cuboid(int A, int B, int H, int C)
            {
                a = A;
                b = B;
                h = H;
                c = C;
            }

            public int Surface()
            {
                return 2 * (a + b) * c;
            }

            public int Volume()
            {
                return a * b * h;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите длину: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите ширину: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Введите высоту: ");
            int h = int.Parse(Console.ReadLine());
            Console.Write("Введите боковое ребро: ");
            int c = int.Parse(Console.ReadLine());

            Cuboid figure = new Cuboid(a, b, h, c);

            int surface = figure.Surface();
            Console.WriteLine($"Площадь боковой поверхности параллелипипеда: {surface}");

            int volume = figure.Volume();
            Console.WriteLine($"Объем параллелипипеда: {volume}");

            Console.ReadKey();
        }
    }
}