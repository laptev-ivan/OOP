using System;

namespace Dwarfs
{
    class Program
    {
        static void FunctionFor16Bits(ref short order1, int myHat, int cnt, int hint)
        {
            Console.WriteLine("Введите число, двоичный код которого представляет гномов:");
            order1 = short.Parse(Console.ReadLine());
            Console.WriteLine("Гномы:");
            for (int i = 0; i <= 15; ++i)
            {
                if ((order1 & (1 << i)) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('0');
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('1');
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            if ((order1 & 2) == 0)
            {
                Console.WriteLine("1-й гном сказал: \"Я в зеленой шапке.\"");
                Console.WriteLine($"1-й гном ошибся и не получил ни одной монеты. Общий счет гномов: {cnt}");
            }
            else
            {
                Console.WriteLine("1-й гном сказал: \"Я в красной шапке.\"");
                Console.WriteLine($"1-й гном ошибся и не получил ни одной монеты. Общий счет гномов: {cnt}");
            }
            for (int i = 1; i <= 15; ++i)
            {
                if ((order1 & (1 << i + 1)) == 0) //узнаем бит след
                    hint = 0;
                else
                    hint = 1;
                if ((order1 & (1 << i)) == 0) //узнаем наш
                    myHat = 0;
                else
                    myHat = 1;
                cnt++;
                if (hint != myHat)
                {
                    if (myHat == 0)
                    {
                        Console.WriteLine($"{i + 1}-й гном сказал: \"Я в зеленой шапке.\"");
                        Console.WriteLine($"{i + 1}-й гном угадал и получил монету. Общий подсчет монет: {cnt}");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}-й гном сказал: \"Я в красной шапке.\"");
                        Console.WriteLine($"{i + 1}-й гном угадал и получил монету. Общий подсчет монет: {cnt}");
                    }
                }
                else if (myHat == 0)
                {
                    Console.WriteLine($"{i + 1}-й гном сказал: \"Я в зеленой шапке.\"");
                    Console.WriteLine($"{i + 1}-й гном угадал и получил монету. Общий подсчет монет: {cnt}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}-й гном сказал: \"Я в красной шапке.\"");
                    Console.WriteLine($"{i + 1}-й гном угадал и получил монету. Общий подсчет монет: {cnt}");
                }
            }
        }
        static void FunctionFor32Bits(ref int order2, int myHat, int cnt, int hint)
        {
            Console.WriteLine("Введите число, двоичный код которого представляет гномов:");
            order2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Гномы:");
            for (int i = 0; i <= 31; ++i)
            {
                if ((order2 & (1 << i)) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('0');
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('1');
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            if ((order2 & 2) == 0)
            {
                Console.WriteLine("1-й гном сказал: \"Я в зеленой шапке.\"");
                Console.WriteLine($"1-й гном ошибся и не получил ни одной монеты. Общий счет гномов: {cnt}");
            }
            else
            {
                Console.WriteLine("1-й гном сказал: \"Я в красной шапке.\"");
                Console.WriteLine($"1-й гном ошибся и не получил ни одной монеты. Общий счет гномов: {cnt}");
            }
            for (int i = 1; i <= 31; i++)
            {

                if ((order2 & (1 << i + 1)) == 0)
                    hint = 0;
                else
                    hint = 1;
                if ((order2 & (1 << i)) == 0)
                    myHat = 0;
                else
                    myHat = 1;
                cnt++;
                if (hint != myHat)
                {
                    if (myHat == 0)
                    {
                        Console.WriteLine($"{i + 1}-й гном сказал: \"Я в зеленой шапке.\"");
                        Console.WriteLine($"{i + 1}-й гном угадал и получил монету. Общий подсчет монет: {cnt}");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}-й гном сказал: \"Я в красной шапке.\"");
                        Console.WriteLine($"{i + 1}-й гном угадал и получил монету. Общий подсчет монет: {cnt}");
                    }
                }
                else if (myHat == 0)
                {
                    Console.WriteLine($"{i + 1}-й гном сказал: \"Я в зеленой шапке и угадал.\"");
                    Console.WriteLine($"{i + 1}-й гном угадал и получил монету. Общий подсчет монет: {cnt}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}-й гном сказал: \"Я в красной шапке и угадал.\"");
                    Console.WriteLine($"{i + 1}-й гном угадал и получил монету. Общий подсчет монет: {cnt}");
                }
            }
        }
        static void Main(string[] args)
        {

            int order2 = 0, hint = 0, myHat = 0, cnt = 0;
            short order1 = 0;
            Console.WriteLine("Введите число гномов (16 или 32):");
            int numOfDwarfs = int.Parse(Console.ReadLine());
            while((numOfDwarfs==16||numOfDwarfs==32)==false)
            {
                Console.WriteLine("Ошибка: введенное число должно быть равно 16 или 32. Повторите ввод:");
                numOfDwarfs = int.Parse(Console.ReadLine());
            }
            if(numOfDwarfs==16)
                FunctionFor16Bits(ref order1, myHat, cnt, hint);
            else
                FunctionFor32Bits(ref order2, myHat, cnt, hint);
            Console.ReadKey();
        }
    }
}
