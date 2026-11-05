using System;
using System.Collections.Generic;
using System.Text;

namespace CP16_var2
{
    public record AttackEvent(string Attacker, string Target, int Damage);

    public record HealEvent(string Healer, string Target, int Amount);

    public record DeathEvent(string Who);

    public class InvalidEventException : Exception
    {
        public InvalidEventException() { }

        public InvalidEventException(string message) : base(message) { }

        public InvalidEventException(string message, Exception inner) : base(message, inner) { }
    }

    public static class BattleLog
    {
        public static string ToLogLine(object gameEvent) => gameEvent switch
        {
            AttackEvent { Damage: > 50 } a => $"КРИТИЧЕСКИЙ УДАР: {a.Attacker} нанес {a.Damage} цели {a.Target}",
            AttackEvent a => $"{a.Attacker} нанес удар {a.Damage} цели {a.Target}",
            HealEvent h when h.Healer == h.Target => $"{h.Healer} подлечился сам на {h.Amount}",
            HealEvent h => $"{h.Healer} вылечил {h.Amount} цели {h.Target}",
            DeathEvent d => $"{d.Who} погиб",
            _ => "неизвестное событие"
        };
    }
}