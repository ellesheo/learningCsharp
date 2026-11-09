using System;
using System.Collections.Generic;
using System.Text;

namespace CP30_metodi_rasshireniya
{
    public enum Suit { Clubs, Diamonds, Hearts, Spades }

    public enum Rank { Six = 6, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public struct Card : IComparable<Card>
    {
        public Rank Rank { get; init; }

        public Suit Suit { get; init; }

        public int CompareTo(Card other) => Rank.CompareTo(other.Rank);

        public override string ToString() => $"{Rank} of {Suit}";
    }

    public class InvalidCardException : Exception
    {
        public InvalidCardException() { }

        public InvalidCardException(string message) : base(message) { }

        public InvalidCardException(string message, Exception inner) : base(message, inner) { }
    }

    public static class Extensions
    {
        public static T? FindMax<T>(this IEnumerable<T> source) where T : IComparable<T>
        {
            T? max = default;
            bool first = true;

            foreach (T item in source)
            {
                if (first || item.CompareTo(max!) > 0)
                {
                    max = item;
                    first = false;
                }
            }

            return max;
        }

        public static void PrintAll<T>(this IEnumerable<T> source, string prefix)
        {
            foreach (T item in source)
                Console.WriteLine($"{prefix}{item}");
        }
    }
}