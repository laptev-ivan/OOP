using System;

namespace _5._1_Практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение A:\t"); int a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение B:\t"); int b = int.Parse(Console.ReadLine());
            int answer = a % b;
            Console.WriteLine($"Ответ:\t{answer}");
            Console.ReadKey();
        }
    }
}