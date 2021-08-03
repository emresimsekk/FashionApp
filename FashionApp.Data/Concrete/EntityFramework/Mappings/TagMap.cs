using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.FullyCombineId).IsRequired();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            builder.Property(t => t.CreatedDate).IsRequired();
            builder.Property(t => t.ModifiedDate).IsRequired();
            builder.Property(t => t.IsActive).IsRequired();
            builder.Property(t => t.IsDeleted).IsRequired();
            builder.HasOne<FullyCombine>(t => t.FullyCombine).WithMany(f => f.Tags).HasForeignKey(t => t.FullyCombineId);
            builder.ToTable("Tags");
        }
    }
}
