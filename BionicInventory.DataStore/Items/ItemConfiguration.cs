/*
 * @CreateTime: Nov 29, 2018 11:44 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 3:11 PM
 * @Description: Modify Here, Please 
 */
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

                builder.HasIndex (e => e.GroupId)
                    .HasName ("fk_ITEM_group_idx");

                builder.HasIndex (e => e.PrimaryUomId)
                    .HasName ("fk_ITEM_storing_uom_idx");

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

                builder.Property (e => e.GroupId)
                    .HasColumnName ("GROUP_ID")
                    .HasDefaultValueSql ("'1'");

                builder.Property (e => e.IsInventory)
                    .HasColumnName ("is_inventory")
                    .HasColumnType ("tinyint(4)")
                    .HasDefaultValueSql ("'1'");

                builder.Property (e => e.IsProcured)
                    .HasColumnName ("is_procured")
                    .HasColumnType ("tinyint(4)")
                    .HasDefaultValueSql ("'0'");

                builder.Property (e => e.MinimumQuantity)
                    .HasColumnName ("minimum_quantity");

                builder.Property (e => e.Name)
                    .IsRequired ()
                    .HasColumnName ("name")
                    .HasColumnType ("varchar(20)");

                builder.Property (e => e.Photo)
                    .HasColumnName ("photo")
                    .HasColumnType ("varchar(50)");

                builder.Property (e => e.Price).HasColumnName ("price");

                builder.Property (e => e.ShelfLife)
                    .HasColumnName ("shelf_life")
                    .HasDefaultValueSql ("'0'");

                builder.Property (e => e.PrimaryUomId)
                    .IsRequired ()
                    .HasColumnName ("primary_UOM_ID");

                builder.Property (e => e.UnitCost).HasColumnName ("unit_cost");

                builder.Property (e => e.Weight).HasColumnName ("weight");

                builder.HasOne (d => d.Group)
                    .WithMany (p => p.Item)
                    .HasForeignKey (d => d.GroupId)
                    .HasConstraintName ("fk_ITEM_group");

                builder.HasOne (d => d.PrimaryUom)
                    .WithMany (p => p.ItemPrimaryUom)
                    .HasForeignKey (d => d.PrimaryUomId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_ITEM_storing_uom");
            }
        }
}