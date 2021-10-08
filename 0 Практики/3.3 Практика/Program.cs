using System;

namespace _3._3_Практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N:\t");
            double n = double.Parse(Console.ReadLine());
            double s = 1;
            for(int i=1; i<n; ++i)
                s += 1/i;
            Console.WriteLine($"а) Расстояние после N-ого этапа:\t{1/n:f2} км");
            Console.WriteLine($"б) Общий путь:\t{s:f2} км");

            Console.ReadKey();
        }
    }
}
