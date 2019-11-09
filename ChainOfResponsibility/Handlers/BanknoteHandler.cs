using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Banknotes;

namespace ChainOfResponsibility.Handlers
{
    public abstract class BanknoteHandler
    {
        private readonly BanknoteHandler _nextHandler;

        protected BanknoteHandler(BanknoteHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public virtual bool Validate(string banknote)
        {
            return _nextHandler != null && _nextHandler.Validate(banknote);
        }

        public IEnumerable<IBanknote> CashOut(ref string value)
        {
            var banknotes = CashOutAsMuchAsPossible(ref value);
            return _nextHandler == null ? banknotes : banknotes.Concat(_nextHandler.CashOut(ref value));
        }

        protected abstract IEnumerable<IBanknote> CashOutAsMuchAsPossible(ref string value);
    }
}
