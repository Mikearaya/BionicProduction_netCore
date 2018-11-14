/*
 * @CreateTime: Nov 14, 2018 11:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 14, 2018 11:14 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Shipments.ShipmentDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Shipments.ShipmentDetails {
    public class ShipmentDetailsConfiguration : IEntityTypeConfiguration<ShipmentDetail> {
        public void Configure (EntityTypeBuilder<ShipmentDetail> builder) {
            builder.ToTable ("SHIPMENT_DETAIL");

            builder.HasIndex (e => e.OrderItemId)
                .HasName ("fk_SHIPMENT_DETAIL_order_item_idx");

            builder.HasIndex (e => e.ShipmentId)
                .HasName ("fk_SHIPMENT_DETAIL_1_idx");

            builder.HasIndex (e => e.StockId)
                .HasName ("STOCK_ID_UNIQUE")
                .IsUnique ();

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

            builder.Property (e => e.OrderItemId).HasColumnName ("ORDER_ITEM_ID");

            builder.Property (e => e.Picked)
                .HasColumnName ("picked")
                .HasColumnType ("tinyint(1)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.ShipmentId).HasColumnName ("SHIPMENT_ID");

            builder.Property (e => e.StockId).HasColumnName ("STOCK_ID");

            builder.HasOne (d => d.OrderItem)
                .WithMany (p => p.ShipmentDetail)
                .HasForeignKey (d => d.OrderItemId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_SHIPMENT_DETAIL_order_item");

            builder.HasOne (d => d.Shipment)
                .WithMany (p => p.ShipmentDetail)
                .HasForeignKey (d => d.ShipmentId)
                .HasConstraintName ("fk_SHIPMENT_DETAIL_shipment");

            builder.HasOne (d => d.Stock)
                .WithOne (p => p.ShipmentDetail)
                .HasForeignKey<ShipmentDetail> (d => d.StockId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_SHIPMENT_DETAIL_stock");
        }
    }
}