using FashionApp.Data.Concrete.EntityFramework.Mappings;
using FashionApp.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FashionApp.Data.Concrete.EntityFramework.Context
{
    public class FashionAppContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public FashionAppContext(DbContextOptions<FashionAppContext> options) : base(options)
        {

        }

        public DbSet<Blocked> Blockeds { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<GenericInfo> GenericInfos { get; set; }
        public DbSet<PrivateInfo> PrivateInfos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FullyCombine> FullyCombines { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BodySize> BodySizes { get; set; }
        public DbSet<Color> Colors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-C588JTV\SQLEXPRESS;Database=FashionApp;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new PrivateInfoMap());
            builder.ApplyConfiguration(new GenericInfoMap());
            builder.ApplyConfiguration(new PostMap());
            builder.ApplyConfiguration(new CommentMap());
            builder.ApplyConfiguration(new LikeMap());
            builder.ApplyConfiguration(new FullyCombineMap());
            builder.ApplyConfiguration(new ImageMap());
            builder.ApplyConfiguration(new TagMap());

            builder.ApplyConfiguration(new ColorMap());
            builder.ApplyConfiguration(new BodySizeMap());
            builder.ApplyConfiguration(new BlockedMap());
            builder.ApplyConfiguration(new FollowMap());
            builder.ApplyConfiguration(new MessageMap());
            base.OnModelCreating(builder);
        }

    }
}
