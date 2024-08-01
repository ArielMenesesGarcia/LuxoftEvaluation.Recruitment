using LuxoftEvaluation.Utility;

namespace LuxoftEvaluation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set the currency configuration (Example: US Currency)
            CurrencyConfig.SetDenominations(new List<decimal>
        {
            100.00m, 50.00m, 20.00m, 10.00m, 5.00m, 2.00m, 1.00m, 0.50m, 0.25m, 0.10m, 0.05m, 0.01m
        });

            Calculator calculator = new Calculator();

            decimal price = 5.25m;
            // providedAmount is the cash provided
            Dictionary<decimal, int> providedAmount = new Dictionary<decimal, int>
        {
            { 10.00m, 1 },
            //{ 2.00m, 1 }
        };
            try
            {
                Dictionary<decimal, int> change = calculator.CalculateChange(price, providedAmount);
                Console.WriteLine("Change to return:");

                foreach (var coin in change)
                {
                    Console.WriteLine($"{coin.Value} x {coin.Key:C}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
