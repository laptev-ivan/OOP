using System;

namespace Пьяница
{
    enum Seniority {
        Шестерка,
        Семерка,
        Восьмерка,
        Девятка,
        Десятка,
        Валет,
        Дама,
        Король,
        Туз
    };

    class Cards {
        Seniority[] deck;
        static Random rnd = new Random();

        public Seniority this[int index] {
            get {
                if (index < 0 || index > 36)
                    throw new Exception(@"введен неверный индекс.");
                else
                    return deck[index];
            }
        }

        public Cards() {
            deck = new Seniority[36];
            for (int i = 0, k = 0, j = 0; i < deck.Length && j <= 8; ++i, ++k) {
                if (k == 4) {
                    k = 0;
                    ++j;
                }
                deck[i] = (Seniority)j;
            }
        }

        public void Shuffle() {
            for (int i = 0; i < deck.Length; ++i) {
                int rand = rnd.Next(0, deck.Length - 1);
                Seniority tmp = deck[i];
                deck[i] = deck[rand];
                deck[rand] = tmp;
            }
        }

        public void Pop() {
            Seniority arr;
            arr = Array.Copy(deck, 1, arr, 0, deck.Length);
        }

        public void OutputDeck() {
            foreach (Seniority e in deck)
                Console.WriteLine($"{e}");
        }
    }

    class Player {
    
    }

    class Program {
        static void Main(string[] args) {
            Cards deck = new Cards();
            Player player1 = new Player();
            Player player2 = new Player();
            deck.Shuffle();

            deck.OutputDeck();
            Console.ReadKey();
        }
    }
}
