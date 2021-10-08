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
            if (D == 0)
                D = 0;
            else if (D > 0)
                D = 1;
            else
                D = -1;
            switch (D)
            {
                case 1:
                    Console.WriteLine($"Уравнение с коэффициентами {a}, {b}, {c} имеет два корня");
                    break;
                case 0:
                    Console.WriteLine($"Уравнение с коэффициентами {a}, {b}, {c} имеет один корень");
                    break;
                case -1:
                    Console.WriteLine($"Уравнение с коэффициентами {a}, {b}, {c} не имеет корней");
                    break;
            }

            Console.ReadKey();
        }
    }
}