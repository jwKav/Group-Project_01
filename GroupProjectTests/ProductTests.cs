using System;
using System.Collections.Generic;
using System.Text;
using GroupProject01;
using NUnit;
using NUnit.Framework;

namespace GroupProjectTests
{
    class ProductTests
    {
        [TestCase("desc", 263.5000)]
        [TestCase("asc", 2.5000)]
        public void UnitPriceDesc(string order, decimal expected)
        {
            var instance01 = new ProductTesting();

            var actual = instance01.UnitPriceDesc(order);
            //Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, 8)]
        [TestCase(false, 69)]
        public void DiscontinuedCountTest(bool IsDiscontinued, int expected)
        {
            var instance01 = new ProductTesting();

            var actual = instance01.DiscontinuedCount(IsDiscontinued);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("bottle", 12)]
        [TestCase("jar", 8)]
        public void ProductsStoredIn(string container, int expected)
        {
            var instance01 = new ProductTesting();

            var actual = instance01.ProductsStoredIn(container);

            Assert.AreEqual(expected, actual);
        }
    }
}
