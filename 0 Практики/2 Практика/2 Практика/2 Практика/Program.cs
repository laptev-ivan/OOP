using System;
using System.Text;

namespace _2._1_практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Введите дальность выстрела:\t");
            int bullet = int.Parse(Console.ReadLine());
            if (bullet >= 28)
            {
                if (bullet < 30)
                    Console.WriteLine("ПОПАЛ!");
                else
                    Console.WriteLine("ПЕРЕЛЕТ");
            }
            else if (bullet <= 0)
                Console.WriteLine("Не бей по своим!");

            Console.ReadKey();
        }
    }
}