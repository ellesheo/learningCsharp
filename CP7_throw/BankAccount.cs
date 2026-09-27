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
            : base($"Недостаточно средств: запрошено {requestedAmount:0.00}, доступно {availableBalance:0.00}.")
        {
            RequestedAmount = requestedAmount;
            AvailableBalance = availableBalance;
        }
    }
    public class InvalidAccountException : BankingException
    {
        public string AccountId { get; }
        public InvalidAccountException(string accountId)
            : base($"Некорректный номер счёта \"{accountId}\". Требуется ровно 6 цифр.")
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