/*
 * @CreateTime: Nov 14, 2018 10:59 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 15, 2018 7:37 PM
 * @Description: Modify Here, Please 
 */

using BionicInventory.Domain.Shipments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Shipments {
    public class ShipmentsConfiguration : IEntityTypeConfiguration<Shipment> {
        public void Configure (EntityTypeBuilder<Shipment> builder) {
            builder.ToTable ("SHIPMENT");

            builder.HasIndex (e => e.BookedBy)
                .HasName ("fk_SALE_store_keeper_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.BookedBy).HasColumnName ("BOOKED_BY");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.DeliveryAddress)
                .HasColumnName ("delivery_address")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.DeliveryDate)
                .HasColumnName ("delivery_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.PickingListNote)
                .HasColumnName ("picking_list_note")
                .HasColumnType ("varchar(100)");

            builder.Property (e => e.ShipmentNote)
                .HasColumnName ("shipment_note")
                .HasColumnType ("varchar(255)");

            builder.Property (e => e.Status)
                .IsRequired ()
                .HasColumnName ("status")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'New'");

            builder.Property (e => e.WaybillNote)
                .HasColumnName ("waybill_note")
                .HasColumnType ("varchar(100)");

        }
    }
}