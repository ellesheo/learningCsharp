using System;
using System.Collections.Generic;
using System.Text;

namespace CP10_sboistva_and_indeksatori_interface
{
    public interface IShape
    {
        double Area();
        double Perimeter();
    }

    public interface IDrawable : IShape
    {
        string Draw();
    }

    public class InvalidShapeException : Exception
    {
        public InvalidShapeException() { }
        public InvalidShapeException(string message) : base(message) { }
        public InvalidShapeException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new InvalidShapeException($"Радиус должен быть больше нуля");

            Radius = radius;
        }

        public double Area() => Math.PI * Radius * Radius;
        public double Perimeter() => 2 * Math.PI * Radius;
        public override string ToString() => $"Круг r={Radius}";
    }

    public class Rectangle : IShape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new InvalidShapeException("Ширина и высота должны быть больше нуля");

            Width = width;
            Height = height;
        }

        public double Area() => Width * Height;
        public double Perimeter() => 2 * (Width + Height);
        public override string ToString() => $"Прямоугольник {Width}x{Height}";
    }

    public class Triangle : IDrawable
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new InvalidShapeException("Стороны должны быть больше нуля");

            if (a + b <= c || a + c <= b || b + c <= a)
                throw new InvalidShapeException("Из таких сторон треугольник не построить");

            A = a;
            B = b;
            C = c;
        }

        public double Perimeter() => A + B + C;

        public double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public string Draw() => "  *\n * *\n*****";

        public override string ToString() => $"Треугольник {A}-{B}-{C}";
    }
}