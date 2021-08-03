using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class GenericInfoMap : IEntityTypeConfiguration<GenericInfo>
    {
        public void Configure(EntityTypeBuilder<GenericInfo> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.UserId).IsRequired();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Surname).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Thumbnail).IsRequired().HasMaxLength(100);
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.ModifiedDate).IsRequired();
            builder.Property(s => s.IsActive).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired();

            builder.HasOne<ApplicationUser>(g => g.ApplicationUser).WithOne(a => a.GenericInfo).HasForeignKey<GenericInfo>(g => g.UserId);
            builder.ToTable("GenericInfo");
        }
    }
}
