using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ChainOfResponsibility.Banknotes;

namespace ChainOfResponsibility.Handlers
{
    public class TenRubleHandler : BanknoteHandler
    {
        public override bool Validate(string banknote)
        {
            if (banknote.Equals("10 Рублей"))
            {
                return true;
            }

            return base.Validate(banknote);
        }

        protected override IEnumerable<IBanknote> CashOutAsMuchAsPossible(ref string value)
        {
            var match = Regex.Match(value, @"^(\d+0) Рублей$");
            if (!match.Success || !uint.TryParse(match.Groups[1].Value, out var amount))
            {
                return Enumerable.Empty<IBanknote>();
            }

            var notesAmount = amount / 10;
            amount -= notesAmount * 10;
            value = $"{amount} Рублей";

            return Enumerable.Range(0, (int) notesAmount).Select(i => new TenRubleBanknote());
        }

        public TenRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        {
        }
    }
}
