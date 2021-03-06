using Microsoft.EntityFrameworkCore;

namespace ConsoleSqlLiteEfCore
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<ConsoleSqlLiteEfCore.User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<PostTag>(new PostTagEntityTypeConfiguration());
        }
    }
}