using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; } // E.g: "CreditCard", "PayPal"
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; } = true;
        public Order Order { get; set; }
    }
}
