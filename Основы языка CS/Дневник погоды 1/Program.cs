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
        static int[] daysMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static int[] minTemp = new int[] { -8, -9, -4, 2, 8, 12, 14, 13, 8, 3, -2, -6 };
        static int[] maxTemp = new int[] { -4, -3, 3, 11, 19, 22, 24, 22,16, 9, 1, -2 };
        static Random rnd = new Random();
        int[,] temperature;
        int month;
        int day;

        public MatrixWeather() {
            month = 2;
            day = 4;
            temperature = new int[daysMonth[month - 1] / 7 + 1, 7]; //daysMonth[month - 1]/7+1
            int days = daysMonth[month - 1]+day-1;
            for (int i = 0; i < temperature.GetLength(0); ++i) {
                for (int j = 0; j < temperature.GetLength(1); ++j) {
                    if(days>=0) {
                        if (j < day && i == 0) temperature[i, j] = NoData;
                        else {
                            temperature[i, j] = Generator(ref month);
                        }
                        days--;
                    }
                    else {
                        temperature[i, j] = NoData;
                    }

                }
            }
        }

        private static int Generator(ref int month) {
            return rnd.Next(minTemp[month], maxTemp[month]);
        }

        public int MaximalDiffernce() {
            int max = 0;
            for(int i=1; i<temperature.GetLength(0); ++i) {
                for(int j=0; j<temperature.GetLength(1); ++j) {
                    if (Math.Abs(temperature[i, j] - temperature[i - 1, j]) > max&&temperature[i, j]!=-1000)
                        max = Math.Abs(temperature[i, j] - temperature[i - 1, j]);
                }
            }
            return max;
        }

        public int Month {
            get {
                return month;
            }
        }

        public int Day {
            set {
                if (value > 31 || value < 1) {
                    day = 1;
                    throw new Exception(@"Ошибка: значение дня не может быть отрицательным или больше 31. Значение дня равно 1."); 
                }
                else {
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
            for (DaysOfWeek i=DaysOfWeek.Пн; i<=DaysOfWeek.Вс; ++i)
                Console.Write($"{i}\t");
            Console.WriteLine();
            for(int i=0; i<array.GetLength(0); ++i) {
                for(int j=0; j<array.GetLength(1); ++j) {
                    if (array[i, j] == -1000) Console.Write("\t");
                    else
                        Console.Write($"{array[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine(temperature.MaximalDiffernce());
        }

        static void Main(string[] args) {
            MatrixWeather temperature = new MatrixWeather();
            TemperatureOutput(ref temperature);
            Console.ReadKey();
        }
    }
}
