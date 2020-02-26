using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace GroupProject01
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public byte[] Picture { get; set; }

		public virtual ICollection<Product> Products { get; set; }
		public Category()
		{
			this.Products = new List<Product>();
		}

		//public Category(int CategoryID_, string CategoryName_, string Description_, byte[] Picture_)
		//{
		//	this.CategoryID = CategoryID_;
		//	this.CategoryName = CategoryName_;
		//	this.Description = Description_;
		//	this.Picture = Picture_;
		//}
	}
}
