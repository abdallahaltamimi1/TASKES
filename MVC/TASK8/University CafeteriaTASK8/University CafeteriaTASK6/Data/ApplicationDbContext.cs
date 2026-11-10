using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using University_CafeteriaTASK6.Models;

namespace University_CafeteriaTASK6.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Product> Products { get; set; } 
        public DbSet<Models.Supplier> Suppliers { get; set; }

        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<SupplyRequest> SupplyRequests { get; set; }
        public DbSet<RequestItem> RequestItems { get; set; }

    }
}
