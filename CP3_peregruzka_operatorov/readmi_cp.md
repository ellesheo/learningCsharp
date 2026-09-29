<img width="1919" height="717" alt="image" src="https://github.com/user-attachments/assets/205d3252-a39e-4d11-a9a9-02a678d475bb" />

Вариант 1. Money (деньги)
Класс Money хранит сумму (decimal Amount). Отрицательное значение допустимо и означает долг — отдельных проверок на знак не требуется.
Конструктор Money(decimal amount) — просто сохраняет сумму.
public static Money operator +(Money a, Money b) — складывает суммы.
public static Money operator -(Money a, Money b) — вычитает суммы.
public static Money operator -(Money a) — унарный минус, возвращает сумму с противоположным знаком.
Переопределите ToString(), например: "125,50 руб." (для отрицательной суммы — со знаком минус).

Проверочные ключи

var a = new Money(100m);
var b = new Money(30m);

(a + b).Amount — 130
(a - b).Amount — 70
(-a).Amount — -100
после a += b: a.Amount — 130
