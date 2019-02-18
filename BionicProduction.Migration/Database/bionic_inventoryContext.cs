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
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Bom> Bom { get; set; }
        public virtual DbSet<BomItems> BomItems { get; set; }
        public virtual DbSet<BookedStockBatch> BookedStockBatch { get; set; }
        public virtual DbSet<BookedStockItems> BookedStockItems { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrder { get; set; }
        public virtual DbSet<CustomerOrderItem> CustomerOrderItem { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<FinishedProduct> FinishedProduct { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<InvoicePayments> InvoicePayments { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumber { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<ProductionOrderList> ProductionOrderList { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderQuotation> PurchaseOrderQuotation { get; set; }
        public virtual DbSet<Routing> Routing { get; set; }
        public virtual DbSet<RoutingBoms> RoutingBoms { get; set; }
        public virtual DbSet<RoutingOperation> RoutingOperation { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<ShipmentDetail> ShipmentDetail { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<StockBatch> StockBatch { get; set; }
        public virtual DbSet<StockBatchStorage> StockBatchStorage { get; set; }
        public virtual DbSet<StorageLocation> StorageLocation { get; set; }
        public virtual DbSet<SystemSettings> SystemSettings { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<UnitOfMeasurment> UnitOfMeasurment { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<VendorPurchaseTerm> VendorPurchaseTerm { get; set; }
        public virtual DbSet<Workstation> Workstation { get; set; }
        public virtual DbSet<WorkstationGroup> WorkstationGroup { get; set; }
        public virtual DbSet<WriteOff> WriteOff { get; set; }
        public virtual DbSet<WriteOffDetail> WriteOffDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=bionic_inventory;port=3306;user=admin;password=admin;");
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

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar(45)");

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

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.Access)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Name).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderKey).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderDisplayName).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId).HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.Value).HasColumnType("longtext");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Email).HasColumnType("varchar(256)");

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedUserName).HasColumnType("varchar(256)");

                entity.Property(e => e.PasswordHash).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumber).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.SecurityStamp).HasColumnType("longtext");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<Bom>(entity =>
            {
                entity.ToTable("BOM");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_BOM_item_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

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

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Bom)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_BOM_item");
            });

            modelBuilder.Entity<BomItems>(entity =>
            {
                entity.ToTable("BOM_ITEMS");

                entity.HasIndex(e => e.BomId)
                    .HasName("fk_BOM_ITEMS_bom_idx");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_BOM_ITEMS_item_idx");

                entity.HasIndex(e => e.UomId)
                    .HasName("fk_BOM_ITEMS_uom_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BomId).HasColumnName("BOM_ID");

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

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UomId).HasColumnName("UOM_ID");

                entity.HasOne(d => d.Bom)
                    .WithMany(p => p.BomItems)
                    .HasForeignKey(d => d.BomId)
                    .HasConstraintName("fk_BOM_ITEMS_bom");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.BomItems)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_BOM_ITEMS_item");

                entity.HasOne(d => d.Uom)
                    .WithMany(p => p.BomItems)
                    .HasForeignKey(d => d.UomId)
                    .HasConstraintName("fk_BOM_ITEMS_uom");
            });

            modelBuilder.Entity<BookedStockBatch>(entity =>
            {
                entity.ToTable("BOOKED_STOCK_BATCH");

                entity.HasIndex(e => e.BatchStorageId)
                    .HasName("fk_BOOKED_STOCK_BATCH_storage_idx");

                entity.HasIndex(e => e.CustomerOrderId)
                    .HasName("fk_BOOKED_STOCK_BATCH_customer_or_idx");

                entity.HasIndex(e => e.ProductionOrderId)
                    .HasName("fk_BOOKED_STOCK_BATCH_1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchStorageId).HasColumnName("BATCH_STORAGE_ID");

                entity.Property(e => e.ConsumedQuantity)
                    .HasColumnName("consumed_quantity")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CustomerOrderId).HasColumnName("CUSTOMER_ORDER_ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.ProductionOrderId).HasColumnName("PRODUCTION_ORDER_ID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.BatchStorage)
                    .WithMany(p => p.BookedStockBatch)
                    .HasForeignKey(d => d.BatchStorageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_BOOKED_STOCK_BATCH_bach_id");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.BookedStockBatch)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_BOOKED_STOCK_BATCH_customer_or");

                entity.HasOne(d => d.ProductionOrder)
                    .WithMany(p => p.BookedStockBatch)
                    .HasForeignKey(d => d.ProductionOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_BOOKED_STOCK_BATCH_production");
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

                entity.Property(e => e.CreditLimit)
                    .HasColumnName("credit_limit")
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

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PaymentPeriod)
                    .HasColumnName("payment_period")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PoBox)
                    .HasColumnName("po_box")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Tin)
                    .HasColumnName("TIN")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("CUSTOMER_ORDER");

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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("order_status")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'Quotation'");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CustomerOrder)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_PURCHASE_ORDER_customer");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CustomerOrder)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_PURCHASE_ORDER_employee");
            });

            modelBuilder.Entity<CustomerOrderItem>(entity =>
            {
                entity.ToTable("CUSTOMER_ORDER_ITEM");

                entity.HasIndex(e => e.CustomerOrderId)
                    .HasName("fk_OUT_ORDER_LIST_order_idx");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_OUT_ORDER_LIST_item_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerOrderId).HasColumnName("CUSTOMER_ORDER_ID");

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

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.CustomerOrderItem)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .HasConstraintName("fk_CUSTOMER_ORDER_item");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CustomerOrderItem)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_OUT_ORDER_LIST_item");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

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

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RecievedBy).HasColumnName("recieved_by");

                entity.Property(e => e.SubmittedBy).HasColumnName("submitted_by");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.FinishedProduct)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_FINISHED_ORDER_id");

                entity.HasOne(d => d.RecievedByNavigation)
                    .WithMany(p => p.FinishedProductRecievedByNavigation)
                    .HasForeignKey(d => d.RecievedBy)
                    .HasConstraintName("fk_FINISHED_PRODUCT_recieved_by");

                entity.HasOne(d => d.SubmittedByNavigation)
                    .WithMany(p => p.FinishedProductSubmittedByNavigation)
                    .HasForeignKey(d => d.SubmittedBy)
                    .HasConstraintName("fk_FINISHED_PRODUCT_submitter");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("INVOICE");

                entity.HasIndex(e => e.PreparedBy)
                    .HasName("fk_INVOICE_prepared_by_idx");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("fk_SALES_PO_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

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

                entity.Property(e => e.InvoiceType)
                    .IsRequired()
                    .HasColumnName("invoice_type")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'INVOICE'");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

                entity.Property(e => e.PaymentMethod)
                    .HasColumnName("payment_method")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.PreparedBy)
                    .HasColumnName("prepared_by")
                    .HasDefaultValueSql("'11'");

                entity.Property(e => e.PrintCount)
                    .HasColumnName("print_count")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PURCHASE_ORDER_ID");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.PreparedByNavigation)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.PreparedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_INVOICE_prepared_by");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_INVOICE_PO_ID");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("INVOICE_DETAIL");

                entity.HasIndex(e => e.InvoiceNo)
                    .HasName("fk_INVOICE_ID_idx");

                entity.HasIndex(e => e.SalesOrderId)
                    .HasName("fk_SALE_DETAIL_INVENTORY_ID_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

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

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.InvoiceNoNavigation)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.InvoiceNo)
                    .HasConstraintName("fk_INVOICE_ID");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.SalesOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_INVOICE_DETAIL_order_item");
            });

            modelBuilder.Entity<InvoicePayments>(entity =>
            {
                entity.ToTable("INVOICE_PAYMENTS");

                entity.HasIndex(e => e.CashierId)
                    .HasName("fk_INVOICE_PAYMENTS_cashier_idx");

                entity.HasIndex(e => e.InvoiceNo)
                    .HasName("fk_INVOICE_PAYMENTS_INVOICE_idx");

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

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PrintCount)
                    .HasColumnName("print_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Cashier)
                    .WithMany(p => p.InvoicePayments)
                    .HasForeignKey(d => d.CashierId)
                    .HasConstraintName("fk_INVOICE_PAYMENTS_cashier");

                entity.HasOne(d => d.InvoiceNoNavigation)
                    .WithMany(p => p.InvoicePayments)
                    .HasForeignKey(d => d.InvoiceNo)
                    .HasConstraintName("fk_INVOICE_PAYMENTS_INVOICE");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("ITEM");

                entity.HasIndex(e => e.Code)
                    .HasName("code_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.DefaultStorageId)
                    .HasName("fk_ITEM_storage_location_idx");

                entity.HasIndex(e => e.GroupId)
                    .HasName("fk_ITEM_group_idx");

                entity.HasIndex(e => e.PrimaryUomId)
                    .HasName("fk_ITEM_storing_uom_idx");

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

                entity.Property(e => e.DefaultStorageId)
                    .HasColumnName("DEFAULT_STORAGE_ID")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.GroupId)
                    .HasColumnName("GROUP_ID")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsInventory)
                    .HasColumnName("is_inventory")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.IsProcured)
                    .HasColumnName("is_procured")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MinimumQuantity)
                    .HasColumnName("minimum_quantity")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PrimaryUomId).HasColumnName("primary_UOM_ID");

                entity.Property(e => e.ShelfLife)
                    .HasColumnName("shelf_life")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UnitCost).HasColumnName("unit_cost");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.DefaultStorage)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.DefaultStorageId)
                    .HasConstraintName("fk_ITEM_storage_location");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("fk_ITEM_group");

                entity.HasOne(d => d.PrimaryUom)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.PrimaryUomId)
                    .HasConstraintName("fk_ITEM_storing_uom");
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

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'Mobile'");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.PhoneNumber)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_PHONE_NUMBER_client");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.ToTable("PRODUCT_GROUP");

                entity.HasIndex(e => e.ParentGroup)
                    .HasName("fk_PRODUCT_GROUP_parent_idx");

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

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasColumnName("group_name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ParentGroup).HasColumnName("parent_group");

                entity.HasOne(d => d.ParentGroupNavigation)
                    .WithMany(p => p.InverseParentGroupNavigation)
                    .HasForeignKey(d => d.ParentGroup)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_PRODUCT_GROUP_parent");
            });

            modelBuilder.Entity<ProductionOrderList>(entity =>
            {
                entity.ToTable("PRODUCTION_ORDER_LIST");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_IN_ORDER_LIST_item_idx");

                entity.HasIndex(e => e.OrderedBy)
                    .HasName("fk_PRODUCTION_ORDER_ordered_by_idx");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("PURCHASE_ORDER_ID_UNIQUE")
                    .IsUnique();

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
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.ToTable("PURCHASE_ORDER");

                entity.HasIndex(e => e.VendorId)
                    .HasName("fk_PURCHASE_ORDER_vendor_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdditionalFee)
                    .HasColumnName("additional_fee")
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

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ExpectedDate)
                    .HasColumnName("expected_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("invoice_id")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.OrderedDate)
                    .HasColumnName("ordered_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShippedDate)
                    .HasColumnName("shipped_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("fk_PURCHASE_ORDER_vendor");
            });

            modelBuilder.Entity<PurchaseOrderQuotation>(entity =>
            {
                entity.ToTable("PURCHASE_ORDER_QUOTATION");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_PURCHASE_ORDER_QUOTATION_item_idx");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("fk_PURCHASE_ORDER_QUOTATION_purchase_order_idx");

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

                entity.Property(e => e.ExpectedDate)
                    .HasColumnName("expected_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PURCHASE_ORDER_ID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.PurchaseOrderQuotation)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_PURCHASE_ORDER_QUOTATION_item");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderQuotation)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .HasConstraintName("fk_PURCHASE_ORDER_QUOTATION_purchase_order");
            });

            modelBuilder.Entity<Routing>(entity =>
            {
                entity.ToTable("ROUTING");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_ROUTING_item_idx");

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

                entity.Property(e => e.FixedCost).HasColumnName("fixed_cost");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.VariableCost).HasColumnName("variable_cost");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Routing)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_ROUTING_item");
            });

            modelBuilder.Entity<RoutingBoms>(entity =>
            {
                entity.ToTable("ROUTING_BOMS");

                entity.HasIndex(e => e.BomId)
                    .HasName("fk_ROUTING_BOMS_bom_idx");

                entity.HasIndex(e => e.RoutingId)
                    .HasName("fk_ROUTING_BOMS_routing_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BomId).HasColumnName("BOM_ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.RoutingId).HasColumnName("ROUTING_ID");

                entity.HasOne(d => d.Bom)
                    .WithMany(p => p.RoutingBoms)
                    .HasForeignKey(d => d.BomId)
                    .HasConstraintName("fk_ROUTING_BOMS_bom");

                entity.HasOne(d => d.Routing)
                    .WithMany(p => p.RoutingBoms)
                    .HasForeignKey(d => d.RoutingId)
                    .HasConstraintName("fk_ROUTING_BOMS_routing");
            });

            modelBuilder.Entity<RoutingOperation>(entity =>
            {
                entity.ToTable("ROUTING_OPERATION");

                entity.HasIndex(e => e.RoutingId)
                    .HasName("fk_ROUTING_DETAIL_routing_idx");

                entity.HasIndex(e => e.WorkstationId)
                    .HasName("fk_ROUTING_DETAIL_workstation_idx");

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

                entity.Property(e => e.FixedCost).HasColumnName("fixed_cost");

                entity.Property(e => e.FixedTime).HasColumnName("fixed_time");

                entity.Property(e => e.Operation)
                    .HasColumnName("operation")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RoutingId).HasColumnName("ROUTING_ID");

                entity.Property(e => e.VariableCost).HasColumnName("variable_cost");

                entity.Property(e => e.VariableTime).HasColumnName("variable_time");

                entity.Property(e => e.WorkstationId).HasColumnName("WORKSTATION_ID");

                entity.HasOne(d => d.Routing)
                    .WithMany(p => p.RoutingOperation)
                    .HasForeignKey(d => d.RoutingId)
                    .HasConstraintName("fk_ROUTING_DETAIL_routing");

                entity.HasOne(d => d.Workstation)
                    .WithMany(p => p.RoutingOperation)
                    .HasForeignKey(d => d.WorkstationId)
                    .HasConstraintName("fk_ROUTING_DETAIL_workstation");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("SHIPMENT");

                entity.HasIndex(e => e.BookedBy)
                    .HasName("fk_SALE_store_keeper_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookedBy).HasColumnName("BOOKED_BY");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.DeliveryAddress)
                    .HasColumnName("delivery_address")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PickingListNote)
                    .HasColumnName("picking_list_note")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ShipmentNote)
                    .HasColumnName("shipment_note")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'New'");

                entity.Property(e => e.WaybillNote)
                    .HasColumnName("waybill_note")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<ShipmentDetail>(entity =>
            {
                entity.ToTable("SHIPMENT_DETAIL");

                entity.HasIndex(e => e.LotBookingId)
                    .HasName("fk_SHIPMENT_DETAIL_stock_idx");

                entity.HasIndex(e => e.ShipmentId)
                    .HasName("fk_SHIPMENT_DETAIL_1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookedQuantity).HasColumnName("booked_quantity");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.LotBookingId).HasColumnName("LOT_BOOKING_ID");

                entity.Property(e => e.PickedQuantity)
                    .HasColumnName("picked_quantity")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ShipmentId).HasColumnName("SHIPMENT_ID");

                entity.HasOne(d => d.LotBooking)
                    .WithMany(p => p.ShipmentDetail)
                    .HasForeignKey(d => d.LotBookingId)
                    .HasConstraintName("fk_SHIPMENT_DETAIL_stock");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentDetail)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("fk_SHIPMENT_DETAIL_shipment");
            });

            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.ToTable("SOCIAL_MEDIA");

                entity.HasIndex(e => e.ClientId)
                    .HasName("fk_SOCIAL_MEDIA_customer_idx");

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
                    .WithMany(p => p.SocialMedia)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SOCIAL_MEDIA_customer");
            });

            modelBuilder.Entity<StockBatch>(entity =>
            {
                entity.ToTable("STOCK_BATCH");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_STOCK_BATCH_item_idx");

                entity.HasIndex(e => e.ManufactureOrderId)
                    .HasName("fk_STOCK_BATCH_manufacture_idx");

                entity.HasIndex(e => e.PurchaseOrderId)
                    .HasName("fk_STOCK_BATCH_purchase_order_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrivalDate)
                    .HasColumnName("arrival_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AvailableFrom)
                    .HasColumnName("available_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.ManufactureOrderId).HasColumnName("MANUFACTURE_ORDER_ID");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PURCHASE_ORDER_ID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.UnitCost).HasColumnName("unit_cost");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.StockBatch)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_STOCK_BATCH_item");

                entity.HasOne(d => d.ManufactureOrder)
                    .WithMany(p => p.StockBatch)
                    .HasForeignKey(d => d.ManufactureOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_STOCK_BATCH_manufacture");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.StockBatch)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_STOCK_BATCH_purchase_order");
            });

            modelBuilder.Entity<StockBatchStorage>(entity =>
            {
                entity.ToTable("STOCK_BATCH_STORAGE");

                entity.HasIndex(e => e.BatchId)
                    .HasName("fk_STOCK_BATCH_STORAGE_bach_idx");

                entity.HasIndex(e => e.PreviousStorageId)
                    .HasName("fk_STOCK_BATCH_STORAGE_parent_idx");

                entity.HasIndex(e => e.StorageId)
                    .HasName("fk_STOCK_BATCH_STORAGE_storage_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchId).HasColumnName("BATCH_ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PreviousStorageId).HasColumnName("PREVIOUS_STORAGE_ID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.StorageId).HasColumnName("STORAGE_ID");

                entity.HasOne(d => d.Batch)
                    .WithMany(p => p.StockBatchStorage)
                    .HasForeignKey(d => d.BatchId)
                    .HasConstraintName("fk_STOCK_BATCH_STORAGE_bach");

                entity.HasOne(d => d.PreviousStorage)
                    .WithMany(p => p.InversePreviousStorage)
                    .HasForeignKey(d => d.PreviousStorageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_STOCK_BATCH_STORAGE_parent");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.StockBatchStorage)
                    .HasForeignKey(d => d.StorageId)
                    .HasConstraintName("fk_STOCK_BATCH_STORAGE_storage");
            });

            modelBuilder.Entity<StorageLocation>(entity =>
            {
                entity.ToTable("STORAGE_LOCATION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<SystemSettings>(entity =>
            {
                entity.ToTable("SYSTEM_SETTINGS");

                entity.HasIndex(e => new { e.Category, e.Type, e.Value })
                    .HasName("lookup_cat_typ_val_uq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
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

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.System)
                    .HasColumnName("system")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.ToTable("tax");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abrevation)
                    .IsRequired()
                    .HasColumnName("abrevation")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Percentage).HasColumnName("percentage");
            });

            modelBuilder.Entity<UnitOfMeasurment>(entity =>
            {
                entity.ToTable("UNIT_OF_MEASURMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Abrivation)
                    .IsRequired()
                    .HasColumnName("abrivation")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("VENDOR");

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

                entity.Property(e => e.LeadTime).HasColumnName("lead_time");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(70)");

                entity.Property(e => e.PaymentPeriod).HasColumnName("payment_period");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TinNumber)
                    .HasColumnName("tin_number")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<VendorPurchaseTerm>(entity =>
            {
                entity.ToTable("VENDOR_PURCHASE_TERM");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_VENDOR_PURCHASE_TERM_item_idx");

                entity.HasIndex(e => e.VendorId)
                    .HasName("fk_VENDOR_PURCHASE_TERM_vendor_idx");

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

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.LeadTime).HasColumnName("lead_time");

                entity.Property(e => e.MinimumQuantity).HasColumnName("minimum_quantity");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorProductId)
                    .HasColumnName("vendor_product_id")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.VendorPurchaseTerm)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_VENDOR_PURCHASE_TERM_item");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.VendorPurchaseTerm)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("fk_VENDOR_PURCHASE_TERM_vendor");
            });

            modelBuilder.Entity<Workstation>(entity =>
            {
                entity.ToTable("WORKSTATION");

                entity.HasIndex(e => e.GroupId)
                    .HasName("fk_WORKSTATION_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("'blue'");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.HolidayHours)
                    .HasColumnName("holiday_hours")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.HourlyRate).HasColumnName("hourly_rate");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MaintenanceHours).HasColumnName("maintenance_hours");

                entity.Property(e => e.MaintenanceItems).HasColumnName("maintenance_items");

                entity.Property(e => e.Productivity)
                    .HasColumnName("productivity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.WorkingHours)
                    .HasColumnName("working_hours")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Workstation)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("fk_WORKSTATION_group");
            });

            modelBuilder.Entity<WorkstationGroup>(entity =>
            {
                entity.ToTable("WORKSTATION_GROUP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

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
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<WriteOff>(entity =>
            {
                entity.ToTable("WRITE_OFF");

                entity.HasIndex(e => e.ItemId)
                    .HasName("fk_WRITE_OFF_item_idx");

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

                entity.Property(e => e.ItemId).HasColumnName("ITEM_ID");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.WriteOff)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("fk_WRITE_OFF_item");
            });

            modelBuilder.Entity<WriteOffDetail>(entity =>
            {
                entity.ToTable("WRITE_OFF_DETAIL");

                entity.HasIndex(e => e.BatchStorageId)
                    .HasName("fk_WRITE_OFF_DETAIL_bach_id_idx");

                entity.HasIndex(e => e.WriteOffId)
                    .HasName("fk_WRITE_OFF_DETAIL_write_off_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BatchStorageId).HasColumnName("BATCH_STORAGE_ID");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.WriteOffId).HasColumnName("WRITE_OFF_ID");

                entity.HasOne(d => d.BatchStorage)
                    .WithMany(p => p.WriteOffDetail)
                    .HasForeignKey(d => d.BatchStorageId)
                    .HasConstraintName("fk_WRITE_OFF_DETAIL_bach_id");

                entity.HasOne(d => d.WriteOff)
                    .WithMany(p => p.WriteOffDetail)
                    .HasForeignKey(d => d.WriteOffId)
                    .HasConstraintName("fk_WRITE_OFF_DETAIL_write_off");
            });
        }
    }
}
