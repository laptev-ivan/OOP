using System;

namespace Побитовые_операции
{
    class Program
    {
        static int masking(ushort x1, int i)
        {
            int mask = 1;
            mask <<= i;
            if ((x1 & mask) != 0)
                return 1;
            else
                return 0;
        }

        static int masking1(short x2, int i)
        {
            int mask = 1;
            mask <<= i;
            if ((x2 & mask) != 0)
                return 1;
            else
                return 0;
        }

        static void binary_code(ushort x1)
        {
            int count = 0;
            for (int i = 15; i >= 0; --i)
            {
                if (masking(x1, i) == 0)
                    count++;
            }
            Console.WriteLine($"Кол-во нулевых бит числа x1: {count}");
        }

        static void no_zeros(short x2)
        {
            for (int i = 15; i >= 0; --i)
            {
                while (masking1(x2, i) != 0)
                {
                    Console.Write($"{masking1(x2, i)}");
                }
            }   
        }

        static void bit_mask(ushort x1, ushort n)
        {

            x1 = (ushort)((x1 >> n) | (x1 << (0xF - n)));
            Console.Write($"Циклический сдвиг на {n} число x1: ");
            for (int i = 15; i >= 0; --i)
            {
                Console.Write(masking(x1, i));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите x1:\t"); ushort x1 = ushort.Parse(Console.ReadLine());
            Console.WriteLine("Введите n:\t"); ushort n = ushort.Parse(Console.ReadLine());
            Console.WriteLine("Введите x2:\t"); short x2 = short.Parse(Console.ReadLine());
            binary_code(x1);
            no_zeros(x2);
            bit_mask(x1, n);
            Console.ReadKey();
        }
    }
}
