/*
 * @CreateTime: Jan 6, 2019 12:52 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 6, 2019 12:52 AM
 * @Description: Modify Here, Please 
 */
/*
 * @CreateTime: Jan 6, 2019 12:51 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 6, 2019 12:52 AM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Settings {
    public class SystemSettingsConfiguration : IEntityTypeConfiguration<SystemSettings> {
        public void Configure (EntityTypeBuilder<SystemSettings> builder) {
            builder.ToTable ("SYSTEM_SETTINGS");

            builder.HasIndex (e => new { e.Category, e.Type, e.Value })
                .HasName ("lookup_cat_typ_val_uq")
                .IsUnique ();

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Category)
                .IsRequired ()
                .HasColumnName ("category")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Description)
                .HasColumnName ("description")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.System)
                .HasColumnName ("system")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Type)
                .IsRequired ()
                .HasColumnName ("type")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Value)
                .IsRequired ()
                .HasColumnName ("value")
                .HasColumnType ("varchar(45)");
        }
    }
}