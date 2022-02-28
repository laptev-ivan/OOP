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


            public int setgetA
            {
                get
                {
                    return a;
                }
                set
                {
                    if (value < 0)
                        a = 1;
                    else
                        a = value;
                }
            }

            public int setgetB
            {
                get
                {
                    return b;
                }
                set
                {
                    if (value < 0)
                        b = 1;
                    else
                        b = value;
                }
            }

            public int setgetH
            {
                get
                {
                    return h;
                }
                set
                {
                    if (value < 0)
                        h = 1;
                    else
                        h = value;
                }
            }

            public int setgetX
            {
                get
                {
                    return x;
                }
                set
                {
                    x = value;
                }
            }

            public int setgetY
            {
                get
                {
                    return y;
                }
                set
                {
                    y = value;
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
            Console.WriteLine($"Длина прямоугольного параллелепипеда: {figure.setgetA}");
            Console.WriteLine($"Ширина прямоугольного параллелепипеда: {figure.setgetB}");
            Console.WriteLine($"Высота прямоугольного параллелепипеда: {figure.setgetH}");
            Console.WriteLine($"X-координата прямоугольного параллелепипеда: {figure.setgetX}");
            Console.WriteLine($"Y-координата прямоугольного параллелепипеда: {figure.setgetY}");
        }

        static void Main(string[] args)
        {
            Cuboid figure;
            Console.WriteLine("Если Вы хотите ввести размеры прямоугольника - введите \'y\', иначе нажмите любую другую клавишу");
            char c = char.Parse(Console.ReadLine());
            if (c == 'y')
            {
                figure = new Cuboid();
                Console.Write("Введите длину: ");
                figure.setgetA = int.Parse(Console.ReadLine());
                Console.Write("Введите ширину: ");
                figure.setgetB = int.Parse(Console.ReadLine());
                Console.Write("Введите высоту: ");
                figure.setgetH = int.Parse(Console.ReadLine());
                Console.Write("Введите начальную координату для OX: ");
                figure.setgetX = int.Parse(Console.ReadLine());
                Console.Write("Введите начальную координату для OY: ");
                figure.setgetY = int.Parse(Console.ReadLine());
                Console.WriteLine();
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
            sbyte ok1 = sbyte.Parse(Console.ReadLine());
            if (ok1 == 1)
            {
                Console.WriteLine("Перемещение по OX (x) или OY (y)?");
                char axis = char.Parse(Console.ReadLine());
                Console.WriteLine($"Введите расстояние, на которое сдвинуть параллелипипед по оси {axis}");
                int s = int.Parse(Console.ReadLine());
                figure.Move(axis, s);
            }
            Console.WriteLine("Если хотите изменить параметры прямоугольника - 1, иначе - 0");
            sbyte ok2 = sbyte.Parse(Console.ReadLine());
            if(ok2==1)
            {
                Console.WriteLine("Введите параметр, который хотите изменить (a, b, h)");
                char param = char.Parse(Console.ReadLine());
                Console.WriteLine($"Введите число, на которое хотите поменять параметр");
                int s = int.Parse(Console.ReadLine());
                if(param=='a')
                {
                    figure.setgetA = s;
                }
                else if (param == 'b')
                {
                    figure.setgetB = s;
                }
                else if (param = 'h')
                {
                    figure.setgetH = s;
                }
            }
            Output(figure);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}