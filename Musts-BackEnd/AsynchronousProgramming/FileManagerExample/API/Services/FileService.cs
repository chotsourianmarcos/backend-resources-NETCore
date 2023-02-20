using API.IServices;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<int> InsertFile(FileItem fileItem)
        {
            try
            {
                _serviceContext.Files.Add(fileItem);
                await _serviceContext.SaveChangesAsync();
                return fileItem.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteFile(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FileItem> GetFileById(int id)
        {
            var file = await _serviceContext.Set<FileItem>().Where(f => f.Id == id).FirstOrDefaultAsync();
            if(file != null)
            {
                return file;
            }
            else
            {
                throw new Exception("No se encontró el archivo.");
            }
        }

        Task<List<FileIdentifierModel>> IFileService.InsertFiles(List<FileItem> fileItemList)
        {
            throw new NotImplementedException();
        }

        Task<List<FileItem>> IFileService.GetFilesByCriteria(FileSearchCriteria fileSearchCriteria)
        {
            throw new NotImplementedException();
        }
    }
}
