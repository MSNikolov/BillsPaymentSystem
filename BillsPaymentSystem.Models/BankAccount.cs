using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }

        public decimal Balance { get; set; }

        public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public HashSet<PaymentMethod> PaymentMethods { get; set; } = new HashSet<PaymentMethod>();

    }
}
