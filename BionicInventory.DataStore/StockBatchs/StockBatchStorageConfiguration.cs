/*
 * @CreateTime: Dec 23, 2018 10:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:42 PM
 * @Description: Modify Here, Please 
 */
using BionicProduction.Domain.StockBatchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.StockBatchs {
    public class StockBatchStorageConfiguration : IEntityTypeConfiguration<StockBatchStorage> {
        public void Configure (EntityTypeBuilder<StockBatchStorage> builder) {
            builder.ToTable ("STOCK_BATCH_STORAGE");

            builder.HasIndex (e => e.BachId)
                .HasName ("fk_STOCK_BACH_STORAGE_bach_idx");

            builder.HasIndex (e => e.PreviousStorage)
                .HasName ("fk_STOCK_BACH_STORAGE_previous_idx");

            builder.HasIndex (e => e.StorageId)
                .HasName ("fk_STOCK_BACH_STORAGE_storage_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.BachId).HasColumnName ("BACH_ID");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.PreviousStorage).HasColumnName ("PREVIOUS_STORAGE");

            builder.Property (e => e.Quantity).HasColumnName ("quantity");

            builder.Property (e => e.StorageId).HasColumnName ("STORAGE_ID");

            builder.HasOne (d => d.Bach)
                .WithMany (p => p.StockBatchStorage)
                .HasForeignKey (d => d.BachId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_STOCK_BACH_STORAGE_bach");

            builder.HasOne (d => d.Storage)
                .WithMany (p => p.StockBatchStorage)
                .HasForeignKey (d => d.StorageId)
                .HasConstraintName ("fk_STOCK_BACH_STORAGE_storage");
        }
    }
}