using System;

namespace _2._4_Практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение a:\t");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение b:\t");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Введите значение c:\t");
            int c = int.Parse(Console.ReadLine());
            string answer = a == b ? a == c ? c == b ? "ДА" : "НЕТ" : "НЕТ" : "НЕТ";

            Console.WriteLine($"Ответ: {answer}");
            Console.ReadKey();
        }
    }
}
