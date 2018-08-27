using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Invoices.InvoiceDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Invoices.InvoiceDetails {
    public class InvoiceDetailConfiguration
        : IEntityTypeConfiguration<InvoiceDetail> {

            public void Configure (EntityTypeBuilder<InvoiceDetail> builder) {

                builder.ToTable ("INVOICE_DETAIL");

                builder.HasIndex (e => e.InventoryId)
                    .HasName ("fk_SALE_DETAIL_INVENTORY_ID_idx");

                builder.HasIndex (e => e.InvoiceNo)
                    .HasName ("fk_INVOICE_ID_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.DateAddded)
                    .HasColumnName ("date_addded")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.InventoryId).HasColumnName ("INVENTORY_ID");

                builder.Property (e => e.InvoiceNo).HasColumnName ("INVOICE_NO");

                builder.HasOne (d => d.Inventory)
                    .WithMany (p => p.InvoiceDetail)
                    .HasForeignKey (d => d.InventoryId)
                    .HasConstraintName ("fk_SALE_DETAIL_INVENTORY_ID");

                builder.HasOne (d => d.InvoiceNoNavigation)
                    .WithMany (p => p.InvoiceDetail)
                    .HasForeignKey (d => d.InvoiceNo)
                    .HasConstraintName ("fk_INVOICE_ID");
            }
        }
}