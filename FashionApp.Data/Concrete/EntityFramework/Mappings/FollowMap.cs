using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class FollowMap : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.UserId).IsRequired();
            builder.Property(f => f.FollowedId).IsRequired();
            builder.Property(f => f.CreatedDate).IsRequired();
            builder.Property(f => f.ModifiedDate).IsRequired();
            builder.Property(f => f.IsActive).IsRequired();
            builder.Property(f => f.IsDeleted).IsRequired();
            //builder.HasOne<ApplicationUser>(f => f.ApplicationUser).WithMany(a => a.Follows).HasForeignKey(f => f.UserId);
            builder.HasOne<ApplicationUser>(f => f.ApplicationUser).WithMany(a => a.Follows).HasForeignKey(f => f.FollowedId);
            builder.ToTable("Follows");
        }
    }
}
