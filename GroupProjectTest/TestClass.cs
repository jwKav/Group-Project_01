using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using GroupProject01;

namespace GroupProjectTests
{
    class TestClass
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("mexico", "owner", 3)]
        [TestCase("USA", "owner", 2)]
        [TestCase("france", "owner", 3)]
        public void Test1MexicoOwners(string country, string contactTitle, int expected)
        {
            var instance = new CodeToTest();

            var actual = instance.ContactTitleInCountry(country, contactTitle);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(69)]
        public void Test2Fax(int expected)
        {
            var instance = new CodeToTest();

            var actual = instance.HasCustomerGotFax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("London", 6)]
        [TestCase("Buenos Aires", 3)]
        [TestCase("Sao Paulo", 4)]
        public void Test3GivenCity(string city, int expected)
        {
            var instance = new CodeToTest();

            var actual = instance.CustomersInGivenCity(city);


            Assert.AreEqual(expected, actual);
        }

        [TestCase("SAVEA")]
        public void Test4CustomerWithMostOrders(string expected)
        {
            var instance = new CodeToTest();

            var actual = instance.TopOrdersFromCustomers();


            Assert.AreEqual(expected, actual);
        }

        [TestCase("Germany", 11)]
        public void Test4GivenCountry(string country, int expected)
        {
            var instance = new CodeToTest();

            var actual = instance.CustomersInGivenCountry(country);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 187)]
        public void Test5FreightOver100(double freight, int expected)
        {
            var instance = new CodeToTest();

            var actual = instance.FreightOver100(freight);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("London", 6)]
        public void Test6PostCodeArea(string country, int expected)
        {
            var instance = new CodeToTest();

            var actual = instance.CustomersInPostCodeArea(country);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(4)]
        public void Test1EmployeesWithMostCustomer(int expected)
        {
            var instance = new CodeToTest();
            var actual = instance.EmployeesWithMostCustomer();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(14)]

        public void Test2FreightAmountGreaterThan100(int expected)
        {
            var instance = new CodeToTest();
            var actual = instance.FreightAmountGreaterThan100();
            Assert.AreEqual(actual, expected);
        }

        [TestCase("UK", 56)]
        [TestCase("USA", 122)]
        [TestCase("France", 77)]
        [TestCase("Italy", 28)]
        public void Test3NumeberOfOrdersBySpecifiedCountry(string x, int expected)
        {
            var instance = new CodeToTest();
            var actual = instance.NumeberOfOrdersBySpecifiedCountry(x);
            Assert.AreEqual(actual, expected);
        }


        [TestCase(507)]
        public void Test4NumberOfOrdersWithNoShipRegion(int expected)
        {
            var instance = new CodeToTest();
            var actual = instance.NumberOfOrdersWithNoShipRegion();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4)]
        public void Test5EmployeeWithMostOrders(int expected)
        {
            var instance = new CodeToTest();
            var actual = instance.EmployeeWithMostOrders();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Around the horn", 13)]
        public void Test6NumberOfCustomerIDsWithTheSameShipName(string shipname, int expected)
        {
            var instance = new CodeToTest();
            var actual = instance.NumberOfCustomerIDsWithTheSameShipName(shipname);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1996-07-22", 1)]
        public void Test7NumberOfOrderIDWithTheSameDate(string date, int expected)
        {
            var instance = new CodeToTest();
            var actual = instance.NumberOfOrderIDWithTheSameDate(date);
            Assert.AreEqual(actual, expected);
        }
        [TestCase("desc", 263.5000)]
        [TestCase("asc", 2.5000)]
        public void UnitPriceDesc(string order, decimal expected)
        {
            var instance01 = new CodeToTest();

            var actual = instance01.UnitPriceDesc(order);
            //Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, 8)]
        [TestCase(false, 69)]
        public void DiscontinuedCountTest(bool IsDiscontinued, int expected)
        {
            var instance01 = new CodeToTest();

            var actual = instance01.DiscontinuedCount(IsDiscontinued);

            Assert.AreEqual(expected, actual);
        }
        [TestCase("bottle", 12)]
        [TestCase("jar", 8)]
        public void ProductsStoredIn(string container, int expected)
        {
            var instance01 = new CodeToTest();

            var actual = instance01.ProductsStoredIn(container);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(2, 4)]
        [TestCase(4, 3)]
        public void ProductsPerSupplier(int supplierId, int expected)
        {
            var instance01 = new CodeToTest();

            var actual = instance01.ProductsPerSupplier(supplierId);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(0, 72)]
        [TestCase(20, 48)]
        public void ProductsStock(int stockGreaterThan, int expected)
        {
            var instance01 = new CodeToTest();

            var actual = instance01.WithStockGreaterThan(stockGreaterThan);

            Assert.AreEqual(expected, actual);
        }
        [TestCase('c', 9)]
        [TestCase('b', 1)]
        public void ProductsBeginWithChar(char letter, int expected)
        {
            var instance01 = new CodeToTest();

            var actual = instance01.ProductsBeginWith(letter);

            Assert.AreEqual(expected, actual);
        }


    }
}
