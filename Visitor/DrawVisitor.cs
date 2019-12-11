using System;

namespace Visitor
{
    public class DrawVisitor : IVisitor
    {
        public string OperationName => "Draw";

        private readonly double x;
        private readonly double y;

        public DrawVisitor(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Visit(Rectangle rectangle)
        {
            var a = $"({x}, {y})";
            var b = $"({x + rectangle.Width}, {y})";
            var c = $"({x}, {y + rectangle.Height})";
            var d = $"({x + rectangle.Width}, {y + rectangle.Height})";
            Console.WriteLine($"Line from {a} to {b}");
            Console.WriteLine($"Line from {b} to {c}");
            Console.WriteLine($"Line from {c} to {d}");
            Console.WriteLine($"Line from {d} to {a}");
        }

        public void Visit(Triangle triangle)
        {
            var a = $"({x}, {y})";
            var b = $"({x}, {y + triangle.Sizes[0]})";

            var cx = x + triangle.BC * Math.Sin(triangle.ABC);
            var cy = y + triangle.BC * Math.Cos(triangle.ABC);
            var c = $"({cx}, {cy})";

            Console.WriteLine($"Line from {a} to {b}");
            Console.WriteLine($"Line from {b} to {c}");
            Console.WriteLine($"Line from {c} to {a}");
        }

        public void Visit(Circle circle)
        {
            Console.WriteLine($"Circle with center in ({x}, {y}) with radius of {circle.Radius}");
        }
    }
}