using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillsPaymentSystem.Data.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.FirstName).HasColumnType("NVARCHAR(50)");

            builder.Property(u => u.LastName).HasColumnType("NVARCHAR(50)");

            builder.Property(u => u.Email).HasColumnType("VARCHAR(80)");

            builder.Property(u => u.Password).HasColumnType("VARCHAR(25)");
        }
    }
}
