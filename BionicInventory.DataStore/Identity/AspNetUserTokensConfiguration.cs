/*
 * @CreateTime: Jan 24, 2019 8:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Jan 24, 2019 8:33 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Identity {
    public class AspNetUserTokensConfiguration : IEntityTypeConfiguration<AspNetUserTokens> {
        public void Configure (EntityTypeBuilder<AspNetUserTokens> builder) {


            builder.HasKey (e => new { e.UserId, e.LoginProvider, e.Name });

            builder.Property (e => e.UserId).HasColumnType ("varchar(255)");

            builder.Property (e => e.LoginProvider).HasColumnType ("varchar(255)");

            builder.Property (e => e.Name).HasColumnType ("varchar(255)");

            builder.Property (e => e.Value).HasColumnType ("longtext");

            builder.HasOne (d => d.User)
                .WithMany (p => p.AspNetUserTokens)
                .HasForeignKey (d => d.UserId);
        }
    }
}