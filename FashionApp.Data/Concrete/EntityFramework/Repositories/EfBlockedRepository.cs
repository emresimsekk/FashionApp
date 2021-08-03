using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FashionApp.Data.Concrete.EntityFramework.Repositories
{
    public class EfBlockedRepository : EfEntityRepositoryBase<Blocked>, IBlockedRepository
    {
        public EfBlockedRepository(DbContext context) : base(context)
        {

        }
    }
}
