using System;

namespace Редактор_текста
{
    class Program
    {   
        static int CountWords(string s)
        {
            string[] Words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return Words.Length;
        }

        static string MinWord(string s)
        {
            char[] separator = { ' ', '.', ',', '!', '?', ';', ':' };
            string[] words = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string min = words[0];
            for (int i=0; i<words.Length; ++i)
            {
                if(words[i].Length<min.Length)
                {
                    min = words[i];
                }
            }
            return min;
        }

        static string MaxWord(string s)
        {
            char[] separator = { ' ', '.', ',', '!', '?', ';', ':' };
            string[] words = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string max = words[0];
            for (int i = 0; i < words.Length; ++i)
            {
                if (words[i].Length > max.Length)
                {
                    max = words[i];
                }
            }
            return max;
        }

        static int CountSents(string s)
        {
            int cnt = 0;
            char[] seps = { '.', '!', '?' };
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == seps[0] || s[i] == seps[1] || s[i] == seps[2])
                {
                    ++cnt;
                }
            }
            return cnt;
        }
        static string CharsInString(string s)
        {
            bool flag = true;
            string ans = "";
            s = s.ToLower();
            for(int i=0; i<s.Length; ++i)
            {
                flag = true;
                for (int j = 0; j < ans.Length; ++j) 
                {
                    if (s[i] == ans[j])
                    {
                        flag = false;
                    }
                }
                if(flag)
                {
                    ans = String.Concat(ans, s[i]);
                }
            }
            return ans;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите строку: "); string s = Console.ReadLine();
            int SumOfWords = CountWords(s);
            string MinLengthWord = MinWord(s);
            string MaxLengthWord = MaxWord(s);
            int SumOfSentences = CountSents(s);
            string Chars = CharsInString(s);
            Console.Write($"Количество слов: {SumOfWords}");
            Console.Write($"Самое короткое слово: {MinLengthWord}");
            Console.Write($"Самое длинное слово: {MaxLengthWord}");
            Console.Write($"Количество предложений: {SumOfSentences}");
            Console.Write($"Символы: {Chars}");
            Console.ReadKey();
        }
    }
}