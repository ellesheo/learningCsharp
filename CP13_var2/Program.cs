namespace CP13_var2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Item[] items = new Item[5];

            items[0] = ReadItem("Первый предмет (например Меч Дракона, Legendary, Weapon): ");
            items[1] = new Item { Name = "Щит Света", Rarity = ItemRarity.Epic, Slot = ItemSlot.Armor };
            items[2] = new Item { Name = "Кольцо Мудрости", Rarity = ItemRarity.Rare, Slot = ItemSlot.Accessory };
            items[3] = new Item { Name = "Посох Огня", Rarity = ItemRarity.Common, Slot = ItemSlot.Weapon };
            items[4] = new Item { Name = "Латы Стража", Rarity = ItemRarity.Legendary, Slot = ItemSlot.Armor };

            Console.WriteLine();
            Console.WriteLine("Все предметы:");
            foreach (Item item in items)
                Console.WriteLine(item);

            Console.WriteLine();
            Item copy = items[0];
            ItemRarity newRarity;

            while (true)
            {
                Console.Write("На какую редкость поменять копию (Common, Rare, Epic, Legendary): ");
                string? input = Console.ReadLine();

                if (Enum.TryParse<ItemRarity>(input, out newRarity))
                    break;

                Console.WriteLine("Не распознано, исключения не было");
            }

            copy.Rarity = newRarity;

            Console.WriteLine();
            Console.WriteLine($"Преображено в:      {copy}");
            Console.WriteLine($"В массиве осталось: {items[0]}");
        }

        static Item ReadItem(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string[] parts = (Console.ReadLine() ?? "").Split(',');

                if (parts.Length == 3
                    && !string.IsNullOrWhiteSpace(parts[0])
                    && Enum.TryParse<ItemRarity>(parts[1].Trim(), out ItemRarity rarity)
                    && Enum.TryParse<ItemSlot>(parts[2].Trim(), out ItemSlot slot))
                {
                    return new Item { Name = parts[0].Trim(), Rarity = rarity, Slot = slot };
                }

                Console.WriteLine("Не понял. Пример: Меч Дракона, Legendary, Weapon");
            }
        }
    }
}