/*
 * @CreateTime: Jan 24, 2019 8:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 24, 2019 8:21 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Identity {
    public class AspNetUserConfiguration : IEntityTypeConfiguration<ApplicationUser> {
        public void Configure (EntityTypeBuilder<ApplicationUser> builder) {

            builder.HasIndex (e => e.NormalizedEmail)
                .HasName ("EmailIndex");

            builder.HasIndex (e => e.NormalizedUserName)
                .HasName ("UserNameIndex")
                .IsUnique ();

            builder.Property (e => e.Id).HasColumnType ("varchar(255)");

            builder.Property (e => e.AccessFailedCount).HasColumnType ("int(11)");

            builder.Property (e => e.ConcurrencyStamp).HasColumnType ("longtext");

            builder.Property (e => e.Email).HasColumnType ("varchar(256)");

            builder.Property (e => e.EmailConfirmed).HasColumnType ("bit(1)");

            builder.Property (e => e.LockoutEnabled).HasColumnType ("bit(1)");

            builder.Property (e => e.NormalizedEmail).HasColumnType ("varchar(256)");

            builder.Property (e => e.NormalizedUserName).HasColumnType ("varchar(256)");

            builder.Property (e => e.PasswordHash).HasColumnType ("longtext");

            builder.Property (e => e.PhoneNumber).HasColumnType ("longtext");

            builder.Property (e => e.PhoneNumberConfirmed).HasColumnType ("bit(1)");

            builder.Property (e => e.SecurityStamp).HasColumnType ("longtext");

            builder.Property (e => e.TwoFactorEnabled).HasColumnType ("bit(1)");

            builder.Property (e => e.UserName).HasColumnType ("varchar(256)");
        }
    }
}