namespace CP16_var2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object[] events =
            {
                new AttackEvent("Герой", "Дракон", 75),
                new AttackEvent("Герой", "Дракон", 10),
                new HealEvent("Жрец", "Жрец", 20),
                new HealEvent("Жрец", "Воин", 20),
                new DeathEvent("Дракон"),
                42
            };

            Console.WriteLine("Проверочные ключи:");
            Console.WriteLine();

            foreach (object gameEvent in events)
            {
                Console.WriteLine(gameEvent);
                Console.WriteLine($"   -> {BattleLog.ToLogLine(gameEvent)}");
            }

            string[] probes =
            {
                "attack, Герой, Дракон, 75",
                "attack, Герой, Дракон, 10",
                "heal, Жрец, Жрец, 20",
                "heal, Жрец, Воин, 20",
                "death, Дракон",
                "attack, Герой, Дракон, много",
                "heal, Жрец, Воин, -5",
                "attack, , Дракон, 30",
                "tancuet, Герой"
            };

            Console.WriteLine();
            Console.WriteLine("Разбор введённых строк:");
            Console.WriteLine();

            foreach (string probe in probes)
            {
                Console.Write($"\"{probe}\"   -> ");

                try
                {
                    Console.WriteLine(BattleLog.ToLogLine(ParseEvent(probe.Split(','))));
                }
                catch (InvalidEventException ex)
                {
                    Console.WriteLine($"ошибка: {ex.Message}");
                }
            }

            Console.WriteLine();
            object own = ReadEvent();
            Console.WriteLine(own);
            Console.WriteLine($"   -> {BattleLog.ToLogLine(own)}");
        }

        static object ReadEvent()
        {
            while (true)
            {
                Console.Write("Своё событие (attack, кто, кого, урон   heal, кто, кого, сколько   death, кто): ");
                string[] parts = (Console.ReadLine() ?? "").Split(',');

                try
                {
                    return ParseEvent(parts);
                }
                catch (InvalidEventException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static object ParseEvent(string[] parts)
        {
            string kind = parts[0].Trim().ToLower();

            if (kind == "attack" && parts.Length == 4)
                return new AttackEvent(ParseName(parts[1]), ParseName(parts[2]), ParseNumber(parts[3]));

            if (kind == "heal" && parts.Length == 4)
                return new HealEvent(ParseName(parts[1]), ParseName(parts[2]), ParseNumber(parts[3]));

            if (kind == "death" && parts.Length == 2)
                return new DeathEvent(ParseName(parts[1]));

            throw new InvalidEventException("Не понял. Пример: attack, Герой, Дракон, 75   heal, Жрец, Воин, 20   death, Дракон");
        }

        static string ParseName(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new InvalidEventException("Имя не может быть пустым");

            return text.Trim();
        }

        static int ParseNumber(string text)
        {
            if (!int.TryParse(text.Trim(), out int value))
                throw new InvalidEventException($"\"{text.Trim()}\" - это не число");

            if (value < 0)
                throw new InvalidEventException("Число не может быть отрицательным");

            return value;
        }
    }
}