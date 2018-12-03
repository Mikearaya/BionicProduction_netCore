/*
 * @CreateTime: Dec 3, 2018 8:46 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 3, 2018 8:49 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.UnitOfMeasurments;
using Microsoft.EntityFrameworkCore;

namespace BionicInventory.DataStore.UnitOfMeasurments {
    public class UnitOfMeasurmentsConfigurations : IEntityTypeConfiguration<UnitOfMeasurment> {
        public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UnitOfMeasurment> builder) {
            builder.ToTable ("UNIT_OF_MEASURMENT");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Abrivation)
                .IsRequired ()
                .HasColumnName ("abrivation")
                .HasColumnType ("varchar(10)");

            
            builder.Property (e => e.Active)
                .IsRequired ()
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)");

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
        }
    }
}