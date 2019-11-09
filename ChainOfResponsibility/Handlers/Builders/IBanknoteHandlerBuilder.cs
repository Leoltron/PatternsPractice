namespace ChainOfResponsibility.Handlers.Builders
{
    public interface IBanknoteHandlerBuilder
    {
        BanknoteHandler Build(BanknoteHandler nextHandler);
    }
}
