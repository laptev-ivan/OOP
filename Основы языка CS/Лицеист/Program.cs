using System;
using System.IO;

namespace Лицеист
{
    enum Groups
    {
        five_one=1,
        five_two,
        five_three,
    };
    struct Lesson
    {
        public int Classroom;
        public string Teacher;
        public Groups Group;
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
            StreamReader input = new StreamReader("C:\\Users\\chels\\Desktop\\oop\\Основы языка CS\\Лицеист\\input.txt");
            StreamWriter output = new StreamWriter("C:\\Users\\chels\\Desktop\\oop\\Основы языка CS\\Лицеист\\output.txt");

            for (Groups i = Groups.five_one; i <=Groups.five_three; ++i)
                Console.WriteLine($"{i}, соответствует {(int)i}");

            int n = int.Parse(input.ReadLine()); 

            Lesson[,] array = new Lesson[3, 3];
            for (int i = 0; i < n; ++i)
            {
                int number = int.Parse(input.ReadLine());
                Groups group = (Groups) int.Parse(input.ReadLine());
                array[number - 1, (int)group - 1].Number = number;
                array[number - 1, (int)group - 1].Group = group;
                array[number - 1, (int)group - 1].Classroom = int.Parse(input.ReadLine());
                array[number - 1, (int)group - 1].Subject = input.ReadLine();
                array[number - 1, (int)group - 1].Teacher = input.ReadLine();
            }
            if (CheckCorrection(array))
            {
                output.Write("Урок");
                for(int i=0; i<array.GetLength(1); ++i)
                    output.Write($"\t{array[0, i].Group}\t\t");
                output.WriteLine();
                for(int i=0; i<3; ++i)
                {
                    output.Write($"{i + 1}\t");
                    for (Groups j=Groups.five_one; j<=Groups.five_three; ++j)
                    {
                        if (array[i, (int)j - 1].Classroom == 0)
                            output.Write("\t\t\t");
                        else 
                            output.Write($"{array[i, (int)j - 1].Classroom} {array[i, (int)j - 1].Subject} {array[i, (int)j - 1].Teacher}\t");
                    }
                    output.WriteLine();
                }
            }
            else
                output.WriteLine("Error!"); 
            input.Close();
            output.Close();
        }
    }
}
