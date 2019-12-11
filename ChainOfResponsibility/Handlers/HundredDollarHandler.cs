namespace ChainOfResponsibility.Handlers
{
    public class HundredDollarHandler : DollarHandlerBase
    {
        protected override uint Value => 100;

        public HundredDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }
}
