using System.Globalization;

namespace CP26_ogranicheniya_class_struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1. Обёртки");
            Console.WriteLine();

            ReferenceBox<string> nameBox = new();
            Console.WriteLine($"новый ReferenceBox<string>: пусто = {nameBox.IsEmpty}");
            nameBox.Set("Алина");
            Console.WriteLine($"после Set(\"Алина\"): пусто = {nameBox.IsEmpty}, внутри = {nameBox.Get()}");

            Console.WriteLine();

            ValueBox<int> ageBox = new();
            Console.WriteLine($"новый ValueBox<int>: пусто = {ageBox.IsEmpty}");
            ageBox.Set(25);
            Console.WriteLine($"после Set(25): пусто = {ageBox.IsEmpty}, внутри = {ageBox.Get()}");

            Console.WriteLine();

            ReferenceBox<Product> productBox = new();
            productBox.Set(new Product { Name = "Клавиатура" });
            Console.WriteLine($"свой класс в ReferenceBox: внутри = {productBox.Get()}");

            ValueBox<Money> moneyBox = new();
            moneyBox.Set(new Money { Amount = 1500, Currency = Currency.Rub });
            Console.WriteLine($"своя структура в ValueBox: внутри = {moneyBox.Get()}");

            // ReferenceBox<int> не соберётся: int - не ссылочный тип (CS0452)
            // ValueBox<string> не соберётся: string - не тип значения (CS0453)

            Console.WriteLine();
            Console.WriteLine("Задание 2. Кэш");
            Console.WriteLine();

            ReferenceCache<string> textCache = new();
            Console.WriteLine($"пустой ReferenceCache<string>: {Describe(textCache.TryGet(out string? text), text)}");
            textCache.Put("сохранённая строка");
            Console.WriteLine($"после Put: {Describe(textCache.TryGet(out text), text)}");

            Console.WriteLine();

            ValueCache<double> numberCache = new();
            Console.WriteLine($"пустой ValueCache<double>: {Describe(numberCache.TryGet(out double? number), number)}");
            numberCache.Put(3.14);
            Console.WriteLine($"после Put: {Describe(numberCache.TryGet(out number), number)}");

            // ReferenceCache<double> не соберётся: double - не ссылочный тип (CS0452)
            // ValueCache<string> не соберётся: string - не тип значения (CS0453)

            Console.WriteLine();
            Console.WriteLine("Свой ввод, задание 1");
            Console.WriteLine();

            ReferenceBox<string> ownText = new();
            Console.WriteLine($"новый ReferenceBox<string>: пусто = {ownText.IsEmpty}");
            Console.Write("Своя строка: ");
            ownText.Set(Console.ReadLine() ?? "");
            Console.WriteLine($"после Set: пусто = {ownText.IsEmpty}, внутри = {ownText.Get()}");

            Console.WriteLine();

            ValueBox<double> ownNumber = new();
            Console.WriteLine($"новый ValueBox<double>: пусто = {ownNumber.IsEmpty}");
            ownNumber.Set(ReadNumber("Своё число: "));
            Console.WriteLine($"после Set: пусто = {ownNumber.IsEmpty}, внутри = {ownNumber.Get()}");

            Console.WriteLine();
            Console.Write("Enter - дальше, к заданию 2: ");
            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Свой ввод, задание 2");
            Console.WriteLine();

            ReferenceCache<string> ownTextCache = new();
            Console.WriteLine($"пустой ReferenceCache<string>: {Describe(ownTextCache.TryGet(out string? ownCached), ownCached)}");
            Console.Write("Своя строка в кэш: ");
            ownTextCache.Put(Console.ReadLine() ?? "");
            Console.WriteLine($"после Put: {Describe(ownTextCache.TryGet(out ownCached), ownCached)}");

            Console.WriteLine();

            ValueCache<double> ownNumberCache = new();
            Console.WriteLine($"пустой ValueCache<double>: {Describe(ownNumberCache.TryGet(out double? ownCachedNumber), ownCachedNumber)}");
            ownNumberCache.Put(ReadNumber("Своё число в кэш: "));
            Console.WriteLine($"после Put: {Describe(ownNumberCache.TryGet(out ownCachedNumber), ownCachedNumber)}");
        }

        static string Describe<T>(bool found, T? value) where T : class =>
            found ? $"true, значение \"{value}\"" : "false, значение null";

        static string Describe<T>(bool found, T? value) where T : struct =>
            found ? $"true, значение {value}" : "false, значение null";

        static double ReadNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                try
                {
                    return ParseNumber(Console.ReadLine() ?? "");
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static double ParseNumber(string text)
        {
            string normalized = text.Trim().Replace(',', '.');

            if (double.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                return value;

            throw new InvalidInputException($"\"{text.Trim()}\" - это не число");
        }
    }
}