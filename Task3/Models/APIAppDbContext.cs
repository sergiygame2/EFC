using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFfromDB.Models
{
    public partial class APIAppDbContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=D:\VSProjects\NETCORE\EFfromDB\src\EFfromDB\northwind.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("sqlite_autoindex_Categories_1");
            });

            modelBuilder.Entity<CustomerCustomerDemo>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CustomerTypeId })
                    .HasName("sqlite_autoindex_CustomerCustomerDemo_1");
            });

            modelBuilder.Entity<CustomerDemographics>(entity =>
            {
                entity.HasKey(e => e.CustomerTypeId)
                    .HasName("sqlite_autoindex_CustomerDemographics_1");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("sqlite_autoindex_Customers_1");
            });

            modelBuilder.Entity<EmployeeTerritories>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.TerritoryId })
                    .HasName("sqlite_autoindex_EmployeeTerritories_1");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("sqlite_autoindex_Employees_1");

                entity.Property(e => e.Deleted).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("sqlite_autoindex_Order Details_1");

                entity.Property(e => e.Discount).HasDefaultValueSql("'0'");

                entity.Property(e => e.Quantity).HasDefaultValueSql("'1'");

                entity.Property(e => e.UnitPrice).HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("sqlite_autoindex_Orders_1");

                entity.Property(e => e.Freight).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<ProductCategoryMap>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ProductId })
                    .HasName("sqlite_autoindex_Product_Category_Map_1");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("sqlite_autoindex_Products_1");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Deleted).HasDefaultValueSql("0");

                entity.Property(e => e.Discontinued).HasDefaultValueSql("0");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ReorderLevel).HasDefaultValueSql("0");

                entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");

                entity.Property(e => e.UnitsInStock).HasDefaultValueSql("0");

                entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Shippers>(entity =>
            {
                entity.HasKey(e => e.ShipperId)
                    .HasName("sqlite_autoindex_Shippers_1");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("sqlite_autoindex_Suppliers_1");
            });

            modelBuilder.Entity<Territories>(entity =>
            {
                entity.HasKey(e => e.TerritoryId)
                    .HasName("sqlite_autoindex_Territories_1");
            });

            modelBuilder.Entity<TextEntry>(entity =>
            {
                entity.HasKey(e => e.ContentId)
                    .HasName("sqlite_autoindex_TextEntry_1");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ListOrder).HasDefaultValueSql("1");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public virtual DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ProductCategoryMap> ProductCategoryMap { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Territories> Territories { get; set; }
        public virtual DbSet<TextEntry> TextEntry { get; set; }
    }
}