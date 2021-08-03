using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.Blockeds
{
    public class BlockedAddDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int BlockedId { get; set; }
    }
}
