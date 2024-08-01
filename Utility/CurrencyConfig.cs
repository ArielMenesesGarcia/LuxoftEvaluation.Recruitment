using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftEvaluation.Utility
{
    public static class CurrencyConfig
    {
        public static List<decimal> Denominations { get; private set; } = new List<decimal>();

        public static void SetDenominations(List<decimal> denominations)
        {
            if (denominations == null || denominations.Count == 0)
            {
                throw new ArgumentException("Denominations cannot be null or empty.");
            }
            Denominations = denominations.OrderByDescending(d => d).ToList();
        }
    }
}
