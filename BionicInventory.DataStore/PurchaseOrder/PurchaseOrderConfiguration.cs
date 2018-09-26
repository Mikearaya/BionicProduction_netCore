/*
 * @CreateTime: Sep 26, 2018 1:19 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Sep 26, 2018 8:30 PM
 * @Description: Modify Here, Please 
 */
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

                builder.HasIndex (e => e.CreatedBy)
                    .HasName ("fk_PURCHASE_ORDER_employee_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.ClientId).HasColumnName ("CLIENT_ID");

                builder.Property (e => e.CreatedBy).HasColumnName ("CREATED_BY");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.PaymentMethod)
                    .IsRequired ()
                    .HasColumnName ("payment_method");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.InitialPayment).HasColumnName ("initial_payment");

                builder.Property (e => e.IssuedOn)
                    .HasColumnName ("issued_on")
                    .HasColumnType ("datetime");

                builder.HasOne (d => d.Client)
                    .WithMany (p => p.PurchaseOrder)
                    .HasForeignKey (d => d.ClientId)
                    .HasConstraintName ("fk_PURCHASE_ORDER_customer");

                builder.HasOne (d => d.CreatedByNavigation)
                    .WithMany (p => p.PurchaseOrder)
                    .HasForeignKey (d => d.CreatedBy)
                    .HasConstraintName ("fk_PURCHASE_ORDER_employee");
            }
        }
}