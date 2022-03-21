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
        Months month;
        DaysOfWeek day;

        public MatrixWeather() {
            month = Months.Февраль;
            day = DaysOfWeek.Вт;
            temperature = new int[daysMonth[(int)month - 1] / 7 + 1, 7];
            int days = daysMonth[(int)month - 1]+(int)day-1;
            for (int i = 0; i < temperature.GetLength(0); ++i) 
                for (int j = 0; j < temperature.GetLength(1); ++j) {
                    if(days>=0) {
                        if (j < (int)day && i == 0) temperature[i, j] = NoData;
                        else 
                            temperature[i, j] = Generator((int)month);
                        --days;
                    }
                    else 
                        temperature[i, j] = NoData;
                }
        }

        public MatrixWeather(int month, int day) {
            this.month =(Months)month;
            this.day = (DaysOfWeek)day;
            temperature = new int[daysMonth[month - 1] / 7 + 1, 7];
            int days = daysMonth[month - 1] + day;
            for (int i = 0; i < temperature.GetLength(0); ++i)
                for (int j = 0; j < temperature.GetLength(1); ++j) {
                    if (days >= 0) {
                        if (j < day && i == 0) temperature[i, j] = NoData;
                        else
                            temperature[i, j] = Generator(month);
                        --days;
                    }
                    else
                        temperature[i, j] = NoData;
                }
        }

        private static int Generator(int month) {
            return rnd.Next(minTemp[month-1], maxTemp[month-1]);
        }

        public int MaximalDifference() {
            int max = temperature[0, 0], index = 0, delta = Math.Abs(temperature[0, 0] - temperature[0, 1]);
            for (int i = 0; i < temperature.GetLength(0); ++i) {
                for (int j = 1; j < 7; ++j) {
                    delta = Math.Abs(temperature[i, j] - temperature[i, j - 1]);
                    if (j <= (int)day) continue;
                    if (delta > max) {
                            max = delta;
                        
                    }
                }
            }
            return max;
        }

        public int MaximalDifference(out int dayMaximalDifference) {
            int max = temperature[0, 0], delta = Math.Abs(temperature[0, 0] - temperature[0, 1]), cnt = 1;
            for (int i = 0; i < temperature.GetLength(0); ++i) {
                for (int j = 1; j < 7; ++j) {
                    delta = Math.Abs(temperature[i, j] - temperature[i, j - 1]);
                    if (j <= (int)day) continue;
                    else {
                        if (delta > max) 
                            max = delta;
                        cnt++;
                    }
                }
            }
            dayMaximalDifference = cnt;
            return max;
        }

        public static void TemperatureOutput(ref MatrixWeather temperature) {
            int[,] array = temperature.Temperature;
            Console.WriteLine($"{(Months)temperature.Month}");
            for (DaysOfWeek i = DaysOfWeek.Пн; i <= DaysOfWeek.Вс; ++i) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{i}\t");
                Console.ResetColor();
            }
            Console.WriteLine();
            int days = 1, sum = 0;
            //for(int j=0; j<array.GetLength(1); ++j) {
            //    if (array[0, j] == NoData) ++sum;
            //}
            for (int i = 0; i < array.GetLength(0); ++i) {
                for (int j = 0; j < array.GetLength(1); ++j) {
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

        public int Month {
            get {
                return (int)month;
            }
        }

        public int Day {
            get {
                return (int)day;
            }
            set {
                if (value > 7 || value < 1) {
                    day = DaysOfWeek.Пн;
                    throw new Exception(@"Ошибка: значение дня не может быть отрицательным или больше 7. Значение дня равно 1.");
                }
                else {
                    int k;
                    if (value < (int)day) {
                        k = (int)day - value;
                        int[] tmp = new int[temperature.GetLength(0)*temperature.GetLength(1)];
                        int count = 0;
                            for (int i=0; i<temperature.GetLength(0); ++i) {
                                for(int j=0; j<temperature.GetLength(1); ++j) {
                                    tmp[count] = temperature[i, j];
                                    count++;
                                }
                            }
                        while (k >= 0) {
                            for (int i = 1; i < tmp.Length; ++i) 
                                tmp[i - 1] = tmp[i];
                            --k;
                        }
                        int cnt = 0, len = tmp.Length - 1;
                        while (tmp[len-1] == NoData) {
                            ++cnt;
                            --len;
                        }
                        int strings = temperature.GetLength(0);
                        if (cnt >= 7) 
                            --strings;
                        for (int i = 0; i < strings; ++i) 
                            for (int j = 0; j < temperature.GetLength(1); ++j) 
                                temperature[i, j] = tmp[7 * i + j];
                    }
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
                return daysMonth[(int)month - 1];
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
        static void Main(string[] args) {
            MatrixWeather temperature = new MatrixWeather();
            MatrixWeather.TemperatureOutput(ref temperature);
            Console.WriteLine("\n");
            for(Months i=Months.Январь; i<=Months.Декабрь; ++i) 
                Console.WriteLine($"{(int)i} соответсвует месяц {i}");
            Console.WriteLine();
            for(DaysOfWeek i = DaysOfWeek.Пн; i<=DaysOfWeek.Вс; ++i)
                Console.WriteLine($"{(int)i} соответсвует  {i}");
            Console.WriteLine("\n");
            byte ok =1;
            do {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
@"Задачи, которые решает данная программа:
0) Создать календарь температур с параметрами
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
                    case 0:
                        Console.Write("Введите номер дня недели (см. выше): ");
                        int day = int.Parse(Console.ReadLine());
                        Console.Write("Введите номер месяца (см. выше): ");
                        int month = int.Parse(Console.ReadLine());
                        temperature = new MatrixWeather(month, day);
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine($"День недели первого числа месяца: {temperature.Day}");
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.Write("Введите день недели первого числа месяца: ");
                        temperature.Day = int.Parse(Console.ReadLine());
                        Console.WriteLine("День недели изменен!");
                        //TemperatureOutput(ref temperature);
                        Console.WriteLine();
                        break;
                    case 3:
                        MatrixWeather.TemperatureOutput(ref temperature);
                        Console.WriteLine();
                        break;
                    case 4:
                        int[,] array = temperature.Temperature;
                        Console.WriteLine("Массив температур: ");
                        for(int i=0; i<array.GetLength(0); ++i) 
                            for(int j=0; j<array.GetLength(1); ++j) 
                                Console.Write($"{array[i, j]} ");
                            Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine($"Количество дней в месяце: {temperature.DaysInMatrix}");
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine($"Количество дней в месяце с температурой 0 градусов: {temperature.ZeroTempDays}");
                        Console.WriteLine();
                        break;
                    case 7:
                        Console.WriteLine("Температура скачка за месяц: " + temperature.MaximalDifference());
                        Console.WriteLine();
                        break;
                    case 8:
                        int dayMaximalDifference;
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
