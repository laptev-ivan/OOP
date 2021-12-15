using System;

namespace Массивы
{
    class Program
    {
        static int[] ReadArray(int n)
        {
            Console.WriteLine("Введите элементы: ");
            int[] arr = new int[n];
            for(int i=0; i<n; ++i)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        static void PrintArray(int[] arr)
        {
            Console.Write("Массив: ");
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
            for(int i=0; i<k; ++i)
            {
                for(int j=arr.Length-1; j>0; --j)
                {
                    int tmp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = tmp;
                }
            }
            return arr;
        }

        static void Elements()
        {
            Console.Write("Введите кол-во элементов в массиве: "); int n = int.Parse(Console.ReadLine());
            int[] arr1 = ReadArray(n);
            int[] arr2 = ReadArray(n);
            Console.Write("Повторяющиеся элементы: ");
            foreach(int elem1 in arr1)
            {
                foreach(int elem2 in arr2)
                {
                    if(elem1==elem2)
                    {
                        Console.Write($"{elem1} ");
                    }
                }
            }
            Console.WriteLine();
        }

        static int[] DeleteArray()
        {
            Console.Write("Введетие кол-во элементов в массиве: "); int n = int.Parse(Console.ReadLine());
            int[] arr = ReadArray(n);
            int p = 0, min = 0;
            for(int i=0; i<arr.Length; ++i)
            {
                int rav = 0;
                for (int j = p; j < arr.Length; ++j)
                {
                    if (arr[min]==arr[j])
                    {
                        rav++;
                    }
                }
                if (rav == 1)
                {
                    Console.Write("${arr[min]} ");
                }
                min++;
                p++;
            }
            return arr;
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
            int[] arr1 = DeleteArray();
            PrintArray(arr);
            PrintArray(arr1);
            Console.ReadKey();
        }
    }
}
