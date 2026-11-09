namespace CP22_events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Проверочные ключи: Start(6)");
            Console.WriteLine();

            RunCountdown(6);

            Console.WriteLine();
            Console.WriteLine("Свой запуск:");
            Console.WriteLine();

            int seconds = ReadSeconds();

            Console.WriteLine();
            RunCountdown(seconds);
        }

        static void RunCountdown(int seconds)
        {
            Timer timer = new();

            EventHandler<int> logger = (sender, left) =>
                Console.WriteLine($"Осталось {left} сек. - {Timer.Comment(Timer.GetPhase(left, seconds))}");

            EventHandler<int> halfStopper = null!;

            halfStopper = (sender, left) =>
            {
                Console.WriteLine("   Гав!");

                if (left <= seconds / 2)
                {
                    Console.WriteLine("   Гав-гав, я спать");
                    timer.Tick -= halfStopper;
                }
            };

            timer.Tick += logger;
            timer.Tick += halfStopper;
            timer.Finished += (sender, e) => Console.WriteLine("Время вышло");

            timer.Start(seconds);
        }

        static int ReadSeconds()
        {
            while (true)
            {
                Console.Write("Сколько секунд отсчитать: ");

                try
                {
                    return ParseSeconds(Console.ReadLine() ?? "");
                }
                catch (InvalidTimeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static int ParseSeconds(string text)
        {
            if (!int.TryParse(text.Trim(), out int value))
                throw new InvalidTimeException($"\"{text.Trim()}\" - это не число");

            if (value <= 0)
                throw new InvalidTimeException("Секунд должно быть больше нуля");

            return value;
        }
    }
}