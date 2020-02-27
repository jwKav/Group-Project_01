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
           
        }     
    }
    public class CustomerTesting
    {
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
    }

    public class CustomerTesting2
    {
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
    }

    public class CustomerTesting3
    {
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

                    return count;
                }
            }
        }
    }
}
