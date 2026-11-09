namespace CP19_delegaty_i_lyambdi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверочные ключи (числа 1, 2, 3, 4, 5, 6):");

            foreach (FilterMode demoMode in Enum.GetValues<FilterMode>())
            {
                Console.WriteLine();
                Console.WriteLine($"Режим {demoMode}:");
                NumberPipeline.Run(new List<int> { 1, 2, 3, 4, 5, 6 }, demoMode);
            }

            Console.WriteLine();
            Console.WriteLine("Свой ввод:");
            Console.WriteLine();

            List<int> numbers = ReadNumbers();
            FilterMode mode = ReadMode();

            Console.WriteLine();
            NumberPipeline.Run(numbers, mode);
        }

        static List<int> ReadNumbers()
        {
            while (true)
            {
                Console.Write("Числа через запятую (например: 1, 2, 3, 4, 5, 6): ");
                string[] parts = (Console.ReadLine() ?? "").Split(',');

                try
                {
                    List<int> result = new();

                    foreach (string part in parts)
                        result.Add(ParseNumber(part));

                    return result;
                }
                catch (InvalidNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static FilterMode ReadMode()
        {
            while (true)
            {
                Console.Write("Режим (even, odd, positive): ");
                string text = (Console.ReadLine() ?? "").Trim();

                if (Enum.TryParse(text, true, out FilterMode mode) && Enum.IsDefined(typeof(FilterMode), mode))
                    return mode;

                Console.WriteLine("Не понял режим. Доступны: even, odd, positive");
            }
        }

        static int ParseNumber(string text)
        {
            if (int.TryParse(text.Trim(), out int value))
                return value;

            throw new InvalidNumberException($"\"{text.Trim()}\" - это не число");
        }
    }
}