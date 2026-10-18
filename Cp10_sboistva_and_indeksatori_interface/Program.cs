using System.Drawing;

namespace CP10_sboistva_and_indeksatori_interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>
            {
                new Circle(5),
                new Rectangle(3, 4),
                new Triangle(3, 4, 5)
            };

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
    }
}