/*
 * @CreateTime: Oct 31, 2018 10:55 PM
 * @Author: undefined
 * @Contact: undefined
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 10:07 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.CustomerOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.CustomerOrders {
    public class CustomerOrderItemConfiguration
        : IEntityTypeConfiguration<CustomerOrderItem> {

            public void Configure (EntityTypeBuilder<CustomerOrderItem> builder) {
                builder.ToTable ("CUSTOMER_ORDER_ITEM");

                builder.HasIndex (e => e.CustomerOrderId)
                    .HasName ("fk_OUT_ORDER_LIST_order_idx");

                builder.HasIndex (e => e.ItemId)
                    .HasName ("fk_OUT_ORDER_LIST_item_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.CustomerOrderId).HasColumnName ("CUSTOMER_ORDER_ID");

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

                builder.Property (e => e.Quantity).HasColumnName ("quantity");

                builder.HasOne (d => d.CustomerOrder)
                    .WithMany (p => p.CustomerOrderItem)
                    .HasForeignKey (d => d.CustomerOrderId)
                    .HasConstraintName ("fk_CUSTOMER_ORDER_item");

                builder.HasOne (d => d.Item)
                    .WithMany (p => p.CustomerOrderItem)
                    .HasForeignKey (d => d.ItemId)
                    .HasConstraintName ("fk_OUT_ORDER_LIST_item");
            }

        }

}