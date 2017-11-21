using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.Models
{
    public class PaymentMethod
    {
		[Key]
		public int PaymentMethodId { get; set; }
        public virtual User Users { get; set; }
        public string PaymentType { get; set; }
        public string PaymentNickname { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public int BillingZip { get; set; }
        public int CreditCardNumber { get; set; }
        public int CVV { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CardholderName { get; set; }
    }
}