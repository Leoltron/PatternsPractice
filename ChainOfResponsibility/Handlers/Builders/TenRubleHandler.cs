namespace ChainOfResponsibility.Handlers.Builders
{
    public class TenRubleHandlerBuilder : IBanknoteHandlerBuilder
    {
        public BanknoteHandler Build(BanknoteHandler nextHandler)
        {
            return new TenRubleHandler(nextHandler);
        }
    }
}
