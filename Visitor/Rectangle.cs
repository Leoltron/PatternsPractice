namespace Visitor
{
    public class Rectangle : Figure
    {
        public double Width => Sizes[0];
        public double Height => Sizes[1];

        public Rectangle(double[] sizes) : base(sizes, 2)
        {
        }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}