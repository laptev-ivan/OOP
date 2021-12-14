using System;

namespace Массивы
{
    class Program
    {
        static int[] ReadArray(int n)
        {
            int[] arr = new int[n];
            for(int i=0; i<n; ++i)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        static void PrintArray(int[] arr)
        {
            Console.WriteLine("Массив: ");
            for(int i=0; i<arr.Length; ++i)
            {
                Console.Write($"{arr[i]} ");
            }
        }

        static int SumOfElements(int[] arr)
        {
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            for(int i=0; i<arr.Length; ++i)
            {
                if(arr[i]>arr[max])
                {
                    max = i;
                }
                if(arr[i]<=arr[min])
                {
                    min = i;
                }
            }
            for(int i=max; i<=min; ++i)
            {
                sum += arr[i];
            }
            return sum;
        }

        static int[] ShiftArray(int[] arr, int k)
        {
            for(int i=arr.Length; i>0; --i)
            {
                arr[i] = arr[i - k];
            }
            return arr;
        }

        static void Elements()
        {
            Console.Write("Введите кол-во элементов в массив: "); int n = int.Parse(Console.ReadLine());
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            for(int i=0; i<n; ++i)
            {
                arr1[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; ++i)
            {
                arr2[i] = int.Parse(Console.ReadLine());
            }
            //ДОДЕЛАТЬ
        }
        static void Main(string[] args)
        {
            Console.Write("Введите кол-во элементов в массиве: "); int n = int.Parse(Console.ReadLine());
            Console.Write("Введите k: "); int k = int.Parse(Console.ReadLine());
            int[] arr = ReadArray(n);
            int answer1 = SumOfElements(arr);
            arr = ShiftArray(arr, k);
            Console.WriteLine($"Сумма элементов между между элементами: {answer1}");
            Elements();
            PrintArray(arr);
            Console.ReadKey();
        }
    }
}
