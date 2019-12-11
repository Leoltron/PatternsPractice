namespace ChainOfResponsibility.Handlers
{
    public class FiftyDollarHandler : DollarHandlerBase
    {
        protected override uint Value => 50;

        public FiftyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }
}
