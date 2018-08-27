using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore {
    public class CustomerConfiguration
        : IEntityTypeConfiguration<Customer> {

            public void Configure (EntityTypeBuilder<Customer> builder) {
                builder.ToTable ("CUSTOMER");

                builder.HasIndex (e => e.Tin)
                    .HasName ("TIN_UNIQUE")
                    .IsUnique ();

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.Email)
                    .HasColumnName ("email")
                    .HasColumnType ("varchar(45)");

                builder.Property (e => e.MainPhone)
                    .IsRequired ()
                    .HasColumnName ("main_phone")
                    .HasColumnType ("varchar(13)");

                builder.Property (e => e.Name)
                    .IsRequired ()
                    .HasColumnName ("name")
                    .HasColumnType ("varchar(50)");

                builder.Property (e => e.Tin)
                    .HasColumnName ("TIN")
                    .HasColumnType ("varchar(10)");

                builder.Property (e => e.Type)
                    .IsRequired ()
                    .HasColumnName ("type")
                    .HasColumnType ("varchar(45)");
            }
        }
}