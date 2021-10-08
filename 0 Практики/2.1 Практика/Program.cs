using System;

namespace _2._1_практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите дальность выстрела:\t");
            int bullet = int.Parse(Console.ReadLine());
            if(bullet > 0) 
            { 
                if(bullet <= 28)
                    Console.WriteLine("НЕДОЛЕТ");

            }
           else if(bullet > 28)
                {
                    if(bullet >= 30)
                        Console.WriteLine("ПЕРЕЛЕТ");
                    else
                        Console.WriteLine("ПОПАЛ!");
                }
           else
                Console.WriteLine("Не бей по своим!");

            Console.ReadKey();
        }
    }
}