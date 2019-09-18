using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BillsPaymentSystem.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwned { get; set; }

        [NotMapped]
        public decimal LimitLeft => this.Limit - this.MoneyOwned;

        public DateTime ExpirationDate { get; set; }

        public HashSet<PaymentMethod> PaymentMethods { get; set; } = new HashSet<PaymentMethod>();

    }
}
