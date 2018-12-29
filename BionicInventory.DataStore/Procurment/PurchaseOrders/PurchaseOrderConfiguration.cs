using BionicInventory.Domain.Procurment.PurchaseOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Procurment.PurchaseOrders {
    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder> {
        public void Configure (EntityTypeBuilder<PurchaseOrder> builder) {
            builder.ToTable ("PURCHASE_ORDER");

            builder.HasIndex (e => e.VendorId)
                .HasName ("fk_PURCHASE_ORDER_vendor_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.AdditionalFee)
                .HasColumnName ("additional_fee")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Discount).HasColumnName ("discount");

            builder.Property (e => e.ExpectedDate)
                .HasColumnName ("expected_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.InvoiceDate)
                .HasColumnName ("invoice_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.InvoiceId)
                .HasColumnName ("invoice_id")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.OrderId)
                .HasColumnName ("order_id")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.OrderedDate)
                .HasColumnName ("ordered_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.PaymentDate)
                .HasColumnName ("payment_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.ShippedDate)
                .HasColumnName ("shipped_date")
                .HasColumnType ("datetime");

            builder.Property (e => e.Status)
                .IsRequired ()
                .HasColumnName ("status")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Tax)
                .HasColumnName ("tax")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.VendorId).HasColumnName ("VENDOR_ID");

            builder.HasOne (d => d.Vendor)
                .WithMany (p => p.PurchaseOrder)
                .HasForeignKey (d => d.VendorId)
                .HasConstraintName ("fk_PURCHASE_ORDER_vendor");
        }
    }
}