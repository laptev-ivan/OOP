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
                    Console.Write($"arr[i,j]");
                Console.WriteLine();
            }
        }

        static int[,] InputArr()
        {
            Console.WriteLine("Введите кол-во строк"); int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите кол-во столбцов"); int m = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, m];
            string[] arrs;
            for(int i=0; i<arr.GetLength(0); ++i)
            {
                arrs = Console.ReadLine().Split(new char[] { ' ' });
                for(int j=0; i<arr.GetLength(1); ++j)
                {
                    arr[i, j] = int.Parse(arrs[j]);
                }
            }
            return arr;
        }
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }
}
