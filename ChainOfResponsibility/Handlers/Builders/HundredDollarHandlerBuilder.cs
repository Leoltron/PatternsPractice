namespace ChainOfResponsibility.Handlers.Builders
{
    public class HundredDollarHandlerBuilder : IBanknoteHandlerBuilder
    {
        public BanknoteHandler Build(BanknoteHandler nextHandler)
        {
            return new HundredDollarHandler(nextHandler);
        }
    }
}
