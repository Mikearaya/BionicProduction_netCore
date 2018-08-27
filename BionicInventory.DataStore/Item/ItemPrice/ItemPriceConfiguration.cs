using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Items.ItemPrices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Items.ItemPrices {
    public class ItemPriceConfiguration
        : IEntityTypeConfiguration<ItemPrice> {

            public ItemPriceConfiguration () {

            }

            public void Configure (EntityTypeBuilder<ItemPrice> builder) {
                builder.ToTable ("ITEM_PRICE");

                builder.HasIndex (e => e.ItemId)
                    .HasName ("fk_ITEM_PRICE_item_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.CategoryName)
                    .IsRequired ()
                    .HasColumnName ("category_name")
                    .HasColumnType ("varchar(45)");

                builder.Property (e => e.Currency)
                    .HasColumnName ("currency")
                    .HasColumnType ("varchar(45)")
                    .HasDefaultValueSql ("'ETB'");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.ItemId).HasColumnName ("ITEM_ID");

                builder.Property (e => e.Price).HasColumnName ("price");

                builder.HasOne (d => d.Item)
                    .WithMany (p => p.ItemPrice)
                    .HasForeignKey (d => d.ItemId)
                    .HasConstraintName ("fk_ITEM_PRICE_item");
            }
        }
}