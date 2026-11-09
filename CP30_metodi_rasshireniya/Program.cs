namespace CP30_metodi_rasshireniya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new() { 5, 9, 2 };

            Console.WriteLine("FindMax");
            Console.WriteLine();
            Console.WriteLine($"List<int> {{ 5, 9, 2 }}: {numbers.FindMax()}");

            List<Card> cards = new()
            {
                new Card { Rank = Rank.Ten, Suit = Suit.Hearts },
                new Card { Rank = Rank.Ace, Suit = Suit.Spades },
                new Card { Rank = Rank.Queen, Suit = Suit.Clubs }
            };

            Console.WriteLine($"List<Card> из трёх карт: {cards.FindMax()}");

            Console.WriteLine();
            Console.WriteLine("PrintAll");
            Console.WriteLine();

            numbers.PrintAll("Элемент: ");
            cards.PrintAll("Карта: ");

            Console.WriteLine();
            Console.WriteLine("Своя карта");
            Console.WriteLine();

            cards.Add(ReadCard());
            cards.PrintAll("Карта: ");
            Console.WriteLine($"старшая: {cards.FindMax()}");
        }

        static Card ReadCard()
        {
            while (true)
            {
                Console.Write("Карта (Ace, Spades): ");

                try
                {
                    return ParseCard(Console.ReadLine() ?? "");
                }
                catch (InvalidCardException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static Card ParseCard(string line)
        {
            string[] parts = line.Split(',');

            if (parts.Length != 2)
                throw new InvalidCardException("Нужно два поля через запятую, например: Ace, Spades");

            if (!Enum.TryParse(parts[0].Trim(), true, out Rank rank) || !Enum.IsDefined(typeof(Rank), rank))
                throw new InvalidCardException($"\"{parts[0].Trim()}\" - не достоинство. Есть: Six..Ten, Jack, Queen, King, Ace");

            if (!Enum.TryParse(parts[1].Trim(), true, out Suit suit) || !Enum.IsDefined(typeof(Suit), suit))
                throw new InvalidCardException($"\"{parts[1].Trim()}\" - не масть. Есть: Clubs, Diamonds, Hearts, Spades");

            return new Card { Rank = rank, Suit = suit };
        }
    }
}