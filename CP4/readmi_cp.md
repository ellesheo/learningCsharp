<img width="1127" height="674" alt="image" src="https://github.com/user-attachments/assets/60e552ec-d21f-4784-86d6-008c98f49f3c" />

Вариант 1. Balance (баланс счёта)
Класс Balance хранит сумму на счёте (decimal Amount).
Конструктор Balance(decimal amount).
operator ==, operator != — сравнение по значению Amount. Переопределите Equals и GetHashCode.
operator <, operator >, operator <=, operator >= — сравнение по значению Amount.
operator true — баланс положительный (Amount > 0); operator false — баланс не положительный.
Переопределите ToString(), например: "125,50 руб.".
