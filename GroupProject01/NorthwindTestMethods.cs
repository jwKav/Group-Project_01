using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GroupProject01
{

    public class NorthwindTestMethods
    {

        static List<Order> OrderList = new List<Order>();

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

        public int FreightAmountGreaterThan100()
        {

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
                    param1.Value = "%"+inputShipName+"%";
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
