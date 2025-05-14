using CouchesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CouchesApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>()
                .Property(p => p.Nom)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
