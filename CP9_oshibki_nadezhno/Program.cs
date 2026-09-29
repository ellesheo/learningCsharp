namespace CP9_oshibki_nadezhno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = new List<string>
            {
                "ORDER001;150,50;3",
                "плохая строка",
                "ORDER002;-10;1",
                "ORDER003;200;2"
            };
            OrderProcessor processor = new OrderProcessor();
            processor.Process(lines);
        }
    }
}