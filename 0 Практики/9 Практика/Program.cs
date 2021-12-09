using System;

namespace _9_Практика
{
    class Program
    {
        static string ThirdDigit(int n)
        {
            string s = String.Concat(n);
            string dot = ".";
            for (int i = s.Length - 1; i >= 0; i -= 3)
            { 
                s = s.Insert(i+1 , dot);
            }
            return s;
        }

        static string Substrings(string s, string subs)
        {
            int lengthofsubs = subs.Length;
            string res = "";
            for(int i=0; i<=s.Length; ++i)
            {
                int index = s.IndexOf(subs);
                if (index == -1)
                {
                    break;
                }
                else
                {
                    res = s.Remove(index, lengthofsubs);
                }
            }
            return res;
        }
        
        static string RemoveMiddlePos(string s)
        {
            int len = s.Length;
            if (len % 2 == 0)
            {
                s = s.Remove(len / 2 - 1, 2);
            }
            else
            {
                s += s.Remove(len / 2, 1);
            }
            return s;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число n: "); int n = int.Parse(Console.ReadLine());
            Console.Write("Введите строку s: "); string s = Console.ReadLine();
            Console.Write("Введите подстроку subs: "); string subs = Console.ReadLine();
            string answer1 = ThirdDigit(n);
            string answer2 = Substrings(s, subs);
            string answer3 = RemoveMiddlePos(s);
            Console.WriteLine($"Число с точками: {answer1}");
            Console.WriteLine($"Удаление подстрок subs из s: {answer2}");
            Console.WriteLine($"Удаление среднего символа(ов): {answer3}");
            Console.ReadKey();
        }
    }
}
