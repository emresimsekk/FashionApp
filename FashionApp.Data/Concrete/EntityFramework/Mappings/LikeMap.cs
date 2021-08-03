using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class LikeMap : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
            builder.Property(l => l.UserId).IsRequired();
            builder.Property(l => l.CreatedDate).IsRequired();
            builder.Property(l => l.ModifiedDate).IsRequired();
            builder.Property(l => l.IsActive).IsRequired();
            builder.Property(l => l.IsDeleted).IsRequired();
            builder.HasOne<Post>(l => l.Post).WithMany(p => p.Likes).HasForeignKey(l => l.PostId);
            builder.ToTable("Likes");
        }
    }
}
