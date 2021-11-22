using System;

namespace _6._2_Практика
{
    class Program
    {
        static int print(int x, int n)
        {
            int mask = 1 << n;
            if ((x & mask) != 0)
                return 1;
            else
                return 0;
        }

        static void translate(int x)
        {
            for (int i = 31; i >= 0; --i)
            {
                Console.Write(print(x, i));
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите x:\t"); int x = int.Parse(Console.ReadLine());
            translate(x);
            Console.ReadKey();
        }
    }
}
