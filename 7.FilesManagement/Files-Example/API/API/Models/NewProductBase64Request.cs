using API.Enums;

namespace API.Models
{
    public class NewProductBase64Request
    {
        public Base64FileModel Base64FileModel { get; set; }
        public ProductData ProductData { get; set; }
    }
}
