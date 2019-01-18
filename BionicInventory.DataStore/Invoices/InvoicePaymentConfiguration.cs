using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Invoices.InvoicePayment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Invoices {
    public class InvoicePaymentsConfiguration
        : IEntityTypeConfiguration<InvoicePayments> {

            public void Configure (EntityTypeBuilder<InvoicePayments> builder) {
                builder.ToTable ("INVOICE_PAYMENTS");

                builder.HasIndex (e => e.CashierId)
                    .HasName ("fk_INVOICE_PAYMENTS_cashier_idx");

                builder.HasIndex (e => e.InvoiceNo)
                    .HasName ("fk_INVOICE_PAYMENTS_INVOICE_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.Amount).HasColumnName ("amount");

                builder.Property (e => e.CashierId).HasColumnName ("CASHIER_ID");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.Note)
                    .HasColumnName ("note")
                    .HasColumnType ("varchar(50)");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.InvoiceNo).HasColumnName ("INVOICE_NO");

                builder.Property (e => e.PrintCount)
                    .HasColumnName ("print_count")
                    .HasColumnType ("int(11)")
                    .HasDefaultValueSql ("'0'");

                builder.HasOne (d => d.Cashier)
                    .WithMany (p => p.InvoicePayments)
                    .HasForeignKey (d => d.CashierId)
                    .HasConstraintName ("fk_INVOICE_PAYMENTS_cashier");

                builder.HasOne (d => d.InvoiceNoNavigation)
                    .WithMany (p => p.InvoicePayments)
                    .HasForeignKey (d => d.InvoiceNo)
                    .HasConstraintName ("fk_INVOICE_PAYMENTS_INVOICE");

            }
        }
}