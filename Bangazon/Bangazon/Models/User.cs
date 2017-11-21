using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.Models
{
    public class User
    {
		[Key]
		public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
		public string State { get; set; }
        public int Zip { get; set; }
        public int Phone { get; set; }
        public string UserName { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}