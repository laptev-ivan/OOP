using System;
using System.IO;

namespace Лицеист
{
    enum Groups
    {
        five_one = 1,
        five_two,
        five_three
    };

    enum Classrooms
    {
        one_zero_five = 105,
        one_one_zero = 110,
        two_zero_one = 201,
        three_zero_four = 304
    };

    struct Lesson
    {
        public Classrooms Classroom;
        public string Teacher;
        public Groups Group;
        public string Subject;
        public int Number;
    }

    class Program
    {
        /// <summary>
        /// Проверка расписания на корректность
        /// </summary>
        /// <param name="array">Массив</param>
        /// <returns>Тру/Фолс</returns>
        static bool CheckCorrection(Lesson[,] array)
        {
            bool flag = true;
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    for (int k = j + 1; k < array.GetLength(1) - 1; ++k)
                    {
                        if ((int)array[i, j].Classroom == (int)array[i, k].Classroom || array[i, j].Teacher == array[i, k].Teacher || array[i, j].Subject == array[i, k].Subject)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// Выборка учебному дню или уроку
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="output">Стримрайтер</param>
        static void Choice(Lesson[,] array, StreamWriter output)
        {
            Console.WriteLine("Если хотите выборку по учебным группам - нажмите 0.");
            Console.WriteLine("Если хотите выборку по урокам - нажмите 1.");
            int menu = int.Parse(Console.ReadLine());
            if (menu == 0)
            {
                Console.WriteLine("Введите номер группы."); Groups group = (Groups)int.Parse(Console.ReadLine());
                foreach(Lesson elem in array)
                {
                    if(elem.Group==group)
                    {
                        Console.WriteLine("{0} {1} {2} {3}", elem.Number, (int)elem.Classroom, elem.Subject, elem.Teacher);
                    }
                }
            }
            else if (menu == 1)
            {
                Console.WriteLine("Введите номер урока. "); int number = int.Parse(Console.ReadLine());
                foreach(Lesson elem in array)
                {
                    if(elem.Number==number)
                    {
                        Console.WriteLine("{0} {1} {2} {3}", (int)elem.Group, (int)elem.Classroom, elem.Subject, elem.Teacher);
                    }
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        /// <summary>
        /// Вывод окна 
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="output">Стримрайтер</param>
        static void Window(Lesson[,] array, StreamWriter output)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    if (array[i, j].Classroom == 0)
                    {
                        for (int k = 0; k < array.GetLength(1); ++k)
                        {
                            if (k == j) continue;
                            else
                            {
                                //дописать
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Функция ввода структур в массив
        /// </summary>
        /// <returns>Заполненный массив структур</returns>
        static Lesson[,] Input()
        {
            StreamReader input = new StreamReader("Z:\\CP\\Основы языка CS\\Лицеист\\input.txt");
            int n = int.Parse(input.ReadLine());
            Lesson[,] array = new Lesson[3, 3];
            for (int i = 0; i < n; ++i)
            {
                int number = int.Parse(input.ReadLine());
                Groups group = (Groups)int.Parse(input.ReadLine());
                array[number - 1, (int)group - 1].Number = number;
                array[number - 1, (int)group - 1].Group = group;
                array[number - 1, (int)group - 1].Classroom = (Classrooms)int.Parse(input.ReadLine());
                array[number - 1, (int)group - 1].Subject = input.ReadLine();
                array[number - 1, (int)group - 1].Teacher = input.ReadLine();
            }
            input.Close();
            return array;
        }

        /// <summary>
        /// Вывод расписания и окон
        /// </summary>
        /// <param name="array">Массв</param>
        static void Output(Lesson[,] array)
        {
            StreamWriter output = new StreamWriter("Z:\\CP\\Основы языка CS\\Лицеист\\output.txt");
            for (Groups i = Groups.five_one; i <= Groups.five_three; ++i)
                Console.WriteLine($"{i}, соответствует {(int)i}");
            if (CheckCorrection(array))
            {
                output.Write("Урок");
                for (int i = 0; i < array.GetLength(1); ++i)
                    output.Write($"\t5.{(int)array[0, i].Group}\t\t\t\t\t");
                output.WriteLine();
                for (int i = 0; i < 3; ++i)
                {
                    output.Write($"{i + 1}\t");
                    for (Groups j = Groups.five_one; j <= Groups.five_three; ++j)
                    {
                        if (array[i, (int)j - 1].Classroom == 0)
                            output.Write("\t\t\t\t\t\t");
                        else
                            output.Write($"{(int)array[i, (int)j - 1].Classroom} {array[i, (int)j - 1].Subject} {array[i, (int)j - 1].Teacher}\t");
                    }
                    output.WriteLine();
                }
                Choice(array, output);
                Window(array, output);
            }
            else
                output.WriteLine("Error");
            output.Close();
        }

        static void Main(string[] args)
        {
            Lesson[,] array = Input();
            Output(array);
            Console.ReadKey();
        }
    }
}