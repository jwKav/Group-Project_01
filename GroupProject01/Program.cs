﻿using System;
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
    }
    
}
