using Domain.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Infrastructure.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ChatHistories> ChatHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChatHistories>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FromId).IsUnicode(false);

                entity.Property(e => e.ToId).IsUnicode(false);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}