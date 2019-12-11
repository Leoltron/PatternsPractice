namespace ChainOfResponsibility.Banknotes
{
    public interface IBanknote
    {
        CurrencyType Currency { get; }
        string Value { get; }
    }
}