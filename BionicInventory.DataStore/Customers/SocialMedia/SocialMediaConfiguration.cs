using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Customers.SocialMedias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Customers.SocialMedias
{
    public class SocialMediaConfiguration 
        : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
               builder.ToTable("SOCIAL_MEDIA");

                builder.HasIndex(e => e.ClientId)
                    .HasName("CLIENT_ID_UNIQUE")
                    .IsUnique();

                builder.Property(e => e.Id).HasColumnName("ID");

                builder.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(45)");

                builder.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                builder.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                builder.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                builder.Property(e => e.Site)
                    .IsRequired()
                    .HasColumnName("site")
                    .HasColumnType("varchar(45)");

                builder.HasOne(d => d.Client)
                    .WithOne(p => p.SocialMedia)
                    .HasForeignKey<SocialMedia>(d => d.ClientId)
                    .HasConstraintName("fk_SOCIAL_MEDIA_client");
        }
    }
}