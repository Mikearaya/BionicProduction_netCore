using BionicInventory.Domain.Sale;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Sale {
    public class SalesConfiguration : IEntityTypeConfiguration<Sales> {
        public void Configure (EntityTypeBuilder<Sales> builder) {
            builder.ToTable ("SALES");

            builder.HasIndex (e => e.InvoiceId)
                .HasName ("fk_SALE_ivoice_idx");

            builder.HasIndex (e => e.StockId)
                .HasName ("STOCK_ID_UNIQUE")
                .IsUnique ();

            builder.HasIndex (e => e.StoreKeeper)
                .HasName ("fk_SALE_store_keeper_idx");

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

            builder.Property (e => e.InvoiceId).HasColumnName ("INVOICE_ID");

            builder.Property (e => e.StockId).HasColumnName ("STOCK_ID");

            builder.Property (e => e.StoreKeeper).HasColumnName ("STORE_KEEPER");

            builder.HasOne (d => d.Invoice)
                .WithMany (p => p.Sale)
                .HasForeignKey (d => d.InvoiceId)
                .HasConstraintName ("fk_SALE_ivoice");

            builder.HasOne (d => d.Stock)
                .WithOne (p => p.Sale)
                .HasForeignKey<Sales> (d => d.StockId)
                .HasConstraintName ("fk_SALE_product");

            builder.HasOne (d => d.StoreKeeperNavigation)
                .WithMany (p => p.Sales)
                .HasForeignKey (d => d.StoreKeeper)
                .HasConstraintName ("fk_SALE_store_keeper");
        }
    }
}