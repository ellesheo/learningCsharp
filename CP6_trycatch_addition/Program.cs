namespace CP6_trycatch_addition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberParser parser = new NumberParser();
            Console.WriteLine("обычный список");
            List<string> values = new List<string> { "10", "", "abc", "20" };
            int sum = parser.SumValidNumbers(values);
            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine();
            Console.WriteLine("список с переполнением");
            List<string> overflow = new List<string> { "10", "99999999999" };
            try
            {
                parser.SumValidNumbers(overflow);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Наверху поймали OverflowException: {ex.Message}");
            }
        }
    }
}