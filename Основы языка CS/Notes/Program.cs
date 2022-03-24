using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp40 {
    enum Months { Январь = 1, Февраль, Март, Апрель, Май, Июнь, Июль, Август, Сентябрь, Октябрь, Ноябрь, Декабрь };
    class Weather1 {
        int[] temperature;
        int date;
        int month;
        static Random a = new Random();
        static int[] minTemp = new int[] { -10, -9, -3, 1, 6, 13, 13, 13, 6, 2, -5, -8 };
        static int[] maxTemp = new int[] { -6, -1, 5, 13, 17, 21, 24, 21, 15, 8, 3, 0 };
        public Weather1() {
            date = 20;
            month = 1;
            temperature = new int[] { -5, -2, 0, 3, -9, -15, -12, -6, 2 };
        }
        public Weather1(int date, int month) {
            if (date >= 1 && date <= 31) {
                this.date = date;
            }
            else {
                throw new Exception("Был введён несуществующий день");
            }
            this.month = month;
            temperature = Random(ref month);
        }
        public int Kolvodays {
            get {
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {
                    return 31;
                }
                else if (month == 4 || month == 6 || month == 9 || month == 11) {
                    return 30;
                }
                else {
                    return 28;
                }
            }
        }
        public int Date {
            get {
                return date;
            }
            set {
                Array.Clear(temperature, date, value - date);
                value = date;
            }
        }
        public int Months {
            get {
                return month;
            }
        }
        public int Hottest {
            get {
                int max = temperature[0];
                foreach (int temp in temperature) {
                    if (temp > max) {
                        max = temp;
                    }
                }
                return max;
            }
        }
        public int Coldest {
            get {
                int min = temperature[0];
                foreach (int temp in temperature) {
                    if (temp < min) {
                        min = temp;
                    }
                }
                return min;
            }
        }
        public int Changing {
            get {
                int count = 0;
                for (int i = 0; i < temperature.Length - 1; ++i) {
                    if (Math.Sign(temperature[i]) != Math.Sign(temperature[i + 1])) {
                        count++;
                    }
                }
                return count;
            }
        }
        public int[] Temperature {
            get {
                return temperature;
            }
        }
        public double average() {
            double sum = 0;
            for (int i = 0; i < temperature.Length; ++i) {
                sum += temperature[i];
            }
            double result = sum / temperature.Length;
            return result;
        }
        private int[] Random(ref int month) {
            int[] temperature = new int[Kolvodays - Date + 1];
            for (int i = 0; i < temperature.Length; i++) {
                temperature[i] = a.Next(minTemp[month - 1], maxTemp[month - 1]);
            }
            return temperature;
        }
        private double Delta() {
            double delta = 0;
            double max = 0;
            for (int i = 0; i < temperature.Length; ++i) {
                delta = Math.Abs((double)temperature[i] - average());
                if (delta > max) {
                    max = delta;
                }
            }
            return delta;
        }
        public int Den() {
            int count = 0;
            double[] razn = new double[temperature.Length];
            double aver = average();
            double d = Delta();
            int[] tempermax = new int[temperature.Length];
            for (int i = 0; i < temperature.Length; ++i) {
                razn[i] = Math.Abs(temperature[i] - aver);
            }
            for (int i = 0; i < razn.Length; ++i) {
                if (razn[i] == d) {
                    return i + date;
                }
            }
            return 0;
        }
        public int Den(out int[] tempermax) {
            int count = 0;
            double[] razn = new double[temperature.Length];
            double aver = average();
            double d = Delta();
            tempermax = new int[temperature.Length];
            int result = 0;
            for (int i = 0; i < temperature.Length; ++i) {
                razn[i] = Math.Abs(temperature[i] - aver);
            }
            for (int i = 0; i < razn.Length; ++i) {
                if (razn[i] == d) {
                    tempermax[count] = i + date;
                    ++count;
                    if (result < i + date) {
                        result = i + date;
                    }
                }
            }
            return result;
        }
    }
    class Program {
        static void OutPut(Weather1 weather) {
            int[] temperature = weather.Temperature;
            Console.Write("Дата\t\t");
            for (int i = 0, den = weather.Date; den <= weather.Kolvodays; ++i) {
                Console.Write($"{den}.{weather.Months}\t");
                den++;
            }
            Console.WriteLine("\n");
            Console.Write("Температура\t");
            for (int i = 0; i < temperature.Length; ++i) {
                Console.Write($"{temperature[i]}\t");
            }
            int[] array = new int[0];
            Console.WriteLine("\n");
            Console.WriteLine($"Средняя температура за месяц\t{weather.average():F2}");
            Console.WriteLine("День, в который температура максимально отклонилась от средней температуры в месяце\t" + weather.Den());
            weather.Den(out array);
            foreach (int elemnt in array) {
                    if(elemnt!=0)
                Console.Write($"{elemnt} ");
            }
        }
        static void Main(string[] args) {
            Console.WriteLine("Если хотите ввести данные с клавиатуры, нажмите 0, если хотите использовать конструктор по умолчанию - любое другое число");
            try {
                int proverka = int.Parse(Console.ReadLine());
                if (proverka == 0) {
                    try {
                        Console.WriteLine("Введите дату ");
                        int date = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите месяц ");
                        int month = int.Parse(Console.ReadLine());
                        Weather1 weather = new Weather1(date, month);
                        OutPut(weather);
                    }
                    catch (Exception error) {
                        Console.WriteLine("Ошибка: " + error.Message);
                    }
                }
                else {
                    Weather1 weather = new Weather1();
                    OutPut(weather);
                }
            }
            catch (Exception error) {
                Console.WriteLine("Ошибка: " + error.Message);
            }
            Console.ReadKey();
        }
    }
}