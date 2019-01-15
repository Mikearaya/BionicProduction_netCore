/*
 * @CreateTime: Dec 23, 2018 9:44 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 15, 2019 12:36 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Procurment.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Vendors {
    public class VendorPurchaseTermConfiguration : IEntityTypeConfiguration<VendorPurchaseTerm> {
        public void Configure (EntityTypeBuilder<VendorPurchaseTerm> builder) {
            builder.ToTable ("VENDOR_PURCHASE_TERM");

            builder.HasIndex (e => e.ItemId)
                .HasName ("fk_VENDOR_PURCHASE_TERM_item_idx");

            builder.HasIndex (e => e.VendorId)
                .HasName ("fk_VENDOR_PURCHASE_TERM_vendor_idx");

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

            builder.Property (e => e.Leadtime).HasColumnName ("lead_time");

            builder.Property (e => e.MinimumQuantity).HasColumnName ("minimum_quantity");

            builder.Property (e => e.Priority).HasColumnName ("priority");

            builder.Property (e => e.UnitPrice).HasColumnName ("unit_price");

            builder.Property (e => e.VendorId).HasColumnName ("VENDOR_ID");

            builder.Property (e => e.VendorProductId)
                .HasColumnName ("vendor_product_id")
                .HasColumnType ("varchar(45)");

            builder.HasOne (d => d.Item)
                .WithMany (p => p.VendorPurchaseTerm)
                .HasForeignKey (d => d.ItemId)
                .HasConstraintName ("fk_VENDOR_PURCHASE_TERM_item");

            builder.HasOne (d => d.Vendor)
                .WithMany (p => p.VendorPurchaseTerm)
                .HasForeignKey (d => d.VendorId)
                .HasConstraintName ("fk_VENDOR_PURCHASE_TERM_vendor");
        }
    }
}