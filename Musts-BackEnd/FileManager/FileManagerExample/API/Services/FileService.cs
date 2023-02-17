using API.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace API.Services
{
    public class FileService : IFileService
    {
        private readonly ServiceContext _serviceContext;
        public FileService(ServiceContext serviceContext) 
        {
            _serviceContext = serviceContext;
        }
        public int InsertFile(FileUploadModel fileUploadModel)
        {
            try
            {
                var fileItem = new FileItem();
                fileItem.Id = 0;
                fileItem.Name = fileUploadModel.Name;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                fileItem.FileExtension = fileUploadModel.FileExtension;

                using (var stream = new MemoryStream())
                {
                    stream.Write(fileUploadModel.Content, 0, fileUploadModel.Content.Length);
                    fileItem.Content = stream.ToArray();
                }

                _serviceContext.Files.Add(fileItem);
                _serviceContext.SaveChanges();
                return fileItem.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<FileIdentifierModel> InsertFiles(List<FileUploadModel> filesUploadModel)
        {
            throw new NotImplementedException();
        }
        public void DeleteFile(int id)
        {
            throw new NotImplementedException();
        }

        public FileItem GetFileById(int id)
        {
            var file = _serviceContext.Set<FileItem>().Where(f => f.Id == id).FirstOrDefault();
            if(file != null)
            {
                return file;
            }
            else
            {
                throw new Exception("No se encontró el archivo.");
            }
        }

        public List<FileItem> GetFilesByCriteria(FileSearchCriteria fileSearchCriteria)
        {
            throw new NotImplementedException();
        }        
    }
}
