using FashionApp.Shared.Entities.Abstract;

namespace FashionApp.Entities.Concrete
{
    public class PrivateInfo : EntityBase, IEntity
    {
        public int UserId { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal ChestWidth { get; set; }
        public decimal WaistWidth { get; set; }
        public decimal HipWidth { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
