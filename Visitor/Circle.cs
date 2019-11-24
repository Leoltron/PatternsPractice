namespace Visitor
{
    public class Circle : Figure
    {
        public double Radius => Sizes[0];

        public Circle(double[] sizes) : base(sizes, 1)
        {
        }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}
