using API.Enums;

namespace API.Models
{
    public class NewProductRequestB
    {
        public NewProductForm NewProductForm { get; set; }
        public Base64FileModel Base64FileModel { get; set; }
    }
}
