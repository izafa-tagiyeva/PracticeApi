using Microsoft.EntityFrameworkCore;
using Practice.Entities;

namespace Practice.DAL
{
    public class PracticeDbContext : DbContext
    {
        public PracticeDbContext(DbContextOptions options):base(options) { 
        }
        public DbSet<Categories> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.Name)
                .IsUnique();
                b.Property(x => x.Name)
                .IsRequired();
               

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
