using NUnit.Framework;
using GroupProject01;

namespace NorthwindNUnitOrdersTest
{
    public class Tests
    {
   
       
        [TestCase(4)]
        public void Test1(int expected)
        {
            var instance = new NorthwindTestMethods();
            var actual = instance.EmployeesWithMostCustomer();
            Assert.AreEqual(actual, expected);
        }

        [TestCase(14)]

        public void Test2(int expected)
        {
            var instance = new NorthwindTestMethods();
            var actual = instance.FreightAmountGreaterThan100();
            Assert.AreEqual(actual, expected);
        }

       [TestCase("UK", 56)]
       [TestCase("USA",122)]
       [TestCase("France",77)]
       [TestCase("Italy",28)]
       public void Test3(string x, int expected)
       {
            var instance = new NorthwindTestMethods();
            var actual = instance.NumeberOfOrdersBySpecifiedCountry(x);
            Assert.AreEqual(actual, expected);
       }
    }
}