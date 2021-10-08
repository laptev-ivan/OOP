using System;
using System.Text;

namespace _3._1_Практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Таблица Пифагора");
            int j = 1, j1 = 1;
            while (j <= 10)
            {
                for (int i = 2; i < 6; ++i)
                {
                    Console.Write($"{i} × {j} = {i * j}\t");
                }
                Console.WriteLine();
                j++;
            }
            Console.WriteLine();
            while (j1 <= 10)
            {
                for (int i = 6; i < 10; ++i)
                {
                    Console.Write($"{i} × {j1} = {i * j1}\t");
                }
                Console.WriteLine();
                j1++;
            }

        }
    }
}
