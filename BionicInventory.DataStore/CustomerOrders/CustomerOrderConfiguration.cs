/*
 * @CreateTime: Sep 26, 2018 1:19 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 11, 2018 10:48 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.CustomerOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.PurchaseOrders {
    public class CustomerOrderConfiguration
        : IEntityTypeConfiguration<CustomerOrder> {

            public void Configure (EntityTypeBuilder<CustomerOrder> builder) {
                builder.ToTable ("CUSTOMER_ORDER");

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
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.OrderStatus)
                    .HasColumnName ("order_status")
                    .HasColumnType ("varchar(45)")
                    .HasDefaultValueSql ("'Quotation'");

                builder.HasOne (d => d.Client)
                    .WithMany (p => p.CustomerOrder)
                    .HasForeignKey (d => d.ClientId)
                    .HasConstraintName ("fk_PURCHASE_ORDER_customer");

                builder.HasOne (d => d.CreatedByNavigation)
                    .WithMany (p => p.CustomerOrder)
                    .HasForeignKey (d => d.CreatedBy)
                    .HasConstraintName ("fk_PURCHASE_ORDER_employee");

            }
        }
}