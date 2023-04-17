using System;
using SocGen.Common;

namespace SocGen.Entities
{
	public class Transaction
	{
		public Category Category {get; set;}
		public double Amount { get; set; }
		public Currency Ccy { get; set; }
		public DateTime AsOfDate { get; set; }

		public Transaction(Category category, double amount, Currency ccy, DateTime asof)
		{
			Category = category;
			Amount = amount;
			Ccy = ccy;
			AsOfDate = asof;
		}

		public Transaction() {}
	}
}

