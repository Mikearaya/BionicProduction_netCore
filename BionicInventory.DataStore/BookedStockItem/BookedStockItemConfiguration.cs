/*
 * @CreateTime: Oct 22, 2018 11:06 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 22, 2018 11:06 PM
 * @Description: Modify Here, Please 
 */

using BionicInventory.Domain.BookedStockItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BionicInventory.DataStore.BookedStockItem {
    public class BookedStockItemConfiguration : IEntityTypeConfiguration<BookedStockItems>
    {
        public void Configure(EntityTypeBuilder<BookedStockItems> builder)
        {
                builder.ToTable("BOOKED_STOCK_ITEMS");

                builder.HasIndex(e => e.BookedBy)
                    .HasName("fk_BOOKED_STOCK_BOOKED_BY_idx");

                builder.HasIndex(e => e.BookedFor)
                    .HasName("fk_BOOKED_STOCK_ITEM_FOR_idx");

                builder.HasIndex(e => e.StockId)
                    .HasName("STOCK_ID_UNIQUE")
                    .IsUnique();

                builder.Property(e => e.Id).HasColumnName("ID");

                builder.Property(e => e.BookedBy).HasColumnName("BOOKED_BY");

                builder.Property(e => e.BookedFor).HasColumnName("BOOKED_FOR");

                builder.Property(e => e.Canceled)
                    .HasColumnName("canceled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                builder.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                builder.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                builder.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                builder.Property(e => e.StockId).HasColumnName("STOCK_ID");

                builder.HasOne(d => d.BookedByNavigation)
                    .WithMany(p => p.BookedStockItems)
                    .HasForeignKey(d => d.BookedBy)
                    .HasConstraintName("fk_BOOKED_STOCK_BOOKED_BY");

                builder.HasOne(d => d.BookedForNavigation)
                    .WithMany(p => p.BookedStockItems)
                    .HasForeignKey(d => d.BookedFor)
                    .HasConstraintName("fk_BOOKED_STOCK_ITEM_FOR");

                builder.HasOne(d => d.Stock)
                    .WithOne(p => p.BookedStockItems)
                    .HasForeignKey<BookedStockItems>(d => d.StockId)
                    .HasConstraintName("fk_BOOKED_STOCK_ITEM_ID");
        }
    }
}