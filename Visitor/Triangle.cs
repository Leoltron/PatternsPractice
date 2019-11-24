using System;

namespace Visitor
{
    public class Triangle : Figure
    {
        public double AB => Sizes[0];
        public double BC => Sizes[1];
        public double CA => Sizes[2];

        public double ABC => Math.Acos((Math.Pow(AB, 2) + Math.Pow(BC, 2) - Math.Pow(CA, 2)) /
                                       (2 * AB * BC));

        public double BCA => Math.Acos((Math.Pow(BC, 2) + Math.Pow(CA, 2) - Math.Pow(AB, 2)) /
                                       (2 * BC * CA));

        public double CAB => Math.Acos((Math.Pow(CA, 2) + Math.Pow(AB, 2) - Math.Pow(BC, 2)) /
                                       (2 * CA * AB));

        public Triangle(double[] sizes) : base(sizes, 3)
        {
        }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}