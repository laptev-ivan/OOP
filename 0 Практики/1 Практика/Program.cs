using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11практика
{
    enum Months
    {
        Январь = 1,
        Февраль,
        Март,
        Апрель,
        Май,
        Июнь,
        Июль,
        Август,
        Сентябрь,
        Октябрь,
        Ноябрь,
        Декабрь,
    }
    enum Seasons
    {
        Зима, Весна, Лето, Осень
    }
    class Program
    {
        static void Info(int[] arr)
        {
            for (Months i = Months.Январь; i <= Months.Декабрь; i++)
            {
                Console.WriteLine($"Месяц:{i}, номер:{(int)i}, количество дней:{arr[(int)i - 1]}");
            }
        }
        static void SFiguration(int N, int n, int d, int[] NoD)
        {

            int r = NoD[N - 1];
            NoD[N - 1] -= n;
            for (int i = N - 1; i < i + 1; i++)
            {
                if (i >= NoD.Length) i = 0;
                if (d >= NoD[i])
                {
                    d -= NoD[i];
                    NoD[N - 1] = r;
                }
                else
                {
                    Console.WriteLine($"{(Seasons)((i % 12) / 3)}!");
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            int[] NoD = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Info(NoD);
            Console.Write("Введите номер месяца:"); int N = int.Parse(Console.ReadLine());
            Console.Write("Введите номер дня:"); int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество дней, которые нужно отсчитать:"); int d = int.Parse(Console.ReadLine());
            SFiguration(N, n, d, NoD);
            Console.ReadKey();
        }
    }
}