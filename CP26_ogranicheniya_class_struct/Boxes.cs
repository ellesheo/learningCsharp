namespace CP26_ogranicheniya_class_struct
{
    public enum Currency { Rub, Usd, Eur }

    public struct Money
    {
        public decimal Amount { get; init; }

        public Currency Currency { get; init; }

        public override string ToString() => $"{Amount} {Currency}";
    }

    public class Product
    {
        public string Name { get; init; } = "";

        public override string ToString() => $"товар \"{Name}\"";
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException() { }

        public InvalidInputException(string message) : base(message) { }

        public InvalidInputException(string message, Exception inner) : base(message, inner) { }
    }

    public class ReferenceBox<T> where T : class
    {
        private T? value;

        public bool IsEmpty => value is null;

        public void Set(T item) => value = item;

        public T? Get() => value;
    }

    public class ValueBox<T> where T : struct
    {
        private T? value;

        public bool IsEmpty => value is null;

        public void Set(T item) => value = item;

        public T? Get() => value;
    }
}