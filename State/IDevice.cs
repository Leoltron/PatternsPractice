namespace State
{
    public interface IDevice
    {
        int DocumentCount { get; }
        string GetDocument(int index);
    }
}
