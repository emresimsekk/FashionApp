using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FashionApp.Data.Concrete.EntityFramework.Repositories
{
    public class EfFollowRepository : EfEntityRepositoryBase<Follow>, IFollowRepository
    {
        public EfFollowRepository(DbContext context) : base(context)
        {

        }
    }
}
