using FashionApp.Data.Abstract;
using FashionApp.Entities.Concrete;
using FashionApp.Shared.Data.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FashionApp.Data.Concrete.EntityFramework.Repositories
{
    public class EfBodySizeRepository : EfEntityRepositoryBase<BodySize>, IBodySizeRepository
    {
        public EfBodySizeRepository(DbContext context) : base(context)
        {

        }
    }
}
