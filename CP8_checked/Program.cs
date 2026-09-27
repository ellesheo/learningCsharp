namespace CP8_checked
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine(calc.SumChecked(new[] { 1, 2, 3 }));
            Console.WriteLine(calc.SumChecked(new[] { int.MaxValue, 1 }));
            Console.WriteLine(calc.ParseOrZero("42"));
            Console.WriteLine(calc.ParseOrZero("abc"));
        }
    }
}