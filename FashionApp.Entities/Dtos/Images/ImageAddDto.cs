using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.Images
{
    public class ImageAddDto
    {

        [Required(ErrorMessage = "Bu alan boş bırakılamaz !")]
        public int? FullyCombineId { get; set; }

        [DisplayName("Beden")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        public int? BodySizeId { get; set; }

        [DisplayName("Renk")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        public int? ColorId { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        public string Path { get; set; }

        [DisplayName("Marka")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        public string Brand { get; set; }

    }
}
