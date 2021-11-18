using System;

namespace _6_Практика
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a = 9;
            uint b = 2;
            Console.WriteLine($"Побитовое \"И\":\t{a & b}");
            Console.WriteLine($"Побитовое \"ИЛИ\":\t{a|b}");
            Console.WriteLine($"Побитовое \"исключающее ИЛИ\":\t{a^b}");
            Console.WriteLine($"Инверсия a:\t{~a}");
            Console.WriteLine($"Инверсия b:\t{~b}");
            Console.WriteLine($"Побитовый сдвиг влево a на 1 бит:\t{a<<1}");
            Console.WriteLine($"Побитовый сдвиг вправо b на 2 бит:\t{b>>2}");
            Console.ReadKey();
        }
    }
}
