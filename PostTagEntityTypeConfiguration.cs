using Microsoft.EntityFrameworkCore;

namespace ConsoleSqlLiteEfCore
{
    public class PostTagEntityTypeConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PostTag> builder)
        {
            builder
               .HasKey(pt => (new { pt.PostId, pt.TagId, pt.UserId }));

            builder
                .HasOne(pt => pt.User)
                .WithMany()
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(pt => pt.Tag)
                .WithMany(pt => pt.Posts)
                .HasForeignKey(pt => pt.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(pt => pt.Post)
                .WithMany(pt => pt.Tags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}