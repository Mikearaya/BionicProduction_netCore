/*
 * @CreateTime: Jan 24, 2019 8:29 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 24, 2019 8:30 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Identity {
    public class AspNetUserRolesConfiguration : IEntityTypeConfiguration<AspNetUserRoles> {
        public void Configure (EntityTypeBuilder<AspNetUserRoles> builder) {
    
            builder.HasKey (e => new { e.UserId, e.RoleId });

            builder.HasIndex (e => e.RoleId);

            builder.Property (e => e.UserId).HasColumnType ("varchar(255)");

            builder.Property (e => e.RoleId).HasColumnType ("varchar(255)");

            builder.HasOne (d => d.Role)
                .WithMany (p => p.AspNetUserRoles)
                .HasForeignKey (d => d.RoleId);

            builder.HasOne (d => d.User)
                .WithMany (p => p.AspNetUserRoles)
                .HasForeignKey (d => d.UserId);
        }
    }
}