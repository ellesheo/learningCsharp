<img width="1718" height="783" alt="image" src="https://github.com/user-attachments/assets/d9ef17ff-ac1b-4dec-85a0-d98c8486b43a" />

<img width="1460" height="367" alt="image" src="https://github.com/user-attachments/assets/183c2a1b-fc31-4134-8ca7-396705a337a1" />

Проверочные ключи

new BankAccount("12345", 1000m) — InvalidAccountException (5 цифр вместо 6)
new BankAccount("123456", 1000m).Withdraw(2000m) — InsufficientFundsException,
    RequestedAmount == 2000, AvailableBalance == 1000
new BankAccount("123456", 1000m).Withdraw(500m) — баланс становится 500, исключения нет

Отдельно проверяется перехват по базовому типу: BankingException ловится
последним catch, когда конкретные типы не подошли.
