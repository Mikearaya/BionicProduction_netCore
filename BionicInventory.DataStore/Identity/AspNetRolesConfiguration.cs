/*
 * @CreateTime: Jan 24, 2019 8:24 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 24, 2019 8:25 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Identity {
    public class AspNetRolesConfiguration : IEntityTypeConfiguration<ApplicationRole> {
        public void Configure (EntityTypeBuilder<ApplicationRole> builder) {

            builder.HasIndex (e => e.NormalizedName)
                .HasName ("RoleNameIndex")
                .IsUnique ();
            builder.Property (e => e.Access).HasColumnType ("text");
            builder.Property (e => e.Id).HasColumnType ("varchar(255)");

            builder.Property (e => e.ConcurrencyStamp).HasColumnType ("longtext");

            builder.Property (e => e.Name).HasColumnType ("varchar(256)");

            builder.Property (e => e.NormalizedName).HasColumnType ("varchar(256)");
        }
    }
}