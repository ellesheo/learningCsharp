using System;
using System.Collections.Generic;
using System.Text;

namespace CP3_peregruzka_operatorov
{
    public class Money
    {
        public decimal Amount { get; }
        public Money(decimal amount)
        {
            Amount = amount;
        }
        public static Money operator +(Money a, Money b) => new Money(a.Amount + b.Amount);
        public static Money operator -(Money a, Money b) => new Money(a.Amount - b.Amount);
        public static Money operator -(Money a) => new Money(-a.Amount);
        public override string ToString() => $"{Amount:0.00} руб.";
    }
}