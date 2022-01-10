using System;

namespace Работа_на_уроке
{
    class Program
    {
        static int[][] MakeArray(int n)
        {
            int[][] arr = new int[n][]; 
            for(int i=0; i<arr.Length; ++i)
            {
                arr[i] = new int[(i + 1) * 2];
                for(int j=0; j<arr[i].Length; ++j)
                {
                    arr[i][j] = i + j;
                }
            }
            return arr;
        }

        static void OutputArray(int[][] arr)
        {
            for(int i=0; i<arr.Length; ++i)
            {
                foreach (int elem in arr[i])
                    Console.Write($"{elem} ");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите кол-во массивов для массива"); int n = int.Parse(Console.ReadLine());
            int[][] arr = MakeArray(n);
            OutputArray(arr);
            Console.ReadKey();
        }
    }
}
