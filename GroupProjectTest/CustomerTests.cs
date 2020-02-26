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
        public void Test1MexicoOwners(string country, string contactTitle, int expected)
        {
            var instance = new CustomerTesting();

            var actual = instance.ContactTitleInCountry(country, contactTitle);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test2Fax(int Fax)
        {
            var instance = new CustomerTesting2();

            var actual = instance.HasCustomerGotFax(Fax);

            Assert.AreEqual(69, actual);
        }
    }
}
