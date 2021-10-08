using System;

namespace _1_Приветствие
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("What's your name?");
            string s = Console.ReadLine();
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine($"Hello, {s}!");
            }
            Console.ReadKey();
        }
    }
}