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
        public Weather1() {

            date = 20;
            month = 1;
            temperature = new int[] { -5, -2, 0, 3, -9, -15, -12, -6, 2 };
        }
        public Weather1(int date, int month) {
            this.date = date;
            this.month = month;
            temperature = Random();

        }
        public int Kolvodays {
            get {
                return temperature.Length;
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
        public void OutPut() {
            int den = date;
            Console.WriteLine("Дата\t\t ");
            for (int i = 0; i < date; ++i) {
                Console.Write($"{den}.{month}\t");
                den++;
            }
            Console.WriteLine("\n");
            Console.WriteLine("Средняя температура за месяц");
            double sum = 0;
            for (int i = 0; i < temperature.Length; ++i) {
                sum += temperature[i];
                
            }
            double result = sum / temperature.Length;
            Console.WriteLine($"{result:f2}");
        }
        public static int[] Random() {
            int[] temperature = new int[] { a.Next(-5, 15), a.Next(-5, 15), a.Next(-5, 15), a.Next(-5, 15), a.Next(-5, 15), a.Next(-5, 15), a.Next(-5, 15), a.Next(-5, 15), a.Next(-5, 15) };
            return temperature;
        }

    }
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Введите дату ");
            int date = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите месяц ");
            int month = int.Parse(Console.ReadLine());
            Weather1 weather = new Weather1(date, month);
            weather.OutPut();
            Console.ReadKey();
        }
    }
}