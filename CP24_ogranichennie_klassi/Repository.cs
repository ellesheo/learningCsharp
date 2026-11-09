using System;
using System.Collections.Generic;
using System.Text;

namespace CP24_ogranichennie_klassi
{
    public class Entity
    {
        public int Id { get; init; }
    }

    public class Product : Entity
    {
        public string Name { get; init; } = "";

        public override string ToString() => $"товар \"{Name}\"";
    }

    public class Customer : Entity
    {
        public string Email { get; init; } = "";

        public override string ToString() => $"клиент {Email}";
    }

    public class DuplicateIdException : Exception
    {
        public DuplicateIdException() { }

        public DuplicateIdException(string message) : base(message) { }

        public DuplicateIdException(string message, Exception inner) : base(message, inner) { }
    }

    public class Repository<T> where T : Entity
    {
        private readonly List<T> items = new();

        public int Count => items.Count;

        public void Add(T item)
        {
            if (GetById(item.Id) != null)
                throw new DuplicateIdException($"Элемент с Id {item.Id} уже есть в репозитории");

            items.Add(item);
        }

        public T? GetById(int id)
        {
            foreach (T item in items)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }
    }
}