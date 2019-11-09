namespace ChainOfResponsibility.Handlers.Builders
{
    public class FiftyDollarHandlerBuilder : IBanknoteHandlerBuilder
    {
        public BanknoteHandler Build(BanknoteHandler nextHandler)
        {
            return new FiftyDollarHandler(nextHandler);
        }
    }
}
