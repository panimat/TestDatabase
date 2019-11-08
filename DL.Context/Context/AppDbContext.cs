using Microsoft.EntityFrameworkCore;
using DL.Context.Entities;

namespace DL.Context.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<JsonEntity> JsonEntities { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JsonEntity>()
                .Property(b => b.JsonValField)
                .HasColumnType("jsonb");
        }
    }
}
