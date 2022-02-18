using System;

namespace Геометрическая_фигура
{
    class Program
    {
        class Cuboid
        {
            int a; //длина
            int b; //ширина
            int h; //высота (ребро)
            int x;
            int y; 

            public Cuboid()
            {
                a = 5;
                b = 5;
                h = 5;
                x = y = 0;
            }

            public Cuboid(int a, int b, int h, int x, int y)
            {
                this.a = a;
                this.b = b;
                this.h = h;
                this.x = x;
                this.y = y; 
            }

            public int getA
            {
                get
                {
                    return a;
                }
            }

            public int getB
            {
                get
                {
                    return b;
                }
            }

            public int getH
            {
                get
                {
                    return h;
                }
            }

            public int getX
            {
                get
                {
                    return x;
                }
            }

            public int getY
            {
                get
                {
                    return y;
                }
            }

            public int Surface()
            {
                return 2 * (a + b) * h;
            }

            public int Volume()
            {
                return a * b * h;
            }

            public void Move(char axis, int s)
            {
                if (axis == 'x')
                {
                    x += s;
                }
                else if (axis == 'y')
                {
                    y += s;

                }
            }
        }

        static void Output(Cuboid figure)
        {
            Console.WriteLine($"Длина прямоугольного параллелепипеда: {figure.getA}");
            Console.WriteLine($"Ширина прямоугольного параллелепипеда: {figure.getB}");
            Console.WriteLine($"Высота прямоугольного параллелепипеда: {figure.getH}");
            Console.WriteLine($"X-координата прямоугольного параллелепипеда: {figure.getX}");
            Console.WriteLine($"Y-координата прямоугольного параллелепипеда: {figure.getY}");
        }

        static void Main(string[] args)
        {
            Cuboid figure;
            Console.WriteLine("Если Вы хотите ввести размеры прямоугольника - введите \'y\', иначе нажмите любую другую клавишу");
            char c = char.Parse(Console.ReadLine());
            if (c == 'y')
            {
                Console.Write("Введите длину: ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("Введите ширину: ");
                int b = int.Parse(Console.ReadLine());
                Console.Write("Введите высоту: ");
                int h = int.Parse(Console.ReadLine());
                Console.Write("Введите начальную координату для OX: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Введите начальную координату для OY: ");
                int y = int.Parse(Console.ReadLine());
                Console.WriteLine();
                figure = new Cuboid(a, b, h, x, y);
            }
            else
            {
                figure = new Cuboid();
                Console.WriteLine("Сработал конструктор по умолчанию");
            }
            Output(figure);
            int surface = figure.Surface();
            Console.WriteLine($"Площадь боковой поверхности параллелипипеда: {surface}");

            int volume = figure.Volume();
            Console.WriteLine($"Объем параллелипипеда: {volume}");

            Console.WriteLine("Если хотите переместить по оси - 1, иначе - 0");
            sbyte ok = sbyte.Parse(Console.ReadLine());
            if (ok == 1)
            {
                Console.WriteLine("Перемещение по OX (x) или OY (y)?");
                char axis = char.Parse(Console.ReadLine());
                Console.WriteLine($"Введите расстояние, на которое сдвинуть параллелипипед по оси {axis}");
                int s = int.Parse(Console.ReadLine());
                figure.Move(axis, s);
            }
            Output(figure);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}