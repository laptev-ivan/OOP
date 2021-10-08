using System;

namespace Точка_в_заштрихованной_области
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение x:\t");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите значение y:\t");
            double y = double.Parse(Console.ReadLine());
            double answer = 0;
            if (x >= -1)
                if (x <= 1)
                    if (y >= -2)
                        if (y <= 1)
                            if (y <= -x)
                                if (y <= x)
                                    answer = x + Math.Sqrt(Math.Pow(y * x, 4));
                                else
                                    answer = Math.Abs(Math.Pow(x, 2) - Math.Pow(y, 3));
            Console.WriteLine($"Ответ:\t{answer:f2}");

            Console.ReadKey();

        }
    }
}