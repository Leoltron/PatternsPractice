using System;

namespace Visitor
{
    public class AreaVisitor : IVisitor
    {
        public string OperationName => "Area";
        public double LastOperationResult { get; private set; }

        public void Visit(Rectangle rectangle) => LastOperationResult = rectangle.Height * rectangle.Width;

        public void Visit(Triangle triangle) =>
            LastOperationResult = triangle.AB * triangle.BC * Math.Sin(triangle.ABC) / 2;

        public void Visit(Circle circle) => LastOperationResult = Math.PI * Math.Pow(circle.Radius, 2);
    }
}