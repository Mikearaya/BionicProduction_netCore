using System;
using System.Collections.Generic;

using System.Linq;
using BionicInventory.Domain.Customers.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Customers.Addresses
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("ADDRESS");

                builder.HasIndex(e => e.ClientId)
                    .HasName("fk_ADDRESS_client_idx");

                builder.Property(e => e.Id).HasColumnName("ID");

                builder.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'Addis Ababa'");

                builder.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                builder.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'Ethiopia'");

                builder.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("varchar(13)");

                builder.Property(e => e.SubCity)
                    .IsRequired()
                    .HasColumnName("sub_city")
                    .HasColumnType("varchar(45)");

                builder.HasOne(d => d.Client)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_ADDRESS_client");
        }
    }
}