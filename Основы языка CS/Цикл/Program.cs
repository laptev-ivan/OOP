using System;

namespace Цикл
{
    class Program
    {
        static void Shift(int k)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            int[] array2 = new int[array.Length];
            for(int i=array.Length-1; i>=0; --i)
            {
                if(i+k>=array.Length)
                {
                    array2[i + k - array.Length] = array[i];
                }
                else
                {
                    array2[i + k] = array[i];
                }
            }
            for(int i=0; i<array2.Length; ++i)
            {
                Console.Write($"{array2[i]} ");
            }

        }
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            Shift(k);
        }
    }
}
