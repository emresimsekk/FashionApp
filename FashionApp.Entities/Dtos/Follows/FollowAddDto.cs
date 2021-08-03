using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.Follows
{
    public class FollowAddDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int FollowedId { get; set; }
    }
}
