using System;

namespace Поиск_min_max_последовательности
{
    class Program
    {
        static uint myFunc(uint n)
        {
            Console.Write("Введите значение a:\t"); uint a = uint.Parse(Console.ReadLine());
            Console.Write("Введите значение b:\t"); uint b = uint.Parse(Console.ReadLine());
            uint mn = a * b;
            for (int i = 0; i < n - 1; ++i)
            {
                Console.Write("Введите значение a:\t"); uint a1 = uint.Parse(Console.ReadLine());
                Console.Write("Введите значение b:\t"); uint b1 = uint.Parse(Console.ReadLine());
                if (a1 * b1 < mn) mn = a1 * b1;
            }
            return mn;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите значение N:\t");
            uint n = uint.Parse(Console.ReadLine());
            Console.WriteLine($"Самая минимальная площадь прямоугольника:\t{myFunc(n)}");

            Console.ReadKey();
        }
    }
}
