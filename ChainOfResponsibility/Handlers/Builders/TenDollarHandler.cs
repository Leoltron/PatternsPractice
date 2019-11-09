namespace ChainOfResponsibility.Handlers.Builders
{
    public class TenDollarHandlerBuilder : IBanknoteHandlerBuilder
    {
        public BanknoteHandler Build(BanknoteHandler nextHandler)
        {
            return new TenDollarHandler(nextHandler);
        }
    }
}
