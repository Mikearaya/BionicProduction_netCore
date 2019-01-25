/*
 * @CreateTime: Jan 24, 2019 8:22 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 24, 2019 8:23 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Identity {
    public class AspNetRoleClaimsConfiguration : IEntityTypeConfiguration<AspNetRoleClaims> {
        public void Configure (EntityTypeBuilder<AspNetRoleClaims> builder) {
            builder.HasIndex (e => e.RoleId);

            builder.Property (e => e.Id).HasColumnType ("int(11)");

            builder.Property (e => e.ClaimType).HasColumnType ("longtext");

            builder.Property (e => e.ClaimValue).HasColumnType ("longtext");

            builder.Property (e => e.RoleId)
                .IsRequired ()
                .HasColumnType ("varchar(255)");

            builder.HasOne (d => d.Role)
                .WithMany (p => p.AspNetRoleClaims)
                .HasForeignKey (d => d.RoleId);
        }
    }
}