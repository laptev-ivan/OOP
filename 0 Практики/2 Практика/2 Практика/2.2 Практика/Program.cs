using System;
using System.Text;

namespace _2._2_практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Введите число:\t");
            byte number = byte.Parse(Console.ReadLine());
            string answer = number <= 9 ? "ДА" : "НЕТ";
            Console.WriteLine($"Ответ: {answer}");

            Console.ReadKey();
        }
    }
}