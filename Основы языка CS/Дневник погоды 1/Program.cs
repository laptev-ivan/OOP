using System;

namespace Дневник_погоды_1 {
    enum Months {
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
        Декабрь
    };

    enum DaysOfWeek {
        Пн,
        Вт,
        Ср,
        Чт, 
        Пт,
        Сб,
        Вс
    };

    class MatrixWeather {
        static int[] daysMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static int[] minTemp = new int[] { -15, -9, -4, 2, 8, 12, 14, 13, 8, 3, -2, -6 };
        static int[] maxTemp = new int[] { 2, -3, 3, 11, 19, 22, 24, 22, 16, 9, 1, -2 };
        static Random rnd = new Random();
        int[,] temperature;
        int month;
        int day;

        public MatrixWeather() {
            month = 2;
            day = 4;
            temperature = new int[daysMonth[month - 1] / 7 + 1, 7]; //daysMonth[month - 1]/7+1
            int days = daysMonth[month - 1]+day-1;
            for (int i = 0; i < temperature.GetLength(0); ++i) 
                for (int j = 0; j < temperature.GetLength(1); ++j) {
                    if(days>=0) {
                        if (j < day && i == 0) temperature[i, j] = NoData;
                        else 
                            temperature[i, j] = Generator(ref month);
                        --days;
                    }
                    else 
                        temperature[i, j] = NoData;
                }
        }

        private static int Generator(ref int month) {
            return rnd.Next(minTemp[month], maxTemp[month]);
        }

        public int MaximalDifference(out int dayMaximalDifference) {
            int max = temperature[0, 0], index = 0, delta = Math.Abs(temperature[0, 0] - temperature[0, 1]), cnt = 1;
            for (int i = 0; i < temperature.GetLength(0); ++i) {
                for (int j = 1; j < 7; ++j) {
                    delta = Math.Abs(temperature[i, j] - temperature[i, j - 1]);
                    if (j <= day) continue;
                    else {
                        if (delta > max) {
                            max = delta;
                        }
                        cnt++;
                    }
                }
            }
            dayMaximalDifference = cnt;
            return max;
        }

        public int Month {
            get {
                return month;
            }
        }

        public int Day {
            get {
                return day;
            }
            set {
                if (value > 7 || value < 1) {
                    day = 1;
                    throw new Exception(@"Ошибка: значение дня не может быть отрицательным или больше 31. Значение дня равно 1.");
                }
                else {
                    int k = day - value;
                    
                }
            }
        }

        public int[,] Temperature {
            get {
                return temperature;
            }
        }

        public int DaysInMatrix {
            get {
                return daysMonth[month - 1];
            }
        }

        public int ZeroTempDays {
            get {
                int days = 0;
                foreach(int temp in temperature) 
                    if (temp == 0)
                        ++days;
                return days;
            }
        }

        public static int NoData {
            get {
                return -1000;
            }
        }
    }

    class Program
    {
        static void TemperatureOutput(ref MatrixWeather temperature) {
            int[,] array = temperature.Temperature;
            Console.WriteLine($"{(Months)temperature.Month}");
            for (DaysOfWeek i = DaysOfWeek.Пн; i <= DaysOfWeek.Вс; ++i) {
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.Write($"{i}\t");
                Console.ResetColor();
            }
            Console.WriteLine();
            int days = 1;
            for(int i=0; i<array.GetLength(0); ++i) {
                for(int j=0; j<array.GetLength(1); ++j) {
                    if (array[i, j] == -1000) Console.Write("\t");
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (days < 10) Console.Write($"0{days} ");
                        else Console.Write($"{days} ");
                        Console.ResetColor();
                        Console.Write($"{array[i, j]}\t");
                        days++;
                    }
                }
                Console.WriteLine();
                
            }
        }

        static void Main(string[] args) {
            MatrixWeather temperature = new MatrixWeather();
            TemperatureOutput(ref temperature);
            Console.WriteLine("\n");

            byte ok=1;
            do {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
@"Задачи, которые решает данная программа:
1) Вывести на экран день недели первого числа месяца
2) Изменить день недели первого числа месяца
3) Вывести на экран месяц
4) Вывести на экран массив со всей температурой
5) Вывести на экран количество дней в месяце
6) Вывести на экран количество дней в месяце с температурой 0 градусов
7) Вывести на экран максимальный скачок температуры за месяц
8) Вывести на экран максимальный скачок температуры за месяц с номером дня и температурой до скачка
9) Закрыть программу
");
                Console.ResetColor();
                Console.Write("Выберете действие: ");
                ok = byte.Parse(Console.ReadLine());
                switch (ok) {
                    case (1):
                        Console.WriteLine($"День недели первого числа месяца: {temperature.Day}");
                        Console.WriteLine();
                        break;
                    case (2):
                        Console.Write("Введите день недели первого числа месяца: ");
                        temperature.Day = int.Parse(Console.ReadLine());
                        Console.WriteLine("День недели изменен!");
                        Console.WriteLine();
                        break;
                    case (3):
                        TemperatureOutput(ref temperature);
                        Console.WriteLine();
                        break;
                    case (4):
                        int[,] array = temperature.Temperature;
                        Console.WriteLine("Массив температур: ");
                        for(int i=0; i<array.GetLength(0); ++i) {
                            for(int j=0; j<array.GetLength(1); ++j) {
                                Console.Write($"{array[i, j]} ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        break;
                    case (5):
                        Console.WriteLine($"Количество дней в месяце: {temperature.DaysInMatrix}");
                        Console.WriteLine();
                        break;
                    case (6):
                        Console.WriteLine($"Количество дней в месяце с температурой 0 градусов: {temperature.ZeroTempDays}");
                        Console.WriteLine();
                        break;
                    case (7):
                        int dayMaximalDifference;
                        Console.WriteLine("Температура скачка за месяц: " + temperature.MaximalDifference(out dayMaximalDifference));
                        Console.WriteLine();
                        break;
                    case (8):
                        Console.WriteLine("Температура скачка за месяц: " + temperature.MaximalDifference(out dayMaximalDifference));
                        Console.WriteLine($"Номер дня: {dayMaximalDifference}");
                        Console.WriteLine();
                        break;
                }
            } while (ok != 9);
            Console.WriteLine("Конец программы!");
            Console.ReadKey();
        }
    }
}
