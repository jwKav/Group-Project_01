﻿using NUnit.Framework;
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

        [TestCase(69)]
        public void Test2Fax(int expected)
        {
            var instance = new CustomerTesting2();

            var actual = instance.HasCustomerGotFax();

            Assert.AreEqual(expected, actual);
        }
    }
}
