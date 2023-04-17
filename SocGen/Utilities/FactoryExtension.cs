using System;
using System.Globalization;
using SocGen.Common;
using SocGen.Entities;

namespace SocGen.Utilities
{
	public static class FactoryExtension
	{
		public static IEnumerable<Transaction> ToTransaction(this IEnumerable<string> source)
		{
			foreach(var line in source)
			{
				var columns = line.Split(";");
				yield return new Transaction
				{
					Amount = double.Parse(columns[1]),
					Category = (Category)Enum.Parse(typeof(Category), columns[3], true),
					Ccy = (Currency)Enum.Parse(typeof(Currency), columns[2]),
					AsOfDate = ConvertIntoDate(columns[0])
				};
			}
		}

		public static DateTime ConvertIntoDate(string d1)
		{
			return DateTime.Parse(d1, new CultureInfo("fr-FR"));
		}
	}
}

