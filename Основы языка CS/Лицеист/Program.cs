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
    struct Lesson
    {
        public classes Classroom;
        public string[] Teacher;
        public string[] Group;
        public string[] Subject;
        public int[] Number;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Lesson l;
            StreamReader input = new StreamReader("Z:\\OOP\\Основы языка CS\\Лицеист\\input.txt");
            StreamWriter output = new StreamWriter("Z:\\OOP\\Основы языка CS\\Лицеист\\output.txt");

            string[] teachers = new string[] { "Иванов", "Петрова", "Сергеев" };
            string[] subjects = new string[] { "математика", "литература", "английский", "русский" };
            string[] groups = new string[] { "5.1", "5.2", "5.3" };

            int n = int.Parse(input.ReadLine()); 

            Lesson[,] array = new Lesson[n, groups.Length];
            for(int i=0; i<n; ++i)
            {
                for (int j = 0; j < groups.Length; ++j)
                {
                    array[i, ]
                }

            input.Close();
            output.Close();
            Console.ReadKey();
        }
    }
}
