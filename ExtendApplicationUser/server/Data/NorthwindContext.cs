using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using ExtendApplicationUser.Models.Northwind;

namespace ExtendApplicationUser.Data
{
  public partial class NorthwindContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public NorthwindContext(DbContextOptions<NorthwindContext> options):base(options)
    {
    }

    public NorthwindContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ExtendApplicationUser.Models.Northwind.CustomerCustomerDemo>().HasKey(table => new {
          table.CustomerID, table.CustomerTypeID
        });
        builder.Entity<ExtendApplicationUser.Models.Northwind.EmployeeTerritory>().HasKey(table => new {
          table.EmployeeID, table.TerritoryID
        });
        builder.Entity<ExtendApplicationUser.Models.Northwind.OrderDetail>().HasKey(table => new {
          table.OrderID, table.ProductID
        });
        builder.Entity<ExtendApplicationUser.Models.Northwind.CustomerCustomerDemo>()
              .HasOne(i => i.Customer)
              .WithMany(i => i.CustomerCustomerDemos)
              .HasForeignKey(i => i.CustomerID)
              .HasPrincipalKey(i => i.CustomerID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.CustomerCustomerDemo>()
              .HasOne(i => i.CustomerDemographic)
              .WithMany(i => i.CustomerCustomerDemos)
              .HasForeignKey(i => i.CustomerTypeID)
              .HasPrincipalKey(i => i.CustomerTypeID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.Employee>()
              .HasOne(i => i.Employee1)
              .WithMany(i => i.Employees1)
              .HasForeignKey(i => i.ReportsTo)
              .HasPrincipalKey(i => i.EmployeeID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.EmployeeTerritory>()
              .HasOne(i => i.Employee)
              .WithMany(i => i.EmployeeTerritories)
              .HasForeignKey(i => i.EmployeeID)
              .HasPrincipalKey(i => i.EmployeeID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.EmployeeTerritory>()
              .HasOne(i => i.Territory)
              .WithMany(i => i.EmployeeTerritories)
              .HasForeignKey(i => i.TerritoryID)
              .HasPrincipalKey(i => i.TerritoryID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.Order>()
              .HasOne(i => i.Customer)
              .WithMany(i => i.Orders)
              .HasForeignKey(i => i.CustomerID)
              .HasPrincipalKey(i => i.CustomerID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.Order>()
              .HasOne(i => i.Employee)
              .WithMany(i => i.Orders)
              .HasForeignKey(i => i.EmployeeID)
              .HasPrincipalKey(i => i.EmployeeID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.Order>()
              .HasOne(i => i.Shipper)
              .WithMany(i => i.Orders)
              .HasForeignKey(i => i.ShipVia)
              .HasPrincipalKey(i => i.ShipperID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.OrderDetail>()
              .HasOne(i => i.Order)
              .WithMany(i => i.OrderDetails)
              .HasForeignKey(i => i.OrderID)
              .HasPrincipalKey(i => i.OrderID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.OrderDetail>()
              .HasOne(i => i.Product)
              .WithMany(i => i.OrderDetails)
              .HasForeignKey(i => i.ProductID)
              .HasPrincipalKey(i => i.ProductID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.Product>()
              .HasOne(i => i.Supplier)
              .WithMany(i => i.Products)
              .HasForeignKey(i => i.SupplierID)
              .HasPrincipalKey(i => i.SupplierID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.Product>()
              .HasOne(i => i.Category)
              .WithMany(i => i.Products)
              .HasForeignKey(i => i.CategoryID)
              .HasPrincipalKey(i => i.CategoryID);
        builder.Entity<ExtendApplicationUser.Models.Northwind.Territory>()
              .HasOne(i => i.Region)
              .WithMany(i => i.Territories)
              .HasForeignKey(i => i.RegionID)
              .HasPrincipalKey(i => i.RegionID);

        builder.Entity<ExtendApplicationUser.Models.Northwind.Order>()
              .Property(p => p.Freight)
              .HasDefaultValueSql("(0)");

        builder.Entity<ExtendApplicationUser.Models.Northwind.OrderDetail>()
              .Property(p => p.UnitPrice)
              .HasDefaultValueSql("(0)");

        builder.Entity<ExtendApplicationUser.Models.Northwind.OrderDetail>()
              .Property(p => p.Quantity)
              .HasDefaultValueSql("(1)");

        builder.Entity<ExtendApplicationUser.Models.Northwind.OrderDetail>()
              .Property(p => p.Discount)
              .HasDefaultValueSql("(0)");

        builder.Entity<ExtendApplicationUser.Models.Northwind.Product>()
              .Property(p => p.UnitPrice)
              .HasDefaultValueSql("(0)");

        builder.Entity<ExtendApplicationUser.Models.Northwind.Product>()
              .Property(p => p.UnitsInStock)
              .HasDefaultValueSql("(0)");

        builder.Entity<ExtendApplicationUser.Models.Northwind.Product>()
              .Property(p => p.UnitsOnOrder)
              .HasDefaultValueSql("(0)");

        builder.Entity<ExtendApplicationUser.Models.Northwind.Product>()
              .Property(p => p.ReorderLevel)
              .HasDefaultValueSql("(0)");

        builder.Entity<ExtendApplicationUser.Models.Northwind.Product>()
              .Property(p => p.Discontinued)
              .HasDefaultValueSql("(0)");

        this.OnModelBuilding(builder);
    }


    public DbSet<ExtendApplicationUser.Models.Northwind.Category> Categories
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.Customer> Customers
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.CustomerCustomerDemo> CustomerCustomerDemos
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.CustomerDemographic> CustomerDemographics
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.Employee> Employees
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.EmployeeTerritory> EmployeeTerritories
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.Order> Orders
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.OrderDetail> OrderDetails
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.Product> Products
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.Region> Regions
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.Shipper> Shippers
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.Supplier> Suppliers
    {
      get;
      set;
    }

    public DbSet<ExtendApplicationUser.Models.Northwind.Territory> Territories
    {
      get;
      set;
    }
  }
}
