namespace CP7_throw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount account = new BankAccount("12345", 1000m);
                Console.WriteLine($"Счет создан, баланс {account.Balance}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Не хватает {ex.RequestedAmount - ex.AvailableBalance} руб");
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"Неверный счет {ex.AccountId}");
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Ошибка банка: {ex.Message}");
            }
            Console.WriteLine();
            try
            {
                BankAccount account = new BankAccount("123456", 1000m);
                account.Withdraw(2000m);
                Console.WriteLine($"Снято, остаток {account.Balance}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Не хватает {ex.RequestedAmount - ex.AvailableBalance} руб");
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"Неверный счет {ex.AccountId}");
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Ошибка банка: {ex.Message}");
            }
            Console.WriteLine();
            try
            {
                BankAccount account = new BankAccount("123456", 1000m);
                account.Withdraw(500m);
                Console.WriteLine($"Снято 500, остаток {account.Balance}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Не хватает {ex.RequestedAmount - ex.AvailableBalance} руб");
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"Неверный счет {ex.AccountId}");
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Ошибка банка: {ex.Message}");
            }
            Console.WriteLine();
            try
            {
                throw new BankingException("Счёт временно заблокирован.");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Не хватает {ex.RequestedAmount - ex.AvailableBalance} руб");
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"Неверный счет {ex.AccountId}");
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Ошибка банка: {ex.Message}");
            }
        }
    }
}