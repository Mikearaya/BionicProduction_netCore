/*
 * @CreateTime: Oct 2, 2018 9:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 26, 2018 10:08 PM
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

                builder.HasIndex (e => e.PurchaseOrderId)
                    .HasName ("PURCHASE_ORDER_ID_UNIQUE")
                    .IsUnique ();

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");
                
                builder.Property (e => e.InvoiceType)
                    .IsRequired ()
                    .HasColumnName ("invoice_type");

                builder.Property (e => e.Tax)
                    .HasColumnType("float")
                    .HasColumnName ("tax");
                builder.Property (e => e.Discount)
                    .HasColumnType("float")
                    .HasColumnName ("discount");
                

                builder.Property (e => e.Note)
                    .HasColumnType("varchar(255)")
                    .HasColumnName ("note");

                builder.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.PrintCount)
                    .HasColumnName ("print_count")
                    .HasDefaultValueSql ("'0'");

                builder.Property (e => e.PurchaseOrderId).HasColumnName ("PURCHASE_ORDER_ID");

                builder.HasOne (d => d.PurchaseOrder)
                    .WithOne (p => p.Invoice)
                    .HasForeignKey<Invoice> (d => d.PurchaseOrderId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_INVOICE_PO_ID");
            }
        }
}