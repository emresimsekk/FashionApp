using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.FullyCombinedId).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(400);
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne<FullyCombine>(p => p.FullyCombine).WithOne(f => f.Post).HasForeignKey<Post>(p => p.FullyCombinedId);
            builder.HasOne<ApplicationUser>(p => p.ApplicationUser).WithMany(a => a.Posts).HasForeignKey(p => p.UserId);
            builder.ToTable("Posts");
        }
    }
}
