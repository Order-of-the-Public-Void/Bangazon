using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.Models
{
    public class Recommendation
    {
		[Key]
		public int RecommendationId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public virtual List<ApplicationUser> Receiver { get; set; }
        public virtual Product Products { get; set; }
    }
}