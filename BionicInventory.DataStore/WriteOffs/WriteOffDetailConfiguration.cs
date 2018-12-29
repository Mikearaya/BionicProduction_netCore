/*
 * @CreateTime: Dec 23, 2018 10:12 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 10:06 PM
 * @Description: Modify Here, Please 
 */
using BionicProduction.Domain.WriteOffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.WriteOffs {
    public class WriteOffDetailConfiguration : IEntityTypeConfiguration<WriteOffDetail> {
        public void Configure (EntityTypeBuilder<WriteOffDetail> builder) {
            builder.ToTable ("WRITE_OFF_DETAIL");

            builder.HasIndex (e => e.BatchStorageId)
                .HasName ("fk_WRITE_OFF_DETAIL_bach_id_idx");

            builder.HasIndex (e => e.WriteOffId)
                .HasName ("fk_WRITE_OFF_DETAIL_write_off_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.BatchStorageId).HasColumnName ("BATCH_STORAGE_ID");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Quantity).HasColumnName ("quantity");

            builder.Property (e => e.WriteOffId).HasColumnName ("WRITE_OFF_ID");

            builder.HasOne (d => d.BatchStorage)
                .WithMany (p => p.WriteOffDetail)
                .HasForeignKey (d => d.BatchStorageId)
                .HasConstraintName ("fk_WRITE_OFF_DETAIL_bach_id");

            builder.HasOne (d => d.WriteOff)
                .WithMany (p => p.WriteOffDetail)
                .HasForeignKey (d => d.WriteOffId)
                .HasConstraintName ("fk_WRITE_OFF_DETAIL_write_off");
        }
    }
}