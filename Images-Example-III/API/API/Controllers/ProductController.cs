﻿using API.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO.Compression;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        public readonly IProductService _productService;
        public ProductController(IFileService fileService, IProductService productService)
        {
            _fileService = fileService;
            _productService = productService;
        }

        [HttpPost(Name = "PostProductFile")]
        public int PostProductFile([FromForm] NewProductFileRequest newProductFileRequest)
        {
            try
            {
                var fileItem = new FileItem();

                fileItem.Id = 0;
                fileItem.Name = newProductFileRequest.File.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                if (newProductFileRequest.File.ContentType == "image/jpeg")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.JPG;
                }
                else if (newProductFileRequest.File.ContentType == "image/png")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.PGN;
                }
                else
                {
                    throw new InvalidDataException();
                }

                using (var stream = new MemoryStream())
                {
                    newProductFileRequest.File.CopyTo(stream);
                    fileItem.Content = stream.ToArray();
                }

                var fileId = _fileService.InsertFile(fileItem);

                var productData = JsonConvert.DeserializeObject<ProductData>(newProductFileRequest.ProductDataString);
                var productItem = productData.ToProductItem();
                productItem.IdPhotoFile = fileId;

                return _productService.InsertProduct(productItem);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost(Name = "PostBase64")]
        public int PostBase64([FromBody] NewProductBase64Request newProductBase64RequestModel)
        {
            try
            {
                var fileItem = new FileItem();

                fileItem.Name = newProductBase64RequestModel.Base64FileModel.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                if (newProductBase64RequestModel.Base64FileModel.Extension == "image/jpeg")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.JPG;
                }else if(newProductBase64RequestModel.Base64FileModel.Extension == "image/png")
                {
                    fileItem.FileExtension = Enums.FileExtensionEnum.PGN;
                }
                else
                {
                    throw new InvalidDataException();
                }
                fileItem.Content = Convert.FromBase64String(newProductBase64RequestModel.Base64FileModel.Base64FileContent);

                var fileId = _fileService.InsertFile(fileItem);

                var productItem = newProductBase64RequestModel.ProductData.ToProductItem();
                productItem.IdPhotoFile = fileId;

                return _productService.InsertProduct(productItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //GET MULTIPLE FILES AS ZIP
        [HttpGet(Name = "GetAllFilesAsZip")]
        public IActionResult GetAllFilesAsZip()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    _fileService.GetAllFiles().ForEach(file =>
                    {
                        var entry = zip.CreateEntry(file.Name);
                        using (var fileStream = new MemoryStream(file.Content))
                        using (var entryStream = entry.Open())
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    });
                }
                return File(ms.ToArray(), "application/zip", "images.zip");
            }
        }

        //GET MULTIPLE FILES AS JSON IN BASE64
        [HttpGet(Name = "GetAllBase64List")]
        public List<Base64FileModel> GetAllBase64List()
        {
            var fileList = _fileService.GetAllFiles();

            List<Base64FileModel> base64FileList = new List<Base64FileModel>();

            foreach(var file in fileList)
            {
                Base64FileModel base64FileModel = new Base64FileModel();

                base64FileModel.FileName = file.Name;
                base64FileModel.Base64FileContent = file.Base64Content;
                if (file.FileExtension == Enums.FileExtensionEnum.JPG)
                {
                    base64FileModel.Extension = "image/jpeg";
                }
                else if (file.FileExtension == Enums.FileExtensionEnum.PGN)
                {
                    base64FileModel.Extension = "image/png";
                }
                else
                {
                    throw new NotImplementedException();
                }

                base64FileList.Add(base64FileModel);
            }

            return base64FileList;
        }

    }
}
