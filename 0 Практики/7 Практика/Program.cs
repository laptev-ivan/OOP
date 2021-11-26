using System;

namespace _7_Практика
{
    class Program
    {
        static void incPar(ref int x1, ref int x2)
        {
            double cnt = 0f;
            while (x2 > 9)
            {
                x2 /= 10;
                ++cnt;
            }
            for (int i = 0; i < cnt; ++i)
                x1 *= 10;
        }
        static void divPar(ref int x1)
        {
            int del = 1;
            for (int i = 1; i < x1; ++i)
                if (x1 % i == 0)
                    if (i > del)
                        del = i;
            x1 = del;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите первый параметр: "); int a = int.Parse(Console.ReadLine());
            Console.Write("Введите второй параметр: "); int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите c: "); int c = int.Parse(Console.ReadLine());
            incPar(ref a, ref b);
            divPar(ref c);
            Console.WriteLine(a);
            Console.WriteLine(c);
            Console.ReadKey(); 
        }
    }
}
