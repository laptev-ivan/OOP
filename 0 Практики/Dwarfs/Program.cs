using System;

namespace Dwarfs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число гномов (16 или 32)");
            int numOfDwarfs = int.Parse(Console.ReadLine());
            while(!(numOfDwarfs==16||numOfDwarfs==32))
            {
                Console.WriteLine("Ошибка: введите число гномов (16 или 32)");
                numOfDwarfs = int.Parse(Console.ReadLine());
            }
            int cnt = 0;
            short order1;
            int order2;
            int hint = 0;
            int myHat = 0;
            if(numOfDwarfs==16)
            {
                Console.WriteLine("Введите число, задающее представление гномов");
                order1 = short.Parse(Console.ReadLine());
                Console.Write("Представление гномов - ");
                for(int i=0; i<16; ++i)
                {
                    if ((order1 & (1 << i)) == 0)
                        Console.Write("0");
                    else
                        Console.Write("1");
                }
                Console.WriteLine();
                if ((order1 & 2) == 0)
                    Console.WriteLine("Первый гном сказал. На мне зеленая шапка если честно  нам без разницы, что говорит первый гном, он просто...");
                else
                    Console.WriteLine("Первый гном сказал. На мне красная шапка ...");
                for(int i=1; i<16; ++i)
                {
                    if ((order1 & (1 << i + 1)) == 0)
                        hint = 0;
                    else
                        hint = 1;
                    if ((order1 & (1 << i)) == 0)
                        myHat = 0;
                    else
                        myHat = 1;
                    cnt++;
                    if(hint!=myHat)
                    {
                        if (myHat == 0)
                            Console.WriteLine($"{i + 1} - й гном сказал. На мне зеленая шапка и угадал, общий счет - {cnt}");
                        else
                            Console.WriteLine($"{i+1} - й гном сказал. На мне красная шапка и угадал, общий счет - {cnt}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ввдетие число, задающее представление гномов");
                order2 = int.Parse(Console.ReadLine());
                Console.Write("Представление гномов - ");
                for(int i=0; i<32; ++i)
                {
                    if ((order2 & (1 << i)) == 0)
                        Console.Write("0");
                    else
                        Console.Write("1");
                }
            }
            Console.ReadKey();
        }
    }
}
