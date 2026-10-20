using System;
using System.Collections.Generic;
using System.Text;

namespace CP13_structuri
{
    public enum Suit { Clubs, Diamonds, Hearts, Spades }

    public enum Rank { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public struct Card
    {
        public Suit Suit;
        public Rank Rank;

        public override string ToString() => $"{Rank} of {Suit}";
    }
}