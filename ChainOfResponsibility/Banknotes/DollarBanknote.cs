namespace ChainOfResponsibility.Banknotes
{
    public class DollarBanknote : IBanknote
    {
        public CurrencyType Currency => CurrencyType.Dollar;
        public string Value { get; }

        public DollarBanknote(uint value)
        {
            Value = value.ToString();
        }
    }
}
