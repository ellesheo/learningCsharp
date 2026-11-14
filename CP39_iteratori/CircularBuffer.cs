using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CP39_iteratori
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() { }

        public InvalidInputException(string message) : base(message) { }

        public InvalidInputException(string message, Exception inner) : base(message, inner) { }
    }

    public class CircularBuffer<T> : IEnumerable<T>
    {
        private readonly T[] items;
        private int start;
        private int count;

        public CircularBuffer(int capacity)
        {
            if (capacity <= 0)
                throw new InvalidInputException("Ёмкость должна быть больше нуля");

            items = new T[capacity];
        }

        public int Capacity => items.Length;

        public int Count => count;

        public void Add(T item)
        {
            if (count < items.Length)
            {
                items[(start + count) % items.Length] = item;
                count++;
            }
            else
            {
                items[start] = item;
                start = (start + 1) % items.Length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return items[(start + i) % items.Length];
        }

        public IEnumerable<T> Reverse()
        {
            for (int i = count - 1; i >= 0; i--)
                yield return items[(start + i) % items.Length];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}