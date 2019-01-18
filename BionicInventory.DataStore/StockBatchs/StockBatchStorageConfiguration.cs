/*
 * @CreateTime: Dec 23, 2018 10:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 10:04 PM
 * @Description: Modify Here, Please 
 */
using BionicProduction.Domain.StockBatchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.StockBatchs {
    public class StockBatchStorageConfiguration : IEntityTypeConfiguration<StockBatchStorage> {
        public void Configure (EntityTypeBuilder<StockBatchStorage> builder) {
            builder.ToTable ("STOCK_BATCH_STORAGE");

            builder.HasIndex (e => e.BatchId)
                .HasName ("fk_STOCK_BATCH_STORAGE_bach_idx");

            builder.HasIndex (e => e.PreviousStorageId)
                .HasName ("fk_STOCK_BATCH_STORAGE_parent_idx");

            builder.HasIndex (e => e.StorageId)
                .HasName ("fk_STOCK_BATCH_STORAGE_storage_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.BatchId).HasColumnName ("BATCH_ID");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.PreviousStorageId).HasColumnName ("PREVIOUS_STORAGE_ID");

            builder.Property (e => e.Quantity).HasColumnName ("quantity");

            builder.Property (e => e.StorageId).HasColumnName ("STORAGE_ID");

            builder.HasOne (d => d.Batch)
                .WithMany (p => p.StockBatchStorage)
                .HasForeignKey (d => d.BatchId)
                .HasConstraintName ("fk_STOCK_BATCH_STORAGE_bach");

            builder.HasOne (d => d.PreviousStorage)
                .WithMany (p => p.PreviousStorageNavigation)
                .HasForeignKey (d => d.PreviousStorageId)
                .OnDelete (DeleteBehavior.Cascade)
                .HasConstraintName ("fk_STOCK_BATCH_STORAGE_parent");

            builder.HasOne (d => d.Storage)
                .WithMany (p => p.StockBatchStorage)
                .HasForeignKey (d => d.StorageId)
                .HasConstraintName ("fk_STOCK_BATCH_STORAGE_storage");
        }
    }
}