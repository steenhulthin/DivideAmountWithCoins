using System;
using System.Linq;
using NUnit.Framework;

namespace DivideAmountWithCoins
{
    static class Program
    {
        static void Main(string[] args)
        {
        }

        // get amount and coin values.
        // order coin values
        // check if current amount is smaller than current largest coin

        public static int GetNumberOfWaysToDivideAmountWithGivenCoins(int amountToDivide, int[] givenCoins)
        {
            Array.Sort(givenCoins);
            return InternalGetNumberOfWaysToDivideAmountWithGivenCoins(amountToDivide, givenCoins);
            
        }

        private static int InternalGetNumberOfWaysToDivideAmountWithGivenCoins(int amountToDivide, int[] givenCoins)
        {
            if (givenCoins.Length == 0)
                return 0;
            if (amountToDivide == 0)
                return 1;
            if (!Divideable(amountToDivide, givenCoins))
            {
                Console.Write("Rest: " + amountToDivide);
                return 0;
            }
            return InternalGetNumberOfWaysToDivideAmountWithGivenCoins(amountToDivide, givenCoins.Take(givenCoins.Length - 1).ToArray()) + InternalGetNumberOfWaysToDivideAmountWithGivenCoins(amountToDivide - givenCoins.Last(), givenCoins);
        }

        private static bool Divideable(int amountToDivide, int[] givenCoins)
        {
            var divideable = givenCoins.Min() <= amountToDivide;
            return divideable;
        }
    }

    [TestFixture]
    class SystemTest
    {
        [TestCase(3, 10, new[]{5,1})]
        [TestCase(2, 10, new[]{10,1})]
        [TestCase(1, 10, new[]{10})]
        [TestCase(2, 10, new[]{8,1})]
        [TestCase(4, 10, new[]{3,1})]
        [TestCase(3, 10, new[]{4,2})]
        [TestCase(0, 100, new[]{101,102})]
        [TestCase(6, 10, new[]{1,2})]
        [TestCase(1, 3, new[]{1})]
        [TestCase(0, 7, new[]{6,3})]
        public void GivenTheAmountToDivideAndCoinValuesNumberOfWaysToDivideShouldBeHappy(int expected, int amountToDivide, int[] givenCoins)
        {
            var actual = Program.GetNumberOfWaysToDivideAmountWithGivenCoins(amountToDivide: amountToDivide, givenCoins: givenCoins);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
