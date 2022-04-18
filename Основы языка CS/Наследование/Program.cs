using System;

namespace Наследование
{
    enum Type {
        Седан,
        Купе,
        Хэчбек,
        Универсал,
        Кабриолет
    };

    class Transport {
        protected string name;
        protected int capacity;
        protected int volume;

        public Transport() {
            name = "Псевдомашина";
            capacity = 100;
            volume = 50;
        }

        public Transport(string name, int capacity, int volume) {
            this.name = name;
            this.capacity = capacity;
            this.volume = volume;
        }

        public string GetName {
            get {
                return name;
            }
        }

        public int GetDistance {
            get {
                return volume / capacity;
            }
        }

        public double Essential(int distance) {
            return distance * capacity / 100f;
        }

        protected void Show() {
            Console.WriteLine($"Имя: {name}\nРасход: {capacity} литров на 100 км\nЕмкость: {volume}");
        }
    }

    class Automobile : Transport {
        Type type;
        int passangers;

        public Automobile() : base() {
            type = (Type)1;
            passangers = 3;
        }

        public Automobile(Type type, int passangers) : base() {
            this.type = type;
            this.passangers = passangers;
        }

        public Automobile(string name, int capacity, int volume, Type type, int passangers) : base(name, capacity, volume) {
            this.type = type;
            this.passangers = passangers;
        }

        public int Pas {
            get {
                return passangers;
            }
            set {
                if (value > 5) {
                    passangers = 5;
                    throw new Exception(@"кол-во пассажиров не может быть больше пяти (значение 5).");
                }
                else if (value < 0) { 
                    passangers = 1;
                    throw new Exception(@"кол-во пассажиров не может быть меньше нуля (значение 1).");
                }
                passangers = value;
            }
        }

       

        public int Percent {
            get {
                return 100 * passangers / 5;
            }
        }

        new public void Show() {
            base.Show();
            Console.WriteLine($"Тип автомобиля: {type}\nКол-во пассажиров: {passangers}");
        }
    }

    class HeavyCar : Transport {
        int heaviness;
        int gruz200;

        public HeavyCar() : base() {
            heaviness = 2000;
            gruz200 = 40;
        }

        public HeavyCar(int heaviness, int gruz200) : base() {
            if (heaviness < gruz200) {
                this.gruz200 = 40;
                throw new Exception(@"реальный груз больше возможного (значение - 40).");
            }
            this.heaviness = heaviness;
            this.gruz200 = gruz200;
        }

        public HeavyCar(string name, int capacity, int volume, int heaviness, int gruz200) : base(name, capacity, volume) {
            this.heaviness = heaviness;
            this.gruz200 = gruz200;
        }

        new public double Essential(int distance) {
            return base.Essential(distance) + gruz200 / 10f;
        }

        public int Gruz {
            get {
                return gruz200;
            }
            set {
                if (heaviness < value) {
                    gruz200 = 40;
                    throw new Exception(@"реальный груз больше возможного (значение - 40).");
                }
                gruz200 = value;
            }
        }

        new public int Percent() {
            return 100 * gruz200 / 5;
        }

        new public void Show() {
            base.Show();
            Console.WriteLine($"Грузоподъемность: {heaviness}\nМасса груза: {gruz200}");
        }
    }

    class Bus : Transport {
        int passengers;
        int price;
        
        public Bus() : base() {
            passengers = 15;
            price = 33;
        }

        public Bus(int passengers, int price) : base() {
            if (passengers > 60) {
                passengers = 60;
                throw new Exception(@"пассажиров не может быть больше 60 (значение 60).");
            }
            else if (passengers < 0) {
                passengers = 0;
                throw new Exception(@"пассажиров не может быть меньше 0 (значение 0).");
            }
            this.passengers = passengers;
            this.price = price;
        }

        public Bus(string name, int capacity, int volume, int passengers, int price) : base(name, capacity, volume) {
            this.passengers = passengers;
            this.price = price;
        }

        new public int Capacity(int time) {
            if (time > 20 && time < 24) {
                return 100;
            }
            return 50;
        }

        public int Percent {
            get {
                return passengers * 100 / 60;
            }
        }

        public int Earn {
            get {
                return passengers * price;
            }
        }

        new public void Show() {
            base.Show();
            Console.WriteLine($"Кол-во пассажиров: {passengers}\nЦена билета: {price}");
        }
    }

    class Program {
        static void Main(string[] args) {
            try {
                for (Type i = Type.Седан; i < Type.Кабриолет; ++i) 
                    Console.WriteLine($"Тип {i} - соответствует числу {(int)i}");
                Console.WriteLine("\n");
                Console.WriteLine("ЛЕГКОВЫЕ АВТОМОБИЛИ");
                Automobile[] automobiles = new Automobile[] { new Automobile(), new Automobile((Type)1, 3), new Automobile("Мерседес", 20, 40, (Type)2, 2) };
                foreach (Automobile automobile in automobiles) {
                    automobile.Show();
                    int distance;
                    Console.Write("Дистанция: ");
                    int.TryParse(Console.ReadLine(), out distance);
                    double essential = automobile.Essential(distance);
                    int passengers;
                    Console.Write("Кол-во пассажиров: ");
                    int.TryParse(Console.ReadLine(), out passengers);
                    automobile.Pas = passengers;
                    Console.WriteLine($"Необходимо топлива: {essential:F2}\nПроцент загрузки: {automobile.Percent}\nКол-во пассажиров: {automobile.Pas}");
                    Console.WriteLine();
                }
                Console.WriteLine("\n");
                Console.WriteLine("ГРУЗОВЫЕ АВТОМОБИЛИ");
                HeavyCar[] heavyCars = new HeavyCar[] { new HeavyCar(), new HeavyCar(1000, 300), new HeavyCar("ВАЗ", 50, 100, 1500, 500) };
                foreach (HeavyCar car in heavyCars) {
                    car.Show();
                    int distance;
                    Console.Write("Дистанция: ");
                    int.TryParse(Console.ReadLine(), out distance);
                    double essential = car.Essential(distance);
                    int percent = car.Percent();
                    int gruz;
                    Console.Write("Масса груза: ");
                    int.TryParse(Console.ReadLine(), out gruz);
                    car.Gruz = gruz;
                    Console.WriteLine($"Необходимо топлива: {essential:F2}\nПроцент загрузки{percent}\nМасса груза: {car.Gruz}");
                    Console.WriteLine();
                }
                Bus[] buses = new Bus[] { new Bus(), new Bus(30, 100), new Bus("Жигули", 30, 100, 50, 38) };
                Console.WriteLine("АВТОБУСЫ");
                foreach (Bus bus in buses) {
                    bus.Show();
                    int distance;
                    Console.Write("Дистанция: ");
                    int.TryParse(Console.ReadLine(), out distance);
                    double essential = bus.Essential(distance);
                    Console.WriteLine($"Необходимо топлива: {essential:F2}\nПроцент загрузки: {bus.Percent}\nВыручка: {bus.Earn}");
                    Console.WriteLine();
                }
            }
            catch (Exception error) {
                Console.WriteLine($"Ошибка: {error.Message}");
            }
            Console.ReadKey();
        }
    }
}
