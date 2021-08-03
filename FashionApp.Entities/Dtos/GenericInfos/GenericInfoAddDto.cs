using FashionApp.Shared.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.GenericInfos
{
    public class GenericInfoAddDto : DtoGetBase
    {

        [Required]
        public int UserId { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz !")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz !")]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz !")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz !")]
        public string Surname { get; set; }

        [DisplayName("Profil Resmi ")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz !")]
        public string Thumbnail { get; set; }
    }
}
