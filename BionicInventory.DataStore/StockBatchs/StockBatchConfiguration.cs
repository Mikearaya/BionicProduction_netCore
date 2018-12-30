/*
 * @CreateTime: Dec 23, 2018 10:18 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 10:02 PM
 * @Description: Modify Here, Please 
 */
using BionicProduction.Domain.StockBatchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.StockBatchs {
    public class StockBatchConfiguration : IEntityTypeConfiguration<StockBatch> {
        public void Configure (EntityTypeBuilder<StockBatch> builder) {
            builder.ToTable ("STOCK_BATCH");

            builder.HasIndex (e => e.ItemId)
                .HasName ("fk_STOCK_BATCH_item_idx");

            builder.HasIndex (e => e.ManufactureOrderId)
                .HasName ("fk_STOCK_BATCH_manufacture_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.ArrivalDate)
                .HasColumnName ("arrival_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.AvailableFrom)
                .HasColumnName ("available_from")
                .HasColumnType ("datetime");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Source)
                .HasColumnName ("source")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.ExpiryDate)
                .HasColumnName ("expiry_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.ItemId).HasColumnName ("ITEM_ID");

            builder.Property (e => e.ManufactureOrderId).HasColumnName ("MANUFACTURE_ORDER_ID");

            builder.Property (e => e.PurchaseOrderId).HasColumnName ("PURCHASE_ORDER_ID");

            builder.Property (e => e.Quantity).HasColumnName ("quantity");

            builder.Property (e => e.Status)
                .HasColumnName ("status")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.UnitCost).HasColumnName ("unit_cost");

            builder.HasOne (d => d.Item)
                .WithMany (p => p.StockBatch)
                .HasForeignKey (d => d.ItemId)
                .HasConstraintName ("fk_STOCK_BATCH_item");

            builder.HasOne (d => d.ManufactureOrder)
                .WithMany (p => p.StockBatch)
                .HasForeignKey (d => d.ManufactureOrderId)
                .OnDelete (DeleteBehavior.Cascade)
                .HasConstraintName ("fk_STOCK_BATCH_manufacture");
        }
    }
}