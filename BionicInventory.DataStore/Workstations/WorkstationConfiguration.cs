/*
 * @CreateTime: Dec 9, 2018 10:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 9, 2018 10:58 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Workstations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Workstations {
    public class WorkstationConfiguration : IEntityTypeConfiguration<Workstation> {
        public void Configure (EntityTypeBuilder<Workstation> builder) {

            builder.ToTable ("WORKSTATION");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Color)
                .HasColumnName ("color")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'blue'");

            builder.Property (e => e.CustomHolidays)
                .HasColumnName ("custom_holidays")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.CustomeWorkingHoures)
                .HasColumnName ("custome_working_houres")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.IsActive)
                .HasColumnName ("is_active")
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

            builder.Property (e => e.HourlyRate).HasColumnName ("hourly_rate");

            builder.Property (e => e.Title)
                .IsRequired ()
                .HasColumnName ("title")
                .HasColumnType ("varchar(45)");
        }
    }
}