namespace Visitor
{
    public interface IVisitor
    {
        string OperationName { get; }
        void Visit(Rectangle rectangle);
        void Visit(Triangle triangle);
        void Visit(Circle circle);
    }
}