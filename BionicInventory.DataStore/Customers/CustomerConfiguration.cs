/*
 * @CreateTime: Nov 27, 2018 3:02 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 3:54 PM
 * @Description: Modify Here, Please 
 */
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

                builder.Property (e => e.CreditLimit)
                    .HasColumnName ("credit_limit")
                    .HasDefaultValueSql ("'0'");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.Email)
                    .HasColumnName ("email")
                    .HasColumnType ("varchar(45)");

                builder.Property (e => e.Fax)
                    .HasColumnName ("fax")
                    .HasColumnType ("varchar(45)");

                builder.Property (e => e.FullName)
                    .IsRequired ()
                    .HasColumnName ("full_name")
                    .HasColumnType ("varchar(50)");

                builder.Property (e => e.PaymentPeriod)
                    .HasColumnName ("payment_period")
                    .HasColumnType ("int(11)")
                    .HasDefaultValueSql ("'0'");

                builder.Property (e => e.PoBox)
                    .HasColumnName ("po_box")
                    .HasColumnType ("varchar(20)");

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