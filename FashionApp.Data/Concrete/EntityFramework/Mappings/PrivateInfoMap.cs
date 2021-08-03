using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class PrivateInfoMap : IEntityTypeConfiguration<PrivateInfo>
    {
        public void Configure(EntityTypeBuilder<PrivateInfo> builder)
        {

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.UserId).IsRequired();
            builder.Property(s => s.Height).IsRequired();
            builder.Property(s => s.Weight).IsRequired();
            builder.Property(s => s.ChestWidth).IsRequired();
            builder.Property(s => s.WaistWidth).IsRequired();
            builder.Property(s => s.HipWidth).IsRequired();
            builder.Property(s => s.CreatedDate).IsRequired();
            builder.Property(s => s.ModifiedDate).IsRequired();
            builder.Property(s => s.IsActive).IsRequired();
            builder.Property(s => s.IsDeleted).IsRequired();

            builder.HasOne<ApplicationUser>(p => p.ApplicationUser).WithOne(a => a.PrivateInfo).HasForeignKey<PrivateInfo>(p => p.UserId);
            builder.ToTable("PrivateInfo");
        }
    }
}
