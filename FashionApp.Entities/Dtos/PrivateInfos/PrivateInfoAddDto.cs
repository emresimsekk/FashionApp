using FashionApp.Shared.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.PrivateInfos
{
    public class PrivateInfoAddDto : DtoGetBase
    {
        [Required]
        public int UserId { get; set; }


        [DisplayName("Boy")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        //[Range(0, 2.50) ]

        //[MaxLength(20, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz !")]
        //[MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz !")]
        public decimal? Height { get; set; }


        [DisplayName("Kilo")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        //[MaxLength(20, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz !")]
        //[MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz !")]
        public decimal? Weight { get; set; }

        [DisplayName("Göğüs Genişliği")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        //[MaxLength(20, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz !")]
        //[MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz !")]
        public decimal? ChestWidth { get; set; }

        [DisplayName("Bel Genişliği")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        //[MaxLength(20, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz !")]
        //[MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz !")]
        public decimal? WaistWidth { get; set; }

        [DisplayName("Kalça Genişliği")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        //[Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        //[MaxLength(20, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz !")]
        //[MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olamaz !")]
        public decimal? HipWidth { get; set; }
    }
}
