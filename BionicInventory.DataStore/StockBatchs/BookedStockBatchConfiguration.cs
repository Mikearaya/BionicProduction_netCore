/*
 * @CreateTime: Dec 23, 2018 10:28 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:29 PM
 * @Description: Modify Here, Please 
 */
using BionicProduction.Domain.StockBatchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.StockBatchs {
    public class BookedStockBatchConfiguration : IEntityTypeConfiguration<BookedStockBatch> {
        public void Configure (EntityTypeBuilder<BookedStockBatch> builder) {
            builder.ToTable ("BOOKED_STOCK_BATCH");

            builder.HasIndex (e => e.CustomerOrderId)
                .HasName ("fk_BOOKED_STOCK_BATCH_customer_or_idx");

            builder.HasIndex (e => e.ProductionOrderId)
                .HasName ("fk_BOOKED_STOCK_BATCH_production_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.BachStorageId).HasColumnName ("BACH_STORAGE_ID");

            builder.Property (e => e.CustomerOrderId).HasColumnName ("CUSTOMER_ORDER_ID");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.ProductionOrderId).HasColumnName ("PRODUCTION_ORDER_ID");

            builder.Property (e => e.Quantity).HasColumnName ("quantity");

            builder.HasOne (d => d.CustomerOrder)
                .WithMany (p => p.BookedStockBatch)
                .HasForeignKey (d => d.CustomerOrderId)
                .OnDelete (DeleteBehavior.Cascade)
                .HasConstraintName ("fk_BOOKED_STOCK_BATCH_customer_or");

            builder.HasOne (d => d.ProductionOrder)
                .WithMany (p => p.BookedStockBatch)
                .HasForeignKey (d => d.ProductionOrderId)
                .OnDelete (DeleteBehavior.Cascade)
                .HasConstraintName ("fk_BOOKED_STOCK_BATCH_production");
        }
    }
}