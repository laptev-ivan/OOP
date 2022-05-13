using System;

namespace Работа_с_иерархией_классов_в_форме {
    enum Type {
        Полный_привод,
        Задний_привод,
        Передний_привод
    };

    abstract class GruzovoeTransportnoeSredstvo {
        protected string name;
        protected int weight;
        protected int pwrReserve; //запасХода
        protected int capacity; //грузоподъемность
        protected int cargoWeight; //массаГруза

        protected GruzovoeTransportnoeSredstvo() {
            name = "ВАЗ";
            weight = 7653;
            pwrReserve = 26;
            capacity = 349;
            cargoWeight = 237;
        }

        protected GruzovoeTransportnoeSredstvo(string name, int weight, int pwrReserve, int capacity, int cargoWeight) {
            this.name = name;
            this.weight = weight;
            this.pwrReserve = pwrReserve;
            this.capacity = capacity;
            this.cargoWeight = cargoWeight;
        }

        protected string Name {
            get { return name; }
        }

        public abstract int Weight { get; }

        public abstract int CargoWeight { get; set; }

        public abstract string ZapasHodaSDannoiNagruzkoi();

        public virtual void OpisanieTS() {
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"МассаТС: {weight} кг");
            Console.WriteLine($"ЗапасХода: {pwrReserve} литров на 100 км");
            Console.WriteLine($"Грузоподъемность: {capacity} кг");
            Console.WriteLine($"МассаГруза: {cargoWeight} кг");
            Console.WriteLine($"ПолнаяМассаТС: {Weight} кг");
        }
    }

    class KolesnoeTS : GruzovoeTransportnoeSredstvo {
        protected int numWheels;
        protected Type typeDriveUnit;

        protected KolesnoeTS() : base() {
            numWheels = 4;
            typeDriveUnit = Type.Полный_привод;
        }

        protected KolesnoeTS(string name, int weight, int pwrReserve, int capacity, int cargoWeight, int numWheels, Type typeDriveUnit) : base(name, weight, pwrReserve, capacity, cargoWeight) {
            this.numWheels = numWheels;
            this.typeDriveUnit = typeDriveUnit;
        }

        public override int CargoWeight {
            get => cargoWeight;
            set {
                if (value < 0 || value > capacity)
                    throw new Exception(@"масса груза не может быть меньше нуля или больше грузоподъемности.");
                cargoWeight = value;
            }
        }

        public override int Weight {
            get {
                return weight + cargoWeight;
            }
        }

        public override string ZapasHodaSDannoiNagruzkoi() {
            return $"{(double)pwrReserve * numWheels * ((int)typeDriveUnit + 1) / cargoWeight * 100:f2}";
        }
    }

    class GruzovoiAutomobile : KolesnoeTS {
        int numVoditeley;

        public GruzovoiAutomobile() : base() {
            numVoditeley = 5;
        }

        public GruzovoiAutomobile(string name, int weight, int pwrReserve, int capacity, int cargoWeight, int numWheels, Type typeDriveUnit, int numVoditeley) : base(name, weight, pwrReserve, capacity, cargoWeight, numWheels, typeDriveUnit) {
            this.numVoditeley = numVoditeley;
        }

        public override int CargoWeight {
            get => base.CargoWeight + numVoditeley * 80;
            set {
                if (value < 0 || value > capacity)
                    throw new Exception(@"масса груза не может быть меньше нуля.");
                base.CargoWeight = value + numVoditeley * 80;
            }
        }

        public override void OpisanieTS() {
            base.OpisanieTS();
            Console.WriteLine($"КоличествоКолес: {numWheels}");
            Console.WriteLine($"ТипПривода: {typeDriveUnit}");
            Console.WriteLine($"КоличествоВодителейНаМаршруте: {numVoditeley}");
        }

        public override int Weight {
            get => base.Weight + CargoWeight;
        }
    }

    class GruzovoiPoezd : KolesnoeTS {
        int numCars;

        public GruzovoiPoezd() : base() {
            numCars = 30;
        }

        public GruzovoiPoezd(string name, int weight, int pwrReserve, int capacity, int cargoWeight, int numWheels, Type typeDriveUnit, int numCars) : base(name, weight, pwrReserve, capacity, cargoWeight, numWheels, typeDriveUnit) {
            this.numCars = numCars;
        }

        public override int CargoWeight {
            get => base.CargoWeight;
            set => base.CargoWeight = value;
        }

        public override int Weight {
            get => weight * numCars + CargoWeight;
        }

        public override string ZapasHodaSDannoiNagruzkoi() {
            return $"{(double)pwrReserve * numWheels * numCars * ((int)typeDriveUnit + 1) / cargoWeight * 100:f2}";
        }

        public override void OpisanieTS() {
            base.OpisanieTS();
            Console.WriteLine($"КоличествоКолес: {numWheels}");
            Console.WriteLine($"ТипПривода: {typeDriveUnit}");
            Console.WriteLine($"ЧислоВагонов: {numCars}");
        }
    }

    class Pickup : GruzovoiAutomobile {
        bool pass;

        public Pickup() : base() {
            pass = true;
        }

        public Pickup(string name, int weight, int pwrReserve, int capacity, int cargoWeight, int numWheels, Type typeDriveUnit, int numVoditeley, bool pass) : base(name, weight, pwrReserve, capacity, cargoWeight, numWheels, typeDriveUnit, numVoditeley) {
            this.pass = pass;
        }

        public override int Weight {
            get => base.Weight;
        }

        public override void OpisanieTS() {
            base.OpisanieTS();
            string y_n = (pass) ? "Есть пассажиры" : "Нет пассажиров";
            Console.WriteLine($"НаличеПассажира: {y_n}");
        }
    }

    class Bolshegruz : GruzovoiAutomobile {
        int numBuck;

        public Bolshegruz() : base() {
            numBuck = 10;
        }

        public Bolshegruz(string name, int weight, int pwrReserve, int capacity, int cargoWeight, int numWheels, Type typeDriveUnit, int numVoditeley, int numBuck) : base(name, weight, pwrReserve, capacity, cargoWeight, numWheels, typeDriveUnit, numVoditeley) {
            this.numBuck = numBuck;
        }

        public override int Weight {
            get => base.Weight + numBuck * 10;
        }

        public override void OpisanieTS() {
            base.OpisanieTS();
            Console.WriteLine($"ЧислоБаков: {numBuck}");
        }

        public override string ZapasHodaSDannoiNagruzkoi() {
            return $"{(double)pwrReserve * numWheels * numBuck * ((int)typeDriveUnit + 1) / cargoWeight * 100:f2}";
        }
    }

    //class Program {
    //    static void Main(string[] args) {
    //        try {
    //            GruzovoeTransportnoeSredstvo[] array = new GruzovoeTransportnoeSredstvo[8] {
    //                new GruzovoiAutomobile(),
    //                new GruzovoiAutomobile("Белаз", 15032, 55, 1450, 300, 4, Type.Полный_привод, 3),
    //                new GruzovoiPoezd(),
    //                new GruzovoiPoezd("Стрела", 500, 70, 10540, 5000, 24, Type.Передний_привод, 5),
    //                new Pickup(),
    //                new Pickup("Волга", 3754, 43, 30, 157, 4, Type.Передний_привод, 4, true),
    //                new Bolshegruz(),
    //                new Bolshegruz("Большегруз 40", 5234, 47, 30, 535, 6, Type.Задний_привод, 2, 5)
    //            };
    //            Console.WriteLine("Все транспортные средства в массиве:\n");
    //            int i = 0;
    //            foreach (GruzovoeTransportnoeSredstvo elem in array) {
    //                if (i % 2 == 0)
    //                    Console.WriteLine("Класс по умолчанию.");
    //                else
    //                    Console.WriteLine("Класс с параметрами.");
    //                elem.OpisanieTS();
    //                elem.ZapasHodaSDannoiNagruzkoi();
    //                Console.WriteLine("\n");
    //                ++i;
    //            }
    //            Console.Write("Введите вес груза в кг (ГрузовойПоезд): ");
    //            int cargo;
    //            int.TryParse(Console.ReadLine(), out cargo);
    //            array[3].CargoWeight = cargo;
    //            array[3].OpisanieTS();
    //            Console.WriteLine("\n");
    //            Console.Write("Введите вес груза в кг (ГрузовойАвтомобиль): ");
    //            int.TryParse(Console.ReadLine(), out cargo);
    //            array[1].CargoWeight = cargo;
    //            array[1].OpisanieTS();
    //        }
    //        catch (Exception error) {
    //            Console.WriteLine($"Ошибка: {error.Message}");
    //        }
    //        Console.ReadKey();
    //    }
    ////}
}
