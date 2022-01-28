using System;

namespace _11_Практика
{    enum Months
    {
        январь = 1,
        февраль,
        март,
        апрель,
        май,
        июнь,
        июль,
        август,
        сентябрь,
        октябрь,
        ноябрь,
        декабрь,
    };
    enum Seasons { Зима, Весна, Лето, Осень };
    class Program
    {
        static void Main(string[] args)
        {
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for (Months i = Months.январь; i <= Months.декабрь; i++)
            {
                Console.WriteLine($"Месяц: \"{i}\", соответсвует числу {(int)i}");
            }
            Console.WriteLine();
            Console.WriteLine("Введите номер месяца:"); int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите номер дня:"); int d = int.Parse(Console.ReadLine());
            Console.WriteLine("Сколько дней  нужно отсчитать?"); int t = int.Parse(Console.ReadLine());
            int r = days[n - 1];
            days[n - 1] -= d;
            for (int i = n - 1; i < i + 1; ++i)
            {
                if (i >= days.Length) i = 0;
                if (t >= days[i])
                {
                    t -= days[i];
                    days[n - 1] = r;
                }
                else
                {
                    ++i;
                    Console.WriteLine($"{(Seasons)(i % 12 / 3)}!");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
