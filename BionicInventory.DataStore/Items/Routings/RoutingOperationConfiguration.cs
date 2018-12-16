/*
 * @CreateTime: Dec 9, 2018 10:57 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 16, 2018 11:15 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Items.Rotings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Items.Routings {
    public class RoutingOperationConfiguration : IEntityTypeConfiguration<RoutingOperation> {
        public void Configure (EntityTypeBuilder<RoutingOperation> builder) {

            builder.ToTable ("ROUTING_OPERATION");

            builder.HasIndex (e => e.RoutingId)
                .HasName ("fk_ROUTING_DETAIL_routing_idx");

            builder.HasIndex (e => e.WorkstationId)
                .HasName ("fk_ROUTING_DETAIL_workstation_idx");

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

            builder.Property (e => e.FixedTime).HasColumnName ("fixed_time");

            builder.Property (e => e.Operation)
                .HasColumnName ("operation")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Quantity)
                .HasColumnName ("quantity")
                .HasColumnType ("int(11)");

            builder.Property (e => e.RoutingId).HasColumnName ("ROUTING_ID");

            builder.Property (e => e.VariableCost).HasColumnName ("variable_cost");

            builder.Property (e => e.VariableTime).HasColumnName ("variable_time");

            builder.Property (e => e.WorkstationId).HasColumnName ("WORKSTATION_ID");

            builder.HasOne (d => d.Routing)
                .WithMany (p => p.RoutingOperation)
                .HasForeignKey (d => d.RoutingId)
                .HasConstraintName ("fk_ROUTING_DETAIL_routing");

            builder.HasOne (d => d.Workstation)
                .WithMany (p => p.RoutingOperation)
                .HasForeignKey (d => d.WorkstationId)
                .HasConstraintName ("fk_ROUTING_DETAIL_workstation");
        }
    }
}