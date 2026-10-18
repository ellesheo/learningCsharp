using System;
using System.Collections.Generic;
using System.Text;

namespace CP10_var2
{
    public interface IAnimal
    {
        string Name { get; }
        void MakeSound();
    }

    public interface ITrainable : IAnimal
    {
        string Train();
    }

    public class InvalidAnimalException : Exception
    {
        public InvalidAnimalException() { }
        public InvalidAnimalException(string message) : base(message) { }
        public InvalidAnimalException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class Lion : IAnimal
    {
        public string Name { get; }

        public Lion(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidAnimalException("Имя животного не может быть пустым");

            Name = name;
        }

        public void MakeSound() => Console.WriteLine("Рррр");

        public override string ToString() => $"Лев {Name}";
    }

    public class Dog : ITrainable
    {
        public string Name { get; }

        public Dog(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidAnimalException("Имя животного не может быть пустым");

            Name = name;
        }

        public void MakeSound() => Console.WriteLine("Гав");

        public string Train() => $"{Name} научился давать лапу";

        public override string ToString() => $"Собака {Name}";
    }

    public class Dolphin : ITrainable
    {
        public string Name { get; }

        public Dolphin(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidAnimalException("Имя животного не может быть пустым");

            Name = name;
        }

        public void MakeSound() => Console.WriteLine("И-и-и");

        public string Train() => $"{Name} научился прыгать через обруч";

        public override string ToString() => $"Дельфин {Name}";
    }
}