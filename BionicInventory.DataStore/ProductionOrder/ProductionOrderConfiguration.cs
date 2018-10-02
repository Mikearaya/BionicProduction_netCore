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

                builder.HasIndex (e => e.OrderedBy)
                    .HasName ("fk_PRODUCTION_ORDERED_BY_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.AddedOn)
                    .HasColumnName ("added_on")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.Description)
                    .IsRequired ()
                    .HasColumnName ("description")
                    .HasColumnType ("varchar(50)");

                builder.Property (e => e.OrderedBy).HasColumnName ("ordered_by");

                builder.Property (e => e.UpdatedOn)
                    .HasColumnName ("updated_on")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.HasOne (d => d.OrderedByNavigation)
                    .WithMany (p => p.ProductionOrder)
                    .HasForeignKey (d => d.OrderedBy)
                    .HasConstraintName ("fk_PRODUCTION_ORDERED_BY");
            }
        }
}