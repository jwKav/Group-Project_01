using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace GroupProject01
{
    class Program
    {
        static void Main(string[] args)
        {

        }

    }
    public class CodeToTest
    {
        static List<Order> OrderList = new List<Order>();
        static List<Product> products = new List<Product>();

        public decimal UnitPriceDesc(string order)
        {
            products.Clear();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                Console.WriteLine(connection.State);
                var sqlQuery = "select ProductName, UnitPrice from products" +
                    " order by UnitPrice " + order;
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    var sqlReader = command.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        string ProductName = sqlReader["ProductName"].ToString();
                        decimal UnitPrice = (decimal)sqlReader["UnitPrice"];


                        var product = new Product()
                        {
                            ProductName = ProductName,
                            UnitPrice = UnitPrice
                        };
                        products.Add(product);
                    }
                }
            }

            return products[0].UnitPrice;
        }
        public int ContactTitleInCountry(string Country, string ContactTitle)
        {
            string inputCountry = Country;
            string inputTitle = ContactTitle;
            string countryRequest = "select count(*) from customers where country = @" + Country + " and contacttitle = @" + ContactTitle + "; ";
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");


            using (connection)
            {
                connection.Open();
                using (var command = new SqlCommand(countryRequest, connection))
                {


                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@" + Country;
                    param1.Value = inputCountry;
                    command.Parameters.Add(param1);
                    SqlParameter param2 = new SqlParameter();
                    param2.ParameterName = "@" + ContactTitle;
                    param2.Value = inputTitle;
                    command.Parameters.Add(param2);
                    Int32 count = (Int32)command.ExecuteScalar();
                    Console.WriteLine(count);

                    return count;

                }
            }
        }
        public string TopOrdersFromCustomers()
        {
            string Request = "select c.CustomerID as CustomerIDS, c.ContactName as CustomerNames, count(o.CustomerID) as TotalOrders" +
                " from Customers c join Orders o on o.CustomerID = c.CustomerID" +
                " group by c.CustomerID, c.ContactName " +
                "order by TotalOrders desc";

            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");

            using (connection)
            {
                connection.Open();
                using (var command = new SqlCommand(Request, connection))
                {


                    var reader = command.ExecuteScalar();


                    Console.WriteLine(reader);

                    return reader.ToString();

                }
            }
        }
        public int HasCustomerGotFax()
        {

            string faxRequest = "select count(*) from customers where fax is not null;";
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");

            using (connection)
            {
                connection.Open();
                using (var command = new SqlCommand(faxRequest, connection))
                {

                    Int32 result = (Int32)command.ExecuteScalar();

                    return result;

                }
            }
        }
        public int CustomersInGivenCity(string City)
        {
            string inputCity = City;

            string cityRequest = "select count(*) from customers where city like @inputCity";
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");

            using (connection)
            {
                connection.Open();
                using (var command = new SqlCommand(cityRequest, connection))
                {


                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@inputCity";
                    param1.Value = "%" + inputCity + "%";
                    command.Parameters.Add(param1);

                    Int32 count = (Int32)command.ExecuteScalar();
                    Console.WriteLine(count);

                    return count;
                }
            }
        }
        public int DiscontinuedCount(bool IsDiscontinued)
        {
            string countRequest = "select count(discontinued) from products where discontinued = @Discontinued";

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                using (var command = new SqlCommand(countRequest, connection))
                {


                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@Discontinued";
                    param1.Value = IsDiscontinued;
                    command.Parameters.Add(param1);
                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;
                }
            }
        }
        public int ProductsStoredIn(string container)
        {
            string countRequest = "select count(productid) from products where QuantityPerUnit like @container";

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                using (var command = new SqlCommand(countRequest, connection))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@container";
                    param1.Value = "%" + container + "%";
                    command.Parameters.Add(param1);
                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;
                }
            }
        }
        public int ProductsPerSupplier(int supplierId)
        {
            string countRequest = "select count(productid) from products group by supplierid having supplierid like @supplier";

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                using (var command = new SqlCommand(countRequest, connection))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@supplier";
                    param1.Value = supplierId;
                    command.Parameters.Add(param1);

                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;
                }
            }
        }
        public int CustomersInGivenCountry(string Country)
        {
            string inputCountry = Country;

            string countryRequest = "select count(*) from customers where country like @inputCountry";
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");

            using (connection)
            {
                connection.Open();
                using (var command = new SqlCommand(countryRequest, connection))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@inputCountry";
                    param1.Value = "%" + inputCountry + "%";
                    command.Parameters.Add(param1);

                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;


                }
            }
        }
        public int FreightOver100(double freight)
        {

            double inputFreight = freight;

            string FreightRequest = "select count(*)" +
                "from customers " +
                "join orders " +
                "on customers.CustomerId = orders.CustomerId " +
                "where orders.Freight >  @" + inputFreight + ";";



            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");

            using (connection)
            {
                connection.Open();
                using (var command = new SqlCommand(FreightRequest, connection))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@" + inputFreight;
                    param1.Value = inputFreight;
                    command.Parameters.Add(param1);

                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;



                }
            }
        }
        public int CustomersInPostCodeArea(string City)
        {
            string inputCity = City;

            string cityRequest = "select count(*) from customers where city = @" + inputCity + ";";
            var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");

            using (connection)
            {
                connection.Open();
                using (var command = new SqlCommand(cityRequest, connection))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@" + City;
                    param1.Value = inputCity;
                    command.Parameters.Add(param1);

                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;

                }
            }
        }
        public int WithStockGreaterThan(int amountOfStock)
        {
            string countRequest = "select count(UnitsInStock) from products where unitsinstock >@stock";

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                using (var command = new SqlCommand(countRequest, connection))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@stock";
                    param1.Value = amountOfStock;
                    command.Parameters.Add(param1);
                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;
                }
            }
        }
        public int ProductsBeginWith(char firstLetter)
        {
            string countRequest = "select count(productid) from products where ProductName like @firstLetter";

            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                using (var command = new SqlCommand(countRequest, connection))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@firstLetter";
                    param1.Value = firstLetter + "%";
                    command.Parameters.Add(param1);
                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;

                }
            }
        }
        public int EmployeesWithMostCustomer()
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind"))
            {
                connection.Open();
                var SqlQuery = "SELECT TOP 1 EMPLOYEEID, COUNT(CustomerID) as custCount" +
                    " FROM Orders" +
                    " GROUP BY EmployeeID" +
                    " ORDER BY custCount DESC";

                using (var command = new SqlCommand(SqlQuery, connection))
                {
                    var sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        string EmployeeID = sqlReader["EmployeeID"].ToString();

                        var Order = new Order()
                        {
                            EmployeeID = int.Parse(EmployeeID)
                        };

                        OrderList.Add(Order);
                    }
                    return OrderList[0].EmployeeID;
                }
            }
        }
        public int FreightAmountGreaterThan100()        {

            OrderList.Clear();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind"))
            {
                connection.Open();
                var SqlQuery = "SELECT ShipCountry, SUM(Freight)" +
                                 " FROM Orders" +
                                 " GROUP BY ShipCountry" +
                                 " HAVING SUM(Freight) > 1000";

                using (var command = new SqlCommand(SqlQuery, connection))
                {
                    var sqlReader = command.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        string ShipCountry = sqlReader["ShipCountry"].ToString();

                        var Order = new Order()
                        {
                            ShipCountry = ShipCountry
                        };

                        OrderList.Add(Order);
                    }
                    return OrderList.Count;
                }
            }

        }
        public int NumeberOfOrdersBySpecifiedCountry(string country)
        {
            OrderList.Clear();
            string inputCountry = country;
            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind"))
            {
                connection.Open();

                var SqlQuery = "SELECT COUNT(OrderID)"
                                + " FROM ORDERS"
                                + " WHERE ShipCountry = @" + country
                                + " GROUP BY ShipCountry";

                using (var command = new SqlCommand(SqlQuery, connection))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@" + country;
                    param1.Value = inputCountry;
                    command.Parameters.Add(param1);
                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;

                }
            }
        }
        public int NumberOfOrdersWithNoShipRegion()
        {
            OrderList.Clear();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind"))
            {
                connection.Open();

                var SqlQuery = "SELECT OrderID, ShipRegion FROM ORDERS"
                                + " WHERE ShipRegion is NULL";

                using (var command = new SqlCommand(SqlQuery, connection))
                {
                    var sqlReader = command.ExecuteReader();


                    while (sqlReader.Read())
                    {
                        int OrderID = Convert.ToInt32(sqlReader["OrderID"]);

                        var Order = new Order()
                        {
                            OrderID = OrderID
                        };

                        OrderList.Add(Order);
                    }

                    return OrderList.Count;
                }
            }
        }
        public int EmployeeWithMostOrders()
        {
            OrderList.Clear();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind"))
            {
                connection.Open();

                var SqlQuery = "SELECT TOP 1 EmployeeID, COUNT(OrderID) FROM Orders" +
                                 " GROUP BY EmployeeID" +
                                    " ORDER BY COUNT(OrderID) DESC";


                using (var command = new SqlCommand(SqlQuery, connection))
                {
                    var sqlReader = command.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        int EmployeeID = Convert.ToInt32(sqlReader["EmployeeID"]);

                        var Order = new Order()
                        {
                            EmployeeID = EmployeeID
                        };

                        OrderList.Add(Order);
                    }

                    return OrderList[0].EmployeeID;
                }
            }
        }
        public int NumberOfCustomerIDsWithTheSameShipName(string shipname)
        {
            OrderList.Clear();
            string inputShipName = shipname;
            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind"))
            {
                connection.Open();

                var SqlQuery = "SELECT COUNT(CustomerID), ShipName"
                                + " FROM ORDERS"
                                + " GROUP BY ShipName" +
                                " HAVING ShipName LIKE @shipname";

                using (var command = new SqlCommand(SqlQuery, connection))
                {
                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@shipname";
                    param1.Value = "%" + inputShipName + "%";
                    command.Parameters.Add(param1);
                    Int32 count = (Int32)command.ExecuteScalar();

                    return count;

                }
            }

        }
        public int NumberOfOrderIDWithTheSameDate(string date)
        {
            OrderList.Clear();
            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind"))
            {
                connection.Open();

                var sqlQuery = "SELECT COUNT(OrderID) FROM Orders" +
                                " GROUP BY OrderDate" +
                                " HAVING OrderDate = @date";


                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@date";
                    sqlParameter.Value = date;
                    command.Parameters.Add(sqlParameter);
                    var count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                }

            }
        }

    }
}



