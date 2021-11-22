using System;

namespace _7_Практика
{
    class Program
    {
        static void sumOfDigits(ref int a, ref int b)
        {
            int copy_a = a;
            a = a + b;
            b = copy_a - b;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите значение a: "); int a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение b: "); int b = int.Parse(Console.ReadLine());
            sumOfDigits(ref a, ref b);
            Console.WriteLine($"Значение a: {a}");
            Console.WriteLine($"Значение b: {b}");
            Console.ReadKey();
        }
    }
}
