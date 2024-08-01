using LuxoftEvaluation.Utility;

namespace LuxoftNTests
{
    public class ChangeCalculatorTests
    {
        [SetUp]
        public void Setup()
        {
            CurrencyConfig.SetDenominations(new List<decimal>
        {
            100.00m, 50.00m, 20.00m, 10.00m, 5.00m, 2.00m, 1.00m, 0.50m, 0.25m, 0.10m, 0.05m, 0.01m
        });
        }

        [Test]
        public void CalculateChange_CorrectChange()
        {
            Calculator calculator = new Calculator();
            decimal price = 5.25m;
            Dictionary<decimal, int> providedAmount = new Dictionary<decimal, int>
        {
            { 5.00m, 1 },
            { 1.00m, 1 }
        };

            Dictionary<decimal, int> expectedChange = new Dictionary<decimal, int>
        {
            { 0.50m, 1 },
            { 0.25m, 1 }
        };

            Dictionary<decimal, int> actualChange = calculator.CalculateChange(price, providedAmount);

            Assert.AreEqual(expectedChange, actualChange);
        }

        [Test]
        public void CalculateChange_InsufficientFunds_ThrowsException()
        {
            Calculator calculator = new Calculator();
            decimal price = 5.25m;
            Dictionary<decimal, int> providedAmount = new Dictionary<decimal, int>
        {
            { 5.00m, 1 }
        };

            Assert.Throws<InvalidOperationException>(() => calculator.CalculateChange(price, providedAmount));
        }

        [Test]
        public void CalculateChange_ExactPayment_NoChange()
        {
            Calculator calculator = new Calculator();
            decimal price = 5.00m;
            Dictionary<decimal, int> providedAmount = new Dictionary<decimal, int>
        {
            { 5.00m, 1 }
        };

            Dictionary<decimal, int> expectedChange = new Dictionary<decimal, int>();

            Dictionary<decimal, int> actualChange = calculator.CalculateChange(price, providedAmount);

            Assert.AreEqual(expectedChange, actualChange);
        }

        [Test]
        public void CalculateChange_NonOptimalChange_ThrowsException()
        {
            Calculator calculator = new Calculator();
            decimal price = 5.25m;
            Dictionary<decimal, int> providedAmount = new Dictionary<decimal, int>
        {
            { 10.00m, 1 }
        };

            Assert.DoesNotThrow(() => calculator.CalculateChange(price, providedAmount));
        }
    }
}