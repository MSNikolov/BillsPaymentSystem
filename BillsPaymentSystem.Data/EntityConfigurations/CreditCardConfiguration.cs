using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data.EntityConfigurations
{
    internal class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(cc => cc.CreditCardId);

            builder.Property(cc => cc.Limit).HasColumnType("DECIMAL(16,2)").IsRequired();

            builder.Property(cc => cc.MoneyOwned).HasColumnType("DECIMAL(16,2)").IsRequired();

            builder.Property(cc => cc.ExpirationDate).IsRequired();
        }
    }
}
