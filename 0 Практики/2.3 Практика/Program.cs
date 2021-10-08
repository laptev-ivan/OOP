using System;
using System.Text;

namespace _2._3_практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.Write("Введии значение a:\t");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение b:\t");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Введите значение c:\t");
            int c = int.Parse(Console.ReadLine());
            int D = b * b - 4 * a * c;
            switch(Math.Sign(D))
            {
                case 1: // (D>0)
                    Console.WriteLine($"Уравнение с коэффициентами {a}, {b}, {c} имеет два корня");
                    break;
                case -1: // (D<0)
                    Console.WriteLine($"Уравнение с коэффициентами {a}, {b}, {c} не имеет корней");
                    break;
                default: // (D==0)
                    Console.WriteLine($"Уравнение с коэффициентами {a}, {b}, {c} имеет один корень");
                    break;
            }

            Console.ReadKey();
        }
    }
}