using NUnit.Framework;
using GroupProject01;

namespace NorthwindNUnitOrdersTest
{
    public class Tests
    {
   
       
        [TestCase(4)]
        public void Test1EmployeesWithMostCustomer(int expected)
        {
            var instance = new NorthwindTestMethods();
            var actual = instance.EmployeesWithMostCustomer();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(14)]

        public void Test2FreightAmountGreaterThan100(int expected)
        {
            var instance = new NorthwindTestMethods();
            var actual = instance.FreightAmountGreaterThan100();
            Assert.AreEqual(actual, expected);
        }

        [TestCase("UK", 56)]
        [TestCase("USA", 122)]
        [TestCase("France", 77)]
        [TestCase("Italy", 28)]
        public void Test3NumeberOfOrdersBySpecifiedCountry(string x, int expected)
        {
            var instance = new NorthwindTestMethods();
            var actual = instance.NumeberOfOrdersBySpecifiedCountry(x);
            Assert.AreEqual(actual, expected);
        }


        [TestCase(507)]
        public void Test4NumberOfOrdersWithNoShipRegion(int expected)
        {
            var instance = new NorthwindTestMethods();
            var actual = instance.NumberOfOrdersWithNoShipRegion();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4)]
        public void Test5EmployeeWithMostOrders(int expected)
        {
            var instance = new NorthwindTestMethods();
            var actual = instance.EmployeeWithMostOrders();
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Around the horn", 13)]
        public void Test6NumberOfCustomerIDsWithTheSameShipName(string shipname , int expected)
        {
            var instance = new NorthwindTestMethods();
            var actual = instance.NumberOfCustomerIDsWithTheSameShipName(shipname);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1996-07-22", 1)]
        public void Test7NumberOfOrderIDWithTheSameDate(string date, int expected)
        {
            var instance = new NorthwindTestMethods();
            var actual = instance.NumberOfOrderIDWithTheSameDate(date);
            Assert.AreEqual(actual, expected);
        }

    }
}