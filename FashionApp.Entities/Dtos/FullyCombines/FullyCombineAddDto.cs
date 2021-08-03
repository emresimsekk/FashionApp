using FashionApp.Entities.Dtos.Images;
using FashionApp.Entities.Dtos.Tags;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FashionApp.Entities.Dtos.FullyCombines
{
    public class FullyCombineAddDto
    {
        [DisplayName("Resim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz !")]
        public string Path { get; set; }

        public IList<ImageAddDto> imageAddDto { get; set; }
        public IList<TagAddDto> tagAddDtos { get; set; }

    }
}
