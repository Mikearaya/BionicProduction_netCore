/*
 * @CreateTime: Dec 23, 2018 10:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 23, 2018 10:40 PM
 * @Description: Modify Here, Please 
 */
using BionicProduction.Domain.WriteOffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.WriteOffs {
    public class WriteOffConfiguration : IEntityTypeConfiguration<WriteOff> {
        public void Configure (EntityTypeBuilder<WriteOff> builder) {
            builder.ToTable ("WRITE_OFF");

            builder.HasIndex (e => e.ItemId)
                .HasName ("fk_WRITE_OFF_item_idx");

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

            builder.Property (e => e.Note)
                .HasColumnName ("note")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Status)
                .HasColumnName ("status")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Type)
                .HasColumnName ("type")
                .HasColumnType ("varchar(45)");

            builder.HasOne (d => d.Item)
                .WithMany (p => p.WriteOff)
                .HasForeignKey (d => d.ItemId)
                .HasConstraintName ("fk_WRITE_OFF_item");
        }
    }
}