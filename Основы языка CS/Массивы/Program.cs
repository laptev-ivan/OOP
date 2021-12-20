using System;

namespace Массивы
{
    class Program
    {
        static int[] ReadArray(int n)
        {
            Console.WriteLine("Введите элементы: ");
            int[] arr = new int[n];
            for (int i = 0; i < n; ++i)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        static void PrintArray(int[] arr)
        {
            Console.Write("Массив: ");
            foreach(int elem in arr)
            {
                Console.Write($"{elem} ");
            }
        }

        static int SumOfElements(int[] arr)
        {
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] > arr[max])
                {
                    max = i;
                }
                if (arr[i] <= arr[min])
                {
                    min = i;
                }
            }
            if (min > max)
            {
                int tmp = min;
                min = max;
                max = tmp;
            }
            for (int i = max; i <= min; ++i)
            {
                sum += arr[i];
            }
            return sum;
        }

        static void ShiftArray(int[] arr, int k)
        {
            for (int i = 0; i < k; ++i)
            {
                for (int j = arr.Length - 1; j > 0; --j)
                {
                    int tmp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = tmp;
                }
            }
        }

        static bool check(int[] arr2, int elem)
        {
            bool ok = false;
            foreach (int elem2 in arr2)
            {
                if (elem2 == elem)
                {
                    ok = true;
                }
            }
            return ok;
        }

        static void ElementsInBothArrays()
        {
            Console.Write("Введите кол-во элементов для первого и второго массивов: "); int n = int.Parse(Console.ReadLine());
            int[] arr1 = ReadArray(n);
            int[] arr2 = ReadArray(n);
            Console.Write("Пересечение множеств: ");
            bool flag = true;
            foreach(int elem in arr1) // TODO: Убрать лишние элементы
            {
                if(check(arr2, elem))
                {
                    foreach(int elem1 in arr1)
                    {
                        flag = true;
                        if(elem1==elem)
                        {
                        }
                    }
                    if(flag) Console.Write($"{elem} ");
                }
            }
        }

        static void DeleteElements()
        {
            Console.Write("Введите кол-во элементов в массиве: "); int n = int.Parse(Console.ReadLine());
            int[] arr = ReadArray(n);
            Console.Write("Массив ");
            for (int m = 0; m < n; ++m)
            {
                Console.Write($"{arr[m]} ");
                for (int i = m + 1; i < n; ++i)
                {
                    if (arr[m] == arr[i])
                    {
                        for (int k = i; k < n - 1; ++k)
                        {
                            arr[k] = arr[k + 1];
                        }
                        n--;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите кол-во элементов в массиве: "); int n = int.Parse(Console.ReadLine());
            int[] arr = ReadArray(n);

            //Первая ф-ция
            int SumOfElems = SumOfElements(arr);
            Console.WriteLine($"Сумма элементов между первым максимальным и последним минимальными элементами: {SumOfElems}");
            Console.WriteLine();

            //Вторая ф-ция
            Console.Write("Введите k: "); int k = int.Parse(Console.ReadLine());
            ShiftArray(arr, k);
            Console.WriteLine("Массив со сдвигом: ");
            PrintArray(arr);
            Console.WriteLine("\n");

            //Третья ф-ция
            ElementsInBothArrays();
            Console.WriteLine("\n");

            //Четвертая ф-ция
            DeleteElements();
            Console.WriteLine("\n");

            Console.ReadKey();
        }
    }
}
