using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Invoices.InvoicePayment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Invoices.InvoicePayment {
    public class InvoicePaymentsConfiguration
        : IEntityTypeConfiguration<InvoicePayments> {

            public void Configure (EntityTypeBuilder<InvoicePayments> builder) {
                builder.ToTable ("INVOICE_PAYMENTS");

                builder.HasIndex (e => e.InvoiceNo)
                    .HasName ("fk_INVOICE_PAYMENTS_INVOICE_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.Amount).HasColumnName ("amount");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.InvoiceNo).HasColumnName ("INVOICE_NO");

                builder.HasOne (d => d.InvoiceNoNavigation)
                    .WithMany (p => p.InvoicePayments)
                    .HasForeignKey (d => d.InvoiceNo)
                    .HasConstraintName ("fk_INVOICE_PAYMENTS_INVOICE");
            }
        }
}