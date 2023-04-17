using System;
using SocGen.Common;

namespace SocGen.Entities
{
	public class Rates : IRates
	{
		public IList<FxRate> FxRates { get; set; }

		public Rates(IList<FxRate> fxRates)
		{
			FxRates = fxRates;
		}

		public double GetFxRate(Currency ccy1, Currency ccy2)
		{
			var query = FxRates.Where(x => x.DomCurrency == ccy1
			&& x.ForCurrency == ccy2).Select(x => x.Rate).First();
			return query;
		}
	}
}

