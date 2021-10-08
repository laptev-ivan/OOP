using System;

namespace _2._2_практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число:\t");
            int number = int.Parse(Console.ReadLine());
            string answer = number >= 0 ? number <= 9 ? "ДА" : "НЕТ" : "НЕТ";
            Console.WriteLine($"Ответ: {answer}");

            Console.ReadKey();
        }
    }
}