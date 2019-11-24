using System;
using System.Linq;

namespace Visitor
{
    public class PerimeterVisitor : IVisitor
    {
        public string OperationName => "Perimeter";
        public double LastOperationResult { get; private set; }

        public void Visit(Rectangle rectangle) => LastOperationResult = rectangle.Sizes.Sum();

        public void Visit(Triangle triangle) => LastOperationResult = triangle.Sizes.Sum();

        public void Visit(Circle circle) => LastOperationResult = 2 * Math.PI * circle.Radius;
    }
}
