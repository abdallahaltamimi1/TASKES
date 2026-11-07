using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace University_Cafeteria_2.Models;

public partial class TempDbContext : DbContext
{
    public TempDbContext(DbContextOptions<TempDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC07D4910C86");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
