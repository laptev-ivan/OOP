using System;



namespace Геометрическая_фигура

{

    class Program

    {

        class Cuboid

        {

            private int a;

            private int b;

            private int h;

            private int x;

            private int y;

            public Cuboid()
            {
                a = 7;
                b = 6;
                h = 5;
                x = 0;
                y = 0;
            }
            public Cuboid(int a, int b, int h, int x, int y)

            {

                this.a = a;

                this.b = b;

                this.h = h;

                this.x = x;

                this.y = y;

            }

            public void PrintXYZ()
            {
                Console.WriteLine($"Длина:{a}, Ширина:{b}, Высота:{h}, координата х:{x}, координата y:{y}");
            }

            public int Plochad()

            {

                return 2 * (a + b) * h;

            }



            public int Objem()

            {

                return a * b * h;

            }

            public void Move(char c, int s)
            {
                if (c == 'x')
                    x += s;
                else if (c == 'y')
                    y += s;
            }
            public void ChangeSize(char c, int s)
            {
                if (c == 'a')
                    a += s;
                else if (c == 'b')
                    b += s;
                else
                {
                    h += s;
                }
            }

        }



        static void Main(string[] args)

        {
            Cuboid figure = new Cuboid();
            Console.WriteLine("если хотите ввести данные вручную введите 1 иначе 0");
            int ahah = int.Parse(Console.ReadLine());
            if (ahah == 1)
            {
                Console.Write("Введите длину: ");

                int a = int.Parse(Console.ReadLine());

                Console.Write("Введите ширину: ");

                int b = int.Parse(Console.ReadLine());

                Console.Write("Введите высоту: ");

                int h = int.Parse(Console.ReadLine());

                Console.Write("Введите начальную координату икс: ");

                int x = int.Parse(Console.ReadLine());

                Console.Write("Введите начальную координату игрик: ");

                int y = int.Parse(Console.ReadLine());
                figure = new Cuboid(a, b, h, x, y);
            }
            else
            {
                Console.WriteLine("cработал конструктор по умолчанию");
                figure = new Cuboid();
            }
            figure.PrintXYZ();





            int surface = figure.Plochad();

            Console.WriteLine($"Площадь боковой поверхности параллелипипеда: {surface}");



            int volume = figure.Objem();

            Console.WriteLine($"Объем параллелипипеда: {volume}");


            Console.WriteLine("Введите по какой оси хотите сдвинуть параллелепипед (х и у)");
            char answ = char.Parse(Console.ReadLine());
            Console.WriteLine("Введите насколько хотите сдвинуть");
            int sdvig = int.Parse(Console.ReadLine());
            figure.Move(answ, sdvig);
            figure.PrintXYZ();

            Console.WriteLine("Введите что хотите изменить длина - а, ширина - b, высота - h");
            answ = char.Parse(Console.ReadLine());
            Console.WriteLine("Введите насколько хотите изменить размер стороны");
            sdvig = int.Parse(Console.ReadLine());
            figure.ChangeSize(answ, sdvig);
            figure.PrintXYZ();


            Console.ReadKey();

        }

    }

}