namespace CP16_zapisi_pattern
{
    public record Point(double X, double Y);

    public record Circle(Point Center, double Radius);

    public record Rectangle(Point TopLeft, Point BottomRight);

    public class InvalidShapeException : Exception
    {
        public InvalidShapeException() { }

        public InvalidShapeException(string message) : base(message) { }

        public InvalidShapeException(string message, Exception inner) : base(message, inner) { }
    }

    public static class ShapeClassifier
    {
        public static string Classify(object shape) => shape switch
        {
            Circle { Center: { X: 0, Y: 0 } } => "окружность в начале координат",
            Circle { Radius: 0 } => "вырожденная окружность (точка)",
            Circle c => $"круг радиуса {c.Radius}",
            Rectangle r when r.TopLeft == r.BottomRight => "вырожденный прямоугольник (точка)",
            Rectangle r => $"прямоугольник шириной {Math.Abs(r.BottomRight.X - r.TopLeft.X)} и высотой {Math.Abs(r.TopLeft.Y - r.BottomRight.Y)}",
            _ => "неизвестная фигура"
        };
    }
}