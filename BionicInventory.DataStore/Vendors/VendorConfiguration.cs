/*
 * @CreateTime: Dec 23, 2018 9:43 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 29, 2018 9:54 PM
 * @Description: Modify Here, Please 
 */
using BionicInventory.Domain.Procurment.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.Vendors {
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor> {
        public void Configure (EntityTypeBuilder<Vendor> builder) {
            builder.ToTable ("VENDOR");

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

            builder.Property (e => e.LeadTime)
                .HasColumnName ("lead_time")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(70)");

            builder.Property (e => e.PaymentPeriod)
                .HasColumnName ("payment_period")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.PhoneNumber)
                .HasColumnName ("phone_number")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.TinNumber)
                .HasColumnName ("tin_number")
                .HasColumnType ("varchar(10)");
        }
    }
}