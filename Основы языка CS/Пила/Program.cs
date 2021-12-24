using System;

namespace Пила
{
    class Program
    {
        static int KitKat(int n)
        {
            int cnt = 0;
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for(int i=2; i<arr.Length-2; ++i)
            {
                if((arr[i]>arr[i-1]&&arr[i]>arr[i+1])||(arr[i]<arr[i-1]&&arr[i]<arr[i+1]))
                {
                    Console.Write($"{arr[i]} ");
                    cnt++;
                }
            }   
            return arr.Length - cnt;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = KitKat(n);
            Console.WriteLine($"Необходимо вычеркнуть {num} элемента");
            Console.ReadKey();
        }
    }
}
