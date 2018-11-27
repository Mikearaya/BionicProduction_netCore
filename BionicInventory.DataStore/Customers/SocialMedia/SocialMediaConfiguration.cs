/*
 * @CreateTime: Nov 27, 2018 3:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 27, 2018 4:28 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Customers.SocialMedias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Customers.SocialMedias {
    public class SocialMediaConfiguration
        : IEntityTypeConfiguration<SocialMedia> {
            public void Configure (EntityTypeBuilder<SocialMedia> builder) {
                builder.ToTable ("SOCIAL_MEDIA");

                builder.HasIndex (e => e.ClientId)
                    .HasName ("fk_SOCIAL_MEDIA_customer_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.Address)
                    .IsRequired ()
                    .HasColumnName ("address")
                    .HasColumnType ("varchar(45)");

                builder.Property (e => e.ClientId).HasColumnName ("CLIENT_ID");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.Site)
                    .IsRequired ()
                    .HasColumnName ("site")
                    .HasColumnType ("varchar(45)");

                builder.HasOne (d => d.Client)
                    .WithMany (p => p.SocialMedia)
                    .HasForeignKey (d => d.ClientId)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_SOCIAL_MEDIA_customer");
            }
        }
}