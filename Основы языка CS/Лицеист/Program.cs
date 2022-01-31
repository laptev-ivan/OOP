using System;
using System.IO;

namespace Лицеист
{
    enum classes
    {
        class105 = 105,
        class110 = 110,
        class201 = 201,
        class304 = 304
    };

    enum teachers
    {
        Иванов,
        Петрова,
        Сергеев,
    };
    struct Lesson
    {
        public classes Classroom;
        public string Teacher;
        public string Subject;
        public int Number;
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader input = new StreamReader("Z:\\OOP\\Основы языка CS\\Лицеист\\input.txt");
            StreamWriter output = new StreamWriter("Z:\\OOP\\Основы языка CS\\Лицеист\\output.txt");

            int n = int.Parse(input.ReadLine()); // Наборы
            for (int i = 0; i < n; ++i)          
            {
                
            }

            input.Close();
            output.Close();
            Console.ReadKey();
        }
    }
}
