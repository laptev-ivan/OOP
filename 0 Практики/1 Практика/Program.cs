using System;
using System.Text;

namespace _1_практика
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            string s = "AMD";
            float f1 = 3.20000f;
            int p = 16;
            float p1 = 0.78932597f;
            float s1 = 4f;
            double r = 64.100d;
            float pr = 100000000000f;
            decimal dec = 18500.5m;

            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите дробное число: ");
            float f = float.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"Привет, {name}!");
            Console.WriteLine("*********************************\n" +
                              "*\tЯ твой компьютер!\t*\n" +
                              "*********************************\n\n" +
                              "У меня следующие характеристики:\n" + 
                              $"Процессор\t{s} с разрядностью {f1:F2}GHz\n" +
                              $"Моя память\t{p}Gb (доступно {p1:P0})\n" +
                              $"Жесткий диск\t{s1*1024:E2} Gb\n" +
                              $"Тип системы\t{r:F0}-разрядная ОС\n\n\n" +
                              $"Моя производительность\t{pr:G2} оп/сек\n" +
                              $"Индекс произв-ти\t{f:F0}\n" +
                              $"Моя стоимость\t\t{dec:C}");

            Console.ReadKey();
        }
    }
}