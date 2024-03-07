using ChatBot.API.Validators;
using System.ComponentModel.DataAnnotations;

namespace ChatBot.API.DTOs
{
    public class ProductForm
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        [Extensions("image/png", "image/jpeg")]
        public IFormFile? ImageFile { get; set; }
    }
}
