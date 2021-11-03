using System;

namespace _5._3_Пракитка
{
    class Program
    {
        static int GCD(int a, int b)
        {
            while(a-b!=0)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите p:\t"); int p = int.Parse(Console.ReadLine());
            Console.Write("Введите q:\t"); int q = int.Parse(Console.ReadLine());
            Console.Write("Делители q, взаимно простые с p: ");
            
            for(int i=1; i<=q; ++i)
            {
                if (q % i == 0)
                {
                    int NOD = GCD(p, i);
                    if(NOD==i)
                        Console.Write($"{i} ");
                }
                        
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}