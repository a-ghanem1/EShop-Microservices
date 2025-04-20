using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountDbContext : DbContext
{
   public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
   {
      // ...
   }

   public DbSet<Coupon> Coupons { get; set; } = default!;

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<Coupon>().HasData(
         new Coupon { Id = 1, ProductName = "IPhone X", Description = "IPhone Discount", Amount = 150 },
         new Coupon { Id = 2, ProductName = "Samsung 10", Description = "Samsung Discount", Amount = 100 }
      );
   }
}