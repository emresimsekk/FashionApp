using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FashionApp.Data.Concrete.EntityFramework.Repositories
{
    public class EfTagRepository : EfEntityRepositoryBase<Tag>, ITagRepository
    {
        public EfTagRepository(DbContext context) : base(context)
        {

        }
    }
}
