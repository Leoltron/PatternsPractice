namespace ChainOfResponsibility.Handlers
{
    public class TenRubleHandler : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            if (banknote.Equals("10 Рублей"))
            {
                return true;
            }
            return base.Validate(banknote);
        }

        public TenRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
}