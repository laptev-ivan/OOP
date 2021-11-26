using System;

namespace _7_Практика
{
    class Program
    {
        static void incPar(ref int x1, int x2)
        {
            int cnt = 0;
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
            Console.Write("Введите параметр для второй задачи: "); int c = int.Parse(Console.ReadLine());
            incPar(ref a, b);
            divPar(ref c);
            Console.WriteLine($"Первое число: {a}");
            Console.WriteLine($"Второе число: {c}");
            Console.ReadKey(); 
        }
    }
}
