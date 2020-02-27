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
    public class CustomerTesting
    {
        public int TotalOrders { get; private set; }

            //Console.WriteLine(ProductTesting.WithStockGreaterThan(0));
        }
    }
    public class ProductTesting
    {
        static List<Product> products = new List<Product>();
        public decimal UnitPriceDesc(string order)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                Console.WriteLine(connection.State);
                var sqlQuery = "select ProductName, UnitPrice from products" +
                    " order by UnitPrice " + order;


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
                    param1.Value = "%"+container+"%";
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


    }

    public class CustomerTesting4
    {
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
    }
    public class CustomerTesting5
    {
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
    }
    public class CustomerTesting6
    {
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
    }

    }   

}
