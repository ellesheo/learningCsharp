namespace CP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Balance b1 = new Balance(100m);
            Balance b2 = new Balance(100m);
            Balance b3 = new Balance(-50m);
            Console.WriteLine(b1 == b2);
            Console.WriteLine(b1 == b3);
            Console.WriteLine(b1 > b3);
            Console.WriteLine(b1.GetHashCode() == b2.GetHashCode());
            if (b1)
                Console.WriteLine("b1 сработал");
            if (b3)
                Console.WriteLine("b3 сработал");
        }
    }
}