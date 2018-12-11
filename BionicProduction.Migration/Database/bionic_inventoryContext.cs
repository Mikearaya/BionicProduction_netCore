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
        public virtual DbSet<Bom> Bom { get; set; }
        public virtual DbSet<BomItems> BomItems { get; set; }
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
        public virtual DbSet<PhoneNumber> PhoneNumber { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<ProductionOrderList> ProductionOrderList { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public virtual DbSet<Routing> Routing { get; set; }
        public virtual DbSet<RoutingDetail> RoutingDetail { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<ShipmentDetail> ShipmentDetail { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<UnitOfMeasurment> UnitOfMeasurment { get; set; }
        public virtual DbSet<Workstation> Workstation { get; set; }
        public virtual DbSet<WorkstationGroup> WorkstationGroup { get; set; }

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BOM_ITEMS_uom");
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

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("text");

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

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("fk_ITEM_group");

                entity.HasOne(d => d.PrimaryUom)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.PrimaryUomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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

                entity.HasOne(d => d.PurchaseOrder)
                    .WithOne(p => p.ProductionOrderList)
                    .HasForeignKey<ProductionOrderList>(d => d.PurchaseOrderId)
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
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

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

            modelBuilder.Entity<Routing>(entity =>
            {
                entity.ToTable("ROUTING");

                entity.HasIndex(e => e.BomId)
                    .HasName("fk_ROUTING_bom_idx");

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

                entity.Property(e => e.FixedCost).HasColumnName("fixed_cost");

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

                entity.HasOne(d => d.Bom)
                    .WithMany(p => p.Routing)
                    .HasForeignKey(d => d.BomId)
                    .HasConstraintName("fk_ROUTING_bom");
            });

            modelBuilder.Entity<RoutingDetail>(entity =>
            {
                entity.ToTable("ROUTING_DETAIL");

                entity.HasIndex(e => e.RoutingId)
                    .HasName("fk_ROUTING_DETAIL_routing_idx");

                entity.HasIndex(e => e.WorkerId)
                    .HasName("fk_ROUTING_DETAIL_worker_idx");

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

                entity.Property(e => e.WorkerId).HasColumnName("WORKER_ID");

                entity.Property(e => e.WorkstationId).HasColumnName("WORKSTATION_ID");

                entity.HasOne(d => d.Routing)
                    .WithMany(p => p.RoutingDetail)
                    .HasForeignKey(d => d.RoutingId)
                    .HasConstraintName("fk_ROUTING_DETAIL_routing");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.RoutingDetail)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_ROUTING_DETAIL_worker");

                entity.HasOne(d => d.Workstation)
                    .WithMany(p => p.RoutingDetail)
                    .HasForeignKey(d => d.WorkstationId)
                    .HasConstraintName("fk_ROUTING_DETAIL_workstation");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("SHIPMENT");

                entity.HasIndex(e => e.BookedBy)
                    .HasName("fk_SALE_store_keeper_idx");

                entity.HasIndex(e => e.CustomerOrderId)
                    .HasName("fk_SHIPMENT_CO_ID_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookedBy).HasColumnName("BOOKED_BY");

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

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShipmentNote)
                    .HasColumnName("shipment_note")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.BookedByNavigation)
                    .WithMany(p => p.Shipment)
                    .HasForeignKey(d => d.BookedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SHIPMENT_BOOKER");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.Shipment)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SHIPMENT_CO_ID");
            });

            modelBuilder.Entity<ShipmentDetail>(entity =>
            {
                entity.ToTable("SHIPMENT_DETAIL");

                entity.HasIndex(e => e.OrderItemId)
                    .HasName("fk_SHIPMENT_DETAIL_order_item_idx");

                entity.HasIndex(e => e.ShipmentId)
                    .HasName("fk_SHIPMENT_DETAIL_1_idx");

                entity.HasIndex(e => e.StockId)
                    .HasName("STOCK_ID_UNIQUE")
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

                entity.Property(e => e.OrderItemId).HasColumnName("ORDER_ITEM_ID");

                entity.Property(e => e.Picked)
                    .HasColumnName("picked")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ShipmentId).HasColumnName("SHIPMENT_ID");

                entity.Property(e => e.StockId).HasColumnName("STOCK_ID");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.ShipmentDetail)
                    .HasForeignKey(d => d.OrderItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SHIPMENT_DETAIL_order_item");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentDetail)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("fk_SHIPMENT_DETAIL_shipment");

                entity.HasOne(d => d.Stock)
                    .WithOne(p => p.ShipmentDetail)
                    .HasForeignKey<ShipmentDetail>(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SHIPMENT_DETAIL_stock");
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

                entity.Property(e => e.CustomHolidays)
                    .HasColumnName("custom_holidays")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CustomeWorkingHoures)
                    .HasColumnName("custome_working_houres")
                    .HasColumnType("tinyint(4)")
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

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.HourlyRate).HasColumnName("hourly_rate");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MaintenanceItems).HasColumnName("maintenance_items");

                entity.Property(e => e.Productivity)
                    .HasColumnName("productivity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(45)");

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
        }
    }
}
