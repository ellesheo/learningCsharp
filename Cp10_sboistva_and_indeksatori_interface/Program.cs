namespace CP10_sboistva_and_indeksatori_interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();

            try
            {
                double radius = ReadDouble("Радиус круга: ");
                shapes.Add(new Circle(radius));
            }
            catch (InvalidShapeException ex)
            {
                Console.WriteLine($"Круг не создан. {ex.Message}");
            }

            try
            {
                double width = ReadDouble("Ширина прямоугольника: ");
                double height = ReadDouble("Высота прямоугольника: ");
                shapes.Add(new Rectangle(width, height));
            }
            catch (InvalidShapeException ex)
            {
                Console.WriteLine($"Прямоугольник не создан. {ex.Message}");
            }

            try
            {
                double a = ReadDouble("Сторона A треугольника: ");
                double b = ReadDouble("Сторона B треугольника: ");
                double c = ReadDouble("Сторона C треугольника: ");
                shapes.Add(new Triangle(a, b, c));
            }
            catch (InvalidShapeException ex)
            {
                Console.WriteLine($"Треугольник не создан. {ex.Message}");
            }

            Console.WriteLine();

            foreach (IShape shape in shapes)
            {
                Console.WriteLine(shape);
                Console.WriteLine($"Площадь: {shape.Area()}");
                Console.WriteLine($"Периметр: {shape.Perimeter()}");

                if (shape is IDrawable drawable)
                    Console.WriteLine(drawable.Draw());

                Console.WriteLine();
            }
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double value))
                    return value;

                Console.WriteLine("Это не число, попробуйте ещё раз");
            }
        }
    }
}