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

        protected string Name {
            get;
        }

        protected int Weight {
            get;
        }

        protected int CargoWeight {
            get {
                return cargoWeight;
            }
            set {
                cargoWeight = value;
            }
        }

        public virtual void ZapasHodaSDannoiNagruzkoi() {
            Console.WriteLine($"Запас хода: {(double)cargoWeight / pwrReserve * 10}");
        }
    }

    class KolesnoeTS : GruzovoeTransportnoeSredstvo {
        protected int numWheels;
        protected Type typeDriveUnit;

        public KolesnoeTS() : base("ВАЗ", 5000, 100, 100000, 5000) {
            numWheels = 4;
            typeDriveUnit = Type.Полный_привод;
        }

        public KolesnoeTS(string name, int weight, int pwrReserve, int capacity, int cargoWeight, int numWheels, Type typeDriveUnit) : base() {
            this.numWheels = numWheels;
            this.typeDriveUnit = typeDriveUnit;
        }
    }

    class Program {
        static void Main(string[] args) {
            Console.ReadKey();
        }
    }
}
