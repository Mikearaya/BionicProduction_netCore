/*
 * @CreateTime: Dec 13, 2018 12:12 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 13, 2018 12:14 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Storages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.StorageLocations {
    public class StorageLocationConfiguration : IEntityTypeConfiguration<StorageLocation> {
        public void Configure (EntityTypeBuilder<StorageLocation> builder) {

            builder.ToTable ("STORAGE_LOCATION");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'1'");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Note)
                .HasColumnName ("note")
                .HasColumnType ("varchar(255)");
        }
    }
}