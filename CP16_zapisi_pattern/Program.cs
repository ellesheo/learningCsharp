using System.Globalization;

namespace CP16_zapisi_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object[] shapes =
            {
                new Circle(new Point(0, 0), 5),
                new Circle(new Point(3, 4), 0),
                new Circle(new Point(3, 4), 5),
                new Rectangle(new Point(1, 1), new Point(1, 1)),
                new Rectangle(new Point(0, 0), new Point(4, 3)),
                "просто строка"
            };

            Console.WriteLine("Проверочные ключи:");
            Console.WriteLine();

            foreach (object shape in shapes)
            {
                Console.WriteLine(shape);
                Console.WriteLine($"   -> {ShapeClassifier.Classify(shape)}");
            }

            string[] probes =
            {
                "circle, 0, 0, 5",
                "circle, 3, 4, 0",
                "rect, 0, 0, 4, 3",
                "rect, 2, 2, 2, 2",
                "circle, 3, abc, 5",
                "circle, 3, 4, -2",
                "treugolnik, 1, 2",
                "circle, 3, 4"
            };

            Console.WriteLine();
            Console.WriteLine("Разбор введённых строк:");
            Console.WriteLine();

            foreach (string probe in probes)
            {
                Console.Write($"\"{probe}\"   -> ");

                try
                {
                    Console.WriteLine(ShapeClassifier.Classify(ParseShape(probe.Split(','))));
                }
                catch (InvalidShapeException ex)
                {
                    Console.WriteLine($"ошибка: {ex.Message}");
                }
            }

            Console.WriteLine();
            object own = ReadShape();
            Console.WriteLine(own);
            Console.WriteLine($"   -> {ShapeClassifier.Classify(own)}");
        }

        static object ReadShape()
        {
            while (true)
            {
                Console.Write("Своя фигура (circle, x, y, r   или   rect, x1, y1, x2, y2): ");
                string[] parts = (Console.ReadLine() ?? "").Split(',');

                try
                {
                    return ParseShape(parts);
                }
                catch (InvalidShapeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static object ParseShape(string[] parts)
        {
            string kind = parts[0].Trim().ToLower();

            if (kind == "circle" && parts.Length == 4)
            {
                double radius = ParseNumber(parts[3]);

                if (radius < 0)
                    throw new InvalidShapeException("Радиус не может быть отрицательным");

                return new Circle(new Point(ParseNumber(parts[1]), ParseNumber(parts[2])), radius);
            }

            if (kind == "rect" && parts.Length == 5)
            {
                return new Rectangle(
                    new Point(ParseNumber(parts[1]), ParseNumber(parts[2])),
                    new Point(ParseNumber(parts[3]), ParseNumber(parts[4])));
            }

            throw new InvalidShapeException("Не понял. Пример: circle, 0, 0, 5   или   rect, 0, 0, 4, 3");
        }

        static double ParseNumber(string text)
        {
            if (double.TryParse(text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                return value;

            throw new InvalidShapeException($"\"{text.Trim()}\" - это не число");
        }
    }
}