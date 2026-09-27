namespace CP6_trycatch_addition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberParser parser = new NumberParser();
            List<string> values = new List<string> { "10", "", "abc", "20" };
            int sum = parser.SumValidNumbers(values);
            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine();
            List<string> overflow = new List<string> { "10", "99999999999" };
            try
            {
                parser.SumValidNumbers(overflow);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Поймали переполнение: {ex.Message}");
            }
        }
    }
}