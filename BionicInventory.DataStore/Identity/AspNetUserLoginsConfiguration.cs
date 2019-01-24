/*
 * @CreateTime: Jan 24, 2019 8:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 24, 2019 8:28 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Identity {
    public class AspNetUserLoginsConfiguration : IEntityTypeConfiguration<AspNetUserLogins> {
        public void Configure (EntityTypeBuilder<AspNetUserLogins> builder) {
            builder.ToTable ("AspNetUserLogins");
            builder.HasKey (e => new { e.LoginProvider, e.ProviderKey });

            builder.HasIndex (e => e.UserId);

            builder.Property (e => e.LoginProvider).HasColumnType ("varchar(255)");

            builder.Property (e => e.ProviderKey).HasColumnType ("varchar(255)");

            builder.Property (e => e.ProviderDisplayName).HasColumnType ("longtext");

            builder.Property (e => e.UserId)
                .IsRequired ()
                .HasColumnType ("varchar(255)");

            builder.HasOne (d => d.User)
                .WithMany (p => p.AspNetUserLogins)
                .HasForeignKey (d => d.UserId);
        }
    }
}