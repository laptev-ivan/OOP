using System;

namespace _5._2_Пракитка
{
    class Program
    {
        static int not_multiple_of_three(int n)
        {
            int digit, sum = 0;
            for (int i = n; i > 0; i /= 10) { 
                digit = i % 10;
                if (digit % 3 > 0)
                    sum += digit;
            }
            return sum;
        }   

        static int second_digit(int n)
        {
            if (n < 0)
                n = -n;
            while (n > 100)
                n /= 10;
            int res = n % 10;
            return res;
        }

        static int n_within_three(int n)
        {
            int digit, count = 1, res = 0;
            for(int i = n; i > 0; i /= 10)  
            {
                digit = i % 10;
                if (digit != 3)
                {
                    res += count * digit;
                    count *= 10;
                }
                n /= 10;
            }
            return res;
        }

        static int replace_first_last_digits(int n)
        {
            int count = 1;
            for(int i = n; i > 0; i /= 10)
            {
                count *= 10;
            }
            int first_digit = n / count;
            int last_digit = n % 10;
            return first_digit; 
        }

        static void Main(string[] args)
        {
            Console.Write("Введите n:\t");  int n = int.Parse(Console.ReadLine());
            int answer = not_multiple_of_three(n);
            if (answer == 0)
                Console.WriteLine("NO");
            else
                Console.WriteLine($"Сумма цифр не кратных 3:\t{answer}");
            int answer2 = second_digit(n);
            Console.WriteLine($"Вторая цифра числа слева:\t{answer2}");
            int answer3 = n_within_three(n);
            Console.WriteLine($"N без \"3\":\t{answer3}");
            int answer4 = replace_first_last_digits(n);
            Console.WriteLine($"Перестановка первой и последней цифры:\t{answer4}");
            Console.ReadKey();
        }
    }
}