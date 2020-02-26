using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace GroupProject01
{
	public class Customer
	{
		public string CustomerID { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string ContactTitle { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Region { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }


		//public Customer(string CustomerID_, string CompanyName_, string ContactName_, string ContactTitle_, string Address_, string City_, string Region_, string PostalCode_, string Country_, string Phone_, string Fax_)
		//{
		//	this.CustomerID = CustomerID_;
		//	this.CompanyName = CompanyName_;
		//	this.ContactName = ContactName_;
		//	this.ContactTitle = ContactTitle_;
		//	this.Address = Address_;
		//	this.City = City_;
		//	this.Region = Region_;
		//	this.PostalCode = PostalCode_;
		//	this.Country = Country_;
		//	this.Phone = Phone_;
		//	this.Fax = Fax_;
		//}
	}
}
