using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ChainOfResponsibility.Banknotes;

namespace ChainOfResponsibility.Handlers
{
    public abstract class DollarHandlerBase : BanknoteHandler
    {
        protected abstract uint Value { get; }

        protected DollarHandlerBase(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }

        public override bool Validate(string banknote)
        {
            return banknote.Equals($"{Value}$") || base.Validate(banknote);
        }

        protected override IEnumerable<IBanknote> CashOutAsMuchAsPossible(ref string value)
        {
            var match = Regex.Match(value, @"^(\d+)\$$");
            if (!match.Success || !uint.TryParse(match.Groups[1].Value, out var amount))
            {
                return Enumerable.Empty<IBanknote>();
            }

            var notesAmount = amount / Value;
            amount -= notesAmount * Value;
            value = $"{amount}$";

            return Enumerable.Range(0, (int) notesAmount).Select(i => new DollarBanknote(Value));
        }
    }
}
