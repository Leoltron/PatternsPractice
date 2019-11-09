using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ChainOfResponsibility.Banknotes;
using ChainOfResponsibility.Handlers;
using ChainOfResponsibility.Handlers.Builders;

namespace ChainOfResponsibility
{
    public class Bancomat
    {
        private readonly BanknoteHandler handler;

        public Bancomat() : this(
            new HundredDollarHandlerBuilder(),
            new FiftyDollarHandlerBuilder(),
            new TenDollarHandlerBuilder(),
            new TenRubleHandlerBuilder())
        {
        }

        /// <param name="builders">Строители в порядке применения</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Bancomat(params IBanknoteHandlerBuilder[] builders)
        {
            if (builders == null)
                throw new ArgumentNullException(nameof(builders));

            if (builders.Length == 0)
                throw new ArgumentException("Builders count cannot be zero", nameof(builders));

            handler = builders.Last().Build(null);

            for (var i = builders.Length - 2; i >= 0; i--)
            {
                handler = builders[i].Build(handler);
            }
        }

        public bool Validate(string banknote)
        {
            return handler.Validate(banknote);
        }

        public IEnumerable<IBanknote> CashOut(string value)
        {
            var result = handler.CashOut(ref value);

            return Regex.Match(value, @"^[^1-9]$").Success ? result : null;
        }
    }
}
