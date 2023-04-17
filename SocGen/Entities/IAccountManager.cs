using System;
using SocGen.Common;

namespace SocGen.Entities
{
	public interface IAccountManager
	{
		double AccountValueByDate(DateTime asOf, Currency currency);
		IEnumerable<Transaction> SortAccountByCategory(int maxValue);
		void UpdateTransactionList(IRates rates);
	}
}

