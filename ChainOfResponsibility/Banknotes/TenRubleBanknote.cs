namespace ChainOfResponsibility.Banknotes
{
    public class TenRubleBanknote : IBanknote
    {
        public CurrencyType Currency => CurrencyType.Ruble;
        public string Value => "10";
    }
}
