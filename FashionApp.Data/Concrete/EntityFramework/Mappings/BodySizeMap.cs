using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class BodySizeMap : IEntityTypeConfiguration<BodySize>
    {
        public void Configure(EntityTypeBuilder<BodySize> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Name).IsRequired().HasMaxLength(10);
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            builder.ToTable("BodySizes");
        }
    }
}
