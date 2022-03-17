using System;

namespace Дневник_погоды_1
{
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
        static int[] daysMonth = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static Random rnd = new Random();
        int[,] temperature;
        int month;
        int day;

        public MatrixWeather() {
            int month = 3;
            int day = 5;
            temperature = new int[daysMonth[month - 1]/7, 7];
            for (int i = 0; i < temperature.GetLength(0); ++i) {
                for (int j = 0; j < temperature.GetLength(1); ++j) {
                    if (j < day && i==0) temperature[i, j] = NoData;
                    else temperature[i, j] = rnd.Next(-11, 9);
                }
            }
        }

        public int Month {
            get {
                return month;
            }
        }

        public int Day {
            set {
                while (value - day >= 0) {
                    int tmp1 = temperature[0, 0], tmp2 = temperature[0, 1];
                    for (int i = 0; i < temperature.GetLength(0) - 2; ++i) {
                        for (int j = 0; j < temperature.GetLength(1) - 2; ++j) {
                            temperature[i, j] = temperature[i, j + 2];
                        }
                    }
                    temperature[temperature.GetLength(0), temperature.GetLength(1) - 2] = tmp1;
                    temperature[temperature.GetLength(0), temperature.GetLength(1) - 1] = tmp2;
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
                return temperature.Length;
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
            for (DaysOfWeek i=DaysOfWeek.Пн; i<DaysOfWeek.Вс; ++i)
                Console.Write($"{i} ");
            Console.WriteLine();
            for(int i=0; i<array.GetLength(0); ++i) {
                for(int j=0; j<array.GetLength(1); ++j) {
                    Console.Write($"{array[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args) {
            MatrixWeather temperature = new MatrixWeather();
            TemperatureOutput(ref temperature);
            Console.ReadKey();
        }
    }
}
