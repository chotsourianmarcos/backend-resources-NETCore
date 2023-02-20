using API.Enums;

namespace API.Models
{
    public class FileUploadModel
    {
        public IFormFile File { get; set; }
        public FileExtensionEnum FileExtension { get; set; }
    }
}
