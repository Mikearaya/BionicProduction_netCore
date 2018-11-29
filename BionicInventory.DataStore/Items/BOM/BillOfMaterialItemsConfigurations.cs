/*
 * @CreateTime: Nov 29, 2018 11:34 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 2:37 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Items.BOMs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Items.BOM {
    public class BillOfMaterialItemsConfigurations : IEntityTypeConfiguration<BomItems> {
        public void Configure (EntityTypeBuilder<BomItems> builder) {
            builder.ToTable ("BOM_ITEMS");

            builder.HasIndex (e => e.ItemId)
                .HasName ("fk_BOM_ITEMS_item_idx");

            builder.HasIndex (e => e.UomId)
                .HasName ("fk_BOM_ITEMS_uom_idx");

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

            builder.Property (e => e.ItemId).HasColumnName ("ITEM_ID");

            builder.Property (e => e.Note)
                .HasColumnName ("note")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.Quantity).HasColumnName ("quantity");

            builder.Property (e => e.UomId).HasColumnName ("UOM_ID");

            builder.HasOne (d => d.Item)
                .WithMany (p => p.BomItems)
                .HasForeignKey (d => d.ItemId)
                .HasConstraintName ("fk_BOM_ITEMS_item");

            builder.HasOne (d => d.Uom)
                .WithMany (p => p.BomItems)
                .HasForeignKey (d => d.UomId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_BOM_ITEMS_uom");
        }
    }
}