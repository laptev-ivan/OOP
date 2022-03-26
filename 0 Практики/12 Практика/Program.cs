using System;

namespace _12_Практика {
    class Point3D {
        int x;
        int y;
        int z;

        public Point3D() {
            x = 5;
            y = 10;
            z = 15;
        }

        private Point3D(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Point3D(decimal xy) {
            x = (int)xy;
            decimal tmp = xy - (int)xy;
            do {
                tmp *= 10;
            } while (tmp % (int)tmp != 0);
            x = (int)tmp;
        }

        public static Point3D CreatePoint() {
            Point3D point=new Point3D();
            try {
                Console.Write("Ввод координат x,y (через точку или запятую) - 1, ввод отдельно x, y, z - 0, конструктор по умолчанию (x=5, y=10, z=15) - любая другая цифра: ");
                sbyte doubleorint = sbyte.Parse(Console.ReadLine());
                switch (doubleorint) {
                    case 0: 
                        Console.WriteLine("Введите координаты так чтобы хотя бы одна из них была кратна пяти.");
                        Console.Write("Введите координату по OX: ");
                        int x = int.Parse(Console.ReadLine());
                        Console.Write("Введите координату по OY: ");
                        int y = int.Parse(Console.ReadLine());
                        Console.Write("Введите координату по OZ: ");
                        int z = int.Parse(Console.ReadLine());
                        if (x * y * z % 5 == 0) 
                            point = new Point3D(x, y, z);
                        break;
                    case 1:
                        Console.WriteLine("Введите через точку координаты (x.y):");
                        decimal xy = decimal.Parse(Console.ReadLine());
                        point = new Point3D(xy);
                        break;
                    default:
                        Console.WriteLine("Сработал конструктор по умолчанию (x=5, y=10, z=15).");
                        Console.WriteLine();
                        point = new Point3D();
                        break;
                }
            }
            catch(Exception error) {
                point = new Point3D();
                Console.WriteLine("Ошибка: " + error.Message);
                Console.WriteLine("Сработал конструктор по умолчанию (x=5, y=10, z=15).");
                Console.WriteLine();
            }    
            return point;
        }

        public static Point3D operator +(Point3D obj1, Point3D obj2) {
            return new Point3D(obj1.x + obj2.y, obj1.y + obj2.y, obj1.z + obj2.z);
        }

        public static Point3D operator -(Point3D obj1, Point3D obj2) {
            return new Point3D(obj1.x - obj2.y, obj1.y - obj2.y, obj1.z - obj2.z);
        }

        public static Point3D operator ++(Point3D obj) {
            ++obj.x;
            ++obj.y;
            ++obj.z;
            return obj;
        }

        public static Point3D operator --(Point3D obj) {
            obj.x--;
            obj.y--;
            obj.y--;
            return obj;
        }

        public static bool operator <=(Point3D obj1, Point3D obj2) {
            if (obj1.x <= obj2.x && obj1.y <= obj2.y && obj1.z <= obj2.z)
                return true;
            return false;
        }

        public static bool operator >=(Point3D obj1, Point3D obj2) {
            if (obj1.x >= obj2.x && obj1.y >= obj2.y && obj1.z >= obj2.z)
                return true;
            return false;
        }

        public static Point3D operator &(Point3D obj1, Point3D obj2) {
            return new Point3D(obj1.x & obj2.x, obj1.y & obj2.y, obj1.z & obj2.z);
        }

        public static Point3D operator |(Point3D obj1, Point3D obj2) {
            return new Point3D(obj1.x | obj2.x, obj1.y | obj2.y, obj1.z | obj2.z);
        }

        public static bool operator true(Point3D obj) {
            if (obj.x >= 0 && obj.y <= 0 && obj.z >= 0)
                return true;
            return false;
        }

        public static bool operator false(Point3D obj) {
            if (obj.x < 0 && obj.y > 0 && obj.z < 0)
                return true;
            return false;
        }

        public int SetX {
            get { return x; }
            set {
                if (value <= 0) throw new Exception(@"координата X не может быть отрицательной.");
                else x = value;
            }
        }

        public int SetY {
            get { return y; }
            set {
                if (value >= 0 && value <= 100) y = value;
                else throw new Exception(@"координата Y не может быть меньше 0 или больше 100.");
            }
        }

        public int SetZ {
            get { return z; }
            set {
                if (value > x + y) throw new Exception(@"координата Z не может быть больше x+y.");
                else z = value;
            }
        }

        public void Move(char c, int s) {
            if (c == 'x')
                x += s;
            else if (c == 'y')
                y += s;
            else if (c == 'z')
                z += s;
        }

        public double RadiusVector() {
            return Math.Sqrt(x * x + y * y + z * z);
            
        }

        public void AddDots(Point3D point2) {
            x += point2.x;
            y += point2.y;
            z += point2.z;
        }

        public void AddDots(int number) {
            x += number;
            y += number;
            z += number;
        }

        public void AddDots(int a, int b, int c) {
            x += a;
            y += b;
            z += c;
        }

        public bool InOutArea() {
            bool ok = false;
            if (y > 2 && x < 10 && x < y)
                ok = true;
            return ok;
        }

        public void PrintXYZ() {
            Console.WriteLine($"X:{x}, Y:{y}, Z:{z}");
        }
    }

    class Program {
        static void Main(string[] args) {
            Point3D point1 = Point3D.CreatePoint();
            try {
                Console.WriteLine("Введите 0 — не сдвигать, 1 — сдвинуть: ");
                sbyte ok1 = sbyte.Parse(Console.ReadLine());
                if (ok1 == 1) {
                    Console.Write("Введите название оси (x, y, z): ");
                    char c = char.Parse(Console.ReadLine());
                    Console.Write("Расстояние: ");
                    int s = int.Parse(Console.ReadLine());
                    point1.Move(c, s);
                }
                point1.PrintXYZ();
                double radius1 = point1.RadiusVector();
                Console.WriteLine($"Длина радиус вектора: {radius1:F2}");

                Point3D point2 = Point3D.CreatePoint();
                point2.PrintXYZ();
                double radius2 = point2.RadiusVector();
                Console.WriteLine($"Длина радиус вектора второй точки: {radius2:F2}");
                Console.Write(
@"0) Добавить единицу к координатам точки.
1) Вычесть единицу из координат точки.
2) Сложить координаты первой и координаты второй точки.
3) Вычесть координаты первой и координаты второй точки.
4) Сравнить больше ли координаты первой точки или нет.
5) Сравнить меньше ли координаты первой точки или нет. 
6)
7)
8) Провека первой точки (true): лежит ли трехмерная точка в четвертой четверти плоскости xy и имеет ли координату z, большую нуля.
9) Провека первой точки (false): не лежит ли трехмерная точка в четвертой четверти плоскости xy и имеет ли координату z, большую нуля.
");
                sbyte ok2 = sbyte.Parse(Console.ReadLine());
                switch (ok2) {
                    case 0:
                        Console.WriteLine("Сложение двух точек.");
                        Point3D point3 = point1 + point2;
                        point3.PrintXYZ();
                        break;
                    case 1:
                        Console.WriteLine("Введите координаты точки с которой хотите сложить первую точку");
                        Console.Write("OX: "); int x = int.Parse(Console.ReadLine());
                        Console.Write("OY: "); int y = int.Parse(Console.ReadLine());
                        Console.Write("OZ: "); int z = int.Parse(Console.ReadLine());
                        point1.AddDots(x, y, z);
                        point1.PrintXYZ();
                        break;
                    default:
                        Console.WriteLine("Введите число на которое хотите увеличить каждую кооридинату");
                        int number;
                        int.TryParse(Console.ReadLine(), out number);
                        point1.AddDots(number);
                        point1.PrintXYZ();
                        break;
                }
                if (point1.InOutArea())
                    Console.WriteLine("Точка находится в области");
                else
                    Console.WriteLine("Точка вне области");
            }
            catch (Exception error) {
                Console.WriteLine("Ошибка: " + error.Message);
            }
            Point3D point4 = Point3D.CreatePoint();
            point4.PrintXYZ();
            Console.ReadKey();
        }
    }
}