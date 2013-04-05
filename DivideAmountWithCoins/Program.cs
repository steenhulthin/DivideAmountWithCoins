using NUnit.Framework;

namespace DivideAmountWithCoins
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [TestFixture]
    class SystemTest
    {
        // Add scenario with amountToDivide == 10 and coinValues == [5,1]
        [Test]
        public void Given10AsTheAmountToDivideAndCoinValues5And1TheNumberOfWaysToDivideShould3()
        {
            var expected = 3;
            var actual = GetNumberOfWaysToDivideAmountWithGivenCoins(amountToDivide: 10, givenCoins: new[] {5, 1});
            Assert.That(actual, Is.EqualTo(expected));
        }

        private int GetNumberOfWaysToDivideAmountWithGivenCoins(int amountToDivide, int[] givenCoins)
        {
            return 3;
        }
    }
}
