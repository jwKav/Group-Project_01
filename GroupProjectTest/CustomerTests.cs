using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using GroupProject01;

namespace GroupProjectTests
{
    class CustomerTests
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
            var instance = new CustomerTesting();

            var actual = instance.ContactTitleInCountry(country, contactTitle);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(69)]
        public void Test2Fax(int expected)
        {
            var instance = new CustomerTesting2();

            var actual = instance.HasCustomerGotFax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase("London", 6)]
        [TestCase("Buenos Aires", 3)]
        [TestCase("Sao Paulo", 4)]
        public void Test3GivenCity(string city, int expected)
        {
            var instance = new CustomerTesting3();

            var actual = instance.CustomersInGivenCity(city);
        }

        [TestCase("SAVEA")]
        public void Test4CustomerWithMostOrders(string expected)
        {
            var instance = new CustomerTesting();

            var actual = instance.TopOrdersFromCustomers();


            Assert.AreEqual(expected, actual);
        }

        [TestCase("Germany", 11)]
        public void Test4GivenCountry(string country, int expected)
        {
            var instance = new CustomerTesting4();

            var actual = instance.CustomersInGivenCountry(country);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, 187)]
        public void Test5FreightOver100(double freight, int expected)
        {
            var instance = new CustomerTesting5();

            var actual = instance.FreightOver100(freight);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("London", 6)]
        public void Test6PostCodeArea(string country, int expected)
        {
            var instance = new CustomerTesting6();

            var actual = instance.CustomersInPostCodeArea(country);

            Assert.AreEqual(expected, actual);
        }
    }
}
