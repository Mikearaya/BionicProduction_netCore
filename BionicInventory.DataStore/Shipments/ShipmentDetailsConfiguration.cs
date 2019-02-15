/*
 * @CreateTime: Nov 14, 2018 11:14 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 14, 2018 11:14 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Shipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Shipments {
    public class ShipmentDetailsConfiguration : IEntityTypeConfiguration<ShipmentDetail> {
        public void Configure (EntityTypeBuilder<ShipmentDetail> builder) {
            builder.ToTable ("SHIPMENT_DETAIL");

            builder.HasIndex (e => e.LotBookingId)
                .HasName ("fk_SHIPMENT_DETAIL_stock_idx");

            builder.HasIndex (e => e.ShipmentId)
                .HasName ("fk_SHIPMENT_DETAIL_1_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.BookedQuantity).HasColumnName ("booked_quantity");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.LotBookingId).HasColumnName ("LOT_BOOKING_ID");

            builder.Property (e => e.PickedQuantity)
                .HasColumnName ("picked_quantity")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.ShipmentId).HasColumnName ("SHIPMENT_ID");

            builder.HasOne (d => d.LotBooking)
                .WithMany (p => p.ShipmentDetail)
                .HasForeignKey (d => d.LotBookingId)
                .HasConstraintName ("fk_SHIPMENT_DETAIL_stock");

            builder.HasOne (d => d.Shipment)
                .WithMany (p => p.ShipmentDetail)
                .HasForeignKey (d => d.ShipmentId)
                .HasConstraintName ("fk_SHIPMENT_DETAIL_shipment");
        }
    }
}