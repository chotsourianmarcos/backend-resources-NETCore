namespace API.Models
{
    public class NewProductFileRequest
    {
        public IFormFile File { get; set; }
        public string ProductDataString { get; set; }
    }
}
