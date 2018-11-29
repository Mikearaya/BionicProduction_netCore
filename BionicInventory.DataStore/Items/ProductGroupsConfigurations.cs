/*
 * @CreateTime: Nov 29, 2018 11:39 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 29, 2018 2:37 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Items {
    public class ProductGroupsConfigurations : IEntityTypeConfiguration<ProductGroup> {
        public void Configure (EntityTypeBuilder<ProductGroup> builder) {
            builder.ToTable ("PRODUCT_GROUP");

            builder.HasIndex (e => e.ParentGroup)
                .HasName ("fk_PRODUCT_GROUP_parent_idx");

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

            builder.Property (e => e.Description)
                .HasColumnName ("description")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.GroupName)
                .IsRequired ()
                .HasColumnName ("group_name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.ParentGroup).HasColumnName ("parent_group");

            builder.HasOne (d => d.ParentGroupNavigation)
                .WithMany (p => p.InverseParentGroupNavigation)
                .HasForeignKey (d => d.ParentGroup)
                .OnDelete (DeleteBehavior.Cascade)
                .HasConstraintName ("fk_PRODUCT_GROUP_parent");
        }
    }
}