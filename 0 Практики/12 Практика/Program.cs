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
            Console.WriteLine("Ввод даблом x,y (через запятую) - 1 или ввод отдельно x, y, z - 0");
            sbyte doubleorint = sbyte.Parse(Console.ReadLine());
            if (doubleorint == 0) {
                Console.WriteLine("Введите координаты так чтобы хотя бы одна из них была кратна пяти.");
                Console.Write("Введите координату по OX: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OY: ");
                int y = int.Parse(Console.ReadLine());
                Console.Write("Введите координату по OZ: ");
                int z = int.Parse(Console.ReadLine());
                if (x * y * z % 5 == 0) {
                    point = new Point3D(x, y, z);
                }
            }
            else if (doubleorint == 1) {
                Console.WriteLine("Введите через точку координаты (x.y):");
                decimal xy = decimal.Parse(Console.ReadLine());
                point = new Point3D(xy);
            }
            else {
                Console.WriteLine("Сработал конструктор по умолчанию");
                point = new Point3D();
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
            obj.x++;
            obj.y++;
            obj.y++;
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
                else {
                    if (value < 0 || value > 100) throw new Exception(@"координата Y не может быть меньше 0 или больше 100");
                    else y = value;
                }
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
    }

    class Program {
        static void PrintXYZ(Point3D point) {
            Console.WriteLine($"X:{point.SetX}, Y:{point.SetY}, Z:{point.SetZ}");
        }

        static void Main(string[] args) {
            Point3D point1 = Point3D.CreatePoint();
            Console.WriteLine("Введите 0 — не сдвигать");
            Console.WriteLine("Введите 1 — сдвигать");
            sbyte ok2 = sbyte.Parse(Console.ReadLine());
            if (ok2==0) {
                Console.WriteLine("Введите название оси (x, y, z)");
                char c = char.Parse(Console.ReadLine());
                Console.WriteLine("Расстояние");
                int s = int.Parse(Console.ReadLine());
                point1.Move(c, s);
            }
            PrintXYZ(point1);
            double radius1 = point1.RadiusVector();
            Console.WriteLine($"Длина радиус вектора: {radius1:F2}");

            Point3D point2 = Point3D.CreatePoint();
            PrintXYZ(point2);
            double radius2 = point2.RadiusVector();
            Console.WriteLine($"Длина радиус вектора второй точки: {radius2:F2}");
            Console.WriteLine("Если хотите сложить точку с точкой - 0, с другой точкой - 1 с числом - любая другая цифра");
            sbyte ok3 = sbyte.Parse(Console.ReadLine());
            if (ok3 == 0) {
                point1.AddDots(point2);
                Console.WriteLine("Сложение двух точек");
                PrintXYZ(point1);
            }
            else if (ok3 == 1) {
                Console.WriteLine("Введите координаты точки с которой хотите сложить первую точку");
                int xX, yY, zZ;
                int.TryParse(Console.ReadLine(), out xX);
                int.TryParse(Console.ReadLine(), out yY);
                int.TryParse(Console.ReadLine(), out zZ);
                try {
                    point1.SetX = xX;
                }
                catch {
                    Console.WriteLine("Введено некорректное значение, координата OX не поменялась.");
                }
                try {
                    point1.SetY = yY;
                }
                catch {
                    Console.WriteLine("Введено некорректное значение, координата OY не поменялась.");
                }
                try {
                    point1.SetZ = zZ;
                }
                catch {
                    Console.WriteLine("Введено некорректное значение, координата OZ не поменялась.");
                }
                point1.AddDots(xX, yY, zZ);
                PrintXYZ(point1);
            }
            else {
                Console.WriteLine("Введите число на которое хотите увеличить каждую кооридинату");
                int Number;
                int.TryParse(Console.ReadLine(), out Number);
                point1.AddDots(Number);
                PrintXYZ(point1);
            }
            if (point1.InOutArea())
                Console.WriteLine("Точка находится в области");
            else
                Console.WriteLine("Точка вне области");
            Point3D point4 = Point3D.CreatePoint();
            PrintXYZ(point4);
            Console.ReadKey();
        }
    }
}