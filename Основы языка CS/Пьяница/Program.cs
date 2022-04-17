using System;

namespace Пьяница {
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

        public Seniority[] FirstDeck() {
            Seniority[] arr = new Seniority[18];
            Array.Copy(deck, 0, arr, 0, 18);
            return arr;
        }

        public Seniority[] SecondDeck() {
            Seniority[] arr = new Seniority[18];
            Array.Copy(deck, 18, arr, 0, 18);
            return arr;
        }

        public void OutputDeck() {
            foreach (Seniority e in deck)
                Console.WriteLine($"{e}");
        }
    }

    class Player {
        Seniority[] deck;

        public Seniority this[int index] {
            get {
                return deck[index];
            }
        }

        public Player(Seniority[] deck) {
            this.deck = deck;
        }

        public void AddCard(Player player) {
            Seniority elem = player.Pop();
            Seniority[] arr = new Seniority[deck.Length + 1];
            Array.Copy(deck, 1, arr, 0, deck.Length - 1);
            arr[deck.Length - 1] = deck[0];
            arr[deck.Length] = elem;
            deck = arr;
        }

        private Seniority Pop() {
            Seniority elem = deck[0];
            Seniority[] arr = new Seniority[deck.Length - 1];
            Array.Copy(deck, 1, arr, 0, deck.Length - 1);
            deck = arr;
            return elem;
        }

        public int Length {
            get {
                return deck.Length;
            }
        }

        public void OutputDeck() {
            foreach (Seniority e in deck)
                Console.WriteLine($"{e}");
        }
    }

    class Program {
        static void Main(string[] args) {
            Cards deck = new Cards();
            deck.Shuffle();
            Seniority[] deck1 = deck.FirstDeck();
            Seniority[] deck2 = deck.SecondDeck();
            Player player1 = new Player(deck1);
            Player player2 = new Player(deck2);
            int index = 0, cnt = 0;
            while (index < 35 && player1.Length > 0 && player2.Length > 0) {
                index = 0;
                Console.WriteLine($"Карта достоинства: {player1[index]}");
                Console.WriteLine($"Карта достоинства: {player2[index]}");
                if (player1[index] > player2[index]) {
                    Console.WriteLine($"Первый игрок выиграл тур, получил: {player1[index]} {player2[index]}");
                    Console.WriteLine($"Добавляем {player1[index]} и {player2[index]}");
                    player1.AddCard(player2);
                }
                else if (player1[index] < player2[index]) {
                    Console.WriteLine($"Второй игрок выиграл тур, получил: {player1[index]} {player2[index]}");
                    Console.WriteLine($"Добавляем {player1[index]} и {player2[index]}");
                    player2.AddCard(player1);
                }
                else {
                    int ind = index + 1;
                    while (player1[ind] == player2[ind]) 
                        ++ind;
                    Console.WriteLine("ВОЙНА");
                    Console.WriteLine($"Карта достоинства: {player1[ind]}");
                    Console.WriteLine($"Карта достоинства: {player2[ind]}");
                    Console.WriteLine($"Карта достоинства: {player1[ind + 1]}");
                    Console.WriteLine($"Карта достоинства: {player2[ind + 1]}");
                    Console.WriteLine($"Первый игрок выложил: одну рубашкой вниз и {player1[ind]}, а второй игрок: тоже закрытую и {player2[ind]}");
                    if (player1[ind] > player2[ind]) {
                        Console.WriteLine("Первый игрок выиграл войну");
                        for (int i = index; i <= ind; ++i) {
                            Console.WriteLine($"Добавляем {player1[i]} и {player2[0]}");
                            player1.AddCard(player2);
                        }
                    }
                    else if (player1[ind] < player2[ind]) {
                        Console.WriteLine("Второй игрок выиграл войну");
                        for (int i = index; i <= ind; ++i) {
                            Console.WriteLine($"Добавляем {player1[0]} и {player2[i]}");
                            player2.AddCard(player1);
                        }
                    }
                }
                ++cnt;
                Console.WriteLine("СЛЕДУЮЩИЙ ТУР");
            }
            Console.WriteLine("Карты закончились!");
            if (player1.Length > player2.Length)
                Console.WriteLine("ВЫИГРАЛ ПЕРВЫЙ игрок!");
            else if (player1.Length < player2.Length)
                Console.WriteLine("ВЫИГРАЛ ВТОРОЙ игрок!");
            Console.WriteLine($"Игра закончена за {cnt + 1} хода(ов)");
            Console.ReadKey();
        }
    }
}
