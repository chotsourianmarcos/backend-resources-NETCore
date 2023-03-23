using API.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController
    {
        private readonly IFileService _fileService;
        public readonly IProductService _productService;
        public ProductController(IFileService fileService, IProductService productService)
        {
            _fileService = fileService;
            _productService = productService;
        }

        //POST FILE FROM IFORMFILE
        [HttpPost(Name = "PostProductA")]
        public int PostProductA([FromForm] NewProductRequestA newProductRequest)
        {
            try
            {
                var fileItem = new FileItem();
                fileItem.Id = 0;
                fileItem.Name = newProductRequest.File.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                fileItem.FileExtension = newProductRequest.FileExtension;

                using (var stream = new MemoryStream())
                {
                    newProductRequest.File.CopyTo(stream);
                    fileItem.Content = stream.ToArray();
                }

                var fileId = _fileService.InsertFile(fileItem);

                var productItem = newProductRequest.NewProductForm.ToProductItem();
                productItem.IdPhotoFile = fileId;
                return _productService.InsertProduct(productItem);

            }
            catch (Exception)
            {
                throw;
            }
        }

        //POST FILE FROM JSON IN BASE64
        [HttpPost(Name = "PostProductB")]
        public int PostProductB([FromForm] NewProductRequestB newProductRequest)
        {
            try
            {
                var fileItem = new FileItem();

                fileItem.Id = 0;
                fileItem.Name = newProductRequest.Base64FileModel.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                fileItem.FileExtension = newProductRequest.Base64FileModel.FileExtension;
                fileItem.Content = Convert.FromBase64String(newProductRequest.Base64FileModel.Content);

                var fileId = _fileService.InsertFile(fileItem);

                var productItem = newProductRequest.NewProductForm.ToProductItem();
                productItem.IdPhotoFile = fileId;
                return _productService.InsertProduct(productItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET SINGLE FILE AS FILESTREAM
        [HttpGet(Name = "GetFileByIdA")]
        public FileStreamResult GetFileByIdA(int id)
        {
            try
            {
                var fileItem = _fileService.GetFileById(id);
                var stream = new MemoryStream(fileItem.Content);
                var mimeType = MediaTypeNames.Image.Jpeg.ToString();
                return new FileStreamResult(stream, new MediaTypeHeaderValue(mimeType))
                {
                    FileDownloadName = fileItem.Name
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET SINGLE FILE AS JSON IN BASE64
        [HttpGet(Name = "GetFileByIdB")]
        public Base64FileModel GetFileByIdB(int id)
        {
            try
            {
                var fileItem = _fileService.GetFileById(id);

                Base64FileModel base64FileModel = new Base64FileModel();
                base64FileModel.FileName = fileItem.Name;
                base64FileModel.Content = fileItem.Base64Content;
                base64FileModel.FileExtension = fileItem.FileExtension;

                return base64FileModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET MULTIPLE FILES AS JSON IN BASE64
        [HttpGet(Name = "GetAllFilesList")]
        public List<Base64FileModel> GetAllFilesList()
        {
            var fileList = _fileService.GetAllFiles();

            List<Base64FileModel> base64FileList = new List<Base64FileModel>();

            foreach(var file in fileList)
            {
                Base64FileModel base64FileModel = new Base64FileModel();
                base64FileModel.FileName = file.Name;
                base64FileModel.Content = file.Base64Content;
                base64FileModel.FileExtension = file.FileExtension;
                base64FileList.Add(base64FileModel);
            }

            return base64FileList;
        }

        //GET MULTIPLE FILES IN .ZIP?
        //GET MULTIPLE FILES IN MPFD?
    }
}
