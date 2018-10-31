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

                builder.Property (e => e.FirstName)
                    .IsRequired ()
                    .HasColumnName ("first_name")
                    .HasColumnType ("varchar(20)");
                
                builder.Property (e => e.LastName)
                    .IsRequired ()
                    .HasColumnName ("last_name")
                    .HasColumnType ("varchar(20)");

                builder.Property (e => e.Tin)
                    .HasColumnName ("TIN")
                    .HasColumnType ("varchar(10)");

                builder.Property (e => e.Type)
                    .IsRequired ()
                    .HasColumnName ("type")
                    .HasColumnType ("varchar(45)");

        builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

            }
        }
}