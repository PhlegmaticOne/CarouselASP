using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CarouselASP.Model
{
    public class FormAlbumImageModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Имя артиста не может быть пустым")]
        public string Artist { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя альбома не может быть пустым")]
        public string AlbumName { get; set; }
        [Required(ErrorMessage = "Выберите картинку для загрузки")]
        public IFormFile Image { get; set; }
    }
}
