namespace CP39_iteratori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CircularBuffer<int> numbers = new(3);

            Console.WriteLine("Буфер на 3, кладём 1, 2, 3, 4, 5");
            Console.WriteLine();

            for (int i = 1; i <= 5; i++)
            {
                numbers.Add(i);
                Console.WriteLine($"добавили {i}: {string.Join(", ", numbers)}");
            }

            Console.WriteLine();
            Console.WriteLine($"от старого к новому (foreach): {string.Join(", ", numbers)}");
            Console.WriteLine($"от нового к старому (Reverse): {string.Join(", ", numbers.Reverse())}");

            Console.WriteLine();
            Console.WriteLine("Буфер на 3, но уже с сообщениями");
            Console.WriteLine();

            CircularBuffer<Message> log = new(3);
            log.Add(new Message(Level.Info, "старт"));
            log.Add(new Message(Level.Warning, "мало места"));
            log.Add(new Message(Level.Error, "файл не найден"));
            log.Add(new Message(Level.Info, "повтор"));

            foreach (Message message in log)
                Console.WriteLine(Format(message));

            Console.WriteLine();
            Console.WriteLine("Своё сообщение");
            Console.WriteLine();

            log.Add(ReadMessage());

            Console.WriteLine();
            Console.WriteLine("от старого к новому (foreach):");

            foreach (Message message in log)
                Console.WriteLine(Format(message));

            Console.WriteLine();
            Console.WriteLine("от нового к старому (Reverse):");

            foreach (Message message in log.Reverse())
                Console.WriteLine(Format(message));
        }

        static string Format(Message message) => $"{Mark(message.Level)}: {message.Text}";

        static string Mark(Level level) => level switch
        {
            Level.Info => "обычное",
            Level.Warning => "важное",
            Level.Error => "ошибка",
            _ => "непонятное"
        };

        static Message ReadMessage()
        {
            while (true)
            {
                Console.Write("Сообщение (error, текст): ");

                try
                {
                    return ParseMessage(Console.ReadLine() ?? "");
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static Message ParseMessage(string line)
        {
            string[] parts = line.Split(',');

            if (parts.Length != 2)
                throw new InvalidInputException("Нужно два поля: error, текст");

            if (!Enum.TryParse(parts[0].Trim(), true, out Level level) || !Enum.IsDefined(typeof(Level), level))
                throw new InvalidInputException($"Нет уровня {parts[0].Trim()}. Есть Info, Warning, Error");

            string text = parts[1].Trim();

            if (text.Length == 0)
                throw new InvalidInputException("Текст пустой");

            return new Message(level, text);
        }
    }
}