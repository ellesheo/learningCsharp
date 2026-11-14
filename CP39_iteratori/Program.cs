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
            Console.WriteLine("Свои числа");
            Console.WriteLine();

            CircularBuffer<int> own = new(ReadNumber("Ёмкость буфера: "));

            while (true)
            {
                int value = ReadNumber("Число (0 - закончить ввод): ");

                if (value == 0)
                    break;

                own.Add(value);
                Console.WriteLine($"в буфере: {string.Join(", ", own)}");
            }

            Console.WriteLine();
            Console.WriteLine($"от старого к новому (foreach): {string.Join(", ", own)}");
            Console.WriteLine($"от нового к старому (Reverse): {string.Join(", ", own.Reverse())}");
        }

        static int ReadNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                if (int.TryParse((Console.ReadLine() ?? "").Trim(), out int value))
                    return value;

                Console.WriteLine("Это не число");
            }
        }
    }
}