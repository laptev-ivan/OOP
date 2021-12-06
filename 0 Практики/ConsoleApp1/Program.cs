using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ГНОМЫ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число гномов (16 или 32)");
            int numberOfDwarfs = int.Parse(Console.ReadLine());
            while (!(numberOfDwarfs == 16 || numberOfDwarfs == 32))
            {
                Console.WriteLine("Ошибка: введите число гномов (16 или 32)");
                numberOfDwarfs = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("0 - зеленые шапки, 1 - красные");
            int COUNT = 0;
            short Poryadok1;
            int Poryadok2;
            int hint = 0;
            int Mynym = 0;
            if (numberOfDwarfs == 16)
            {
                Console.WriteLine("Введите число, задающее представление гномов");
                Poryadok1 = short.Parse(Console.ReadLine());
                Console.Write("Представление гномов - ");
                for (int i = 0; i < 16; i++)
                {
                    if ((Poryadok1 & (1 << i)) == 0)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write("1");
                    }
                }
                Console.WriteLine();
                if ((Poryadok1 & 2) == 0)
                {
                    Console.WriteLine("Первый гном сказал: На мне зеленая шапка  если честно нам без разницы, что говорит первый гном, он просто называет цвет второго, так что его голос мы не учитываем :-)");
                }
                else
                {
                    Console.WriteLine("Первый гном сказал: На мне красная шапка     если честно нам без разницы, что говорит первый гном, он просто называет цвет второго, так что его голос мы не учитываем :-)");
                }
                for (int i = 1; i < 16; i++)
                {

                    if ((Poryadok1 & (1 << i + 1)) == 0)
                    {
                        hint = 0;
                    }
                    else
                    {
                        hint = 1;
                    }
                    if ((Poryadok1 & (1 << i)) == 0)
                    {
                        Mynym = 0;
                    }
                    else
                    {
                        Mynym = 1;
                    }

                    COUNT++;
                    if (hint != Mynym)
                    {
                        if (Mynym == 0)
                        {
                            Console.WriteLine($"{i + 1} - й гном сказал: На мне зеленая шапка и угадал, общий счет - {COUNT}");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1} - й гном сказал: На мне красная шапка и угадал, общий счет - {COUNT}");
                        }
                    }
                    else if (Mynym == 0)
                    {
                        Console.WriteLine($"{i + 1} - й гном сказал: Я в зеленой шапке и угадал, общий счет - {COUNT}");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1} - й гном сказал: Я в красной шапке и угадал, общий счет - {COUNT}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Введите число, задающее представление гномов");
                Poryadok2 = int.Parse(Console.ReadLine());
                Console.Write("Представление гномов - ");
                for (int i = 0; i < 32; i++)
                {
                    if ((Poryadok2 & (1 << i)) == 0)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        Console.Write("1");
                    }
                }
                Console.WriteLine();
                if ((Poryadok2 & 2) == 0)
                {
                    Console.WriteLine("Первый гном сказал: На мне зеленая шапка  если честно нам без разницы, что говорит первый гном, он просто называет цвет второго, так что его голос мы не учитываем :-)");
                }
                else
                {
                    Console.WriteLine("Первый гном сказал: На мне красная шапка     если честно нам без разницы, что говорит первый гном, он просто называет цвет второго, так что его голос мы не учитываем :-)");
                }
                for (int i = 1; i < 32; i++)
                {

                    if ((Poryadok2 & (1 << i + 1)) == 0)
                    {
                        hint = 0;
                    }
                    else
                    {
                        hint = 1;
                    }
                    if ((Poryadok2 & (1 << i)) == 0)
                    {
                        Mynym = 0;
                    }
                    else
                    {
                        Mynym = 1;
                    }

                    COUNT++;
                    if (hint != Mynym)
                    {
                        if (Mynym == 0)
                        {
                            Console.WriteLine($"{i + 1} - й гном сказал: На мне зеленая шапка и угадал, общий счет - {COUNT}");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1} - й гном сказал: На мне красная шапка и угадал, общий счет - {COUNT}");
                        }
                    }
                    else if (Mynym == 0)
                    {
                        Console.WriteLine($"{i + 1} - й гном сказал: Я в зеленой шапке и угадал, общий счет - {COUNT}");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1} - й гном сказал: Я в красной шапке и угадал, общий счет - {COUNT}");
                    }
                }
            }




            Console.WriteLine("секрет гномов: первый гном называет цвет второго, каждый последующий если цвет следующего отличается от его(свой он знает от прошлого) начинает свою фразу с .НА МНЕ. если же цвет шапки следующего такой же, то он начинает свою фразу с .Я В.");
            Console.ReadKey();
        }
    }
}