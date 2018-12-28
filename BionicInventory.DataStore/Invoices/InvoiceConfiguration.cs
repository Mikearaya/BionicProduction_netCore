/*
 * @CreateTime: Oct 2, 2018 9:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 10:57 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Invoices {
    public class InvoiceConfiguration
        : IEntityTypeConfiguration<Invoice> {

            public void Configure (EntityTypeBuilder<Invoice> builder) {

                builder.ToTable ("INVOICE");

                builder.HasIndex (e => e.PreparedBy)
                    .HasName ("fk_INVOICE_prepared_by_idx");

                builder.HasIndex (e => e.PurchaseOrderId)
                    .HasName ("fk_SALES_PO_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.Discount)
                    .HasColumnName ("discount")
                    .HasDefaultValueSql ("'0'");
                builder.Property (e => e.InvoiceType)
                    .HasColumnName ("invoice_type")
                    .HasColumnType ("varchar(30)")
                    .IsRequired ();
                builder.Property (e => e.PaymentMethod)
                    .HasColumnName ("payment_method")
                    .HasColumnType ("varchar(30)")
                    .IsRequired ();

                builder.Property (e => e.DueDate)
                    .HasColumnName ("due_date")
                    .HasColumnType ("datetime");

                builder.Property (e => e.Note)
                    .HasColumnName ("note")
                    .HasColumnType ("text");

                builder.Property (e => e.PreparedBy)
                    .HasColumnName ("prepared_by")
                    .HasDefaultValueSql ("'11'");

                builder.Property (e => e.PrintCount)
                    .HasColumnName ("print_count")
                    .HasDefaultValueSql ("'0'");

                builder.Property (e => e.PurchaseOrderId).HasColumnName ("PURCHASE_ORDER_ID");

                builder.Property (e => e.Tax)
                    .HasColumnName ("tax")
                    .HasDefaultValueSql ("'0'");

                builder.HasOne (d => d.PreparedByNavigation)
                    .WithMany (p => p.Invoice)
                    .HasForeignKey (d => d.PreparedBy)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_INVOICE_prepared_by");

                builder.HasOne (d => d.CustomerOrder)
                    .WithMany (p => p.Invoice)
                    .HasForeignKey (d => d.PurchaseOrderId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_INVOICE_PO_ID");
            }
        }
}