namespace ChainOfResponsibility.Handlers
{
    public abstract class DollarHandlerBase : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            if (banknote.Equals($"{Value}$"))
            {
                return true;
            }
            return base.Validate(banknote);
        }

        protected abstract int Value { get; }

        protected DollarHandlerBase(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }
}