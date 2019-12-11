using System;

namespace Visitor
{
    public abstract class Figure
    {
        public readonly double[] Sizes;

        protected Figure(double[] sizes, int expectedLength)
        {
            if (sizes == null)
            {
                throw new ArgumentNullException(nameof(sizes));
            }

            if (sizes.Length != expectedLength)
            {
                throw new Exception($"Expected sizes length of {expectedLength}, got {sizes.Length}");
            }

            Sizes = sizes;
        }

        public abstract void Accept(IVisitor visitor);
    }
}
