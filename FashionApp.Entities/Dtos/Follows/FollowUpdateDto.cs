using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.Follows
{
    public class FollowUpdateDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int FollowedId { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
