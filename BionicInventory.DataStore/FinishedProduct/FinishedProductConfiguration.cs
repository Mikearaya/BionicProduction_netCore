using System;
using System.Collections.Generic;
using System.Linq;
using BionicInventory.Domain.FinishedProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.FinishedProducts {
    public class FinishedProductConfiguration
        : IEntityTypeConfiguration<FinishedProduct> {

            public void Configure (EntityTypeBuilder<FinishedProduct> builder) {
                builder.ToTable ("FINISHED_PRODUCT");
                builder.HasIndex (e => e.OrderId)
                    .HasName ("fk_FINISHED_ORDER_id_idx");

                builder.HasIndex (e => e.RecievedBy)
                    .HasName ("fk_FINISHED_PRODUCT_recieved_by_idx");

                builder.HasIndex (e => e.SubmittedBy)
                    .HasName ("fk_FINISHED_PRODUCT_submitter_idx");

                builder.Property (e => e.Id).HasColumnName ("ID");

                builder.Property (e => e.DateAdded)
                    .HasColumnName ("date_added")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

                builder.Property (e => e.DateUpdated)
                    .HasColumnName ("date_updated")
                    .HasColumnType ("datetime")
                    .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate ();

                builder.Property (e => e.OrderId).HasColumnName ("ORDER_ID");

                builder.Property (e => e.Quantity)
                    .HasColumnName ("quantity")
                    .HasColumnType ("int(11)");

                builder.Property (e => e.RecievedBy).HasColumnName ("recieved_by");

                builder.Property (e => e.SubmittedBy).HasColumnName ("submitted_by");

                builder.HasOne (d => d.Order)
                    .WithMany (p => p.FinishedProduct)
                    .HasForeignKey (d => d.OrderId)
                    .HasConstraintName ("fk_FINISHED_ORDER_id");

                builder.HasOne (d => d.RecievedByNavigation)
                    .WithMany (p => p.FinishedProductRecievedByNavigation)
                    .HasForeignKey (d => d.RecievedBy)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_FINISHED_PRODUCT_recieved_by");

                builder.HasOne (d => d.SubmittedByNavigation)
                    .WithMany (p => p.FinishedProductSubmittedByNavigation)
                    .HasForeignKey (d => d.SubmittedBy)
                    .OnDelete (DeleteBehavior.ClientSetNull)
                    .HasConstraintName ("fk_FINISHED_PRODUCT_submitter");
            }
        }

}