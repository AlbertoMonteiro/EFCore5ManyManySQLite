using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleSqlLiteEfCore
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypeBuilderShared = modelBuilder.SharedTypeEntity<PostTag>("PostTag", builder =>
            {
                builder.Property(x => x.CreatedDate).IsRequired();
            });
            var entityTypeBuilder = modelBuilder.Entity<Post>();
            //entityTypeBuilder
            //    .HasKey(pt => (new { pt.PostId, pt.TagId }));

            entityTypeBuilder
                .HasMany(pt => pt.Tags)
                .WithMany(t => t.Posts)
                .UsingEntity<PostTag>(
                    "PostTag",
                    x => x.HasOne(x => x.Tag).WithMany(),
                    x => x.HasOne(x => x.Post).WithMany()
                );

            //entityTypeBuilder
            //.HasOne(pt => pt.Tag)
            //.WithMany(pt => pt.Posts)
            //.HasForeignKey(pt => pt.TagId)
            //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}