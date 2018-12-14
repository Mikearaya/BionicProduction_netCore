/*
 * @CreateTime: Dec 9, 2018 10:58 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 15, 2018 1:50 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Workstations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Workstations {
    public class WorkstationConfiguration : IEntityTypeConfiguration<Workstation> {
        public void Configure (EntityTypeBuilder<Workstation> builder) {
            builder.ToTable ("WORKSTATION");

            builder.HasIndex (e => e.GroupId)
                .HasName ("fk_WORKSTATION_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Color)
                .HasColumnName ("color")
                .HasColumnType ("varchar(45)")
                .HasDefaultValueSql ("'blue'");

            builder.Property (e => e.HolidayHours)
                .HasColumnName ("holiday_hours")
                .HasColumnType ("double");

            builder.Property (e => e.WorkingHours)
                .HasColumnName ("working_hours")
                .HasColumnType ("double");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.GroupId).HasColumnName ("GROUP_ID");

            builder.Property (e => e.HourlyRate).HasColumnName ("hourly_rate");

            builder.Property (e => e.IsActive)
                .HasColumnName ("is_active")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'1'");

            builder.Property (e => e.MaintenanceItems).HasColumnName ("maintenance_items");

            builder.Property (e => e.Productivity)
                .HasColumnName ("productivity")
                .HasDefaultValueSql ("'1'");

            builder.Property (e => e.Title)
                .IsRequired ()
                .HasColumnName ("title")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.MaintenanceHours)
                .HasColumnName ("maintenance_hours")
                .HasColumnType ("float");

            builder.HasOne (d => d.Group)
                .WithMany (p => p.Workstation)
                .HasForeignKey (d => d.GroupId)
                .HasConstraintName ("fk_WORKSTATION_group");
        }
    }
}