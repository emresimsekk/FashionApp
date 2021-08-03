using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.FullyCombineId).IsRequired();
            builder.Property(i => i.BodySizeId).IsRequired();
            builder.Property(i => i.ColorId).IsRequired();
            builder.Property(i => i.Path).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Brand).IsRequired().HasMaxLength(50);
            builder.Property(i => i.CreatedDate).IsRequired();
            builder.Property(i => i.ModifiedDate).IsRequired();
            builder.Property(i => i.IsActive).IsRequired();
            builder.Property(i => i.IsDeleted).IsRequired();

            //builder.HasOne<BodySize>(i => i.BodySize).WithOne(b => b.Image).HasForeignKey<Image>(i => i.BodySizeId);
            //builder.HasOne<Color>(i => i.Color).WithOne(c => c.Image).HasForeignKey<Image>(i => i.ColorId);
            builder.HasOne<FullyCombine>(i => i.FullyCombine).WithMany(f => f.Images).HasForeignKey(i => i.FullyCombineId);
            builder.HasOne<Color>(i => i.Color).WithMany(f => f.Images).HasForeignKey(i => i.ColorId);
            builder.HasOne<BodySize>(i => i.BodySize).WithMany(f => f.Images).HasForeignKey(i => i.BodySizeId);
            builder.ToTable("Images");
        }
    }
}
