namespace CP7_throw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount account = new BankAccount("12345", 1000m);
                Console.WriteLine($"Счёт создан, баланс {account.Balance:0.00}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Не хватает {ex.RequestedAmount - ex.AvailableBalance:0.00} руб.");
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"Плохой номер счёта \"{ex.AccountId}\". {ex.Message}");
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Банковская ошибка: {ex.Message}");
            }
            Console.WriteLine();
            try
            {
                BankAccount account = new BankAccount("123456", 1000m);
                account.Withdraw(2000m);
                Console.WriteLine($"Снято, остаток {account.Balance:0.00}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Не хватает {ex.RequestedAmount - ex.AvailableBalance:0.00} руб.");
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"Плохой номер счёта \"{ex.AccountId}\". {ex.Message}");
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Банковская ошибка: {ex.Message}");
            }
            Console.WriteLine();
            try
            {
                BankAccount account = new BankAccount("123456", 1000m);
                account.Withdraw(500m);
                Console.WriteLine($"Снято 500,00, остаток {account.Balance:0.00}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Не хватает {ex.RequestedAmount - ex.AvailableBalance:0.00} руб.");
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"Плохой номер счёта \"{ex.AccountId}\". {ex.Message}");
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Банковская ошибка: {ex.Message}");
            }
            Console.WriteLine();
            try
            {
                throw new BankingException("Счёт временно заблокирован.");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Не хватает {ex.RequestedAmount - ex.AvailableBalance:0.00} руб.");
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"Плохой номер счёта \"{ex.AccountId}\". {ex.Message}");
            }
            catch (BankingException ex)
            {
                Console.WriteLine($"Банковская ошибка: {ex.Message}");
            }
        }
    }
}