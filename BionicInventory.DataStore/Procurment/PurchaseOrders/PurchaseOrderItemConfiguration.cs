/*
 * @CreateTime: Dec 29, 2018 10:01 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 10:01 PM
 * @Description: Modify Here, Please 
 */
/*
 * @CreateTime: Dec 29, 2018 10:00 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 10:01 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Procurment.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Procurment.PurchaseOrders {
    public class PurchaseOrderItemConfiguration : IEntityTypeConfiguration<PurchaseOrderItem> {
        public void Configure (EntityTypeBuilder<PurchaseOrderItem> builder) {
            builder.ToTable ("PURCHASE_ORDER_ITEM");

            builder.HasIndex (e => e.ItemId)
                .HasName ("fk_PURCHASE_ORDER_ITEM_id_idx");

            builder.HasIndex (e => e.PurchaseOrderId)
                .HasName ("fk_PURCHASE_ORDER_ITEM_po_idx");

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

            builder.Property (e => e.ExpectedDate)
                .HasColumnName ("expected_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.ItemId).HasColumnName ("ITEM_ID");

            builder.Property (e => e.PurchaseOrderId).HasColumnName ("PURCHASE_ORDER_ID");

            builder.Property (e => e.Quantity).HasColumnName ("quantity");

            builder.Property (e => e.UnitPrice).HasColumnName ("unit_price");

            builder.HasOne (d => d.Item)
                .WithMany (p => p.PurchaseOrderItem)
                .HasForeignKey (d => d.ItemId)
                .HasConstraintName ("fk_PURCHASE_ORDER_ITEM_id");

            builder.HasOne (d => d.PurchaseOrder)
                .WithMany (p => p.PurchaseOrderItem)
                .HasForeignKey (d => d.PurchaseOrderId)
                .HasConstraintName ("fk_PURCHASE_ORDER_ITEM_po");
        }
    }
}