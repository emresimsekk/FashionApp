using System;

namespace FashionApp.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual Boolean IsActive { get; set; } = true;
        public virtual Boolean IsDeleted { get; set; } = false;
    }
}
