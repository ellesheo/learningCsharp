namespace CP13_structuri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card[] cards = new Card[5];

            for (int i = 0; i < cards.Length; i++)
                cards[i] = ReadCard($"Карта {i + 1} (например King Hearts): ");

            Console.WriteLine();
            Console.WriteLine("Все карты:");
            foreach (Card card in cards)
                Console.WriteLine(card);

            Console.WriteLine();
            Card copy = cards[0];
            Rank newRank;

            while (true)
            {
                Console.Write("На какое достоинство поменять копию (Two, Jack, Queen, King, Ace): ");
                string? input = Console.ReadLine();

                if (Enum.TryParse<Rank>(input, out newRank))
                    break;

                Console.WriteLine("Не распознано, исключения не было");
            }

            copy.Rank = newRank;

            Console.WriteLine();
            Console.WriteLine($"Преображено в:      {copy}");
            Console.WriteLine($"В массиве осталось: {cards[0]}");
        }

        static Card ReadCard(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string[] parts = (Console.ReadLine() ?? "").Split(' ');

                if (parts.Length == 2
                    && Enum.TryParse<Rank>(parts[0], out Rank rank)
                    && Enum.TryParse<Suit>(parts[1], out Suit suit))
                {
                    return new Card { Rank = rank, Suit = suit };
                }

                Console.WriteLine("Не понял. Пример: King Hearts");
            }
        }
    }
}