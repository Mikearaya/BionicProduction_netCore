/*
 * @CreateTime: Oct 9, 2018 11:04 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 14, 2018 11:25 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.ProductionOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.ProductionOrders.ProductionOrderLists {
    public class ProductionOrderListConfiguration
        : IEntityTypeConfiguration<ProductionOrderList> {

            public void Configure (EntityTypeBuilder<ProductionOrderList> builder) {
                builder.ToTable ("PRODUCTION_ORDER_LIST");

                builder.HasIndex (e => e.ItemId)
                    .HasName ("fk_IN_ORDER_LIST_item_idx");

                builder.HasIndex (e => e.OrderedBy)
                    .HasName ("fk_PRODUCTION_ORDER_ordered_by_idx");

                builder.HasIndex (e => e.PurchaseOrderId)
                    .HasName ("PURCHASE_ORDER_ID_UNIQUE")
                    .IsUnique ();

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.CostPerItem).HasColumnName ("cost_per_item");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.Description)
                    .HasColumnName ("description")
                    .HasColumnType ("varchar(255)");

                builder.Property (e => e.DueDate)
                    .HasColumnName ("due_date")
                    .HasColumnType ("datetime");

                builder.Property (e => e.ItemId).HasColumnName ("ITEM_ID");

                builder.Property (e => e.OrderedBy).HasColumnName ("ordered_by");

                builder.Property (e => e.PurchaseOrderId).HasColumnName ("PURCHASE_ORDER_ID");

                builder.Property (e => e.Quantity).HasColumnName ("quantity");

                builder.Property (e => e.Start)
                    .HasColumnName ("start")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.HasOne (d => d.Item)
                    .WithMany (p => p.ProductionOrderList)
                    .HasForeignKey (d => d.ItemId)
                    .HasConstraintName ("fk_IN_ORDER_LIST_item");

                builder.HasOne (d => d.OrderedByNavigation)
                    .WithMany (p => p.ProductionOrderList)
                    .HasForeignKey (d => d.OrderedBy)
                    .HasConstraintName ("fk_PRODUCTION_ORDER_ordered_by");

            }
        }

}