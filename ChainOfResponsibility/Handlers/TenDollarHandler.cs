namespace ChainOfResponsibility.Handlers
{
    public class TenDollarHandler : DollarHandlerBase
    {
        protected override uint Value => 10;

        public TenDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }
}
