using API.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;
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
        public int PostFile([FromForm] FileUploadModel fileUploadModel)
        {
            if (fileUploadModel == null)
            {
                throw new InvalidOperationException();
            }

            try
            {
                return _fileService.InsertFile(fileUploadModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet(Name = "DownloadFile")]
        public void DownloadFile(int id)
        {
            try
            {
                var file = _fileService.GetFileById(id);
                var content = new MemoryStream(file.Content);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Name);

                using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    content.CopyToAsync(fileStream);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public void CopyStream(Stream stream, string downloadPath)
        //{
        //    using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
        //    {
        //        stream.CopyToAsync(fileStream);
        //    }
        //}
    }
}
