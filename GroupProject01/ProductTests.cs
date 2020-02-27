using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace GroupProject01
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

        //[TestCase(20)]
        //public void ProductsInStockCount(int expected)
        //{
        //    var instance01 = new ProductTesting();

        //    var actual = instance01.ProductInStockCount();

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
