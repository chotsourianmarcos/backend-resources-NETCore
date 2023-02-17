using API.Enums;
using Microsoft.VisualBasic.FileIO;

namespace API.Models
{
    public class FileUploadModel
    {
        public IFormFile File { get; set; }
        public FileExtensionEnum FileExtension { get; set; }
    }
}
