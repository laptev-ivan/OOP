using System;

namespace _4_практика
{
    class Program
    {
        static int max(int a, int b)
        {
            return a > b ? a : b;
        }
        static int min(int a, int b, int c)
        {
            if (a < b)
            {
                if (a < c) return a;
                else return c;
            }
            else return b;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите значение a:\t");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение b:\t");
            int b = int.Parse(Console.ReadLine());
            int result = max((int)Math.Pow(min(a + 1, Math.Abs(b - a), a * b), 2), 2 / a * b) * min(a, b, max(0, -b)) + 2 * max(a, 3 + a * b);
            Console.WriteLine($"Ответ на задачу:\t{result}");
            
            Console.ReadKey();
        }
    }
}
