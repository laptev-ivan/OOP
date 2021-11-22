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

        static int maskingShort(short x2, int i)
        {
            int mask = 1;
            mask <<= i;
            if ((x2 & mask) != 0)
                return 1;
            else
                return 0;
        }

        static void binaryCode(ushort x1)
        {
            int count = 0;
            for (int i = 15; i >= 0; --i)
            {
                if (masking(x1, i) == 0)
                    count++;
            }
            Console.WriteLine($"Кол-во нулевых бит числа x1: {count}");
        }

        static void noZeros(short x2)
        {
            bool f = false;
            for (int i = 15; i >= 0; --i)
            {
                if (maskingShort(x2, i) == 1)
                {
                    Console.Write(1);
                    f=true;
                }
                else if(f==true)
                    Console.Write(0);
            }   
        }

        static void bitMask(ushort x1, ushort n)
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
            binaryCode(x1);
            noZeros(x2);
            bitMask(x1, n);
            Console.ReadKey();
        }
    }
}
