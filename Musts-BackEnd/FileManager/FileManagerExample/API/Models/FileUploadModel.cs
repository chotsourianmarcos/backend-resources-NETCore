using API.Enums;
using Microsoft.VisualBasic.FileIO;

namespace API.Models
{
    public class FileUploadModel
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public FileExtensionEnum FileExtension { get; set; }
    }
}
