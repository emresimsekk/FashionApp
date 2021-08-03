using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.Tags
{
    public class TagAddDto
    {
        public int FullyCombineId { get; set; }
        [DisplayName("Tag")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        public string Name { get; set; }
    }
}
