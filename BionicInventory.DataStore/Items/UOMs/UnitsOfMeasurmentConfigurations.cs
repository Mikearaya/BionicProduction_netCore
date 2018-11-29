/*
 * @CreateTime: Nov 29, 2018 11:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 2:37 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Items.UOMs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Items.UOMs {
    public class UnitsOfMeasurmentConfigurations : IEntityTypeConfiguration<UnitOfMeasurments> {
        public void Configure (EntityTypeBuilder<UnitOfMeasurments> builder) {
            builder.ToTable ("UNIT_OF_MEASURMENTS");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Abrivation)
                .IsRequired ()
                .HasColumnName ("abrivation")
                .HasColumnType ("varchar(10)");

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