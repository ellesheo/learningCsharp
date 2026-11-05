<img width="1531" height="884" alt="image" src="screen.png" />

Вариант 2. Игровые события через записи

public record AttackEvent(string Attacker, string Target, int Damage);
public record HealEvent(string Healer, string Target, int Amount);
public record DeathEvent(string Who);
Метод string ToLogLine(object gameEvent) через switch-выражение:
AttackEvent { Damage: > 50 } (свойственный паттерн) — "КРИТИЧЕСКИЙ УДАР: ...".
AttackEvent a — обычная строка лога об атаке.
HealEvent h when h.Healer == h.Target (when, сравнение двух свойств друг с другом) — "... подлечился сам".
HealEvent h — обычная строка лога о лечении.
DeathEvent d — "... погиб".
_ — "неизвестное событие".

Проверочные ключи

<img width="1140" height="230" alt="image" src="https://github.com/user-attachments/assets/11b0889e-91eb-45a7-8185-e8dc89c69fa8" />
