using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class FullyCombineMap : IEntityTypeConfiguration<FullyCombine>
    {
        public void Configure(EntityTypeBuilder<FullyCombine> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.Path).IsRequired().HasMaxLength(100);
            builder.Property(f => f.CreatedDate).IsRequired();
            builder.Property(f => f.ModifiedDate).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.IsDeleted).IsRequired();
            builder.ToTable("FullCombines");
        }
    }
}
