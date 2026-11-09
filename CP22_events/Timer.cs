namespace CP22_events
{
    public enum TimerPhase { Start, Middle, Final }

    public class InvalidTimeException : Exception
    {
        public InvalidTimeException() { }

        public InvalidTimeException(string message) : base(message) { }

        public InvalidTimeException(string message, Exception inner) : base(message, inner) { }
    }

    public class Timer
    {
        public event EventHandler<int>? Tick;

        public event EventHandler? Finished;

        public void Start(int seconds)
        {
            if (seconds <= 0)
                throw new InvalidTimeException("Количество секунд должно быть больше нуля");

            for (int left = seconds; left >= 1; left--)
            {
                Tick?.Invoke(this, left);
            }

            Finished?.Invoke(this, EventArgs.Empty);
        }

        public static TimerPhase GetPhase(int left, int total) => left switch
        {
            _ when left > total * 2 / 3 => TimerPhase.Start,
            _ when left > total / 3 => TimerPhase.Middle,
            _ => TimerPhase.Final
        };

        public static string Comment(TimerPhase phase) => phase switch
        {
            TimerPhase.Start => "начало отсчёта",
            TimerPhase.Middle => "середина",
            TimerPhase.Final => "финишная прямая",
            _ => "неизвестная фаза"
        };
    }
}