/*
 * @CreateTime: Dec 16, 2018 10:48 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 10:51 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Routings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Items.Routings {
    public class RoutingBomsConfiguration : IEntityTypeConfiguration<RoutingBoms> {
        public void Configure (EntityTypeBuilder<RoutingBoms> builder) {
            builder.ToTable ("ROUTING_BOMS");

            builder.HasIndex (e => e.BomId)
                .HasName ("fk_ROUTING_BOMS_bom_idx");

            builder.HasIndex (e => e.RoutingId)
                .HasName ("fk_ROUTING_BOMS_routing_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.BomId).HasColumnName ("BOM_ID");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.RoutingId).HasColumnName ("ROUTING_ID");

            builder.HasOne (d => d.Bom)
                .WithMany (p => p.RoutingBoms)
                .HasForeignKey (d => d.BomId)
                .HasConstraintName ("fk_ROUTING_BOMS_bom");

            builder.HasOne (d => d.Routing)
                .WithMany (p => p.RoutingBoms)
                .HasForeignKey (d => d.RoutingId)
                .HasConstraintName ("fk_ROUTING_BOMS_routing");
        }
    }
}