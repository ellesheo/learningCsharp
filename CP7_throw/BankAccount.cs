using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CP7_throw
{
    public class BankingException : Exception
    {
        public BankingException() { }
        public BankingException(string message) : base(message) { }
        public BankingException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class InsufficientFundsException : BankingException
    {
        public decimal RequestedAmount { get; }
        public decimal AvailableBalance { get; }
        public InsufficientFundsException(decimal requestedAmount, decimal availableBalance)
            : base($"Не хватает денег: надо {requestedAmount}, есть {availableBalance}")
        {
            RequestedAmount = requestedAmount;
            AvailableBalance = availableBalance;
        }
    }
    public class InvalidAccountException : BankingException
    {
        public string AccountId { get; }
        public InvalidAccountException(string accountId)
            : base($"Неверный номер счета {accountId}, нужно 6 цифр")
        {
            AccountId = accountId;
        }
    }
    public class BankAccount
    {
        public string AccountId { get; }
        public decimal Balance { get; private set; }
        public BankAccount(string accountId, decimal initialBalance)
        {
            if (accountId == null || accountId.Length != 6 || !accountId.All(char.IsDigit))
                throw new InvalidAccountException(accountId);
            AccountId = accountId;
            Balance = initialBalance;
        }
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InsufficientFundsException(amount, Balance);
            Balance -= amount;
        }
    }
}