using System;
using SocGen.Common;

namespace SocGen.Entities
{
	public class FxRate
	{
		public Currency DomCurrency { get; set; }
		public Currency ForCurrency { get; set; }
		public double Rate { get; set; }

		public FxRate()
		{
		}

		public FxRate(Currency ccy1, Currency ccy2, double rate)
		{
			DomCurrency = ccy1;
			ForCurrency = ccy2;
			Rate = rate;
		}
	}
}

