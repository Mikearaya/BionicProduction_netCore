using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Items {
    public class ItemConfiguration
        : IEntityTypeConfiguration<Item> {
            public void Configure (EntityTypeBuilder<Item> builder) {
                builder.ToTable ("ITEM");

                builder.HasIndex (e => e.Code)
                    .HasName ("code_UNIQUE")
                    .IsUnique ();

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.Code)
                    .IsRequired ()
                    .HasColumnName ("code")
                    .HasColumnType ("varchar(45)");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdate)
                    .HasColumnName ("date_update")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.Description)
                    .HasColumnName ("description")
                    .HasColumnType ("text");

                builder.Property (e => e.UnitCost)
                    .HasColumnType ("float")
                    .HasColumnName ("unit_cost");

                builder.Property (e => e.Name)
                    .IsRequired ()
                    .HasColumnName ("name")
                    .HasColumnType ("varchar(20)");

                builder.Property (e => e.Photo).HasColumnName ("photo");

                builder.Property (e => e.Weight)
                    .HasColumnName ("weight")
                    .HasColumnType ("float");
            }
        }
}