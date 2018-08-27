
using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.Customers.PhoneNumbers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Customers.PhoneNumbers
{
    public class PhoneNumberConfiguration 
    : IEntityTypeConfiguration<PhoneNumber>
    {

        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PHONE_NUMBER");

                builder.HasIndex(e => e.ClientId)
                    .HasName("fk_PHONE_NUMBER_client_idx");

                builder.HasIndex(e => e.Number)
                    .HasName("number_UNIQUE")
                    .IsUnique();

                builder.Property(e => e.Id).HasColumnName("ID");

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

                builder.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasColumnType("varchar(13)");

                builder.HasOne(d => d.Client)
                    .WithMany(p => p.PhoneNumber)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_PHONE_NUMBER_client");
        }
    }
}