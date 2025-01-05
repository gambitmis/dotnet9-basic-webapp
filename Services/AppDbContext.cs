using InvoiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add any additional configuration here
            modelBuilder.Entity<Invoice>()
                .Property(p => p.UnitPrice)
                .HasPrecision(16, 2);
        }
    }
}
