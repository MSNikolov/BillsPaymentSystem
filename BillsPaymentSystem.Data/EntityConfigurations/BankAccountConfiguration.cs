using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data.EntityConfigurations
{
    internal class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.BankAccountId);

            builder.Property(ba => ba.Balance).HasColumnType("DECIMAL(16,2)").IsRequired();

            builder.Property(ba => ba.BankName).HasColumnType("NVARCHAR(50)").IsRequired();

            builder.Property(ba => ba.SwiftCode).HasColumnType("VARCHAR(20)").IsRequired();
        }
    }
}
