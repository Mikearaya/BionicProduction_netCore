using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.ProductionOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.ProductionOrders {
    public class ProductionOrderConfiguration
        : IEntityTypeConfiguration<ProductionOrder> {
            public void Configure (EntityTypeBuilder<ProductionOrder> builder) {
                builder.ToTable ("PRODUCTION_ORDER");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.AddedOn)
                    .HasColumnName ("added_on")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DueDate)
                    .HasColumnName ("due_date")
                    .HasColumnType ("datetime");

                builder.Property (e => e.OrderedOn)
                    .HasColumnName ("ordered_on")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.UpdatedOn)
                    .HasColumnName ("updated_on")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();
            }
        }
}