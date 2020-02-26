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

        
        public int NumeberOfOrdersBySpecifiedCountry(string x)
        {

            OrderList.Clear();

            using (var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog = Northwind"))
            {
                connection.Open();
                var SqlQuery = "SELECT ShipCountry, COUNT(OrderID)"
                                + " FROM ORDERS"
                                + $" WHERE ShipCountry = {x}"
                                + " GROUP BY ShipCountry";

                using (var command = new SqlCommand(SqlQuery, connection))
                {
                    var sqlReader = command.ExecuteReader();

                    string columnname = "ShipCountry";

                    while (sqlReader.Read())
                    {
                        string ShipCountry = sqlReader[columnname].ToString();

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





    }
}
