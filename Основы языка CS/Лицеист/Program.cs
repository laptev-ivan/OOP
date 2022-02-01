using System;
using System.IO;

namespace Лицеист
{
    struct Lesson
    {
        public int Classroom;
        public string Teacher;
        public string Group;
        public string Subject;
        public int Number;
    }
    
    class Program
    {
        static bool CheckCorrection(Lesson[,] array)
        {
            bool flag = true;
            for(int i=0; i<array.GetLength(0); ++i)
            {
                for(int j=0; j<array.GetLength(1); ++j)
                {
                    for (int k = j+1; k < array.GetLength(1)-1; ++k)
                    {
                        if (array[i, j].Classroom == array[i, k].Classroom || array[i, j].Teacher == array[i, k].Teacher || array[i, j].Subject == array[i, k].Subject)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            return flag;
        }
        static void Main(string[] args)
        {
            //StreamReader input = new StreamReader("C:\\Users\\chels\\Desktop\\oop\\Основы языка CS\\Лицеист\\input.txt");
            //StreamWriter output = new StreamWriter("C:\\Users\\chels\\Desktop\\oop\\Основы языка CS\\Лицеист\\output.txt");
            
            int n = int.Parse(Console.ReadLine()); 

            string[] groups = new string[] { "5.1", "5.2", "5.3" };

            Lesson[,] array = new Lesson[n, groups.Length];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < groups.Length; ++j)
                {
                    array[i, j].Number = int.Parse(Console.ReadLine());
                    array[i, j].Group = Console.ReadLine();
                    array[i, j].Classroom = int.Parse(Console.ReadLine());
                    array[i, j].Subject = Console.ReadLine();
                    array[i, j].Teacher = Console.ReadLine();
                }
            }
            if (CheckCorrection(array))
            {
                for (int i = 0; i < array.GetLength(1); ++i)
                {
                    Console.Write("Урок\t5.1\t5.2\t5.3");
                }
                for (int i = 0; i < n; ++i)
                {
                    Console.Write($"{i + 1} ");
                    for (int j = 0; j < groups.Length; ++j)
                    {
                        Console.Write("{0} {1} {2} ", array[i, j].Classroom, array[i, j].Subject, array[i, j].Teacher); 
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Error"); // maybe input.WriteLine("Error");
            }
            //input.Close();
            //output.Close();
            Console.ReadKey();
        }
    }
}
