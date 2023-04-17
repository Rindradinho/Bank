using System;
using System.Linq;
using SocGen.Common;
using SocGen.Entities;

namespace SocGen
{
	public class Account : IAccountManager
	{
		public IList<Transaction> TransactionList { get; set; }
		public Currency AccountCurrency { get; set; }

		public Account(IList<Transaction> tl, Currency accountCurrency)
		{
			TransactionList = tl;
			AccountCurrency = accountCurrency;
		}

		public double AccountValueByDate(DateTime asOf, Currency ccy)
		{
			var query = (from t in TransactionList
						 .Where(x => x.AsOfDate == asOf)
						 select (t.Amount)).Sum();

			return query;
		}

		public IEnumerable<Transaction> SortAccountByCategory(int maxValue)
		{
			var query = from transaction in TransactionList
						group transaction by transaction.Category into g
						select new Transaction
						{
							Category = g.First().Category,
							Amount = g.Sum(x => x.Amount)
						};
					
			return query.Take(maxValue);
		}

        public void UpdateTransactionList(IRates rates)
        {
            foreach(var e in TransactionList)
			{
				if(e.Ccy != AccountCurrency)
				{
					double rate = rates.GetFxRate(AccountCurrency, e.Ccy);
					e.Ccy = AccountCurrency;
					e.Amount /= rate;
				}
			}
        }
    }
}

