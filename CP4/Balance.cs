using System;
using System.Collections.Generic;
using System.Text;

namespace CP4
{
    public class Balance
    {
        public decimal Amount { get; }
        public Balance(decimal amount)
        {
            Amount = amount;
        }
        public static bool operator ==(Balance a, Balance b) => a.Amount == b.Amount;
        public static bool operator !=(Balance a, Balance b) => !(a == b);
        public override bool Equals(object? obj) => obj is Balance b && this == b;
        public override int GetHashCode() => Amount.GetHashCode();
        public static bool operator <(Balance a, Balance b) => a.Amount < b.Amount;
        public static bool operator >(Balance a, Balance b) => a.Amount > b.Amount;
        public static bool operator <=(Balance a, Balance b) => a.Amount <= b.Amount;
        public static bool operator >=(Balance a, Balance b) => a.Amount >= b.Amount;
        public static bool operator true(Balance b) => b.Amount > 0;
        public static bool operator false(Balance b) => b.Amount <= 0;
        public override string ToString() => $"{Amount:0.00} руб.";
    }
}