using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace GroupProject01
{
    class Program
    {
       
        static void Main(string[] args)
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
                    
                   
                }
            }
        }     

        
    }
    public class CustomerTesting
    {
        public int TotalOrders { get; private set; }

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
    }
}



