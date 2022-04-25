using System;

namespace Грузовые_транспортные_средства {

    enum Type {
        Полный_привод,
        Задний_привод,
        Передний_привод
    };

    class GruzovoeTransportnoeSredstvo {
        protected string name;
        protected int weight;
        protected int pwrReserve; //запасХода
        protected int capacity; //грузоподъемность
        protected int cargoWeight; //массаГруза

        public GruzovoeTransportnoeSredstvo() {
            name = "ВАЗ";
            weight = 5000;
            pwrReserve = 100;
            capacity = 100000;
            cargoWeight = 5000;
        }

        public GruzovoeTransportnoeSredstvo(string name, int weight, int pwrReserve, int capacity, int cargoWeight) {
            this.name = name;
            this.weight = weight;
            this.pwrReserve = pwrReserve;
            this.capacity = capacity;
            this.cargoWeight = cargoWeight;
        }

        public string Name {
            get;
        }

        public virtual int Weight {
            get {
                return weight;
            }
        }

        public virtual int CargoWeight {
            get {
                return cargoWeight;
            }

            set {
                if (weight < 0) throw new Exception(@"масса груза не может быть меньше нуля.");
                cargoWeight = value;
            }
        }

        public virtual void ZapasHodaSDannoiNagruzkoi() {
            Console.WriteLine($"Запас хода: {(double)cargoWeight / pwrReserve * 10}");
        }

        public virtual void OpisanieTS() {
            Console.WriteLine($"Название: {name}");
            Console.WriteLine($"МассаТС: {weight}");
            Console.WriteLine($"ЗапасХода: {pwrReserve}");
            Console.WriteLine($"Грузоподъемность: {capacity}");
            Console.WriteLine($"МассаГруза: {cargoWeight}");
        }
    }

    class KolesnoeTS : GruzovoeTransportnoeSredstvo {
        protected int numWheels;
        protected Type typeDriveUnit;

        public KolesnoeTS() : base() {
            numWheels = 4;
            typeDriveUnit = Type.Полный_привод;
        }

        public KolesnoeTS(string name, int weight, int pwrReserve, int capacity, int cargoWeight, int numWheels, Type typeDriveUnit) : base(name, weight, pwrReserve, capacity, cargoWeight) {
            this.numWheels = numWheels;
            this.typeDriveUnit = typeDriveUnit;
        }

        public override void ZapasHodaSDannoiNagruzkoi() {
            Console.WriteLine($"Запас хода: {(double)cargoWeight / pwrReserve * 100 / (int)typeDriveUnit + 1}");
        }
    }

    class GruzovoiAutomobile : KolesnoeTS {
        protected int numVoditeley;

        public GruzovoiAutomobile() : base() {
            numVoditeley = 5;
        }

        public GruzovoiAutomobile(string name, int weight, int pwrReserve, int capacity, int cargoWeight, int numWheels, Type typeDriveUnit, int numVoditeley) : base(name, weight, pwrReserve, capacity, cargoWeight, numWheels, typeDriveUnit) {
            this.numVoditeley = numVoditeley;
        }

        public override int CargoWeight {
            get {
                return base.CargoWeight + numVoditeley * 80;
            }

            set {
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
            get {
                return base.Weight + CargoWeight;
            }
        }
    }

    class GruzovoiPoezd :  KolesnoeTS {
        int numCars;

        public GruzovoiPoezd() : base() {
            numCars = 30;
        }

        public GruzovoiPoezd(string name, int weight, int pwrReserve, int capacity, int cargoWeight, int numWheels, Type typeDriveUnit, int numCars) : base(name, weight, pwrReserve, capacity, cargoWeight, numWheels, typeDriveUnit) {
            this.numCars = numCars;
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
            get {
                return base.Weight;
            }
        }

        public override void ZapasHodaSDannoiNagruzkoi() {
            base.ZapasHodaSDannoiNagruzkoi();
        }

        public override void OpisanieTS() {
            base.OpisanieTS();
            string y_n = (pass) ? "Есть пассажиры" : "Нет, пассажиров";
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
            get {
                return base.Weight + numBuck * 10;
            }
        }

        public override void OpisanieTS() {
            base.OpisanieTS();
            Console.WriteLine($"ЧислоБаков: {numBuck}");
        }

        public override void ZapasHodaSDannoiNagruzkoi() {
            Console.WriteLine();
        }
    }

    class Program {
        static void Main(string[] args) {
            try {
                GruzovoeTransportnoeSredstvo[] array = new GruzovoeTransportnoeSredstvo[6] {
                    new GruzovoeTransportnoeSredstvo(),
                    new KolesnoeTS("Мотоцикл", 10000, 53, 30, 2000, 2, Type.Задний_привод),
                    new GruzovoiAutomobile("Белаз", 10000, 53, 30, 2000, 2, Type.Полный_привод, 3),
                    new GruzovoiPoezd("Стрела", 10000, 53, 30, 2000, 2, Type.Передний_привод, 3),
                    new Pickup("Волга", 10000, 53, 30, 2000, 2, Type.Передний_привод, 3, false),
                    new Bolshegruz("Скотина", 10000, 53, 30, 2000, 2, Type.Передний_привод, 3, 5)
                };
                Console.WriteLine("Все транспортные средства в массиве: ");
                int i = 0;
                foreach(GruzovoeTransportnoeSredstvo elem in array) {
                    Console.WriteLine(i);
                    elem.OpisanieTS();
                    Console.WriteLine();
                    ++i;
                }
                int cargoweight;
                Console.WriteLine("Вес груза:");
                int.TryParse(Console.ReadLine(), out cargoweight);
                array[0].CargoWeight = cargoweight;
            }
            catch (Exception error) {
                Console.WriteLine($"Ошибка: {error.Message}");
            }
            Console.ReadKey();
        }
    }
}
