﻿using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; }

    public DiscountContext(DbContextOptions<DiscountContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Coupon>()
            .HasData(
                new Coupon
                {
                    Id = 1,
                    ProductName = "IPhone 16 Pro Max",
                    Description = "IPhone 16 Pro Max Discount Coupon",
                },
                new Coupon
                {
                    Id = 2,
                    ProductName = "Samsung Galaxy S25",
                    Description = "Samsung Galaxy S25 Discount Coupon",
                }
            );
    }
}
