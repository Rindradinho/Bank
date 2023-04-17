using System;
using SocGen.Common;

namespace SocGen.Entities
{
	public interface IRates
	{
        public double GetFxRate(Currency ccy1, Currency ccy2);
    }
}

