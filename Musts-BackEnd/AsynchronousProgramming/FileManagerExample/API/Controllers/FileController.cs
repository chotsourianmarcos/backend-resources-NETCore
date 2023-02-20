using API.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FileController
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost(Name = "PostFile")]
        public async Task<int> PostFile([FromForm] FileUploadModel fileUploadModel)
        {
            try
            {
                //validaciones varias, de extension, tamaño, etcs
                var fileItem = new FileItem();
                fileItem.Id = 0;
                fileItem.Name = fileUploadModel.File.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                fileItem.FileExtension = fileUploadModel.FileExtension;

                using (var stream = new MemoryStream())
                {
                    fileUploadModel.File.CopyTo(stream);
                    fileItem.Content = stream.ToArray();
                }

                //tmb considerar qué archivos habría que encryptar o eso?
                return await _fileService.InsertFile(fileItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(Name = "GetFileById")]
        public FileStreamResult GetFileById(int id)
        {
            try
            {
                var fileItem = _fileService.GetFileById(id);
                var stream = new MemoryStream(fileItem.Content);
                //no hardcodear ese MIME
                return new FileStreamResult(stream, new MediaTypeHeaderValue("image/jpg"))
                {
                    FileDownloadName = fileItem.Name
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        //DOWNLOADEAR NO ES UN MUST. LUEGO VERLO
        //EN SÍ QUE LO DESCARGUE EL FRONT, UNA API NO DEBERÍA TENER UN "DOWNLOAD" O SÍ?
        //NO PODEMOS ASUMIR QUE LA VA A CONSUMIR UN NAVEGADOR, DIGAMOS
        
    }
}
