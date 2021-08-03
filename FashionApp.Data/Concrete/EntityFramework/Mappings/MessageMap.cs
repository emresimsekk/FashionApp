using FashionApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FashionApp.Data.Concrete.EntityFramework.Mappings
{
    public class MessageMap : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.UserId).IsRequired();
            builder.Property(m => m.ReceiverId).IsRequired();
            builder.Property(m => m.CreatedDate).IsRequired();
            builder.Property(m => m.ModifiedDate).IsRequired();
            builder.Property(m => m.IsActive).IsRequired();
            builder.Property(m => m.IsDeleted).IsRequired();

            builder.HasOne<ApplicationUser>(m => m.ApplicationUser).WithMany(a => a.Messages).HasForeignKey(m => m.UserId);
            builder.ToTable("Messages");

        }
    }
}
