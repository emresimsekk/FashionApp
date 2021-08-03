using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class BlockedMap : IEntityTypeConfiguration<Blocked>
    {
        public void Configure(EntityTypeBuilder<Blocked> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.BlockedId).IsRequired();
            builder.Property(b => b.CreatedDate).IsRequired();
            builder.Property(b => b.ModifiedDate).IsRequired();
            builder.Property(b => b.IsActive).IsRequired();
            builder.Property(b => b.IsDeleted).IsRequired();
            //builder.HasOne<ApplicationUser>(a => a.ApplicationUser).WithMany(b => b.Blockeds).HasForeignKey(a => a.UserId);
            builder.HasOne<ApplicationUser>(a => a.ApplicationUser).WithMany(b => b.Blockeds).HasForeignKey(a => a.BlockedId);

            builder.ToTable("Blockeds");
        }
    }
}
