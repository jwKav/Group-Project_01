using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace GroupProject01
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                Console.WriteLine(connection.State);
                var sqlQuery = "select * from customers";


                //send command to database
                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    //read data
                    var sqlReader = command.ExecuteReader();

                    //while (sqlReader has records coming in)
                    while (sqlReader.Read())
                    {
                        string CustomerId = sqlReader["CustomerID"].ToString();
                        string ContactName = sqlReader["ContactName"].ToString();
                        string CompanyName = sqlReader["CompanyName"].ToString();
                        string City = sqlReader["City"].ToString();


                        var customer = new Customer()
                        {
                            CustomerID = CustomerId,
                            ContactName = ContactName,
                            CompanyName = CompanyName,
                            City = City
                        };
                        customers.Add(customer);
                        //ReadSingleRow((IDataRecord)sqlReader);
                    }
                }
            }
            //static void ReadSingleRow(IDataRecord record)
            //{
            //    for (int j = 0; j < record.FieldCount; j++)
            //    {
            //        Console.WriteLine();
            //        for (int i = 0; i < record.FieldCount; i++)
            //        {

            //            Console.Write($"{record[i]} \t");

            //        }
            //    }


            //}

            //print customers
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-40}" +
                $"{c.CompanyName,-40}{c.City}"));

        }
    }
}
