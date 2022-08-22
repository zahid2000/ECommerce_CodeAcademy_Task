using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ECommerceContext:DbContext
    {
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ECommerceDb; Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProductDetail>(
                    pd =>
                    {
                        pd.ToTable("ProductDetails").HasKey(k => k.Id);
                        pd.Property(v => v.Id).HasColumnName("Id");
                        pd.Property(v => v.Segment).HasColumnName("Segment");
                        pd.Property(v => v.Country).HasColumnName("Country");
                        pd.Property(v => v.Product).HasColumnName("Product");
                        pd.Property(v => v.DiscountBand).HasColumnName("DiscountBand");
                        pd.Property(v => v.UnitsSold).HasColumnName("UnitsSold");
                        pd.Property(v => v.ManufacturingPrice).HasColumnName("ManufacturingPrice");
                        pd.Property(v => v.SalePrice).HasColumnName("SalePrice");
                        pd.Property(v => v.GrossSales).HasColumnName("GrossSales");
                        pd.Property(v => v.Discounts).HasColumnName("Discounts");
                        pd.Property(v => v.Sales).HasColumnName("Sales");
                        pd.Property(v => v.COGS).HasColumnName("COGS");
                        pd.Property(v => v.Profit).HasColumnName("Profit");
                        pd.Property(v => v.Date).HasColumnName("Date");
                    });


        }

    }
}
