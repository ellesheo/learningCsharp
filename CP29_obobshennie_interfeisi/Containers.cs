using System;
using System.Collections.Generic;
using System.Text;

namespace CP29_obobshennie_interfeisi
{
    public enum AnimalKind { Dog, Cat }

    public interface IContainer<out T>
    {
        T GetItem();
    }

    public class Animal
    {
        public string Name { get; init; } = "";

        public override string ToString() => $"зверь {Name}";
    }

    public class Dog : Animal
    {
        public override string ToString() => $"собака {Name}";
    }

    public class Cat : Animal
    {
        public override string ToString() => $"кошка {Name}";
    }

    public class InvalidAnimalException : Exception
    {
        public InvalidAnimalException() { }

        public InvalidAnimalException(string message) : base(message) { }

        public InvalidAnimalException(string message, Exception inner) : base(message, inner) { }
    }

    public class Box<T> : IContainer<T>
    {
        private readonly T item;

        public Box(T item) => this.item = item;

        public T GetItem() => item;
    }
}