using System;

namespace Выражения
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение a: "); int a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение b: "); int b = int.Parse(Console.ReadLine());
            Console.Write("Введите значение c: "); int c = int.Parse(Console.ReadLine());

            double result = (double) (a + c) / (b + a) + Math.Pow((Math.Sin(b) + a), 1.0 / 3) + Math.Pow(c, 2);

            Console.WriteLine($"Результат выражения = {result:f2}");

            Console.ReadKey();
        }
    }
}
