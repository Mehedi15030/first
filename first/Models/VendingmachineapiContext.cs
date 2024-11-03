using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace first.Models;

public partial class VendingmachineapiContext : DbContext
{
    public VendingmachineapiContext()
    {
    }

    public VendingmachineapiContext(DbContextOptions<VendingmachineapiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<MaintenanceLog> MaintenanceLogs { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TransactionItem> TransactionItems { get; set; }

    public virtual DbSet<Transactiontable> Transactiontables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-N5D29R5;Database=Vendingmachineapi;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__D54EE9B465A3B279");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DisplayOrder).HasColumnName("display_order");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorId).HasName("PK__ErrorLog__DA71E16C599B183F");

            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorId)
                .ValueGeneratedNever()
                .HasColumnName("error_id");
            entity.Property(e => e.ErrorCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("error_code");
            entity.Property(e => e.ErrorDescription)
                .HasColumnType("text")
                .HasColumnName("error_description");
            entity.Property(e => e.MachineId).HasColumnName("machine_id");
            entity.Property(e => e.OccurrenceDate)
                .HasColumnType("datetime")
                .HasColumnName("occurrence_date");
            entity.Property(e => e.ResolutionDate)
                .HasColumnType("datetime")
                .HasColumnName("resolution_date");
            entity.Property(e => e.ResolutionDescription)
                .HasColumnType("text")
                .HasColumnName("resolution_description");

            entity.HasOne(d => d.Machine).WithMany(p => p.ErrorLogs)
                .HasForeignKey(d => d.MachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ErrorLog__machin__5AEE82B9");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__B59ACC497E49C88C");

            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId)
                .ValueGeneratedNever()
                .HasColumnName("inventory_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.CurrentQuantity).HasColumnName("current_quantity");
            entity.Property(e => e.LastRestocked)
                .HasColumnType("datetime")
                .HasColumnName("last_restocked");
            entity.Property(e => e.MachineId).HasColumnName("machine_id");
            entity.Property(e => e.MinimumStock)
                .HasDefaultValue(5)
                .HasColumnName("minimum_stock");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SlotNumber).HasColumnName("slot_number");

            entity.HasOne(d => d.Machine).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.MachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__machi__46E78A0C");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__produ__47DBAE45");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__771831EA2BF34BA6");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("location_id");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contact_person");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contact_phone");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("district");
            entity.Property(e => e.Divison)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("divison");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("postal_code");
            entity.Property(e => e.Postoffice)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("postoffice");
            entity.Property(e => e.Upazila)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("upazila");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.MachineId).HasName("PK__Machine__7B75BEA96FCB897D");

            entity.ToTable("Machine");

            entity.HasIndex(e => e.SerialNumber, "UQ__Machine__BED14FEEC4F28912").IsUnique();

            entity.Property(e => e.MachineId)
                .ValueGeneratedNever()
                .HasColumnName("machine_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.CurrentCashBalance)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("current_cash_balance");
            entity.Property(e => e.InstallationDate).HasColumnName("installation_date");
            entity.Property(e => e.LastMaintenanceDate)
                .HasColumnType("datetime")
                .HasColumnName("last_maintenance_date");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.MaintenanceDueDate).HasColumnName("maintenance_due_date");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("serial_number");
            entity.Property(e => e.SoftwareVersion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("software_version");
            entity.Property(e => e.Temperature)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("temperature");

            entity.HasOne(d => d.Location).WithMany(p => p.Machines)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Machine__locatio__37A5467C");
        });

        modelBuilder.Entity<MaintenanceLog>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("PK__Maintena__9D754BEABE658EB3");

            entity.ToTable("MaintenanceLog");

            entity.Property(e => e.MaintenanceId)
                .ValueGeneratedNever()
                .HasColumnName("maintenance_id");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.MachineId).HasColumnName("machine_id");
            entity.Property(e => e.NextServiceDate).HasColumnName("next_service_date");
            entity.Property(e => e.ServiceDate)
                .HasColumnType("datetime")
                .HasColumnName("service_date");
            entity.Property(e => e.TechnicianId).HasColumnName("technician_id");

            entity.HasOne(d => d.Machine).WithMany(p => p.MaintenanceLogs)
                .HasForeignKey(d => d.MachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Maintenan__machi__5812160E");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PaymentD__ED1FC9EACC76EEE3");

            entity.ToTable("PaymentDetail");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.AuthorizationCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("authorization_code");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaymentDe__trans__5535A963");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__47027DF5EB125FA3");

            entity.ToTable("Product");

            entity.HasIndex(e => e.Sku, "UQ__Product__DDDF4BE7A5AD2D99").IsUnique();

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NutritionalInfo)
                .HasColumnType("text")
                .HasColumnName("nutritional_info");
            entity.Property(e => e.RetailPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("retail_price");
            entity.Property(e => e.ShelfLifeDays).HasColumnName("shelf_life_days");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.UnitCost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_cost");
            entity.Property(e => e.WeightGrams)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("weight_grams");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__categor__4222D4EF");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PoId).HasName("PK__Purchase__368DA7F05502836B");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.PoId)
                .ValueGeneratedNever()
                .HasColumnName("po_id");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("delivery_date");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__suppl__5FB337D6");
        });

        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasKey(e => e.PoItemId).HasName("PK__Purchase__E2A58305FB527FE4");

            entity.ToTable("PurchaseOrderItem");

            entity.Property(e => e.PoItemId)
                .ValueGeneratedNever()
                .HasColumnName("po_item_id");
            entity.Property(e => e.PoId).HasColumnName("po_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReceivedQuantity).HasColumnName("received_quantity");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Po).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.PoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__po_id__6477ECF3");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__produ__656C112C");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__6EE594E8A710AFDD");

            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId)
                .ValueGeneratedNever()
                .HasColumnName("supplier_id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contact_person");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PaymentTerms)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("payment_terms");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.TaxId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tax_id");
        });

        modelBuilder.Entity<TransactionItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Transact__52020FDDA220FCF5");

            entity.ToTable("TransactionItem");

            entity.Property(e => e.ItemId)
                .ValueGeneratedNever()
                .HasColumnName("item_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Product).WithMany(p => p.TransactionItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__produ__52593CB8");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionItems)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__trans__5165187F");
        });

        modelBuilder.Entity<Transactiontable>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AF101D970C");

            entity.ToTable("Transactiontable");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnName("transaction_id");
            entity.Property(e => e.MachineId).HasColumnName("machine_id");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reference_number");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("transaction_date");

            entity.HasOne(d => d.Machine).WithMany(p => p.Transactiontables)
                .HasForeignKey(d => d.MachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__machi__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
