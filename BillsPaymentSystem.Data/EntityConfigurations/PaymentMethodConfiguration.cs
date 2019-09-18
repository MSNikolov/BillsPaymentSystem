using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data.EntityConfigurations
{
    internal class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.UserId).IsRequired();

            builder.HasOne(pm => pm.User).WithMany(u => u.PaymentMethods).HasForeignKey(pm => pm.UserId);

            builder.HasOne(pm => pm.CreditCard).WithMany(cc => cc.PaymentMethods).HasForeignKey(pm => pm.CreditCardId);

            builder.HasOne(pm => pm.BankAccount).WithMany(ba => ba.PaymentMethods).HasForeignKey(pm => pm.BankAccountId);
        }
    }
}
