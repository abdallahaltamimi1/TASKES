using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TASK5._2.Models;

namespace TASK5._2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PurchaseOrderItems>()
                .HasOne(p => p.PurchaseOrder)
                .WithMany(o => o.PurchaseOrderItems)
                .HasForeignKey(p => p.PurchaseOrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    }

