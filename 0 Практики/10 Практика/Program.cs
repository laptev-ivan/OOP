using System;

namespace _10_Практика
{
    class Program
    {
        static int[] MakeArray(int l, int r)
        {
            int[] arr = new int[r - l + 1];
            for(int i= 0; i<arr.Length; ++i)
            {
                arr[i] = l + i;
            }
            return arr;
        }
        
        static void FirstFunction(int[] arr, out int sum, out int min) 
        {
            int minimum = arr[0];
            int summa = 0;
            foreach (int elem in arr)
            {
                if(elem>=1107&&elem<=9504)
                { 
                    if(elem%9==0&&elem%7!=0&&elem%15!=0&&elem%17!=0&&elem%19!=0)
                    {
                        ++summa;
                        if(elem<minimum) minimum = elem;
                    }
                }
            }
            sum = summa;
            min = minimum;
        }

        static void SecondFunction(int[] arr, out int sum, out int min)
        {
            int minimal = arr[arr.Length-1];
            int summa = 0;
            foreach(int elem in arr)
            {
                if(elem>=1529&&elem<=9482)
                {
                    if(elem%4==1&&elem%2==1&&elem%5==3)
                    {
                        summa += elem;
                        if (elem < minimal)
                            minimal = elem;
                    }
                }
            }
            sum = summa;
            min = minimal;
        }

        static void ThirdFunction(int[] arr, out int sum, out int max)
        {
            int maximum = arr[0];
            int summa = 0;
            foreach(int elem in arr)
            {
                if(elem/10%10>=3&&elem/10%10<=7&&elem/100%10!=1&&elem/100%10!=9)
                {
                    ++summa;
                    if (elem > maximum) maximum = elem; 
                }
            }
            sum = summa;
            max = maximum;
        }
        

        static bool Digit(int n)
        {
            int z = 0, f = 0, t = 0;
            while(n>0)
            {
                if (n % 10 == 0)
                    ++z;
                if (n % 10 == 5)
                    ++f;
                if (n % 10 == 2)
                    ++t;
                n /= 10;
            }
            return (z!=0&&f!=0&&t!=0) ? true : false;
        }

        static void FourthFunction(int[] arr, out int sum, out int min)
        {
            int summa = 0;
            int minimum = arr[arr.Length - 1] + 1;
            foreach(int elem in arr)
            {
                if(elem%7==0&&Digit(elem))
                {
                    minimum = elem;
                    break;
                }
            }
            foreach(int elem in arr)
            {
                if (elem % 7 == 0 && Digit(elem)) ++summa;
            }
            sum = summa;
            min = minimum;
        }

        static int Delemiter(int n)
        {
            int sum = 0;
            for(int i=1; i<=n; ++i)
            {
                if (n % i == 0) ++sum;
            }
            return sum;
        }
        static void FifthFunction(int[] arr, out int sum, out int min)
        {
            int summa = 0;
            int minimum = arr[arr.Length - 1] + 1;
            foreach(int elem in arr)
            {
                if (Delemiter(elem) > 35)
                {
                    minimum = elem;
                    break;
                }
            }
            foreach(int elem in arr)
            {
                if (Delemiter(elem) > 35) ++summa;
            }
            sum = summa;
            min = minimum;
        }

        static void Main(string[] args)
        {
            int sum1, min1, sum2, min2, sum3, max3, sum4, min4, sum5, min5;
            FirstFunction(MakeArray(1107, 9504), out sum1, out min1);
            Console.WriteLine($"Сумма: {sum1}");
            Console.WriteLine($"Минимальное: {min1}");
            SecondFunction(MakeArray(1529, 9482), out sum2, out min2);
            Console.WriteLine($"Сумма: {sum2}");
            Console.WriteLine($"Минимальное: {min2}");
            ThirdFunction(MakeArray(2461, 9719), out sum3, out max3);
            Console.WriteLine($"Сумма: {sum3}");
            Console.WriteLine($"Максимальное: {max3}");
            FourthFunction(MakeArray(2079, 43167), out sum4, out min4);
            Console.WriteLine($"Сумма: {sum4}");
            Console.WriteLine($"Минимальное: {min4}");
            FifthFunction(MakeArray(56123, 97354), out sum5, out min5);
            Console.WriteLine($"Сумма: {sum5}");
            Console.WriteLine($"Минимальное: {min5}");
            Console.ReadKey();
        }
    }
}
