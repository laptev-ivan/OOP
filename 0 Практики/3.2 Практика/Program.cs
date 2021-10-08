using System;

namespace _3._2_Практика
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            for(int i=101; i<1000; ++i)
            {
                a = i/100;
                b = (i-a)/10;
                c = i%10;
                if(a==b||b==c||a==c)
                    Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
