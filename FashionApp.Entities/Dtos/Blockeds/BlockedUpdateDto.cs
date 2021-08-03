using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.Blockeds
{
    public class BlockedUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BlockedId { get; set; }
    }
}
