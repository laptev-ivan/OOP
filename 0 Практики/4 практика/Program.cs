using System;

namespace _4_Практика
{
    class Program
    {
        static double max(double a, double b)
        {
            return a > b ? a : b;
        }
        static double min(double a, double b, double c)
        {
            double mn = a;
            if (b < mn) mn = b;
            if (c < mn) mn = c;
            return mn;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите значение a:\t");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение b:\t");
            int b = int.Parse(Console.ReadLine());
            if (a == 0 || b == 0)
                Console.WriteLine("Ошибка: деление на ноль.");
            else
            {
                double result = max(Math.Pow(min(a + 1, Math.Abs(b - a), a * b), 2), 2.0 / a * b) * min(a, b, max(0, -b)) + 2 * max(a, 3 + a * b);
                Console.WriteLine($"Ответ на задачу:\t{result:f2}");
            }

            Console.ReadKey();
        }
    }
}