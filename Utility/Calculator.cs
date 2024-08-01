using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftEvaluation.Utility
{
    public class Calculator
    {
        /// <summary>
        /// This function will return the best option to return change if the amount provided
        /// is more or equals to the price
        /// </summary>
        /// <param name="price"> Price provided</param>
        /// <param name="providedAmount">Amount provided</param>
        /// <returns>the best option to return change</returns>
        /// <exception cref="InvalidOperationException"> Throw exception if the conditions apply</exception>
        public Dictionary<decimal, int> CalculateChange(decimal price, Dictionary<decimal, int> providedAmount)
        {
            //Next line will sum the amount provided
            decimal totalProvided = providedAmount.Sum(x => x.Key * x.Value);
            // Let's evaluate if totalProvided is correct to work, if not then, send exception
            if (totalProvided < price)
            {
                throw new InvalidOperationException("Provided amount is less than the price.");
            }
            // Let's get the change to return
            decimal changeToReturn = totalProvided - price;
            Dictionary<decimal, int> change = new Dictionary<decimal, int>();
            // Let's start reducing the amount from currency options 
            foreach (var denomination in CurrencyConfig.Denominations)
            {
                int count = (int)(changeToReturn / denomination);
                // If count is more than 0, this means wecan apply discount to changeToReturn variable
                if (count > 0)
                {
                    change[denomination] = count;
                    changeToReturn -= count * denomination;
                    // If changeToReturn is 0, this means we are ready to return the change
                    if (changeToReturn == 0)
                        break;
                }
            }
            //If changeToReturn is not equals to 0, this means we are not able to give correct change
            if (changeToReturn > 0)
            {
                throw new InvalidOperationException("Unable to return the exact change with the available denominations.");
            }

            return change;
        }
    }
}
