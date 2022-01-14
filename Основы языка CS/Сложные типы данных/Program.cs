using System;

namespace Сложные_типы_данных
{
    class Program
    {
        static void OutputArr(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); ++i) 
            { 
                for (int j = 0; j < arr.GetLength(1); ++j)
                    Console.Write($"{arr[i,j]} ");
                Console.WriteLine();
            }
        }

        static int[,] InputArr()
        {
            Console.Write("Введите кол-во строк: "); int n = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во столбцов: "); int m = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, m];
            string[] arrs = new string[n];
            for(int i=0; i<arr.GetLength(0); ++i)
            {
                arrs = Console.ReadLine().Split(new char[] { ' ' });
                for(int j=0; j<arr.GetLength(1); ++j)
                    arr[i, j] = int.Parse(arrs[j]);
            }
            return arr;
        }

        static void ReplaceDiagonals(int[,] arr)
        {
            int strings = arr.GetLength(0);
            int columns = arr.GetLength(1);
            if(strings==columns)
            {
                for (int i = 0; i < strings; ++i)
                {
                    int tmp = arr[i, i];
                    arr[i, i] = arr[i, strings - 1 - i];
                    arr[i, strings - 1 - i] = tmp;
                }

                Console.WriteLine("Замена диагоналей: ");
                OutputArr(arr);
            }
            else
                Console.WriteLine("Массив не квадратный");
        }

        static int Index(int[,] arr)
        {
            int min = -1, max = -1, index = 0;
            int[] res = new int[arr.GetLength(1)];
            for (int i = 0; i < arr.GetLength(1); ++i)
            {
                min = arr[0, 0];
                for (int j = 0; j < arr.GetLength(0); ++j)
                    if (arr[j, i] < min) min = arr[j, i];
                if (min > max)
                {
                    max = min;
                    index = i;
                }
            }
            return index;
        }

        static void Main(string[] args)
        {
            int[,] arr = InputArr();
            Console.WriteLine("\nВывод массива:");
            OutputArr(arr);
            Console.WriteLine();
            ReplaceDiagonals(arr);
            Console.WriteLine();
            int index = Index(arr);
            Console.WriteLine($"Индекс: {index}");
            Console.ReadKey();
        }
    }
}
