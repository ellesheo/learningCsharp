namespace CP19_delegaty_i_lyambdi
{
    public enum FilterMode { Even, Odd, Positive }

    public class InvalidNumberException : Exception
    {
        public InvalidNumberException() { }

        public InvalidNumberException(string message) : base(message) { }

        public InvalidNumberException(string message, Exception inner) : base(message, inner) { }
    }

    public static class NumberPipeline
    {
        public static void Run(List<int> numbers, FilterMode mode)
        {
            Func<int, bool> filter = GetFilter(mode);
            Func<int, int> square = x => x * x;

            List<int> history = new();

            Action<int> show = n => Console.WriteLine(n);
            show += n => history.Add(n);

            List<int> filtered = new();

            foreach (int number in numbers)
            {
                if (filter(number))
                {
                    filtered.Add(number);
                }
            }

            List<int> squared = new();

            foreach (int number in filtered)
            {
                squared.Add(square(number));
            }

            Console.WriteLine($"Исходные числа: {string.Join(", ", numbers)}");
            Console.WriteLine($"Отфильтровано: {string.Join(", ", filtered)}");
            Console.WriteLine($"Квадраты: {string.Join(", ", squared)}");
            Console.WriteLine("Объединённое действие (вывод + сохранение):");

            foreach (int number in squared)
            {
                show(number);
            }

            Console.WriteLine($"Сохранено элементов: {history.Count}");
        }

        public static Func<int, bool> GetFilter(FilterMode mode) => mode switch
        {
            FilterMode.Even => x => x % 2 == 0,
            FilterMode.Odd => x => x % 2 != 0,
            FilterMode.Positive => x => x > 0,
            _ => x => true
        };
    }
}