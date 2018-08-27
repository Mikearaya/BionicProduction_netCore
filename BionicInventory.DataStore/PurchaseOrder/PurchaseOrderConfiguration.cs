using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.PurchaseOrders {
    public class PurchaseOrderConfiguration
        : IEntityTypeConfiguration<PurchaseOrder> {

            public void Configure (EntityTypeBuilder<PurchaseOrder> builder) {
                builder.ToTable ("PURCHASE_ORDER");

                builder.HasIndex (e => e.ClientId)
                    .HasName ("fk_PURCHASE_ORDER_customer_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.AddedPayment)
                    .HasColumnName ("added_payment")
                    .HasDefaultValueSql ("'0'");

                builder.Property (e => e.ClientId).HasColumnName ("CLIENT_ID");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.DueDate)
                    .HasColumnName ("due_date")
                    .HasColumnType ("datetime");

                builder.Property (e => e.InitialPayment).HasColumnName ("initial_payment");

                builder.Property (e => e.IssuedOn)
                    .HasColumnName ("issued_on")
                    .HasColumnType ("datetime");

                builder.Property (e => e.PaymentAmount).HasColumnName ("payment_amount");

                builder.HasOne (d => d.Client)
                    .WithMany (p => p.PurchaseOrder)
                    .HasForeignKey (d => d.ClientId)
                    .HasConstraintName ("fk_PURCHASE_ORDER_customer");
            }
        }
}