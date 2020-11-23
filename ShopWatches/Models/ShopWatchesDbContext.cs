namespace ShopWatches.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopWatchesDbContext : DbContext
    {
        public ShopWatchesDbContext()
            : base("name=ShopWatchesDbContext")
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Categories_Product> Categories_Product { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Orders_Details> Orders_Details { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .Property(e => e.descrption)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.emailCtm)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.passwordCtm)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.nameCtm)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phoneCtm)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.addressCtm)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.genderCtm)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Cart)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.customerID);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.customerID);

            modelBuilder.Entity<Employee>()
                .Property(e => e.emailEmp)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.passwordEmp)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.nameEmp)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.phoneEmp)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.addressEmp)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.genderEmp)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.employeeID);

            modelBuilder.Entity<Orders>()
                .Property(e => e.statusOrder)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.statusPayment)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.Orders_Details)
                .WithOptional(e => e.Orders)
                .HasForeignKey(e => e.OrderID);

            modelBuilder.Entity<Picture>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Picture>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.warrantyTime)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.originName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.detail)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.nameSup)
                .IsUnicode(false);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.phoneSup)
                .IsUnicode(false);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.emailSup)
                .IsUnicode(false);

            modelBuilder.Entity<Suppliers>()
                .Property(e => e.addressSup)
                .IsUnicode(false);

            modelBuilder.Entity<Suppliers>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Suppliers)
                .HasForeignKey(e => e.SupplierID);

            modelBuilder.Entity<Voucher>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Voucher>()
                .Property(e => e.status)
                .IsUnicode(false);
        }
    }
}
