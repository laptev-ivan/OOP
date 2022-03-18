using System;

namespace Геометрическая_фигура
{
    class Cuboid
    {
        int a; //длина
        int b; //ширина
        int h; //высота (ребро)
        int x;
        int y;
        public readonly bool cube = false;

        public Cuboid()
        {
            a = 5;
            b = 5;
            h = 5;
            x = y = 0;
        }

        private Cuboid(int a, int b, int h, int x, int y)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            this.x = x;
            this.y = y;
        }

        public static Cuboid CreateCuboid(Cuboid figure)
        {
            Console.WriteLine("Если Вы хотите ввести размеры прямоугольника - введите \'y\', иначе нажмите любую другую клавишу");
            char c;
            char.TryParse(Console.ReadLine(), out c);
            try
            {
                if (c == 'y')
                {
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
                }
                else if (c == 'n')
                {
                    figure = new Cuboid();
                    Console.WriteLine("Сработал конструктор по умолчанию");
                }
                else throw new Exception(@"неправильная буква");
            }
            catch(Exception error)
            {
                Console.WriteLine("Ошибка: " + error.Message);
            }
            return figure;
        }

        public int setgetA
        {
            get { return a; }
            set
            {
                if (value < 0)
                {
                    a = 1;
                    throw new Exception(@"длина не может быть меньше нуля, значение 1.");
                }
                else a = value;
            }
        }

        public int setgetB
        {
            get { return b; }
            set
            {
                if (value < 0)
                {
                    b = 1;
                    throw new Exception(@"ширина не может быть меньше нуля, значение 1.");
                }
                else b = value;
            }
        }

        public int setgetH
        {
            get { return h; }
            set
            {
                if (value < 0)
                {
                    h = 1;
                    throw new Exception(@"высота не может быть меньше нуля, значение 1.");
                }
                else h = value;
            }
        }

        public int setgetX
        {
            get { return x; }
            set { x = value; }
        }

        public int setgetY
        {
            get { return y; }
            set { y = value; }
        }

        public bool getCube
        {
            get
            {
                if (Volume() == 1)
                    return true;
                else
                    return false;
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
                x += s;
            else if (axis == 'y')
                y += s;
        }

        public Cuboid Matching (Cuboid cuboid)
        {
            int x1 = x;
            int y1 = y + b;
            int y2 = y;
            int x2 = x + a;
            int x3 = cuboid.setgetX;
            int y3 = cuboid.setgetY + cuboid.setgetB;
            int y4 = cuboid.setgetY;
            int x4 = cuboid.setgetX + cuboid.setgetA;
            int left = Math.Max(x1, x3);
            int top = Math.Min(y2, y4);
            int right = Math.Min(x2, x4);
            int bottom = Math.Max(y1, y3);

            int width = left-right;
            int height = bottom-top;

            cuboid.setgetA = Math.Abs(width);
            cuboid.setgetB = Math.Abs(height);
            return cuboid;
        }

    }

    class Program
    {
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
            Cuboid figure = new Cuboid();
            figure = Cuboid.CreateCuboid(figure);
            
            Console.WriteLine();
            Output(figure);

            int surface = figure.Surface();
            Console.WriteLine($"Площадь боковой поверхности параллелипипеда: {surface}");

            int volume = figure.Volume();
            Console.WriteLine($"Объем параллелипипеда: {volume}");

            Console.WriteLine("Если хотите переместить по оси - 1, иначе - 0");
            sbyte ok1;
            sbyte.TryParse(Console.ReadLine(), out ok1);
            try
            {
                if (ok1 == 1)
                {
                    Console.WriteLine("Перемещение по OX (x) или OY (y)?");
                    char axis = char.Parse(Console.ReadLine());
                    Console.WriteLine($"Введите расстояние, на которое сдвинуть параллелипипед по оси {axis}");
                    int s = int.Parse(Console.ReadLine());
                    figure.Move(axis, s);
                }
                Console.WriteLine("Если хотите изменить параметры прямоугольника - 1, иначе - 0");
                sbyte ok2;
                sbyte.TryParse(Console.ReadLine(), out ok2);
                try
                {
                    if (ok2 == 1)
                    {
                        Console.WriteLine("Введите параметр, который хотите изменить (a, b, h)");
                        char param = char.Parse(Console.ReadLine());
                        Console.WriteLine($"Введите число, на которое хотите поменять параметр");
                        char s;
                        char.TryParse(Console.ReadLine(), out s);
                        try
                        {
                            if (param == 'a')
                            {
                                figure.setgetA = s;
                            }
                            else if (param == 'b')
                            {
                                figure.setgetB = s;
                            }
                            else if (param == 'h')
                            {
                                figure.setgetH = s;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка: введено неверное значение");
                            return;
                        }
                    }
                    if(figure.getCube==true)
                        Console.WriteLine("Это куб.");
                    else Console.WriteLine("Это не куб.");
                    
                }
                catch
                {
                    Console.WriteLine("Ошибка: введено неверное значение");
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Ошибка: введено неверное значение");
                return;
            }
            finally
            {
                Console.WriteLine("\nВсе ок.\n");
            }
            Output(figure);
            Cuboid figure2 = new Cuboid();
            figure2 = Cuboid.CreateCuboid(figure2);
            Cuboid answerFig = new Cuboid();
            answerFig= figure.Matching(figure2);
            Output(answerFig);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}