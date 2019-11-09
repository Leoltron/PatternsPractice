namespace ChainOfResponsibility
{
    public interface IBanknote
    {
        CurrencyType Currency { get; }
        string Value { get; }
    }
}