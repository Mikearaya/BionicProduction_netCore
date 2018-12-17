/*
 * @CreateTime: Dec 9, 2018 10:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 10:50 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Items.Rotings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Items.Routings {
    public class RoutingConfiguration : IEntityTypeConfiguration<Routing> {
        public void Configure (EntityTypeBuilder<Routing> builder) {
            builder.ToTable ("ROUTING");

            builder.HasIndex (e => e.ItemId)
                .HasName ("fk_ROUTING_item_idx");

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

            builder.Property (e => e.FixedCost).HasColumnName ("fixed_cost");

            builder.Property (e => e.ItemId).HasColumnName ("ITEM_ID");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Note)
                .HasColumnName ("note")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Quantity)
                .HasColumnName ("quantity")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.VariableCost).HasColumnName ("variable_cost");

            builder.HasOne (d => d.Item)
                .WithMany (p => p.Routing)
                .HasForeignKey (d => d.ItemId)
                .HasConstraintName ("fk_ROUTING_item");
        }
    }
}