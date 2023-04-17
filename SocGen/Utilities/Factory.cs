using System;
using System.Text.RegularExpressions;
using SocGen.Common;
using SocGen.Entities;

namespace SocGen.Utilities
{
	public class Factory
	{
		public List<Transaction> BuildTransaction(string path)
		{
            var query =
                File.ReadAllLines(path)
                .Skip(4)
                .ToTransaction();

			return query.ToList();
		}

		public List<FxRate> BuildFxRates()
		{
			//Temporary, use Regex to match fxRate pattern (ccy/ccy : value)
			return new List<FxRate>
			{
				new FxRate{DomCurrency = Currency.EUR, ForCurrency = Currency.JPY , Rate = 0.482},
                new FxRate{DomCurrency = Currency.EUR, ForCurrency = Currency.USD , Rate = 1.445}
            };
		}
    }
}

