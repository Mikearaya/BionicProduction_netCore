/*
 * @CreateTime: Oct 31, 2018 10:55 PM
 * @Author: undefined
 * @Contact: undefined
 * @Last Modified By: undefined
 * @Last Modified Time: Oct 31, 2018 10:55 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.PurchaseOrders.PurchaseOrderDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.PurchaseOrders.PurchaseOrderDetails {
    public class PurchaseOrderDetailConfiguration
        : IEntityTypeConfiguration<PurchaseOrderDetail> {

            public void Configure (EntityTypeBuilder<PurchaseOrderDetail> builder) {
                builder.ToTable ("PURCHASE_ORDER_DETAIL");

                builder.HasIndex (e => e.ItemId)
                    .HasName ("fk_OUT_ORDER_LIST_item_idx");

                builder.HasIndex (e => e.PurchaseOrderId)
                    .HasName ("fk_OUT_ORDER_LIST_order_idx");

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

                builder.Property (e => e.DueDate)
                    .HasColumnName ("due_date")
                    .HasColumnType ("datetime");

                builder.Property (e => e.ItemId).HasColumnName ("ITEM_ID");

                builder.Property (e => e.PricePerItem).HasColumnName ("price_per_item");

                builder.Property (e => e.PurchaseOrderId).HasColumnName ("PURCHASE_ORDER_ID");

                builder.Property (e => e.Quantity).HasColumnName ("quantity");

                builder.HasOne (d => d.Item)
                    .WithMany (p => p.PurchaseOrderDetail)
                    .HasForeignKey (d => d.ItemId)
                    .HasConstraintName ("fk_OUT_ORDER_LIST_item");

                builder.HasOne (d => d.PurchaseOrder)
                    .WithMany (p => p.PurchaseOrderDetail)
                    .HasForeignKey (d => d.PurchaseOrderId)
                    .HasConstraintName ("fk_PURCHASE_ORDER_PO_ID");
            }
        }

}