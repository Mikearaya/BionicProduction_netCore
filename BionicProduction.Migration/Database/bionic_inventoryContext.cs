using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BionicProduction.Migration.Database
{
    public partial class bionic_inventoryContext : DbContext
    {
        public bionic_inventoryContext()
        {
        }

        public bionic_inventoryContext(DbContextOptions<bionic_inventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BookedStockItems> BookedStockItems { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<FinishedProduct> FinishedProduct { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<InvoicePayments> InvoicePayments { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemPrice> ItemPrice { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumber { get; set; }
        public virtual DbSet<ProductionOrderList> ProductionOrderList { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=bionic_inventory;port=3306;user=mikael");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_ADDRESS_client_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'Addis Ababa'");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'Ethiopia'");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.SubCity)
                    .IsRequired()
                    .HasColumnName("sub_city")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_ADDRESS_client");
            });

            modelBuilder.Entity<BookedStockItems>(entity =>
            {
                entity.ToTable("BOOKED_STOCK_ITEMS");

                entity.HasIndex(e => e.BookedBy)
                    .HasName("fk_BOOKED_STOCK_BOOKED_BY_idx");

                entity.HasIndex(e => e.BookedFor)
                    .HasName("fk_BOOKED_STOCK_ITEM_FOR_idx");

                entity.HasIndex(e => e.StockId)
                    .HasName("STOCK_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookedBy).HasColumnName("BOOKED_BY");

                entity.Property(e => e.BookedFor).HasColumnName("BOOKED_FOR");

                entity.Property(e => e.Canceled)
                    .HasColumnName("canceled")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.StockId).HasColumnName("STOCK_ID");

                entity.HasOne(d => d.BookedByNavigation)
                    .WithMany(p => p.BookedStockItems)
                    .HasForeignKey(d => d.BookedBy)
                    .HasConstraintName("fk_BOOKED_STOCK_BOOKED_BY");

                entity.HasOne(d => d.BookedForNavigation)
                    .WithMany(p => p.BookedStockItems)
                    .HasForeignKey(d => d.BookedFor)
                    .HasConstraintName("fk_BOOKED_STOCK_ITEM_FOR");

                entity.HasOne(d => d.Stock)
                    .WithOne(p => p.BookedStockItems)
                    .HasForeignKey<BookedStockItems>(d => d.StockId)
                    .HasConstraintName("fk_BOOKED_STOCK_ITEM_ID");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("COMPANY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SubCity)
                    .IsRequired()
                    .HasColumnName("sub_city")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Tin)
                    .IsRequired()
                    .HasColumnName("TIN")
                    .HasColumnType("varchar(12)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.HasIndex(e => e.Tin)
                    .HasName("TIN_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.MainPhone)
                    .IsRequired()
                    .HasColumnName("main_phone")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.Tin)
                    .HasColumnName("TIN")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<FinishedProduct>(entity =>
            {
                entity.ToTable("FINISHED_PRODUCT");

                entity.HasIndex(e => e.OrderId)
                    .HasName("fk_FINISHED_ORDER_id_idx");

                entity.HasIndex(e => e.RecievedBy)
                    .HasName("fk_FINISHED_PRODUCT_recieved_by_idx");

                entity.HasIndex(e => e.SubmittedBy)
                    .HasName("fk_FINISHED_PRODUCT_submitter_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.OrderId).HasColumnName("ORDER_ID");

                entity.Property(e => e.RecievedBy).HasColumnName("recieved_by");

                entity.Property(e => e.SubmittedBy).HasColumnName("submitted_by");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.FinishedProduct)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_FINISHED_ORDER_id");

                entity.HasOne(d => d.RecievedByNavigation)
                    .WithMany(p => p.FinishedProductRecievedByNavigation)
                    .HasForeignKey(d => d.RecievedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FINISHED_PRODUCT_recieved_by");

                entity.HasOne(d => d.SubmittedByNavigation)
                    .WithMany(p => p.FinishedProductSubmittedByNavigation)
                    .HasForeignKey(d => d.SubmittedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FINISHED_PRODUCT_submitter");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("INVOICE");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("fk_INVOICE_created_by_idx");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("PURCHASE_ORDER_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateOn)
                    .HasColumnName("create_on")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.PrintCount)
                    .HasColumnName("print_count")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PURCHASE_ORDER_ID");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_INVOICE_created_by");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithOne(p => p.Invoice)
                    .HasForeignKey<Invoice>(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_INVOICE_PO_ID");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("INVOICE_DETAIL");

                entity.HasIndex(e => e.AddedBy)
                    .HasName("fk_INVOICE_DETAIL_added_by_idx");

                entity.HasIndex(e => e.InvoiceNo)
                    .HasName("fk_INVOICE_ID_idx");

                entity.HasIndex(e => e.SalesOrderId)
                    .HasName("fk_SALE_DETAIL_INVENTORY_ID_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddedBy)
                    .HasColumnName("added_by")
                    .HasDefaultValueSql("'11'");

                entity.Property(e => e.DateAddded)
                    .HasColumnName("date_addded")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.InvoiceNo).HasColumnName("INVOICE_NO");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SalesOrderId).HasColumnName("SALES_ORDER_ID");

                entity.Property(e => e.Tax).HasColumnName("tax");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_INVOICE_DETAIL_added_by");

                entity.HasOne(d => d.InvoiceNoNavigation)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.InvoiceNo)
                    .HasConstraintName("fk_INVOICE_ID");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.SalesOrderId)
                    .HasConstraintName("fk_SALE_DETAIL_INVENTORY_ID");
            });

            modelBuilder.Entity<InvoicePayments>(entity =>
            {
                entity.ToTable("INVOICE_PAYMENTS");

                entity.HasIndex(e => e.CashierId)
                    .HasName("fk_INVOICE_PAYMENTS_cashier_idx");

                entity.HasIndex(e => e.InvoiceNo)
                    .HasName("fk_INVOICE_PAYMENTS_INVOICE_idx");

                entity.HasIndex(e => e.PreparedBy)
                    .HasName("fk_INVOICE_PAYMENTS_prepared_by_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CashierId).HasColumnName("CASHIER_ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.InvoiceNo).HasColumnName("INVOICE_NO");

                entity.Property(e => e.PreparedBy).HasColumnName("PREPARED_BY");

                entity.Property(e => e.PrintCount)
                    .HasColumnName("print_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.InvoicePaymentsCashier)
                    .HasForeignKey(d => d.CashierId)
                    .HasConstraintName("fk_INVOICE_PAYMENTS_cashier");

                entity.HasOne(d => d.InvoiceNoNavigation)
                    .WithMany(p => p.InvoicePayments)
                    .HasForeignKey(d => d.InvoiceNo)
                    .HasConstraintName("fk_INVOICE_PAYMENTS_INVOICE");

                entity.HasOne(d => d.PreparedByNavigation)
                    .WithMany(p => p.InvoicePaymentsPreparedByNavigation)
                    .HasForeignKey(d => d.PreparedBy)
                    .HasConstraintName("fk_INVOICE_PAYMENTS_prepared_by");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("ITEM");

                entity.HasIndex(e => e.Code)
                    .HasName("code_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Unit)
                    .IsRequired()
                    .HasColumnName("unit")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.UnitCost).HasColumnName("unit_cost");

                entity.Property(e => e.Weight).HasColumnName("weight");
            });

            modelBuilder.Entity<ItemPrice>(entity =>
            {
                entity.ToTable("ITEM_PRICE");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_ITEM_PRICE_item_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'ETB'");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemPrice)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_ITEM_PRICE_item");
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.ToTable("PHONE_NUMBER");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_PHONE_NUMBER_client_idx");

                entity.HasIndex(e => e.Number)
                    .HasName("number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasColumnType("varchar(13)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PhoneNumber)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_PHONE_NUMBER_client");
            });

            modelBuilder.Entity<ProductionOrderList>(entity =>
            {
                entity.ToTable("PRODUCTION_ORDER_LIST");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_IN_ORDER_LIST_item_idx");

                entity.HasIndex(e => e.OrderedBy)
                    .HasName("fk_PRODUCTION_ORDER_ordered_by_idx");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("fk_PRODUCTION_ORDER_LIST_sales_id_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostPerItem).HasColumnName("cost_per_item");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.OrderedBy).HasColumnName("ordered_by");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PURCHASE_ORDER_ID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ProductionOrderList)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_IN_ORDER_LIST_item");

                entity.HasOne(d => d.OrderedByNavigation)
                    .WithMany(p => p.ProductionOrderList)
                    .HasForeignKey(d => d.OrderedBy)
                    .HasConstraintName("fk_PRODUCTION_ORDER_ordered_by");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.ProductionOrderList)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_PRODUCTION_ORDER_LIST_sales_id");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.ToTable("PURCHASE_ORDER");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_PURCHASE_ORDER_customer_idx");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("fk_PURCHASE_ORDER_employee_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InitialPayment).HasColumnName("initial_payment");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_PURCHASE_ORDER_customer");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_PURCHASE_ORDER_employee");
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.ToTable("PURCHASE_ORDER_DETAIL");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_OUT_ORDER_LIST_item_idx");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("fk_OUT_ORDER_LIST_order_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.PricePerItem).HasColumnName("price_per_item");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PURCHASE_ORDER_ID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_OUT_ORDER_LIST_item");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderDetail)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .HasConstraintName("fk_PURCHASE_ORDER_PO_ID");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.ToTable("SALES");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("fk_SALE_ivoice_idx");

                entity.HasIndex(e => e.StockId)
                    .HasName("STOCK_ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.StoreKeeper)
                    .HasName("fk_SALE_store_keeper_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.InvoiceId).HasColumnName("INVOICE_ID");

                entity.Property(e => e.StockId).HasColumnName("STOCK_ID");

                entity.Property(e => e.StoreKeeper).HasColumnName("STORE_KEEPER");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("fk_SALE_ivoice");

                entity.HasOne(d => d.Stock)
                    .WithOne(p => p.Sales)
                    .HasForeignKey<Sales>(d => d.StockId)
                    .HasConstraintName("fk_SALE_product");

                entity.HasOne(d => d.StoreKeeperNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StoreKeeper)
                    .HasConstraintName("fk_SALE_store_keeper");
            });

            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.ToTable("SOCIAL_MEDIA");

                entity.HasIndex(e => e.ClientId)
                    .HasName("CLIENT_ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasColumnName("site")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Client)
                    .WithOne(p => p.SocialMedia)
                    .HasForeignKey<SocialMedia>(d => d.ClientId)
                    .HasConstraintName("fk_SOCIAL_MEDIA_client");
            });
        }
    }
}
