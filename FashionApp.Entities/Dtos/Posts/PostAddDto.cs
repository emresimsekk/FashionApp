using FashionApp.Entities.Dtos.FullyCombines;
using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.Posts
{
    public class PostAddDto
    {


        [Required(ErrorMessage = "Bu alanı boş bırakılamaz !")]
        public int UserId { get; set; }
        public int FullyCombinedId { get; set; }
        public string Description { get; set; }
        public FullyCombineAddDto FullyCombineAddDto { get; set; }


    }
}
