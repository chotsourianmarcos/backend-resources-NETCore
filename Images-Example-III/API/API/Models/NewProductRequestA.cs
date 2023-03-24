using API.Enums;

namespace API.Models
{
    public class NewProductRequestA
    {
        public IFormFile File { get; set; }
        public FileExtensionEnum FileExtension { get; set; }
        public NewProductForm NewProductForm { get; set; }
    }
}
