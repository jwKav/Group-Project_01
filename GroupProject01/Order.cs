using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupProject01 
{
	public class Order
	{
		public int OrderID { get; set; }
		public string CustomerID { get; set; }
		public int EmployeeID { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime RequiredDate { get; set; }
		public DateTime ShippedDate { get; set; }
		public int ShipVia { get; set; }
		public decimal Freight { get; set; }
		public string ShipName { get; set; }
		public string ShipAddress { get; set; }
		public string ShipCity { get; set; }
		public string ShipRegion { get; set; }
		public string ShipPostalCode { get; set; }
		public string ShipCountry { get; set; }

		public virtual ICollection<Customer> Customers { get; set; }
		public Order()
		{
			this.Customers = new List<Customer>();
		}
		

		//public Order(int OrderID_, string CustomerID_, int EmployeeID_, DateTime OrderDate_, DateTime RequiredDate_, DateTime ShippedDate_, int ShipVia_, decimal Freight_, string ShipName_, string ShipAddress_, string ShipCity_, string ShipRegion_, string ShipPostalCode_, string ShipCountry_)
		//{
		//	this.OrderID = OrderID_;
		//	this.CustomerID = CustomerID_;
		//	this.EmployeeID = EmployeeID_;
		//	this.OrderDate = OrderDate_;
		//	this.RequiredDate = RequiredDate_;
		//	this.ShippedDate = ShippedDate_;
		//	this.ShipVia = ShipVia_;
		//	this.Freight = Freight_;
		//	this.ShipName = ShipName_;
		//	this.ShipAddress = ShipAddress_;
		//	this.ShipCity = ShipCity_;
		//	this.ShipRegion = ShipRegion_;
		//	this.ShipPostalCode = ShipPostalCode_;
		//	this.ShipCountry = ShipCountry_;
		//}
	}
}


